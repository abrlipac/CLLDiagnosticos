using System;

namespace Diagnosticos.Service.EventHandlers.Exceptions
{
    public class DiagnosticosDiagnosticoCreateCommandException : Exception
    {
        public DiagnosticosDiagnosticoCreateCommandException(string message) : base(message)
        {

        }
    }
}
