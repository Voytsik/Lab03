using System;

namespace Lab02.Exceptions
{
    class IllegalEmailException : Exception
    {
        public override string Message => "Некоректний email!";
    }
}