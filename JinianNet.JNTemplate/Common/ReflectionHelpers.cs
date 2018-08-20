﻿/*****************************************************
   Copyright (c) 2013-2014 翅膀的初衷  (http://www.jiniannet.com)

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
using JinianNet.JNTemplate.Parser.Node;
using System.ComponentModel;
using System.Reflection;
using System.Globalization;
using System.Collections;

namespace JinianNet.JNTemplate.Common
{
    /// <summary>
    /// 反射辅助类
    /// </summary>
    public class ReflectionHelpers
    {
        private static readonly Char[] _expressionPartSeparator = new Char[] { '.' };
        private static readonly Char[] _indexExprEndChars = new Char[] { ']', ')' };
        private static readonly Char[] _indexExprStartChars = new Char[] { '[', '(' };

        #region EVAL解析
        #region 4.0版本

        /// <summary>
        /// 获取索引值
        /// </summary>
        /// <param name="container">对象</param>
        /// <param name="expr">表达式</param>
        /// <returns></returns>
        public static Object GetIndexedPropertyValue(Object container, String expr)
        {
            if (container == null)
            {
                return null;
                //throw new ArgumentNullException("container");
            }
            if (String.IsNullOrEmpty(expr))
            {
                return null;
                //throw new ArgumentNullException("expr");
            }

            Int32 length = expr.IndexOfAny(_indexExprStartChars);
            Int32 num = expr.IndexOfAny(_indexExprEndChars, length + 1);
            if (((length < 0) || (num < 0)) || (num == (length + 1)))
            {
                return null;
                //throw new ArgumentException("DataBinder_Invalid_Indexed_Expr");//SR.GetString("DataBinder_Invalid_Indexed_Expr", new Object[] { expr }));
            }

            String propName = null;
            String propIndex = expr.Substring(length + 1, (num - length) - 1).Trim();
            if (length != 0)
            {
                propName = expr.Substring(0, length);
            }

            return GetIndexedProperty(container, propName, propIndex);

            #region
            //if (container == null)
            //{
            //    return null;
            //    //throw new ArgumentNullException("container");
            //}
            //if (String.IsNullOrEmpty(expr))
            //{
            //    return null;
            //    //throw new ArgumentNullException("expr");
            //}
            //Object obj2 = null;
            //bool flag = false;
            //Int32 length = expr.IndexOfAny(_indexExprStartChars);
            //Int32 num2 = expr.IndexOfAny(_indexExprEndChars, length + 1);
            //if (((length < 0) || (num2 < 0)) || (num2 == (length + 1)))
            //{
            //    return null;
            //    //throw new ArgumentException("DataBinder_Invalid_Indexed_Expr");//SR.GetString("DataBinder_Invalid_Indexed_Expr", new Object[] { expr }));
            //}
            //String propName = null;
            //Object obj3 = null;
            //String s = expr.Substring(length + 1, (num2 - length) - 1).Trim();
            //if (length != 0)
            //{
            //    propName = expr.Substring(0, length);
            //}
            //if (s.Length != 0)
            //{
            //    if (((s[0] == '"') && (s[s.Length - 1] == '"')) || ((s[0] == '\'') && (s[s.Length - 1] == '\'')))
            //    {
            //        obj3 = s.Substring(1, s.Length - 2);
            //    }
            //    else if (char.IsDigit(s[0]))
            //    {
            //        Int32 num3;
            //        flag = Int32.TryParse(s, NumberStyles.Integer, CultureInfo.InvariantCulture, out num3);
            //        if (flag)
            //        {
            //            obj3 = num3;
            //        }
            //        else
            //        {
            //            obj3 = s;
            //        }
            //    }
            //    else
            //    {
            //        obj3 = s;
            //    }
            //}
            //if (obj3 == null)
            //{
            //    return null;
            //    //throw new ArgumentException("DataBinder_Invalid_Indexed_Expr");//SR.GetString("DataBinder_Invalid_Indexed_Expr", new Object[] { expr }));
            //}
            //Object property = null;
            //if ((propName != null) && (propName.Length != 0))
            //{
            //    property = GetProperty(container, propName);
            //}
            //else
            //{
            //    property = container;
            //}
            //if (property == null)
            //{
            //    return obj2;
            //}
            //Array array = property as Array;
            //if ((array != null) && flag)
            //{
            //    return array.Get((Int32)obj3);
            //}
            //if ((property is IList) && flag)
            //{
            //    return ((IList)property)[(Int32)obj3];
            //}
            //PropertyInfo info = property.GetType().GetProperty("Item", BindingFlags.Public | BindingFlags.Instance, null, null, new Type[] { obj3.GetType() }, null);
            //if (info == null)
            //{
            //    return null;
            //    //throw new ArgumentException("DataBinder_No_Indexed_Accessor");//SR.GetString("DataBinder_No_Indexed_Accessor", new Object[] { property.GetType().FullName }));
            //}
            //return info.Get(property, new Object[] { obj3 });
            #endregion
        }

        /// <summary>
        /// 获取索引值
        /// </summary>
        /// <param name="container">对象</param>
        /// <param name="propIndex">索引名称</param>
        /// <param name="isNumber">索引名称是否数字</param>
        /// <returns></returns>
        public static Object GetIndexedProperty(Object container, Boolean isNumber, Object propIndex)
        {
            //Array array = container as Array;
            //if ((array != null) && isNumber)
            //{
            //    return array.GetValue((Int32)propIndex);
            //}
            if (isNumber && (container is IList))
            {
                return ((IList)container)[(Int32)propIndex];
            }
            /*
            if(container is System.Data.DataRowView){
                if (isNumber)
                {
                    return ((System.Data.DataRowView)container)[(Int32)propIndex];
                }
                else
                {
                    return ((System.Data.DataRowView)container)[propIndex.ToString()];
                }
            }
             */
            //System.Data.DataRowView
            PropertyInfo info = container.GetType().GetProperty("Item", BindingFlags.Public | BindingFlags.Instance, null, null, new Type[] { propIndex.GetType() }, null);
            if (info == null)
            {
                return null;
                //throw new ArgumentException("DataBinder_No_Indexed_Accessor");//SR.GetString("DataBinder_No_Indexed_Accessor", new Object[] { property.GetType().FullName }));
            }
            return info.GetValue(container, new Object[] { propIndex });
        }

        public static Object GetIndexedProperty(Object container, String propName, String propIndex)
        {
            Boolean flag = false;

            Object value = null;

            if (propIndex.Length != 0)
            {
                if (((propIndex[0] == '"') && (propIndex[propIndex.Length - 1] == '"')) || ((propIndex[0] == '\'') && (propIndex[propIndex.Length - 1] == '\'')))
                {
                    value = propIndex.Substring(1, propIndex.Length - 2);
                }
                else if (char.IsDigit(propIndex[0]))
                {
                    Int32 num;
                    flag = Int32.TryParse(propIndex, NumberStyles.Integer, CultureInfo.InvariantCulture, out num);
                    if (flag)
                    {
                         value= num;
                    }
                    else
                    {
                         value= propIndex;
                    }
                }
                else
                {
                     value= propIndex;
                }
            }
            if ( value== null)
            {
                return null;
                //throw new ArgumentException("DataBinder_Invalid_Indexed_Expr");//SR.GetString("DataBinder_Invalid_Indexed_Expr", new Object[] { expr }));
            }
            Object property = null;

            if ((propName != null) && (propName.Length != 0))
            {
                property = GetPropertyValue(container, propName);
            }
            else
            {
                property = container;
            }
            if (property == null)
            {
                return null;
            }

            return GetIndexedProperty(property, flag, value);

        }

        #endregion

        public static String Eval(Object container, String expression, String format)
        {
            Object obj = Eval(container, expression);
            if ((obj == null) || (obj == DBNull.Value))
            {
                return String.Empty;
            }
            if (String.IsNullOrEmpty(format))
            {
                return obj.ToString();
            }
            return String.Format(format, obj);
        }

        //public static Object Eval(VariableScope container, String expression)
        //{
        //    String[] expressionParts = expression.Split(_expressionPartSeparator);
        //    if (expressionParts.Length > 0)
        //    {
        //        if (expressionParts.Length==1)
        //        {
        //            return container[expressionParts[0]];
        //        }
        //        return Eval(container[expressionParts[0]], expressionParts, 1, expressionParts.Length);
        //    }

        //    return null;
        //}

        public static Object Eval(Object container, String expression)
        {
            if (expression == null)
            {
                //throw new ArgumentNullException("expression");
                return null;
            }
            expression = expression.Trim();
            if (expression.Length == 0)
            {
                //throw new ArgumentNullException("expression");
                return null;
            }
            if (container == null)
            {
                return null;
            }
            String[] expressionParts = expression.Split(_expressionPartSeparator);
            return Eval(container, expressionParts);
        }

        //public static Object Eval(Object container, String[] expressionParts)
        //{
        //    Object property = container;
        //    for (Int32 i = 0; (i < expressionParts.Length) && (property != null); i++)
        //    {
        //        String propName = expressionParts[i];
        //        bool isIndexedProperty = false;
        //        if (propName.IndexOfAny(_indexExprStartChars) >= 0)
        //        {
        //            propName = propName.TrimStart('[').TrimEnd(']').Trim('"');
        //            isIndexedProperty = true;
        //        }

        //        #region 针对特定类型做处理，加快解析速度
        //        if (property == null || container == null)
        //        {

        //        }
        //        //else if (container is IDictionary)
        //        //{
        //        //    property = (container as IDictionary)[propName];

        //        //}
        //        //else if (container is IList)
        //        //{
        //        //    property = (container as IList)[Convert.ToInt32(propName)];

        //        //}
        //        //else if (container is System.Data.DataRowCollection)
        //        //{
        //        //    property = (container as System.Data.DataRowCollection)[Convert.ToInt32(propName)];
        //        //}
        //        //else if (container is System.Data.DataRow || container is System.Data.DataRowView)
        //        //{
        //        //    System.Data.DataRow dr;
        //        //    if (container is System.Data.DataRowView)
        //        //        dr = (container as System.Data.DataRowView).Row;
        //        //    else
        //        //        dr = container as System.Data.DataRow;

        //        //    if (ParserRegex.Number.Match(propName).Success)
        //        //        property = dr[Convert.ToInt32(propName)];
        //        //    else
        //        //        property = dr[propName];
        //        //}
        //        else
        //        {
        //            propName = expressionParts[i];
        //            if (!isIndexedProperty)
        //            {
        //                property = GetProperty(property, propName);
        //            }
        //            else
        //            {
        //                property = GetIndexedProperty(property, propName);
        //            }
        //        }
        //        #endregion

        //    }
        //    return property;
        //}
        #region
        public static Object Eval(Object container, String[] expressionParts)
        {
            return Eval(container, expressionParts, 0, expressionParts.Length);
        }

        private static Object Eval(Object container, String[] expressionParts,Int32 start,Int32 end)
        {
            Object property = container;
            for (Int32 i = start; (i < end) && (property != null); i++)
            {
                String propName = expressionParts[i];
                if (propName.IndexOfAny(_indexExprStartChars) < 0)
                {
                    property = GetPropertyValue(property, propName);
                }
                else
                {
                    property = GetIndexedPropertyValue(property, propName);
                }
            }
            return property;
        }
        #endregion

        public static Object GetPropertyValue(Object container, String propName)
        {
            if (container == null)
            {
                return null;
                //throw new ArgumentNullException("container");
            }
            if (String.IsNullOrEmpty(propName))
            {
                return null;
                //throw new ArgumentNullException("propName");
            }
            //PropertyDescriptor descriptor = GetPropertiesFromCache(container).Find(propName, true);

            PropertyDescriptor descriptor = TypeDescriptor.GetProperties(container).Find(propName, true);
            if (descriptor == null)
            {
                Object value;
                Int32 num;
                bool flag = Int32.TryParse(propName, NumberStyles.Integer, CultureInfo.InvariantCulture, out num);
                if (flag)
                {
                     value= num;
                }
                else
                {
                     value= propName;
                }
                return GetIndexedProperty(container, flag, value);
                //throw new HttpException("Property Not Found");//", new Object[] { container.GetType().FullName, propName })
            }
            return descriptor.GetValue(container);
        }

        #endregion
        #region

        public static MethodInfo GetMethod(Type type, String methodName, Type[] args)
        {
            if (args==null || Array.LastIndexOf(args, null) == -1) //
            {
                return type.GetMethod(methodName,
                    BindingFlags.Public | BindingFlags.IgnoreCase | BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Static,
                    null, args, null);
            }
            else
            {
                ParameterInfo[] pi;
                Boolean accord;
                foreach (MethodInfo m in type.GetMembers(BindingFlags.Public | BindingFlags.IgnoreCase | BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Static))
                {
                    if(m.Name.Equals(methodName, StringComparison.OrdinalIgnoreCase)){
                         pi =  m.GetParameters();
                        if (pi.Length == args.Length)
                        {
                            accord=true;
                            for (Int32 i = 0; i < pi.Length; i++)
                            {
                                if (args[i] != null && args[i]!= pi[i].ParameterType)
                                {
                                    accord = false;
                                    break;
                                }
                            }
                            if (accord)
                            {
                                return m;
                            }
                        }
                    }
                }
            }
            return null;
        }
        public static Object GetMethod(Object container, String methodName, Object[] args)
        {
            Type[] types = new Type[args.Length];
            for (Int32 i = 0; i < args.Length; i++)
                types[i] = args[i].GetType();
            Type t = container.GetType();
            MethodInfo method = GetMethod(t, methodName, types);
            if (method == null)
                return null; //throw new Exception(String.Concat("在类型 ", t.Name, " 中未找到方法 ", methodName));

            return method.Invoke(container, args);
        }

        public static IEnumerable ToIEnumerable(Object dataSource)
        {
            if (dataSource == null)
                return null;
            if (dataSource is IListSource)
            {
                IListSource source = (IListSource)dataSource;
                IList list = source.GetList();
                if (!source.ContainsListCollection)
                {
                    return list;
                }
                if ((list != null) && (list is ITypedList))
                {
                    PropertyDescriptorCollection itemProperties = ((ITypedList)list).GetItemProperties(new PropertyDescriptor[0]);
                    if ((itemProperties == null) || (itemProperties.Count == 0))
                    {
                        return null;
                    }
                    PropertyDescriptor descriptor = itemProperties[0];
                    if (descriptor != null)
                    {
                        Object component = list[0];
                        Object value = descriptor.GetValue(component);
                        if ((value != null) && (value is IEnumerable))
                        {
                            return (IEnumerable)value;
                        }
                    }
                    return null;
                }
            }
            if (dataSource is IEnumerable)
            {
                return (IEnumerable)dataSource;
            }
            return null;

        }


        #endregion
    }
}