//--------------------------------------------------------------------------------
// �ļ�������${table.TableNote}ʵ����
// �ļ����ߣ�${author}
// �������ڣ�${datetime}
// �޸ļ�¼�� 
//--------------------------------------------------------------------------------
using System;
using System.ComponentModel.DataAnnotations;
using RC.Framework.DB;

namespace ${namespace}.Model
{
    /// <summary> 
    /// ${table.TableNote}ʵ����
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


