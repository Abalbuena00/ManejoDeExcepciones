using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManejoDeExcepciones
{
    public class Calculadora
    {
        private double numero1 ;
        private double numero2;

        public Calculadora(double numero1, double numero2)
        {
            this.numero1 = numero1;
            this.numero2 = numero2;
        }

        public double Sumar()
        {
            return numero1 + numero2;
        }

        public double Restar()
        {
            return numero1 - numero2;
        }

        public double Multiplicar()
        {
            return numero1 * numero2;
        }

        public double Dividir()
        {
            if (numero2 == 0)
            {
                throw new DivideByZeroException("No se puede dividir entre cero.");
            }
            return numero1 / numero2;
        }
    }
}
