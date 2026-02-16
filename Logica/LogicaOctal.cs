using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;

namespace ConvertidorSistematico.Logica
{
    internal class LogicaOctal
    {
        //Equivalentes octales de binarios de 3 bits, valores respectivamente agrupados al indice del arreglo
        private static string[] equivalente = {"000","001","010","011","100","101","110","111"};
       
        public static string decimalToOctal(int numero)
        {
            int cociente;
            string resultado="";
            resultado = (numero == 0) ? "0" : "";
            while (numero>0)
            {
                //flujo
                cociente = numero / 8;
                resultado =(numero%8)+resultado;
                //area comodar 
                numero = cociente;
            }
            return resultado;
        }



        public static string decimalFraccionToOctal(float numero)
        {
            string r = decimalToOctal((int)numero);
            if ((numero - (int)Math.Truncate(numero)) == 0.0)
            {
                //Es entero
            }
            else
            {
                //Es fraccionario
                r = fraccionToOctal(numero, r);
            }
            return r;
        }

        public static string fraccionToOctal(float numero, string r)
        {
            r += ".";
            float fraccionaria = numero - (float)Math.Truncate(numero);
            //fraccion de hasta que llegue a cero o maximo 10 digitos
            for (int i = 0; i < 10; i++)
            {
                numero = fraccionaria * 8;
                fraccionaria = numero % 1;
                r += Math.Truncate(numero);
                if (fraccionaria == 0)
                {
                    break;
                }
            }
            return r;
        }

        public static string octalToDecimal(string numero)
        {
            int l = (numero.Length);
            float resultado = 0;
            for (int i = 0; i < numero.Length; i++)
            {
                l--;
                resultado += (int)Char.GetNumericValue(numero[i]) *(int)Math.Pow(8,l);
            }

            return resultado+"";
        }

        public static string fraccionoctalToDecimal(string numero)
        {
            //se coloca solo la parte entera
            //int f = int.Parse(numero) % 1;
            string entero = "";
            string fraccion = "";
            int condicion = numero.IndexOf(".");
            if (condicion != -1)
            {
                //Es fraccionario
                entero = octalToDecimal(numero.Substring(0, condicion));
                fraccion = octalToDecimal(numero.Substring(condicion + 1, numero.Length - (condicion + 1)));
                entero += ".";
            }
            else
            {
                //Es entero
                entero = octalToDecimal(numero);
            }
            return entero + fraccion;
        }
        public static string fraccionoctalToBinario(string numero)
        {
            string entero = "";
            string fraccion = "";
            int condicion = numero.IndexOf(".");
            if (condicion != -1)
            {
                //Es fraccionario
                entero = octalToBinario(numero.Substring(0, condicion));
                fraccion = octalToBinario(numero.Substring(condicion + 1, numero.Length - (condicion + 1)));
                entero += ".";
            }
            else
            {
                //Es entero
                entero = octalToBinario(numero);
            }
            return entero + fraccion;
        }
        public static string octalToBinario(string numero)
        {
            string r = "";
            foreach(char l in numero)
            {
                r += equivalente[(int)Char.GetNumericValue(l)];
            }
            return r;
        }
    }
}
