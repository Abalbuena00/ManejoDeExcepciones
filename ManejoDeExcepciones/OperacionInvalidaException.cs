
using System;

namespace ManejoDeExcepciones
{
    public class OperacionInvalidaException : Exception
    {
        public OperacionInvalidaException(string mensaje) : base(mensaje)
        {
        }
    }
}
