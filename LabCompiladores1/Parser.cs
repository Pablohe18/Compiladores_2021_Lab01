using System;
using System.Collections.Generic;
using System.Text;

namespace LabCompiladores1
{
    class Parser
    {
        public bool error = false;
        Scanner _scanner;
        Token _token;
        
        private void E()
        {
            switch (_token.Tag)
            {
                case TokenType.Numero:
                case TokenType.Resta:
                case TokenType.LParen:
                    T();
                    EP();
                    break;
                default:
                    break;
            }
        }

        private void EP()
        {
            switch (_token.Tag)
            {
                case TokenType.Suma:
                    Match(TokenType.Suma);
                    T();
                    EP();
                    break;
                case TokenType.Resta:
                    T();
                    EP();
                    break;
                case TokenType.RParen:
                case TokenType.EOF:
                    Match(TokenType.RParen);
                    break;
                default:
                    break;
            }
        }

        private void T()
        {
            switch (_token.Tag)
            {
                case TokenType.Numero:
                case TokenType.Resta:
                case TokenType.LParen:
                    G();
                    TP();
                    break;
                default:
                    break;
            }
        }

        private void TP()
        {
            switch (_token.Tag)
            {
                case TokenType.Multiplicacion:
                    Match(TokenType.Multiplicacion);
                    G();
                    TP();
                    break;
                case TokenType.Division:
                    Match(TokenType.Division);
                    G();
                    TP();
                    break;
                case TokenType.Suma:
                case TokenType.Resta:
                case TokenType.RParen:
                case TokenType.EOF:
                    Match(_token.Tag);
                    break;
                default:
                    break;
            }
        }

        private void G()
        {
            switch (_token.Tag)
            {
                case TokenType.Numero:
                    F();
                    break;
                case TokenType.Resta:
                    Match(TokenType.Resta);
                    F();
                    break;
                case TokenType.LParen:
                    F();
                    break;
                default:
                    break;
            }
        }

        private void F()
        {
            switch (_token.Tag)
            {
                case TokenType.Numero:
                    Match(TokenType.Numero);
                    break;
                case TokenType.LParen:
                    Match(TokenType.LParen);
                    E();
                    Match(TokenType.RParen);
                    break;
                default:
                    break;
            }
        }
        private void Match(TokenType tag)
        {
            if(_token.Tag == tag)
            {
                _token = _scanner.GetToken();
            }
            else
            {
                error = true;
            }
        }
        public bool Parse(string regexp)
        {
            _scanner = new Scanner(regexp + (char)TokenType.EOF);
            _token = _scanner.GetToken();
            if (_token.Tag == TokenType.err)
            {
                Console.WriteLine("ERROR EN ANALISIS LEXICO");
            }
            else
            {
                switch (_token.Tag)
                {
                    case TokenType.Numero:
                    case TokenType.Resta:
                    case TokenType.LParen:
                        E();
                        break;
                    default:
                        break;
                }
            }          
            return error;
            Match(TokenType.EOF);
        }
    }
}
