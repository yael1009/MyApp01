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
    public partial class frmAgregar : Form
    {
        Datos datos;
        public frmAgregar()
        {
            InitializeComponent();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            datos = new Datos();
            bool f = datos.Insertar(txtNombre.Text,txtapPaterno.Text,txtapMaterno.Text,txtTelefono.Text,txtCorreo.Text);
            if (f)
            {
                MessageBox.Show("Registro agregado correctamente");
                    this.Close();
            }
            else
            {
                MessageBox.Show("Error al agregar registar");
            }
        }
    }
}
