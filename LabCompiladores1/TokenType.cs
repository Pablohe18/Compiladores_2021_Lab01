using System;
using System.Collections.Generic;
using System.Text;

namespace LabCompiladores1
{
    public enum TokenType
    {
        Multiplicacion = '*',
        Suma = '+',
        LParen = '(',
        RParen = ')',
        Resta = '-',
        Division = '/',
        EOF = (char)0,
        Empty = (char)1,
        Numero = (char)3
    }
}
