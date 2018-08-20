using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;
using JinianNet.JNTemplate;
using Microsoft.CSharp;
using RC.Software.Framework.DbService;
using RC.Software.Framework.Helper;
using RC.Software.Presentation;
using FieldInfo = RC.Software.Presentation.FieldInfo;

namespace RC.Software.DevTools
{
    public class FormCodeService
    {
        public static bool IsInherit(Type type, Type baseType)
        {
            if (type.BaseType == null) return false;
            if (type.BaseType == baseType) return true;
            return IsInherit(type.BaseType, baseType);
        }

        public static string CreateCode(int dbId, string tableName, string templateFile)
        {
            var sw = new Stopwatch();
            sw.Start();
            var config = ConfigHelper.GetConfig<AppConfig>();
            var con = FormDbService.GetConnectionString(dbId);

            var template = BuildManager.CreateTemplate(templateFile);

            #region 表实体

            var className = tableName.Contains("_")
                ? tableName.Substring(tableName.LastIndexOf("_", StringComparison.Ordinal) + 1)
                : tableName;
            var classChineseName = SqlserverHelper.GetTableNote(con, tableName);
            var tableInfo = new TableInfo
            {
                TableNote = classChineseName,
                ClassName = className,
                TableName = tableName
            };

            #endregion

            #region 字段

            var fieldList = SqlserverHelper.GetFieldInfoList(con, tableName);
            var list = new List<FieldInfo>();
            var except = config.ExceptFields ?? "";
            var excepts = except.Replace("，", ",").ToLower().Trim().Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var fieldInfo in fieldList)
            {
                if (!excepts.Contains(fieldInfo.Name.ToLower())) list.Add(fieldInfo);
                if (fieldInfo.IsPrimaryKey) tableInfo.PrimaryKey = fieldInfo.Name;
            }

            #endregion

            #region 加载模板内置对象

            Dictionary<string, PresentBase> tempData = new Dictionary<string, PresentBase>();
            if (tempData.Count <= 0)
            {
                Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
                foreach (Assembly assembly in assemblies)
                {
                    //反射调用展现层类库
                    if (assembly.FullName.Contains("RC.Software.Presentation"))
                    {
                        Type[] classes = assembly.GetTypes();
                        foreach (Type type in classes)
                        {
                            if (IsInherit(type, typeof(PresentBase)))
                            {
                                string name = type.Name.ToLower();
                                var instance = Activator.CreateInstance(type) as PresentBase;
                                tempData.Add(name, instance);
                            }
                        }
                    }
                }
            }
            foreach (var pair in tempData)
            {
                template.Context.TempData[pair.Key] = pair.Value;
            }

            #endregion

            template.Context.CurrentPath = templateFile;
            template.Context.TempData["datetime"] = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            template.Context.TempData["conn"] = con;
            template.Context.TempData["table"] = tableInfo;
            template.Context.TempData["fields"] = list;
            template.Context.TempData["author"] = config.Author ?? "";
            template.Context.TempData["namespace"] = config.NameSpace ?? "";

            #region 内置标签方法 (动态加载)

            object insideStaticLabel = null;
            try
            {
                const string insideClassName = "RC.Software.Presentation.InsideStaticLabel";
                string fileName = Path.Combine(Thread.GetDomain().BaseDirectory, @"InsideStaticLabel.cs");

                if (File.Exists(fileName))
                {
                    var sourceFile = new FileInfo(fileName);
                    CodeDomProvider provider = new CSharpCodeProvider();
                    var cp = new CompilerParameters();
                    cp.ReferencedAssemblies.Add("System.dll"); //添加命名空间引用 
                    cp.ReferencedAssemblies.Add("RC.Software.Presentation.dll"); //添加命名空间引用 
                    cp.ReferencedAssemblies.Add("RC.Software.Framework.dll");

                    cp.GenerateExecutable = false; // 生成类库 
                    cp.GenerateInMemory = true; // 保存到内存 
                    cp.TreatWarningsAsErrors = false; // 不将编译警告作为错误

                    // 编译
                    CompilerResults results = provider.CompileAssemblyFromFile(cp, sourceFile.FullName);
                    if (results.Errors.Count < 1)
                    {
                        Assembly asm = results.CompiledAssembly; // 加载
                        insideStaticLabel = asm.CreateInstance(insideClassName); //获取编译后的类型   
                    }
                    else
                    {
                        string msg = null;
                        for (int index = 0; index < results.Errors.Count; index++)
                        {
                            CompilerError error = results.Errors[index];
                            msg += "【错误" + (index + 1) + "】" + Environment.NewLine;
                            msg += "[文件] " + error.FileName + Environment.NewLine;
                            msg += "[位置] 行" + error.Line + ",列" + error.Column + Environment.NewLine;
                            msg += "[信息] " + error.ErrorText + Environment.NewLine;
                            msg += Environment.NewLine;
                        }
                        MessageBox.Show(msg, "内置方法类编译错误");
                    }
                }
            }
            catch
            {
                //如果用户文件写的有问题，用系统内置的标签方法
                if (insideStaticLabel == null)
                {
                    insideStaticLabel = new InsideStaticLabel();
                }
            }
            if (insideStaticLabel == null)
            {
                insideStaticLabel = new InsideStaticLabel();
            }
            template.Context.TempData["rc"] = insideStaticLabel;

            #endregion

            var html = template.Render();
            return html;
        }
    }
}