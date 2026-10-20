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
                //dgvInformacion.DataSource = ds.Tables[0];
                ActualizaDatos(ds);
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

        public void ActualizaDatos(DataSet ds)
        {
            if (ds != null)
            {
                //dgvInformacion.Rows.Clear(); //Esta linea da error

                dgvInformacion.AutoGenerateColumns = false;
                dgvInformacion.Columns[0].DataPropertyName = "id";
                dgvInformacion.Columns[1].DataPropertyName = "nombre";
                dgvInformacion.Columns[2].DataPropertyName = "paterno";
                dgvInformacion.Columns[3].DataPropertyName = "materno";
                dgvInformacion.Columns[4].DataPropertyName = "telefono";
                dgvInformacion.Columns[5].DataPropertyName = "correo";

                dgvInformacion.DataSource = ds.Tables[0];
            }
        }

        private void frmInformacion_Activated(object sender, EventArgs e)
        {
            datos = new Datos();
            DataSet ds = datos.informacion("Select * From Datos");
            ActualizaDatos(ds);
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
