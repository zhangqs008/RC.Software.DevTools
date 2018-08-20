//--------------------------------------------------------------------------------
// 文件描述：${table.TableNote}服务类
// 文件作者：${author}
// 创建日期：${datetime}
// 修改记录： 
//--------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using ${namespace}.Model;
 
namespace ${namespace}.Service
{
    /// <summary>
    ///${table.TableNote}服务类
    /// </summary>
    public class ${table.ClassName}Service : ServiceBase<${table.ClassName}>
    {  
         /// <summary>
        /// 通过编号取得${table.TableNote}实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ${table.ClassName} GetById(string id)
        {
            const string sql = "SELECT * FROM ${table.TableName} WHERE id=@0";
            return Db.FirstOrDefault<${table.ClassName}>(sql, id);
        }
        
        /// <summary>
        /// 添加${table.TableNote}
        /// </summary>
        /// <param name="instance"></param>
        /// <returns></returns>
        public bool Add(${table.ClassName} instance)
        { 
            //数据验证
			$foreach(field in fields)if(instance.${field.Name}.Length==0){
				return false;
			}  
			$end
			//其他代码
            return false;
        } 
        /// <summary>
        /// 修改${table.TableNote}
        /// </summary>
        /// <param name="instance"></param>
        /// <returns></returns>
        public bool Edit(${table.ClassName} instance)
        { 
           	$foreach(field in fields)instance.${field.Name}="";	//${field.Note}		
			$end
            return false;
        }

        /// <summary>
        ///     删除${table.TableNote}记录
        /// </summary>
        /// <param name="id">根据ID删除${table.TableNote}记录</param>
        /// <returns>返回true表示删除成功，返回false表示删除失败</returns>
        public bool Delete(int id)
        {
           try{
            	const string sql ="DELETE FROM ${table.TableName} WHERE ${table.primaryKey}=@0"; 
                var instance = DbHelper.CurrentDb.SingleOrDefault<${table.ClassName}>(id);
                Whir.Foundation.Context.AppService.LogService.Log(string.Format("{0} 删除${table.TableNote}" , WhirContext.Current.Admin.LoginName),
                                      string.Format("{0}", instance.ToXml()));
                return DbHelper.CurrentDb.Execute(sql, id) > 0;
            }
            catch (Exception ex)
            { 
                Foundation.Context.AppService.LogService.LogException(ex);
                return false;
            }
        }

        /// <summary>
        ///     批量删除${table.TableNote}实体
        /// </summary>
        /// <param name="ids">根据ID批量删除${table.TableNote}实体</param>
        /// <returns>返回true表示删除成功，返回false表示删除失败</returns>
        public bool Delete(string ids)
        {
            return Db.Delete(ids);
        }
      
    }
}