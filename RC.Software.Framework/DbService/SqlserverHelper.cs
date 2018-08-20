using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using RC.Software.Presentation;

namespace RC.Software.Framework.DbService
{
    public class SqlserverHelper
    {
        public static List<string> GetTableNames(string conn)
        {
            var dbName = new Regex(
                "(?i)(database|Initial Catalog)=(?<db>[^;]*?);",
                RegexOptions.CultureInvariant
                | RegexOptions.Compiled
            ).Match(conn).Groups["db"].Value;

            var list = new List<string>();
            try
            {
                var sql = @"SELECT  sysobjects.name
                            FROM    sysobjects ,master..sysdatabases t
                            WHERE   type = 'U' AND t.name = '{0}'
                            ORDER BY sysobjects.name ASC";
                sql = string.Format(sql, dbName);
                var cmd = new SqlCommand();
                var sqlcon = new SqlConnection(conn);
                using (sqlcon)
                {
                    cmd.Connection = sqlcon;
                    cmd.CommandText = sql;
                    sqlcon.Open();
                    SqlDataReader sdr = cmd.ExecuteReader();
                    while (sdr.Read())
                    {
                        list.Add(sdr[0].ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                list.Add("Error");
            }
            return list;
        }

        public static string GetTableNote(string con, string tableName)
        {
            string tableNote;
            string sql =
                @"SELECT TOP 1 value AS TableName
                    FROM    sys.extended_properties
                    WHERE   major_id IN ( SELECT    object_id
                                          FROM      sys.tables
                                          WHERE     name = '{0}')";
            sql = string.Format(sql, tableName);
            var connection = new SqlConnection(con);
            using (connection)
            {
                var cmd = new SqlCommand { Connection = connection, CommandText = sql };

                connection.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                if (sdr.Read())
                {
                    string str = sdr["TableName"].ToString();
                    tableNote = str;
                }
                else
                {
                    tableNote = tableName;
                }
            }
            return tableNote;
        }

        public static List<RC.Software.Presentation.FieldInfo> GetFieldInfoList(string con, string tableName)
        {
            var itemlist = new List<FieldInfo>();
            string sql = string.Format(@"SELECT   
                                表名=CASE WHEN C.column_id=1 THEN O.name ELSE N'' END,  
                                表说明=ISNULL(CASE WHEN C.column_id=1 THEN PTB.[value] END,N''),  
                                字段序号=C.column_id,  
                                字段名=C.name,  
                                主键=ISNULL(IDX.PrimaryKey,N''),  
                                标识=CASE WHEN C.is_identity=1 THEN N'√'ELSE N'' END,  
                                计算列=CASE WHEN C.is_computed=1 THEN N'√'ELSE N'' END,  
                                类型=T.name,  
                                字节数=C.max_length,  
                                长度=COLUMNPROPERTY(C.[object_id],C.name,'precision'),  
                                小数位数=C.scale,  
                                允许空=CASE WHEN C.is_nullable=1 THEN N'√'ELSE N'' END,  
                                默认值=ISNULL(D.definition,N''),  
                                字段说明=ISNULL(PFD.[value],N''),  
                                索引=ISNULL(IDX.IndexName,N''),  
                                索引排序=ISNULL(IDX.Sort,N''),  
                                创建日期=O.Create_Date,  
                                修改日期=O.Modify_date  
                               FROM sys.columns C  
                                INNER JOIN sys.objects O  
                                    ON C.[object_id]=O.[object_id]  
                                        AND O.type='U'  
                                        AND O.is_ms_shipped=0  
                                INNER JOIN sys.types T  
                                    ON C.user_type_id=T.user_type_id  
                                LEFT JOIN sys.default_constraints D  
                                    ON C.[object_id]=D.parent_object_id  
                                        AND C.column_id=D.parent_column_id  
                                        AND C.default_object_id=D.[object_id]  
                                LEFT JOIN sys.extended_properties PFD  
                                    ON PFD.class=1   
                                        AND C.[object_id]=PFD.major_id   
                                        AND C.column_id=PFD.minor_id  
                            --             AND PFD.name='Caption'  -- 字段说明对应的描述名称(一个字段可以添加多个不同name的描述)  
                                LEFT JOIN sys.extended_properties PTB  
                                    ON PTB.class=1   
                                        AND PTB.minor_id=0   
                                        AND C.[object_id]=PTB.major_id  
                            --             AND PFD.name='Caption'  -- 表说明对应的描述名称(一个表可以添加多个不同name的描述)   
  
                                LEFT JOIN                       -- 索引及主键信息  
                                (  
                                    SELECT   
                                        IDXC.[object_id],  
                                        IDXC.column_id,  
                                        Sort=CASE INDEXKEY_PROPERTY(IDXC.[object_id],IDXC.index_id,IDXC.index_column_id,'IsDescending')  
                                            WHEN 1 THEN 'DESC' WHEN 0 THEN 'ASC' ELSE '' END,  
                                        PrimaryKey=CASE WHEN IDX.is_primary_key=1 THEN N'√'ELSE N'' END,  
                                        IndexName=IDX.Name  
                                    FROM sys.indexes IDX  
                                    INNER JOIN sys.index_columns IDXC  
                                        ON IDX.[object_id]=IDXC.[object_id]  
                                            AND IDX.index_id=IDXC.index_id  
                                    LEFT JOIN sys.key_constraints KC  
                                        ON IDX.[object_id]=KC.[parent_object_id]  
                                            AND IDX.index_id=KC.unique_index_id  
                                    INNER JOIN  -- 对于一个列包含多个索引的情况,只显示第个索引信息  
                                    (  
                                        SELECT [object_id], Column_id, index_id=MIN(index_id)  
                                        FROM sys.index_columns  
                                        GROUP BY [object_id], Column_id  
                                    ) IDXCUQ  
                                        ON IDXC.[object_id]=IDXCUQ.[object_id]  
                                            AND IDXC.Column_id=IDXCUQ.Column_id  
                                            AND IDXC.index_id=IDXCUQ.index_id  
                                ) IDX  
                                    ON C.[object_id]=IDX.[object_id]  
                                        AND C.column_id=IDX.column_id   
  
                            WHERE O.name=N'{0}'       -- 如果只查询指定表,加上此条件  
                            ORDER BY O.name,C.column_id", tableName);
            var cmd = new SqlCommand();
            var connection = new SqlConnection(con);
            using (connection)
            {
                cmd.Connection = connection;
                cmd.CommandText = sql;
                connection.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    var item = new FieldInfo();
                    item.Name = sdr["字段名"].ToString();
                    item.Type = sdr["类型"].ToString();
                    item.Length = Convert.ToInt32(sdr["长度"]);
                    item.IsPrimaryKey = (sdr["主键"] != null && sdr["主键"].ToString() == "√");
                    item.IsNull = (sdr["允许空"] != null && sdr["允许空"].ToString() == "√");
                    item.Note = !string.IsNullOrEmpty(sdr["字段说明"].ToString())
                                    ? sdr["字段说明"].ToString()
                                    : sdr["字段名"].ToString();
                    if (!string.IsNullOrEmpty(item.Note))
                    {
                        if (item.Note.IndexOf("{*}", StringComparison.Ordinal) > -1)
                        {
                            item.IsRequired = true;
                            item.Note = item.Note.Replace("{*}", "");
                        }
                        Regex regex = new Regex("\\{(?<inputType>([A-Za-z]*))\\|(?<verify>([A-Za-z]*))\\}");
                        Match match = regex.Match(item.Note);
                        if (match.Groups["inputType"] != null)
                        {
                            item.InputType = match.Groups["inputType"].ToString();
                        }

                        if (match.Groups["verify"] != null)
                        {
                            item.Verify = match.Groups["verify"].ToString();
                        }
                        if (!string.IsNullOrEmpty(match.ToString()))
                        {
                            item.Note = item.Note.Replace(match.ToString(), "");
                        }
                    }
                    itemlist.Add(item);
                }
            }


            return itemlist;
        }
        public static List<TableInfo> GetTables(string conn)
        {
            var dbName = new Regex(
                "(?i)(database|Initial Catalog)=(?<db>[^;]*?);",
                RegexOptions.CultureInvariant
                | RegexOptions.Compiled
            ).Match(conn).Groups["db"].Value;

            var tables = new List<TableInfo>();
            try
            {
                string sql =
                    @"SELECT  sysobjects.name
                        FROM    sysobjects , master..sysdatabases t
                        WHERE   type = 'U' AND t.name = '" + dbName + "' ORDER BY sysobjects.name ASC";
                var cmd = new SqlCommand();
                var sqlcon = new SqlConnection(conn);
                using (sqlcon)
                {
                    cmd.Connection = sqlcon;
                    cmd.CommandText = sql;
                    sqlcon.Open();
                    SqlDataReader sdr = cmd.ExecuteReader();
                    while (sdr.Read())
                    {
                        tables.Add(new TableInfo
                        {
                            TableNote = sdr[0].ToString(),
                            TableName = sdr[0].ToString()
                        });
                    }
                }
            }
            catch
            {
            }
            return tables;
        }
    }
}
