using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace MyApp01
{
    public partial class frmAgregar : Form
    {
        bool updateMode = false;
        int id;
        Datos datos;
        public frmAgregar()
        {
            InitializeComponent();
        }

        public frmAgregar(string nombre, string paterno, string materno,
            string telefono, string correo, int id)
        {
            InitializeComponent();
            txtNombre.Text = nombre;
            txtapPaterno.Text = paterno;
            txtapMaterno.Text = materno;
            txtTelefono.Text = telefono;
            txtCorreo.Text = correo;
            btnAgregar.Text = "Actualiza";
            updateMode = true;
            this.id = id;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            datos = new Datos();
            if (updateMode == false)
            {
                bool f = datos.ejecutar("Insert Into Datos(nombre,paterno,materno," +
                "telefono,correo)Values('"
                + txtNombre.Text + "','" + txtapPaterno.Text + "','" + txtapMaterno.Text
                + "','" + txtTelefono.Text + "','" + txtCorreo.Text + "')");
                if (f)
                {
                    MessageBox.Show("Registro agregado correctamente");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Error al agregar el registro");
                }
            }
            else
            {
                SqlCommand comando = new SqlCommand("Update Datos Set nombre=@nombre," +
                    "paterno=@paterno,materno=@materno,telefono=@telefono," +
                    "correo=@correo Where id=@id");
                comando.Parameters.AddWithValue("@nombre", txtNombre.Text);
                comando.Parameters.AddWithValue("@paterno", txtapPaterno.Text);
                comando.Parameters.AddWithValue("@materno", txtapMaterno.Text);
                comando.Parameters.AddWithValue("@telefono", txtTelefono.Text);
                comando.Parameters.AddWithValue("@correo", txtCorreo.Text);
                bool f = datos.ejecutar(comando);
                if (f)
                {
                    MessageBox.Show("Registro actualizado correctamente");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Error al actualizar el registro");
                }
            }
        }
    }
}
