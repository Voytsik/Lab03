using System;

namespace Lab02.Exceptions
{
    class IsNotBirthException : Exception
    {
        public override string Message => "Ви ще не народилися!";
    }
}