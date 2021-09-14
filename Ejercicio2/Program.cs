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

        static string[] Continentes = new string[] { "America", "Asia", "Europa", "Africa", "Oceania" };
        static string[] Pagos = new string[] { "Débito", "Crédito", "Efectivo", "Mercado Pago", "Cheque", "Leliq" };

        static void Main(string[] args)
        {

            string[] datos = new string[2];

            bool ContinenteValido = ValidarContinente( ref datos);
            Console.WriteLine("El valor de retorno de Continente es: {0} \n datos guardados: {1}",ContinenteValido,datos[0]);
        }

        static bool ValidarContinente(ref string [] datos)
        {
            Console.WriteLine("Escriba el continente donde desea viajar: ");
            string continente = Console.ReadLine().Trim();
            

            for (int i = 0; i < Continentes.Length; i++)
            {
                if (!string.IsNullOrEmpty(continente))
                {
                    continente = char.ToUpper(continente[0]) + continente.Substring(1).ToLower();
                    if (Continentes[i] == continente)
                    {
                        datos[0] = continente;
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
    }
}
