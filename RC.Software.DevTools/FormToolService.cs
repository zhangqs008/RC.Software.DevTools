using System;
using System.IO;
using System.Text;
using System.Threading;
using System.Xml;
using RC.Software.Framework.Helper;

namespace RC.Software.DevTools
{
    public class FormToolService
    {
        /// <summary>
        ///     格式化xml输出
        /// </summary>
        /// <param name="xmlString"></param>
        /// <returns></returns>
        public static string FormatXml(string xmlString)
        {
            try
            {
                var xd = new XmlDocument();
                xd.LoadXml(xmlString);
                var sb = new StringBuilder();
                var writer = new StringWriter(sb);
                XmlTextWriter xmlTxtWriter = null;
                try
                {
                    xmlTxtWriter = new XmlTextWriter(writer);
                    xmlTxtWriter.Formatting = Formatting.Indented;
                    xmlTxtWriter.Indentation = 1;
                    xmlTxtWriter.IndentChar = '\t';
                    xd.WriteTo(xmlTxtWriter);
                }
                finally
                {
                    if (xmlTxtWriter != null)
                        xmlTxtWriter.Close();
                }

                return sb.ToString();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        /// <summary>
        ///     格式化HTML输出
        /// </summary>
        /// <param name="str"></param>
        /// <param name="bLineAndIndent"></param>
        /// <returns></returns>
        public static string FormatHtml(string str, bool bLineAndIndent)
        {
            XmlDocument document1 = ConvertToXmlDocument(str);
            if (bLineAndIndent)
            {
                var builder1 = new StringBuilder();
                var writer1 = new XmlTextWriter(new StringWriter(builder1))
                {
                    IndentChar = ' ',
                    Indentation = 4,
                    Formatting = Formatting.Indented
                };
                if (document1.DocumentElement != null) document1.DocumentElement.WriteContentTo(writer1);
                return builder1.ToString();
            }
            if (document1.DocumentElement != null) return document1.DocumentElement.InnerXml;
            return null;
        }

        /// <summary>
        ///     转换为整理后的Xml文档
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        private static XmlDocument ConvertToXmlDocument(string str)
        {
            var document1 = new XmlDocument();
            document1.LoadXml("<xml/>");
            SafeHtmlParser.ParseHtml(document1.DocumentElement, str);
            return document1;
        }
    }
}