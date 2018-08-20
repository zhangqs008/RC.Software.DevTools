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

namespace JinianNet.JNTemplate.Parser
{
    /// <summary>
    /// 词素分析器
    /// </summary>
    public class TemplateLexer
    {
        /// <summary>
        /// 状态
        /// </summary>
        private LexerMode mode;
        /// <summary>
        /// 当前文档
        /// </summary>
        private String document;
        /// <summary>
        /// 当前列
        /// </summary>
        private Int32 column;
        /// <summary>
        /// 当前行
        /// </summary>
        private Int32 line;
        /// <summary>
        /// 当前TokenKind
        /// </summary>
        private TokenKind kind;
        /// <summary>
        /// 起始列
        /// </summary>
        private Int32 startColumn;
        /// <summary>
        /// 起始行
        /// </summary>
        private Int32 startLine;
        /// <summary>
        /// 扫描器
        /// </summary>
        private CharScanner scanner;

        private List<Token> collection;

        private Stack<String> pos;
        /// <summary>
        /// TemplateLexer
        /// </summary>
        /// <param name="text">文本内容</param>
        public TemplateLexer(String text)
        {
            this.document = text;
            Reset();
        }
        /// <summary>
        /// 重置分析器
        /// </summary>
        public void Reset()
        {
            this.mode = LexerMode.None;
            this.line = 1;
            this.column = 1;
            this.kind = TokenKind.Text;
            this.startColumn = 1;
            this.startLine = 1;
            this.scanner = new CharScanner(this.document);
            this.collection = new List<Token>();
            this.pos = new Stack<String>();
        }


        private Token GetToken(TokenKind tokenKind)
        {
            Token _token = new Token(this.kind, this.scanner.GetString());
            _token.BeginLine = this.startLine;
            _token.BeginColumn = this.startColumn;
            _token.EndColumn = this.column;
            _token.BeginLine = this.line;
            this.kind = tokenKind;
            this.startColumn = this.column;
            this.startLine = this.line;
            return _token;
        }



        private bool Next()
        {
            return Next(1);
        }
        private bool Next(Int32 i)
        {
            if (this.scanner.Next(i))
            {
                this.column += i;
                return true;
            }

            return false;
        }

        private bool IsTagStart()
        {
            if (this.scanner.Read() == '$')
            {
                if (!this.scanner.IsEnd())
                {
                    Char value = this.scanner.Read(1);
                    if (value == '{')
                    {
                        this.pos.Push("${");
                        return true;
                    }
                    if (Char.IsLetter(value))
                    {
                        this.pos.Push("$");
                        return true;
                    }
                }
            }
            return false;
        }

        private bool IsTagEnd()
        {
            if (this.pos.Count == 1)
            {
                if (this.scanner.IsEnd())
                {
                    return true;
                }
                Char value = this.scanner.Read();
                if (this.pos.Peek().Length == 2)
                {
                    if (value == '}')
                    {
                        return true;
                    }
                }
                else if (value != '.')
                {
                    if (((value == '(' || Common.ParserHelpers.IsWord(value)) && Common.ParserHelpers.IsWord(this.scanner.Read(-1)))
                        || (Common.ParserHelpers.IsWord(value) && (this.scanner.Read(-1) == '.')))
                    {
                        return false;
                    }
                    return true;
                }
                //else if (value != '.' && value != '(')
                //{
                //    if (Char.IsControl(value) || (Char.IsPunctuation(value) && value != '_') || Char.IsSeparator(value) || Char.IsSymbol(value) || Char.IsWhiteSpace(value) || (Int32)value > 167)
                //    {
                //        return true;
                //    }
                //}

            }
            return false;
        }
        /// <summary>
        /// 分析所有Token
        /// </summary>
        /// <returns></returns>
        public Token[] Parse()
        {
            if (this.kind != TokenKind.EOF)
            {
                do
                {
                    if (this.mode == LexerMode.EnterLabel)
                    {
                        Next(this.pos.Peek().Length - 1);
                        AddToken(GetToken(GetTokenKind(this.scanner.Read())));
                        switch (this.kind)
                        {
                            case TokenKind.StringStart:
                                this.pos.Push("\"");
                                break;
                            case TokenKind.LeftParentheses:
                                this.pos.Push("(");
                                break;
                        }
                        ReadToken();
                    }
                    else if (IsTagStart())
                    {
                        AddToken(GetToken(TokenKind.TagStart));
                        this.mode = LexerMode.EnterLabel;

                    }
                    else if (this.scanner.Read() == '\n')
                    {
                        this.line++;
                        this.column = 1;
                    }
                }
                while (Next());

                AddToken(GetToken(TokenKind.EOF));


                if (this.mode == LexerMode.EnterLabel)
                {
                    this.mode = LexerMode.LeaveLabel;
                    AddToken(new Token(TokenKind.TagEnd, String.Empty));
                }

            }

            return this.collection.ToArray();

        }

