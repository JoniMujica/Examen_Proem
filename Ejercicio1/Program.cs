using System;

namespace Ejercicio1
{
    class Program
    {
        /*
         1. Pedir dos números por consola y mostrar el resultado:
            a. Si son iguales muestro el cuadrado del número.
            b. Si el primero es divisible por el segundo, los resto, de lo contrario muestro
            solo el resto.
            c. si el resto es mayor a 3(tres ) informar por consola.
         */
        static void Main(string[] args)
        {
            double[] numeros = new double[2];
            ValidarNumero(ref numeros);
            Casos(numeros);
        }

        static void ValidarNumero(ref double [] nums)
        {
            for (int i = 0; i < nums.Length; i++)
            {
                Console.WriteLine("Ingrese el {0}{1} numero: ", (i + 1), (i == 0) ? "er" : "do");
                bool conv = false;
                do
                {
                    conv = Double.TryParse(Console.ReadLine(), out nums[i]);
                    if (!conv)
                    {
                        Console.WriteLine("ERROR: el valor ingresado es incorrecto, ingrese un valor numerico:");
                    }
                } while (!conv);
            }
        }
        static void Casos(double [] nums)
        {
            if (nums[0] == nums[1])
                Console.WriteLine("Lo numeros son iguales, valor numerico al cuadrado: {0}",nums[1]*nums[1]);


            Console.WriteLine("El valor {0} es {1}", (nums[0] % nums[1] == 0) ? "de la Resta" : "del Resto", (nums[0] % nums[1] == 0) ? (nums[0] - nums[1]) : nums[0] % nums[1]);

            if (nums[0] % nums[1] > 3)
                Console.WriteLine("El resto de los numeros es mayor a 3");
        }
    }
}
