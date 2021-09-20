using System;

namespace Ejercicio5
{
    class Program
    {

        /*
         * 
         * Realizar el algoritmo que permita ingresar el nombre de un estudiante, la edad
            (validar) , el sexo (validar) y la nota del final (validar) hasta que el usuario quiera e
            informar al terminar el ingreso por consola:
            a. La cantidad de varones aprobados
            b. El promedio de notas de los menores de edad
            c.
         */
        static void Main(string[] args)
        {
            //[0] sexo [1] nombres de alumnos [2] edad de aloumnos en string [3] sexo del alumno
            double[] lista = new double[18];
            string[][] listaSexo = new string[][]
            {
                new string[] { "varon", "mujer" },
                new string[1]
            };
            /*
             * 
            0 edad
            1 nota
            2 varones aprobados

            3 sumatoria notas Menores;
            4 CantidadMenores;
            5 promedioNotas menores de edad
            
            6 sumatoria adolecentes
            7 cantidadAdolecentes
            8 Promedio Notas Adolecentes

            9 sumatoria mayores
            10 cantidadMayores
            11 promedio nota mayores

            12 sumatoria Varon
            13 cantidadVaron
            14 PromedioVaron

            15 SumatoriaMujer
            16 CantidadMujer
            17 Promedio Mujer
            */
            CargarDatos(ref lista ,ref listaSexo);
            Console.WriteLine("Cantidad de varones aprobados: {0}",lista[2]);
            Console.WriteLine("Promedio de notas de los menores de edad: {0}",lista[5]);
            Console.WriteLine("Promedio de notas adolecentes: {0}",lista[8]);
            Console.WriteLine("Promedio de notas mayores: {0}",lista[11]);
            Console.WriteLine("Promedio de notas varones: {0}",lista[14]);
            Console.WriteLine("Promedio de notas mujeres: {0}",lista[17]);
        }
        static void CargarDatos(ref double[] vec ,ref string[][] sexo)
        {
            bool noVacio = false;
            //int dato = 0;
            string nombre;
            do
            {

            
                Console.WriteLine("Escriba el nombre del alumno: ");
                do
                {
                    nombre = Console.ReadLine();
                    if (string.IsNullOrEmpty(nombre))
                    {
                        Console.WriteLine("error: los valores son incorrectos, escriba el nombre del alumno");
                    }

                } while (string.IsNullOrEmpty(nombre));

                Console.WriteLine("Escriba la edad del alumno: ");
                do
                {
                    noVacio = Double.TryParse(Console.ReadLine(), out vec[0]);
                    if (!noVacio || vec[0] < 0)
                    {
                        Console.WriteLine("ERROR: los datos ingresados no son validos,escriba un numero mayor a 0");
                    }
                } while (!noVacio || vec[0] < 0);

                Console.WriteLine("Escriba el sexo del alumno: ");
                do
                {
                    sexo[1][0] = Console.ReadLine();
                    if (string.IsNullOrEmpty(sexo[1][0]) || !ValidarSexo(sexo, sexo[1][0]))
                    {
                        noVacio = false;
                        Console.WriteLine("ERROR: los datos del sexo son incorrectos, intente nuevamente [Hombre,Mujer]");
                    }
                } while (!noVacio || string.IsNullOrEmpty(sexo[1][0]));

                Console.WriteLine("Escriba la nota final del alumno: ");
                do
                {
                    noVacio = Double.TryParse(Console.ReadLine(), out vec[1]);
                    if (!noVacio || vec[1] < 0)
                    {
                        Console.WriteLine("ERROR: los datos ingresados son invalidos,escriba la nota entre 0 y 10");
                    }
                } while (!noVacio || vec[1] < 0 || vec[1] > 10);


                Operar(ref vec,ref sexo);

                Console.WriteLine("¿Desea continuar?");
                string continua = Console.ReadLine();
                noVacio = string.IsNullOrEmpty(continua);
                 Console.Clear();
            } while (!noVacio);

        }
        static void Operar(ref double[] listNum,ref string[][] sexo)
        {
            if (sexo[1][0] == sexo[0][0] && listNum[1] >=6 )
            {
                listNum[2]++;
            }
            if (listNum[0] < 13)
            {
                listNum[3] += listNum[1];
                listNum[4]++;
                listNum[5] = listNum[3] / listNum[4];
            }
            if (listNum[0] >= 13 && listNum[0] <18)
            {
                listNum[6] += listNum[1];
                listNum[7]++;
                listNum[8] = listNum[6] / listNum[7];
            }
            if (listNum[0] >= 18)
            {
                listNum[9] += listNum[1];
                listNum[10]++;
                listNum[11] = listNum[9] / listNum[10];
            }
            if (sexo[1][0] == sexo[0][0])
            {
                listNum[12] += listNum[1];
                listNum[13]++;
                listNum[14] = listNum[12] / listNum[13];
            }
            else if (sexo[1][0] == sexo[0][1])
            {
                listNum[15] += listNum[1];
                listNum[16]++;
                listNum[17] = listNum[15] / listNum[16];
            }

        }

        static bool ValidarSexo(string[][]sexo,string dato)
        {
            for (int i = 0; i < sexo[0].Length; i++)
            {
                if (dato == sexo[0][i])
                    return true;
            }
            return false;
        }
    }
}
