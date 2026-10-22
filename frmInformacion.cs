using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
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
            /*datos = new Datos();
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
            }*/
            ActualizarGrid();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmAgregar agregar = new frmAgregar();
            agregar.Show();
        }

        public void ActualizarGrid()
        {
            datos = new Datos();
            DataSet ds = datos.informacion("Select * From Datos");
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
            else
            {
                {
                    MessageBox.Show("No se pudo obtener la información de la base de datos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void frmInformacion_Activated(object sender, EventArgs e)
        {
            /*datos = new Datos();
            DataSet ds = datos.informacion("Select * From Datos");*/
            ActualizarGrid();
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
        // 1. Verificar si hay al menos una fila seleccionada en el DataGridView
        //if (dataGridView1.SelectedRows.Count > 0){
            // Obtener la fila seleccionada
            //DataGridViewRow filaSeleccionada = dataGridView1.SelectedRows[0];

            // Opcional: Obtener un dato de la fila para mostrarlo en el mensaje (ejemplo: Columna "ID" o "Nombre")
            //string valorFila = filaSeleccionada.Cells[0].Value?.ToString() ?? "este registro";

            // 2. Mostrar el MessageBox con botones Sí / No e icono de pregunta
            DialogResult respuesta = MessageBox.Show(
                $"¿Estás seguro de que deseas eliminar este registro?",
                "Confirmar eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            // 3. Evaluar la respuesta del usuario
            if (respuesta == DialogResult.Yes)
            {
                Datos datos = new Datos();
                SqlCommand comando = new SqlCommand("Delete from Datos Where id=@id");
                comando.Parameters.AddWithValue("@id", Convert.ToInt32(dgvInformacion.Rows[fila].Cells[0].Value));
                bool f = datos.ejecutar(comando);
                if (f)
                {
                    MessageBox.Show("Registro eliminado correctamente");
                    //this.Close();
                }
                else
                {
                    MessageBox.Show("Error al eliminar el registro");
                }

                // Eliminar la fila del DataGridView
                //dataGridView1.Rows.Remove(filaSeleccionada);

                // *Verification:* Muestra confirmación de que la fila fue removida
                //MessageBox.Show("El registro fue eliminado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        /*}
        else
        {
            MessageBox.Show("Por favor, selecciona una fila primero.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }*/
        }
    }
}
