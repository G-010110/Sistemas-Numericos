using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Policy;
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
            int cociente=0;
            string resultado = "";
            resultado = (numero == 0) ? "0":"";
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

        public static string decimalFraccionToBinaria(float numero)
        {
            string r = decimalToBinaria((int)numero);
            if ((numero - (int)Math.Truncate(numero))==0.0)
            {
                //Es entero
            } else
            {
                //Es fraccionario
                r = fraccionToBinaria(numero,r);
            }
            return r;
        }

        public static string fraccionToBinaria(float numero, string r)
        {
            r += ".";
            float fraccionaria = numero - (float)Math.Truncate(numero);
            //fraccion de hasta que llegue a cero o maximo 10 digitos
            for (int i = 0; i < 10; i++)
            {
                numero = fraccionaria * 2;
                fraccionaria = numero%1;
                r += Math.Truncate(numero);
                if (fraccionaria == 0)
                {
                    break;
                }
            }
            return r;
        }



        public static string binariaToDecimal(string numero)
        {
            int l = (numero.Length);
            int resultado = 0;
            if(numero == "0") { return "0"; };
            for (int i = 0; i < numero.Length; i++)
            {
                l--;
                resultado += (int)Char.GetNumericValue(numero[i]) * (int)Math.Pow(2, l);
            }

            return resultado + "";
        }

        public static string fraccionbinariaToDecimal(string numero)
        {
            //se coloca solo la parte entera
            //int f = int.Parse(numero) % 1;
            string entero="";
            string fraccion = "";
            int condicion = numero.IndexOf(".");
            if (condicion != -1)
            {
                //Es fraccionario
                entero = binariaToDecimal(numero.Substring(0,condicion));
                fraccion = binariaToDecimal(numero.Substring(condicion+1,numero.Length-(condicion+1)));
                entero += ".";
            }
            else
            {
                //Es entero
                entero = binariaToDecimal(numero);
            }
            return entero+fraccion;
        }

        public string fraccionbinarioToOctal(string numero)
        {
            string entero = "";
            string fraccion = "";
            int condicion = numero.IndexOf(".");
            if (condicion != -1)
            {
                //Es fraccionario
                entero = binarioToOctal(numero.Substring(0, condicion));
                fraccion = binarioToOctal(numero.Substring(condicion + 1, numero.Length - (condicion + 1)));
                entero += ".";
            }
            else
            {
                //Es entero
                entero = binarioToOctal(numero);
            }
            return entero + fraccion;
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