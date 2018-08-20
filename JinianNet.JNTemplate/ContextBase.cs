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
    /// ContextBase ����
    /// </summary>
    public class ContextBase : ICloneable
    {

        private VariableScope variableScope;
        /// <summary>
        /// ģ������
        /// </summary>
        public VariableScope TempData
        {
            get { return variableScope; }
            set { variableScope = value; }
        }

        /// <summary>
        /// ContextBase 
        /// </summary>
        public ContextBase()
        {
            variableScope = new VariableScope();
        }

        #region ICloneable ��Ա

        public Object Clone()
        {
            return this.MemberwiseClone();
        }

        #endregion
    }
}
