//--------------------------------------------------------------------------------
// 文件描述：模板解析内置标签方法
// 文件作者：张清山
// 创建日期：2014-8-7 10:52:28
// 注意事项：
// 1.此文件为代码生成时，内置模板标签方法类，可以根据您的需求来对数据库字段进行处理。
// 2.此文件为代码生成时动态编译，代码里的变量不能使用 var 关键字，必须明确指明变量类型。
// 3.此文件将被动态编译，请务必保证此文件代码编写正确。
//--------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace RC.Software.Presentation
{
    /// <summary>
    ///     模板内置静态标签方法
    /// </summary>
    public class InsideStaticLabel
    {
        #region 数据库字段转换

        /// <summary>
        ///     [字段类型转换]将数据库类型转C#类型
        /// </summary>
        /// <param name="datatype"></param>
        /// <returns></returns>
        public string SqlToCsharpType(string datatype)
        {
            return FieldTypeConverter.SqlToCsharp(datatype);
        }

        /// <summary>
        ///     [字段类型转换]将数据库类型转ADO.NET DB类型
        /// </summary>
        /// <param name="datatype"></param>
        /// <returns></returns>
        public string SqlToDbType(string datatype)
        {
            return FieldTypeConverter.SqlToDbType(datatype);
        }

        #endregion

        #region 辅助方法

        /// <summary>
        ///     [辅助方法]驼峰命名
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public string CamelCase(string input)
        {
            if (!string.IsNullOrEmpty(input))
            {
                input = input.ToCharArray()[0].ToString(CultureInfo.InvariantCulture).ToLower() + input.Substring(1);
                return input;
            }
            return string.Empty;
        }

        #endregion
         
          
        /// <summary>
        /// 字段类型转化
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        protected string GetFormat(string type)
        {
            type = SqlToCsharpType(type);
            switch (type.ToLower())
            {
                case "int":
                    return "ToInt()";
                case "string":
                    return "ToStr()";
                case "decimal":
                    return "ToDecimal()";
                case "datetime":
                    return "ToDateTime()";
                case "bool":
                    return "ToBoolean()";
            }
            return string.Empty;
        }
    }
}