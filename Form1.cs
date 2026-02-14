using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
/*using es como el import en java
 para usar una clase de otro paquete se debe de importar 
la ubicacion del archivo*/
using ConvertidorSistematico.Logica;

namespace ConvertidorSistematico
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            
            InitializeComponent();
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            //extraer datos del campo de texto
            /*a diferencia de java .getText(), en c# se ocupa .Text*/

            //switch con patrones, solo disponible en c# 8
            switch (comboBox1.SelectedIndex)
            {
                //Decimal a decimal
                case 0 when comboBox2.SelectedIndex == 0:
                    
                    break;
                //decimal a octal
                case 0 when comboBox2.SelectedIndex == 1:
                    resultado.Text = LogicaOctal.decimalToOctal(int.Parse(campo1.Text));
                    break;
                //octal a octal
                case 1 when comboBox2.SelectedIndex == 1:
                    break;
                //octal a decimal 
                case 1 when comboBox2.SelectedIndex == 0:
                    resultado.Text = LogicaOctal.octalToDecimal(campo1.Text);
                    break;
                //octal a binario 
                case 1 when comboBox2.SelectedIndex == 2:
                    resultado.Text = LogicaOctal.octalToBinario(campo1.Text);
                    break;
                ////////////////////////////////////////////
                //Decimal a binario
                case 0 when comboBox2.SelectedIndex == 2:
                    resultado.Text = LogicaBinaria.decimalToBinaria(int.Parse(campo1.Text));
                    break;
                //Binario a decimal 
                case 2 when comboBox2.SelectedIndex == 0:
                    resultado.Text = LogicaBinaria.binariaToDecimal(campo1.Text);
                    break;
                //Binario a octal
                case 2 when comboBox2.SelectedIndex == 1:
                    LogicaBinaria lb = new LogicaBinaria();
                    resultado.Text = lb.binarioToOctal(campo1.Text);
                    break;
                default:
                    MessageBox.Show("Ingresa el sistema numerico I/O","Advertencia");
                    break;
            }    
        }

        private void button1_Click(object sender, EventArgs e)
        {
            resultado.Text = LogicaOctal.octalToDecimal(campo1.Text); 
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void resultado_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
