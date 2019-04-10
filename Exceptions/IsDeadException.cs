using System;

namespace Lab02.Exceptions
{
    class IsDeadException : Exception
    {
        public override string Message => "Вам дійсно більше 135 років?";
    }
}