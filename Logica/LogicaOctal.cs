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

        public static string octalToDecimal(string numero)
        {
            int l = (numero.Length);
            int resultado = 0;
            for (int i = 0; i < numero.Length; i++)
            {
                l--;
                resultado += (int)Char.GetNumericValue(numero[i]) *(int)Math.Pow(8,l);
            }

            return resultado+"";
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
