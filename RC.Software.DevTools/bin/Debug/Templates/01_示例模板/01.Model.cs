//--------------------------------------------------------------------------------
// 文件描述：${table.TableNote}实体类
// 文件作者：${author}
// 创建日期：${datetime}
// 修改记录： 
//--------------------------------------------------------------------------------
using System;
using System.ComponentModel.DataAnnotations;
using RC.Framework.DB;

namespace ${namespace}.Model
{
    /// <summary> 
    /// ${table.TableNote}实体类
    /// </summary>
    [TableName("${table.TableName}")]
    [PrimaryKey("${table.primaryKey}")]
    [Serializable]
    public class ${table.ClassName}: ModelBase
    {  
        $foreach(field in fields)        
        /// <summary> 
		/// $field.Note 
		/// </summary> 		
        [Display(Name = @"$field.Note")]
        public $rc.SqlToCsharpType(field.Type) $field.Name {get;set;}
        $end 
         

    }
}


