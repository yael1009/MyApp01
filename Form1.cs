using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyApp01
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        /*private void btnProceso_Click(object sender, EventArgs e)
        {
            String nombre = txtNombre.Text;
            MessageBox.Show("El nombre es: " + nombre);
        }*/

        private void Form1_Load(object sender, EventArgs e) { }

        private void label2_Click(object sender, EventArgs e)
        {
            
        }


        private void btnCalcular_Click(object sender, EventArgs e)
        {
            int a, b = 0;
            a = Int32.Parse(txtNumero1.Text);
            b = Convert.ToInt32(txtNumero2.Text);

            //MessageBox.Show("la suma es: " + (a + b));
            txtResultado.Text = (a + b).ToString();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtNumero1.Clear();
            txtNumero2.Clear();
            txtResultado.Clear();

            txtNumero1.Focus();
        }
    }
}
