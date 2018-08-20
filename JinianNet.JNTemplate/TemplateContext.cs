/*****************************************************
   Copyright (c) 2013-2014 ���ĳ���  (http://www.jiniannet.com)

   Licensed under the Apache License, Version 2.0 (the "License");
   you may not use this file except in compliance with the License.
   You may obtain a copy of the License at

       http://www.apache.org/licenses/LICENSE-2.0

   Unless required by applicable law or agreed to in writing, software
   distributed under the License is distributed on an "AS IS" BASIS,
   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
   See the License for the specific language governing permissions and
   limitations under the License.

   Redistributions of source code must retain the above copyright notice
 *****************************************************/
using System;
using System.Collections.Generic;
using System.Text;
using JinianNet.JNTemplate.Parser;

namespace JinianNet.JNTemplate
{
    /// <summary>
    /// Context
    /// </summary>
    public class TemplateContext : ContextBase
    {
        /// <summary>
        /// Context
        /// </summary>
        public TemplateContext()
        {
            this.Charset = System.Text.Encoding.Default;
            this.ThrowExceptions = true;
        }

        private String currentPath;
        /// <summary>
        /// ��ǰ��Դ·��
        /// </summary>
        public String CurrentPath
        {
            get { return currentPath; }
            set { currentPath = value; }
        }

        private Encoding charset;
        /// <summary>
        /// ��ǰ��Դ����
        /// </summary>
        public Encoding Charset
        {
            get { return charset; }
            set { charset = value; }
        }

        /// <summary>
        /// ģ����Դ·��
        /// </summary>
        [Obsolete("��ʹ��Resources.Paths �����������")]
        public List<String> Paths
        {
            get { return Resources.Paths; }
            private set
            {
                //if (!Resources.Paths.Contains(value))
                //{
                Resources.Paths.AddRange(value);
                //}
            }
        }

        private bool throwErrors;

        /// <summary>
        /// �Ƿ��׳��쳣(Ĭ��Ϊtrue)
        /// </summary>
        public bool ThrowExceptions
        {
            get { return throwErrors; }
            set { throwErrors = value; }
        }

        //public virtual System.Exception[] AllErrors
        //{
        //    get
        //    {
        //        return null;
        //    }
        //}

        ///// <summary>
        ///// ��ȡ��ǰ��һ���쳣��Ϣ
        ///// </summary>
        //public virtual System.Exception Error
        //{
        //    get
        //    {
        //        if (this.AllErrors.Length > 0)
        //        {
        //            return this.AllErrors[0];
        //        }

        //        return null;
        //    }
        //}

        /// <summary>
        /// ���쳣��ӵ���ǰ �쳣�����С�
        /// </summary>
        /// <param name="e">�쳣</param>
        public void AddError(System.Exception e)
        {

        }

        /// <summary>
        /// ��������쳣
        /// </summary>
        public void ClearError()
        {

        }

        /// <summary>
        /// ��ָ��TemplateContext����һ�����Ƶ�ʵ��
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public static TemplateContext CreateContext(TemplateContext context)
        {
            TemplateContext ctx = new TemplateContext();
            ctx.TempData = new VariableScope(context.TempData);
            ctx.Charset = context.Charset;
            ctx.CurrentPath = context.CurrentPath;
            ctx.ThrowExceptions = context.ThrowExceptions;
            return ctx;
        }
    }
}