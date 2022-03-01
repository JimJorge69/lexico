using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lexico
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            button2.Enabled = false;//Se inicia con el boton 2 que es de reinicio para evitar algun error
            button2.BackColor = Color.Red;//Se le coloca el color rojo al boton
        }

        private void button1_Click(object sender, EventArgs e)//Boton de inicio
        {
            if (textBox1.Text=="")//Valido que el campo de texto este vacio
            {
                MessageBox.Show("Campos Vacios","Alerta");
            }
            else//si no es vacio se inicia el analizador
            {
                dataGridView1.Rows.Clear();//vacio la tabla
                String entrada = textBox1.Text;//Decalro el texto ingresado en un string
                AnalizadorLexico lex = new AnalizadorLexico();//Se manda a llamar el objeto
                LinkedList<Token> ltokens = lex.escanear(entrada);//Se crea una lista con TOKEN y se ingresa en el objeto
                foreach (Token token in ltokens)//Se Ingresan todos los datos en la tabla
                {
                    dataGridView1.Rows.Add(token.Getval(), token.GetTipo(), token.GetID());
                }
                lex.imprimirListaToken(ltokens);//Se colocan los datos en la tabla
                button1.Enabled = false;//Desactivo el boton iniciar
                button1.BackColor = Color.Red;//Se coloca en color rojo el boton iniciar
                button2.Enabled = true;//Habilito el boton reiniciar
                button2.BackColor = Color.YellowGreen;//Se coloca en color verde el boton de reiniciar
                textBox1.Enabled = false;//Se desabilita el campo del texto para mejor experiencia de usuario
            }
        }

        private void button2_Click(object sender, EventArgs e)//Boton de reinicio
        {
            dataGridView1.Rows.Clear();//Se vacia la tabla
            textBox1.Text = "";//Se vacia el campo de texto
            button1.Enabled = true;//Habilita el boton de iniciar
            button1.BackColor = Color.GreenYellow;//Coloca el color verde
            button2.Enabled = false;//Desabilito el boton de reinicio
            button2.BackColor = Color.Red;//Coloco el color rojo en el boton de reinicio
            textBox1.Enabled = true;//Habilito el campo de texto
        }
        
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
           
        }
    }
}
