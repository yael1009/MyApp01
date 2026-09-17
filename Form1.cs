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
        List<Persona> personas = new List<Persona>();
        public Form1()
        {
            InitializeComponent();
            personas.Add(new Persona(1,"BETaGEY","8715726304"));
            personas.Add(new Persona(2, "Flancisco", "8715726303"));
            personas.Add(new Persona(3, "GigaChad", "8715726305"));

        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            dgvInformacion.Rows.Add();
            dgvInformacion[0, dgvInformacion.Rows.Count - 1].Value = dgvInformacion.Rows.Count;
            dgvInformacion[1,dgvInformacion.Rows.Count-1].Value = txtNombre.Text;
            dgvInformacion[2,dgvInformacion.Rows.Count-1].Value = mtbTelefono.Text;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            foreach (var Persona in personas)
            {
                //dgvInformacion.Rows.Add(Persona.id,Persona.nombre,Persona.telefono);
                dgvInformacion.Rows.Add();
                dgvInformacion[0, dgvInformacion.Rows.Count - 1].Value = Persona.id;
                dgvInformacion[1, dgvInformacion.Rows.Count - 1].Value = Persona.nombre;
                dgvInformacion[2, dgvInformacion.Rows.Count - 1].Value = Persona.telefono;
            }
            //dgvInformacion.DataSource = personas;
        }
    }
}
