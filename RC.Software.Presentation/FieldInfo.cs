namespace RC.Software.Presentation
{
    /// <summary>
    ///     数据库字段实体类
    /// </summary>
    public class FieldInfo
    {
        public FieldInfo()
        {
            IsRequired = false;
        }

        public FieldInfo(string name, string type)
        {
            IsRequired = false;
            Name = name;
            Type = type;
            Note = Note;
        }

        /// <summary>
        ///     字段名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        ///     字段类型
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        ///     字段注释
        /// </summary>
        public string Note { get; set; }

        /// <summary>
        ///     字段长度
        /// </summary>
        public int Length { get; set; }

        /// <summary>
        ///     是否主键
        /// </summary>
        public bool IsPrimaryKey { get; set; }

        /// <summary>
        ///     是否为空
        /// </summary>
        public bool IsNull { get; set; }


        /// <summary>
        ///     文本框类型
        /// </summary>
        public string InputType { get; set; }

        /// <summary>
        ///     验证类型
        /// </summary>
        public string Verify { get; set; }


        /// <summary>
        ///     是否必填
        /// </summary>
        public bool IsRequired { get; set; }
    }
}