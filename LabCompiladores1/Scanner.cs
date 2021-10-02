using System;
using System.Collections.Generic;
using System.Text;

namespace LabCompiladores1
{
    public class Scanner
    {
        private string _regexp = "";
        private int _index = 0;
        private int _state = 0;
        private string _error = "";

        public Scanner(string regexp)
        {
            _regexp = regexp + (char)TokenType.EOF;
            _index = 0;
            _state = 0;
        }
        public Token GetToken()
        {
            Token result = new Token() { Value = (char)0 };
            bool tokenFound = false;
            while (!tokenFound)
            {
                char peek = _regexp[_index];
                switch (_state)
                {
                    case 0:

                        while(char.IsWhiteSpace(peek)){
                            _index++;
                            peek = _regexp[_index];
                        }

                        switch (peek)
                        {
                            case (char)TokenType.LParen:
                            case (char)TokenType.RParen:
                            case (char)TokenType.Multiplicacion:
                            case (char)TokenType.Suma:
                            case (char)TokenType.Resta:
                            case (char)TokenType.Division:
                            case (char)TokenType.EOF:
                                tokenFound = true;
                                result.Tag = (TokenType)peek;
                                break;
                            default:
                                int valor;
                                bool esNumero = int.TryParse(peek.ToString(), out valor);
                                if (esNumero)
                                {
                                    tokenFound = true;
                                    result.Tag = TokenType.Numero;
                                    result.Value = peek;
                                }
                                else
                                {
                                    Console.WriteLine("Lex Error TOKEN NO RECONOCIDO: " + peek.ToString());
                                    result.Tag = TokenType.err;
                                    return result;
                                }
                                break;
                        }
                        _index++;
                        break;
                    default:
                        break;
                }//Switch
            }//While
            _state = 0;
            return result;
        }
    }
}
