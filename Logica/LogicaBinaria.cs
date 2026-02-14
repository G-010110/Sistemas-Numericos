using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConvertidorSistematico.Logica
{
    internal class LogicaBinaria
    {
        //Atributos 
        //diccionario con indices de equivalentes binarios de numeros octales
        private Dictionary<string, string> equivalentes = new Dictionary<string, string>()
        {
            //equivalentes.Add("clave","valor");
            //clave, valor
            {"000","0"},
            {"001","1"},
            {"010","2"},
            {"011","3"},
            {"100","4"},
            {"101","5"},
            {"110","6"},
            {"111","7"}
        };
        
        //Metodos 
        public static string decimalToBinaria(int numero)
        {
            int cociente;
            string resultado = "";

            while (numero > 0)
            {
                //flujo
                cociente = numero / 2;
                resultado = (numero % 2) + resultado;
                //area comodar 
                numero = cociente;
            }
            return resultado;
        }

        public static string binariaToDecimal(string numero)
        {
            int l = (numero.Length);
            int resultado = 0;
            for (int i = 0; i < numero.Length; i++)
            {
                l--;
                resultado += (int)Char.GetNumericValue(numero[i]) * (int)Math.Pow(2, l);
            }

            return resultado + "";
        }

        public string binarioToOctal(string numero)
        {
            string r = "";
            //verifica si el residuo es cero "osea si el numero al dividir entre 3 da un numero entero"
            if(numero.Length%3 == 0 )
            {
                r = CalculaBtO(numero);
            //sino, intentar rellenar con ceros 
            } else
            {
                while(true)
                {
                    numero = "0" + numero;
                    if(numero.Length%3 == 0)
                    {
                        r = CalculaBtO(numero);
                        break;
                    }
                } 
            }

                return r;
        }

        public string CalculaBtO(string n)
        {
            string r = "",p="";
            //Encapsular de derecha a izquierda en grupos de 3 bits
            for (int i = 0; i <= n.Length - 1; i+=3)
            {
                p = n.Substring(i, 3);
                r += equivalentes[p];
                p = "";
            }
            return r;
        }
    }
}