        private void AddToken(Token token)
        {
            if (this.collection.Count > 0 && this.collection[this.collection.Count - 1].Next == null)
            {
                this.collection[this.collection.Count - 1].Next = token;
            }
            this.collection.Add(token);
        }

        private void ReadToken()
        {
            while (Next())
            {
                if (this.scanner.Read() == '"')
                {
                    if (this.pos.Count > 1 && this.pos.Peek() == "\"")
                    {
                        if (this.kind == TokenKind.StringStart)
                        {
                            AddToken(GetToken(TokenKind.String));
                        }
                        AddToken(GetToken(TokenKind.StringEnd));
                        this.pos.Pop();
                        continue;
                    }

                    if (this.kind == TokenKind.TagStart
                        || this.kind == TokenKind.LeftBracket
                        || this.kind == TokenKind.LeftParentheses
                        || this.kind == TokenKind.Operator
                        || this.kind == TokenKind.Punctuation
                        || this.kind == TokenKind.Comma
                        || this.kind == TokenKind.Space)
                    {
                        AddToken(GetToken(TokenKind.StringStart));
                        this.pos.Push("\"");
                        continue;
                    }
                }

                if (this.kind == TokenKind.StringStart)
                {
                    AddToken(GetToken(TokenKind.String));
                    continue;
                }

                if (this.kind == TokenKind.String)
                {
                    continue;
                }

                if (this.scanner.Read() == '(')
                {
                    this.pos.Push("(");
                }
                else if (this.scanner.Read() == ')' && this.pos.Peek() == "(")// && this.pos.Count > 2
                {
                    this.pos.Pop();
                    if (this.pos.Count == 1)
                    {

                    }
                }
                else if (IsTagEnd())
                {
                    //Next(1);
                    //this.pos.Pop();
                    AddToken(GetToken(TokenKind.TagEnd));
                    this.mode = LexerMode.LeaveLabel;
                    if (this.pos.Pop().Length == 2)
                    {
                        Next(1);
                    }
                    if (IsTagStart())
                    {
                        AddToken(GetToken(TokenKind.TagStart));
                        this.mode = LexerMode.EnterLabel;
                    }
                    else
                    {
                        AddToken(GetToken(TokenKind.Text));
                    }
                    break;
                }
                TokenKind tk;
                if (this.scanner.Read() == '+' || this.scanner.Read() == '-') //正负数符号识别
                {
                    if (Char.IsNumber(this.scanner.Read(1)) && 
                        (this.kind == TokenKind.Operator || this.kind == TokenKind.LeftParentheses))
                    {
                        tk = TokenKind.Number;
                    }
                    else
                    {
                        tk = TokenKind.Operator;
                    }
                }
                else
                {
                    tk = GetTokenKind(this.scanner.Read());
                }
                //if (this.kind == tk || (tk == TokenKind.Number && this.kind == TokenKind.TextData))
                if ((this.kind != tk || this.kind == TokenKind.LeftParentheses || this.kind == TokenKind.RightParentheses)
                    && (tk != TokenKind.Number || this.kind != TokenKind.TextData)
                    //&& (this.kind == TokenKind.Number && tk != TokenKind.Dot)
                    )
                //|| (this.kind != TokenKind.Number && tk == TokenKind.Dot)
                {
                    if (tk == TokenKind.Dot && this.kind == TokenKind.Number)
                    {

                    }
                    else
                    {
                        AddToken(GetToken(tk));
                    }
                }

            }
        }


        private TokenKind GetTokenKind()
        {
            return GetTokenKind(this.scanner.Read());
        }

        private TokenKind GetTokenKind(Char c)
        {
            if (this.mode != LexerMode.EnterLabel)
            {
                return TokenKind.Text;
            }
            switch (c)
            {
                case ' ':
                    return TokenKind.Space;
                case '(':
                    return TokenKind.LeftParentheses;
                case ')':
                    return TokenKind.RightParentheses;
                case '[':
                    return TokenKind.LeftBracket;
                case ']':
                    return TokenKind.RightBracket;

                case '0':
                case '1':
                case '2':
                case '3':
                case '4':
                case '5':
                case '6':
                case '7':
                case '8':
                case '9':
                    return TokenKind.Number;
                case '*':
                case '-':
                case '+':
                case '/':
                case '>':
                case '<':
                case '=':
                case '!':
                case '&':
                case '|':
                case '~':
                case '^':
                case '?':
                case '%':
                    return TokenKind.Operator;
                case ',':
                    return TokenKind.Comma;
                case '.':
                    return TokenKind.Dot;
                case '"':
                    return TokenKind.StringStart;
                case ';':
                    return TokenKind.Punctuation;
                default:
                    return TokenKind.TextData;
            }
        }

    }
}
