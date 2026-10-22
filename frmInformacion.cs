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
        int fila;
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

        private void dgvInformacion_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            /*frmAgregar actualizar = new frmAgregar(dgvInformacion.Rows[e.RowIndex].Cells[1].Value.ToString(),
                dgvInformacion.Rows[e.RowIndex].Cells[2].Value.ToString(),
                dgvInformacion.Rows[e.RowIndex].Cells[3].Value.ToString(),
                dgvInformacion.Rows[e.RowIndex].Cells[4].Value.ToString(),
                dgvInformacion.Rows[e.RowIndex].Cells[5].Value.ToString(),
                Convert.ToInt32(dgvInformacion.Rows[e.RowIndex].Cells[0].Value));
            actualizar.Show();*/
        }

        private void dgvInformacion_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if(e.Button == MouseButtons.Right && e.RowIndex >= 0)
            {
                fila = e.RowIndex;
                //fila = Convert.ToInt32(dgvInformacion.Rows[e.RowIndex]);
                cmsEditar.Show(Cursor.Position);
            }
        }

        private void actualizarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAgregar actualizar = new frmAgregar(dgvInformacion.Rows[fila].Cells[1].Value.ToString(),
                dgvInformacion.Rows[fila].Cells[2].Value.ToString(),
                dgvInformacion.Rows[fila].Cells[3].Value.ToString(),
                dgvInformacion.Rows[fila].Cells[4].Value.ToString(),
                dgvInformacion.Rows[fila].Cells[5].Value.ToString(),
                Convert.ToInt32(dgvInformacion.Rows[fila].Cells[0].Value));
            actualizar.Show();
        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
