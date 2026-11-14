
using System;

namespace ManejoDeExcepciones
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MostrarMenu();
        }

        public static void MostrarMenu()
        {
            while (true)
            {
                Console.Clear();    

                Console.WriteLine("\n===== MENÚ =====");
                Console.WriteLine("1. Sumar");
                Console.WriteLine("2. Restar");
                Console.WriteLine("3. Multiplicar");
                Console.WriteLine("4. Dividir");
                Console.WriteLine("5. Salir");
                Console.WriteLine("=================");

                Console.Write("Seleccione una opción: ");
                string opcion = Console.ReadLine() ?? "";

                try
                {
                    switch (opcion)
                    {
                        case "1":
                            RealizarOperacion("+");
                            break;
                        case "2":
                            RealizarOperacion("-");
                            break;
                        case "3":
                            RealizarOperacion("*");
                            break;
                        case "4":
                            RealizarOperacion("/");
                            break;
                        case "5":
                            Console.WriteLine("Saliendo del programa...");
                            return;
                        default:
                            throw new OperacionInvalidaException("Opción no válida.");
                    }
                }
                catch (OperacionInvalidaException ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
                finally
                {
                    Console.WriteLine("Ejecución finalizada.");
                }

                Console.WriteLine("\nPresione cualquier tecla para continuar...");
                Console.ReadKey();
            }
        }

        public static void RealizarOperacion(string operacion)
        {
            try
            {
                int numero1 = LeerNumero("Ingrese el primer número: ");
                int numero2 = LeerNumero("Ingrese el segundo número: ");

                Calculadora calculadora = new Calculadora(numero1, numero2);

                double resultado = 0;

                switch (operacion)
                {
                    case "+":
                        resultado = calculadora.Sumar();
                        break;
                    case "-":
                        resultado = calculadora.Restar();
                        break;
                    case "*":
                        resultado = calculadora.Multiplicar();
                        break;
                    case "/":
                        resultado = calculadora.Dividir();
                        break;
                    default:
                        throw new OperacionInvalidaException("Operación no válida.");
                }

                Console.WriteLine("Resultado: " + resultado);
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                Console.WriteLine("Operación terminada.");
            }
        }

        public static int LeerNumero(string mensaje)
        {
            while (true)
            {
                try
                {
                    Console.Write(mensaje);
                    return int.Parse(Console.ReadLine() ?? "");
                }
                catch (FormatException)
                {
                    Console.WriteLine("Error: Debe ingresar un número entero.");
                }
                catch (OverflowException)
                {
                    Console.WriteLine("Error: Número fuera del rango permitido.");
                }
            }
        }
    }
}
