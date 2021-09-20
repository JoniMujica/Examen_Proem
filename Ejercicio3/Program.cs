using System;

namespace Ejercicio3
{
    class Program
    {
        /*
         Realizar el algoritmo que permita el ingreso de 10 bolsas de alimento para
        mascotas, con los kilos (validar entre 0 y 500) , sabor validar (carne vegetales pollo)
        e informar por consola:
        a. El promedio de los kilos totales.
        b. La bolsa más liviana y su sabor
        c. La cantidad de bolsas sabor carne y el promedio de kilos de sabor carne
         
         */
        static void Main(string[] args)
        {
            string[][] lista = new string[][]
            {
                // [0] va los kilos, [1] los sabores , [2] los sabores ingresador por consola
                new string[10],
                new string[] { "carne", "vegetales", "pollo" },
                new string[10],
            };
            PedirDatos(ref lista);
            Operar(lista);
        }

        static void Operar(string[][] Lista)
        {
            int cantidadDeCarne = 0;
            double promedio = Promedio(Lista , ref cantidadDeCarne,false);
            int liviana = BolsaLiviana(Lista[0]);
            double PromedioCarne = Promedio(Lista,ref cantidadDeCarne,true);
            //Console.Clear();
            Console.WriteLine("Promedio de los kilos totales {0}", promedio);
            Console.WriteLine("La bolsa mas liviana es la n°{0} y su sabor es {1}", (liviana + 1), Lista[2][liviana]);
            Console.WriteLine("La cantidad de bolsas de carne son {0} y su promedio en peso es {1}",cantidadDeCarne,PromedioCarne);

            Console.ReadKey();
        }

        static double Promedio(string[][] vec ,ref int cantidadC, bool EsCarne)
        {
            double res = 0;

            for (int i = 0; i < vec[0].Length; i++)
            {
                if (!EsCarne)
                {
                    res += Int32.Parse(vec[0][i]);
                }
                else if (vec[2][i] == "carne")
                {
                    res += Int32.Parse(vec[0][i]);
                    cantidadC++;
                }
            }
            return (!EsCarne) ? (res/vec[0].Length):(res/cantidadC);
        }
        static int BolsaLiviana(string[] vec)
        {
            int pos = 0;
            int liv = Int32.MaxValue;
            for (int i = 0; i < vec.Length; i++)
            {
                int num = Int32.Parse(vec[i]);
                if (num < liv)
                {
                    liv = num;
                    pos = i;
                }
            }
            return pos;
        }
        static void PedirDatos(ref string [][] vec)
        {
            for (int i = 0; i < vec[0].Length; i++)
            {
                bool[] condicion = new bool[3];
                int kilos = 0;
                do
                {
                    Console.WriteLine("Ingrese la cantidad de kilos que desea en la bolsa {0}",(i+1));
                    condicion[0] = Int32.TryParse(Console.ReadLine(),out (kilos));
                    condicion[1] = ValidarKilos(kilos);
                    Console.WriteLine("Ingrese el sabor que desea en la bolsa:");
                    string sabor = Console.ReadLine().Trim().ToLower();
                    if (condicion[2] = ValidarSabor(sabor) && condicion[1])
                    {
                        vec[0][i] = kilos.ToString(); //vuelvo a convertir para validar lo que se envio sea un numero y no cualquier cosa
                        vec[2][i] = sabor;
                    }
                    else
                    {
                        Console.WriteLine("ERROR: los datos ingresados son incorrectos:");
                    }
                } while (!condicion[0] || !condicion[1] || !condicion[2]);
            }
        }
        static bool ValidarSabor(string dato) {

            switch (dato)
            {
                case "carne":
                case "vegetales":
                case "pollo":
                    return true;
            }
            return false;
        }
        static bool ValidarKilos(int kilos)
        {
            if (kilos > 0 && kilos < 500)
                return true;

            return false;
        }
    }
}
