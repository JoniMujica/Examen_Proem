using System;

namespace Ejercicio2
{
    class Program
    {
        /*
         Una empresa de viajes le solicita ingresar que continente le gustaría visitar y la
        cantidad de días , la oferta dice que por día se cobra $100 , que se puede pagar de
        todas las maneras:
        a. Crear un método que valide continentes: recibe un continente y retorna true
        si se trata de un continente válido (América, Asia, Europa, Africa, Oceanía).
        Crear un método que valide forma de pago: recibe la forma de pago y retorna
        true si se trata de una forma de pago válido (Débito, Crédito, Efectivo,
        Mercado Pago, Cheque, Leliq)
        b. Si es América tiene un 15% de descuento y si además paga por débito se le
        agrega un 10% más de descuento
        c. Si es África u Oceanía tiene un 30% de descuento y si además paga por
        mercadoPago o efectivo se le agrega un 15% más de descuento
        d. Si es Europa tiene un 20% de descuento y si además paga por débito se le
        agrega un 15% , por mercadoPago un 10% y cualquier otro medio 5%
        e. cualquier otro continente tiene un recargo del 20%
        f. en cualquier continente , si paga con cheque, se recarga un 15% de
        impuesto al cheque      
         */
        static double dias;
        static int idx = 1;
        static void Main(string[] args)
        {
            // en [0] van los datos ingresados, en [1] los continentes, en [2] los tipos de pagos, en [3] el resultado de operacion en string
            string[][] lista = new string[][]
            {
                new string[2],
                new string[] { "America", "Asia", "Europa", "Africa", "Oceania" },
                new string[] { "Debito", "Credito", "Efectivo", "Mercadopago", "Cheque", "Leliq" },
                new string[3]
            };
            bool[] condiciones = new bool[2];
            SolicitarDias();
            condiciones[0] = ValidarContinente( ref lista);
            condiciones[1] = ValidarContinente(ref lista);

            OperarCasos(ref lista, condiciones);
            Console.Clear();
            Console.WriteLine("Usted solicito {0} dias con destino a {1} y tipo de pago {2}",dias/100,lista[0][0],lista[0][1]);
            Console.WriteLine("Bono continente: {0}$\nBono tipo de pago:{1}$\nTotal a pagar: {2}$",lista[3][0],lista[3][1],lista[3][2]);
            Console.ReadKey();
        }

        static void SolicitarDias()
        {
            bool cnv = false;
            Console.WriteLine("Ingrese la cantidad de dias que desea viajar: ");
            do
            {
                cnv = Double.TryParse(Console.ReadLine(), out (dias));
                if (cnv)
                {
                    dias = dias * 100;
                }
                else
                {
                    Console.WriteLine("ERROR: el valor ingresado es incorrecto");
                }
            } while (!cnv);
        }
        static bool ValidarContinente(ref string [][] datos)
        {
            int pos = (datos[idx].Length <= 5) ? 0 : 1;
            Console.WriteLine("Escriba el {0}: " , (datos[idx].Length <= 5) ? "continente donde desea viajar" : "tipo de pago con que desea abonar");
            string dato = Console.ReadLine().Trim();
            
            for (int i = 0; i < datos[idx].Length; i++)
            {
                if (!string.IsNullOrEmpty(dato))
                {
                    dato = char.ToUpper(dato[0]) + dato.Substring(1).ToLower();
                    datos[0][pos] = dato;
                    if (datos[idx][i] == dato)
                    {
                        idx++;
                        if (idx > 2) idx = 1;
                        return true;
                    }
                }
                else
                {
                    Console.WriteLine("Error: Este campo no puede estar vacio");
                    break;
                }
            }
            idx++;
            return false;
        }

        static void  OperarCasos(ref string [][] datos,bool [] condicion)
        {
            //[0] descuento por continente [1] descuento por pagos [3] pago total
            double[] calculados = new double[3];

            if (!string.IsNullOrEmpty(datos[0][0]) && !string.IsNullOrEmpty(datos[0][1]))
            {
                if (datos[0][0] == datos[1][0] && datos[0][1] == datos[2][0]) //Si es América tiene un 15% de descuento y si además paga por débito
                {
                    calculados[0] = dias * 0.15;
                    calculados[1] = dias * 0.10;
                    calculados[2] = dias - dias * 0.15 - dias * 0.10;
                }
                else if (datos[0][0] == datos[1][0]) // Si es América tiene un 15 % de descuento
                {
                    calculados[0] = dias * 0.15;
                    calculados[2] = dias - dias * 0.15;
                }
                if ((datos[0][0] == datos[1][3] || datos[0][0] == datos[1][4]) && (datos[0][1] == datos[2][2] || datos[0][1] == datos[2][3])) //Si es África u Oceanía tiene un 30% de descuento y si además paga por mercadoPago o efectivo
                {
                    calculados[0] = dias * 0.30;
                    calculados[1] = dias * 0.15;
                    calculados[2] = dias - dias * 0.30 - dias * 0.15;
                }
                else if (datos[0][0] == datos[1][3] || datos[0][0] == datos[1][4]) ////Si es África u Oceanía tiene
                {
                    calculados[0] = dias * 0.30;
                    calculados[2] = dias - dias * 0.30;
                }
                if ((datos[0][0] == datos[1][2]) && (datos[0][1] == datos[2][0])) //Si es Europa tiene un 20% de descuento y si además paga por débito se le agrega un 15 %
                {
                    calculados[0] = dias * 0.20;
                    calculados[1] = dias * 0.15;
                    calculados[2] = dias - dias * 0.20 - dias * 0.15;
                }
                else if ((datos[0][0] == datos[1][2]) && (datos[0][1] == datos[2][3])) //Si es Europa tiene un 20% de descuento y si además paga por mercadoPago un 10%
                {
                    calculados[0] = dias * 0.20;
                    calculados[1] = dias * 0.10;
                    calculados[2] = dias - dias * 0.20 - dias * 0.10;
                }
                else if ((datos[0][0] == datos[1][2]) && ((datos[0][1] != datos[2][0] && datos[0][1] !=  datos[2][3]) || !condicion[1])) //cualquier otro medio 5%
                {
                    calculados[0] = dias * 0.20;
                    calculados[1] = dias * 0.05;
                    calculados[2] = dias - dias * 0.20 - dias * 0.05;
                }   
                if (!condicion[0]) //cualquier otro continente tiene un recargo del 20%
                {
                    calculados[0] = dias * 0.20;
                    calculados[2] = dias + dias * 0.20;
                }
                if (datos[0][1] == datos[2][4]) //en cualquier continente , si paga con cheque, se recarga un 15% de impuesto al cheque
                {
                    calculados[1] += dias * 0.15;
                    calculados[2] += dias * 0.15;
                }

                // con esto convierto a string
                for (int i = 0; i < calculados.Length; i++)
                {
                    datos[3][i] = calculados[i].ToString();
                }
            }

        }
    }
}