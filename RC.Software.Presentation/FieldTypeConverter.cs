namespace RC.Software.Presentation
{
    /// <summary>
    ///     数据库字段类型转换类
    /// </summary>
    public class FieldTypeConverter
    {
        /// <summary>
        ///     将SQL类型转换为C#类型
        /// </summary>
        /// <param name="datatype">SQL类型</param>
        /// <returns>C#字段类型</returns>
        public static string SqlToCsharp(string datatype)
        {
            datatype = datatype.ToLower();
            switch (datatype)
            {
                case "bigint":
                    return "long";
                case "binary":
                    return "object";
                case "sql_variant":
                    return "object";
                case "bit":
                    return "bool";
                case "char":
                    return "string";
                case "nchar":
                    return "string";
                case "ntext":
                    return "string";
                case "nvarchar":
                    return "string";
                case "text":
                    return "string";
                case "varchar":
                    return "string";
                case "xml":
                    return "string";
                case "datetime":
                    return "DateTime";
                case "decimal":
                    return "decimal";
                case "numeric":
                    return "decimal";
                case "float":
                    return "double";
                case "image":
                    return "byte[]";
                case "timestamp":
                    return "byte[]";
                case "int":
                    return "int";
                case "money":
                    return "decimal";
                case "real":
                    return "float";
                case "smalldatetime":
                    return "DateTime";
                case "smallint":
                    return "short";
                case "smallmoney":
                    return "decimal";
                case "tinyint":
                    return "byte";
                case "uniqueidentelse ifier":
                    return "Guid";
                case "varbinary":
                    return "byte[]";
                default:
                    return null;
            }
        }

        /// <summary>
        ///     转换类型为大写形式
        /// </summary>
        /// <param name="datatype">SQL类型</param>
        /// <returns>类型的大写形式</returns>
        public static string FieldNameToUper(string datatype)
        {
            datatype = datatype.ToLower();

            switch (datatype)
            {
                case "bigint":
                    return "BigInt";
                case "binary":
                    return "Binary";
                case "sql_variant":
                    return "Variant";
                case "bit":
                    return "Bit";
                case "char":
                    return "Char";
                case "nchar":
                    return "NChar";
                case "ntext":
                    return "NText";
                case "nvarchar":
                    return "NVarChar";
                case "text":
                    return "Text";
                case "varchar":
                    return "VarChar";
                case "xml":
                    return "Xml";
                case "datetime":
                    return "DateTime";
                case "decimal":
                    return "Decimal";
                case "numeric":
                    return "Numeric";
                case "float":
                    return "Float";
                case "image":
                    return "Image";
                case "timestamp":
                    return "Timestamp";
                case "int":
                    return "Int";
                case "money":
                    return "Money";
                case "real":
                    return "Real";
                case "smalldatetime":
                    return "SmallDateTime";
                case "smallint":
                    return "Smallint";
                case "smallmoney":
                    return "SmallMoney";
                case "tinyint":
                    return "TinyInt";
                case "uniqueidentelseifier":
                    return "UniqueIdentelseifier";
                case "varbinary":
                    return "VarBinary";
                default:
                    return null;
            }
        }

        /// <summary>
        ///     将SQL数据类型转换为DBType
        /// </summary>
        /// <param name="datatype"></param>
        /// <returns></returns>
        public static string SqlToDbType(string datatype)
        {
            datatype = datatype.ToLower();
            switch (datatype)
            {
                case "bigint":
                    return "Int64";
                case "binary":
                    return "Binary";
                case "sql_variant":
                    return "Variant";
                case "bit":
                    return "Boolean";
                case "char":
                    return "String";
                case "nchar":
                    return "String";
                case "ntext":
                    return "String";
                case "nvarchar":
                    return "String";
                case "text":
                    return "String";
                case "varchar":
                    return "String";
                case "xml":
                    return "Xml";
                case "datetime":
                    return "DateTime";
                case "decimal":
                    return "Decimal";
                case "numeric":
                    return "Numeric";
                case "float":
                    return "Double";
                case "image":
                    return "Byte";
                case "timestamp":
                    return "Byte";
                case "int":
                    return "Int32";
                case "money":
                    return "Decimal";
                case "real":
                    return "Single";
                case "smalldatetime":
                    return "DateTime";
                case "smallint":
                    return "Int16";
                case "smallmoney":
                    return "Decimal";
                case "tinyint":
                    return "Byte";
                case "uniqueidentelseifier":
                    return "Guid";
                case "varbinary":
                    return "Byte";
                default:
                    return null;
            }
        }
    }
}