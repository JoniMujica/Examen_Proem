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
        static double[] cuenta = new double[2];

        static void Main(string[] args)
        {

            string[] datos = new string[2];
            bool[] condiciones = new bool[2];
            string[] Continentes = new string[] { "America", "Asia", "Europa", "Africa", "Oceania" };
            string[] Pagos = new string[] { "Debito", "Credito", "Efectivo", "Mercado pago", "Cheque", "Leliq" };

            SolicitarDias();
            condiciones[0] = ValidarContinente( ref datos , Continentes);
            condiciones[1] = ValidarContinente(ref datos, Pagos);
            string [][] lista = new string[][] { datos, Continentes, Pagos };
            Console.WriteLine("El valor de retorno de Continente es: {0} \ndatos guardados: {1}", condiciones[0], datos[0]);
            Console.WriteLine("El valor de retorno de Pagos es: {0} \ndatos guardados: {1}", condiciones[1], datos[1]);


            OperarCasos(lista, condiciones);

            Console.WriteLine("El monto total a pagar es: {0}", cuenta[0],cuenta[1]);

            Console.WriteLine("test {0}",lista[0][1]);
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
        static bool ValidarContinente(ref string [] datos, string [] Tipos)
        {
            int pos = (Tipos.Length <= 5) ? 0 : 1;
            Console.WriteLine("Escriba el {0}: " , (Tipos.Length <= 5) ? "continente donde desea viajar" : "tipo de pago con que desea abonar");
            string dato = Console.ReadLine().Trim();
            
            for (int i = 0; i < Tipos.Length; i++)
            {
                if (!string.IsNullOrEmpty(dato))
                {
                    dato = char.ToUpper(dato[0]) + dato.Substring(1).ToLower();
                    datos[pos] = dato;
                    if (Tipos[i] == dato)
                    {
                        //datos[pos] = dato;
                        return true;
                    }
                }
                else
                {
                    Console.WriteLine("Error: Este campo no puede estar vacio");
                    break;
                }
            }
            return false;
        }

        static void  OperarCasos(string [][] datos,bool [] condicion)
        {
            if (!string.IsNullOrEmpty(datos[0][0]) && !string.IsNullOrEmpty(datos[0][1]))
            {
                if (datos[0][0] == datos[1][0] )
                {
                    cuenta[0] = dias - dias * 0.15;
                }
                else if (datos[0][0] == datos[0][1] && datos[0][1] == datos[2][0]) 
                {
                    cuenta[0] = dias - dias * 0.15 - dias * 0.10;
                }
                
                if ((datos[0][0] == datos[1][3] || datos[0][0] == datos[1][4]) && (datos[0][1] == datos[2][2] || datos[0][1] == datos[2][3]))
                {
                    cuenta[0] = dias - dias * 0.30 - dias * 0.15;
                }
                else if (datos[0][0] == datos[1][3] || datos[0][0] == datos[1][4])
                {
                    cuenta[0] = dias - dias * 0.30;
                }
                else if (((datos[0][0] == datos[1][2])) && (datos[0][1] == datos[2][0]))
                {
                    cuenta[0] = dias - dias * 0.20 - dias * 0.15;
                }
                else if ((datos[0][0] == datos[1][2]) && (datos[0][1] == datos[2][3]))
                {
                    cuenta[0] = dias - dias * 0.20 - dias * 0.10;
                }
                else if ((datos[0][0] == datos[1][2]) && !condicion[1])
                {
                    cuenta[0] = dias - dias * 0.20 - dias * 0.05;
                }
                
                if (!condicion[0])
                {
                    cuenta[0] = dias + dias * 0.20;
                }

                if (!condicion[0] && datos[0][1] == datos[2][4])
                {
                    cuenta[0] = dias + dias * 0.15;
                }
            }

        }

        /*
        static bool ValidarPagos(ref string[] datos)
        {
            Console.WriteLine("Escriba el continente donde desea viajar: ");
            string pagos = Console.ReadLine().Trim();
            for (int i = 0; i < datos.Length; i++)
            {
                if (!string.IsNullOrEmpty(pagos))
                {
                    pagos = char.ToUpper(pagos[0]) + pagos.Substring(1).ToLower();
                    if (datos[i] == pagos)
                    {
                        datos[1] = pagos;
                        return true;
                    }
                }
                else
                {
                    Console.WriteLine("Error: Este campo no puede estar vacio");
                    break;
                }
            }
            return false;
        }*/
    }
}
