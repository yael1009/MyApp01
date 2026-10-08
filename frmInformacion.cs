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
    public partial class frmInformacion : Form
    {
        Datos datos;
        public frmInformacion()
        {
            InitializeComponent();
        }

        private void frmInformacion_Load(object sender, EventArgs e)
        {
            datos = new Datos();
            DataSet ds = datos.informacion("Select * From Datos");
            if (ds != null)
            {
                dgvInformacion.DataSource = ds.Tables[0];
            }
            else
            {
                MessageBox.Show("Error al cargar informacion","Sistema",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmAgregar agregar = new frmAgregar();
            agregar.Show();
        }
    }
}
