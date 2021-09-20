using System;

namespace Ejercicio4
{
    class Program
    {

        /*
         Realizar el algoritmo que permita iterar el ingreso de dos datos de un vehiculo, un
        color (rojo verde o amarillo) y un valor entre 0 y 10000 hasta que el usuario quiera e
        informar al terminar el ingreso por consola:
        a. La cantidad de rojos
        b. La cantidad de rojos con precio mayor a 5000
        c. La cantidad de vehículos con precio inferior a 5000
        d. El promedio de todos los vehículos ingresados.
        e. El más caro y su color.
         
         */
        static void Main(string[] args)
        {
            double[] lista = new double[9];
            string[][] listaCol = new string[][]
            {
                new string[] { "rojo", "verde", "amarillo" },
                new string[1]
            };

            /*
             * var
             c rojo
             c rojo & p>5000
             c < 5000
             sumatoria
             cantidad
            promedio
            caro
            pos caro
             */

            Solicitar(ref lista, ref listaCol);
            Console.WriteLine("La cantidad de audos rojos es: {0}",lista[1]);
            Console.WriteLine("La cantidad de rojos con precio mayor a 5000 es: {0}",lista[2]);
            Console.WriteLine("La cantidad de autos con precio menor a 5000 es: {0}",lista[3]);
            Console.WriteLine("El promedio de los autos es: {0}",lista[6]);
            Console.WriteLine("El auto mas caro es {0} y es de color {1}",lista[8],listaCol[1][0]);
        }
        static void Solicitar(ref double[] lista, ref string[][] listaCol) {

            bool noVacio = false;
            string color;
            int pos = 1;
            do
            {
                Console.WriteLine("Ingrese el color del auto n°{0}",pos);
                do
                {
                    color = Console.ReadLine();
                    if (string.IsNullOrEmpty(color) || !ColorValido(listaCol, color))
                    {
                        Console.WriteLine("error: los valores son incorrectos, escriba uno de los siguientes colores [rojo,verde,amarillo]");
                    }
                } while (string.IsNullOrEmpty(color) || !ColorValido(listaCol, color));


                Console.WriteLine("Ingrese un valor de 0 a 10000 del auto numero n°{0}",pos);
                do
                {
                    noVacio = Double.TryParse(Console.ReadLine(), out lista[0]);
                    if (!noVacio || !ValidarNumero(lista[0]))
                    {
                        Console.WriteLine("error: los valores son incorrectos, escriba precios de 0 al 10000");
                    }

                } while (!noVacio || !ValidarNumero(lista[0]));

                if (lista[0] >= lista[7])
                {
                    lista[7] = lista[0];
                    lista[8] = pos;
                    listaCol[1][0] = color;
                }
                

                Operar(ref lista , ref listaCol, color);

                Console.WriteLine("\n\nDesea continuar agregando? [Presione cualquier tecla para continuar, ENTER para salir]");
                pos++;
                string continua = Console.ReadLine();
                noVacio = string.IsNullOrEmpty(continua);
                Console.Clear();
            } while (!noVacio);
        }
        static void Operar(ref double [] listaNums,ref  string[][] listaCol, string color)
        {
            if (color == listaCol[0][0] && listaNums[0] >= 5000)
            {
                listaNums[1]++;
                listaNums[2]++;
            }else if (color == listaCol[0][0])
            {
                listaNums[1]++;
            }

            if (listaNums[0]<5000)
            {
                listaNums[3]++;
            }

            listaNums[4] += listaNums[0];
            listaNums[5]++;
            listaNums[6] = listaNums[4] / listaNums[5];

            
        }
        static bool ColorValido(string[][] listaCol,string dato)
        {
            for (int i = 0; i < listaCol[0].Length; i++)
            {
                if (dato == listaCol[0][i])
                    return true;
            } 
            return false;
        }

        static bool ValidarNumero(double dato)
        {
            if (dato > 0 && dato < 10000)
                return true;

            return false;
        }
    }
}
