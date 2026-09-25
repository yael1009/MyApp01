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
    public partial class Form2 : Form
    {

        public string ActualizarNombre {  get; set; }
        public string ActualizarCorreo { get; set; }
        public Form2(string nombre, string correo)
        {
            InitializeComponent();
            txtNombre.Text = nombre;
            txtCorreo.Text = correo;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ActualizarNombre = txtNombre.Text;
            ActualizarCorreo = txtCorreo.Text;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
