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
            button2.Enabled = false;
            button2.BackColor = Color.Red;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text=="")
            {
                MessageBox.Show("Campos Vacios","Alerta");
            }
            else
            {
                dataGridView1.Rows.Clear();
                String entrada = textBox1.Text;
                AnalizadorLexico lex = new AnalizadorLexico();
                LinkedList<Token> ltokens = lex.escanear(entrada);
                foreach (Token token in ltokens)
                {
                    dataGridView1.Rows.Add(token.Getval(), token.GetTipo(), token.GetID());
                }
                lex.imprimirListaToken(ltokens);
                button1.Enabled = false;
                button1.BackColor = Color.Red;
                button2.Enabled = true;
                button2.BackColor = Color.YellowGreen;
                textBox1.Enabled = false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            textBox1.Text = "";
            button1.Enabled = true;
            button1.BackColor = Color.GreenYellow;
            button2.Enabled = false;
            button2.BackColor = Color.Red;
            textBox1.Enabled = true;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
           
        }
    }
}
