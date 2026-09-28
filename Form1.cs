using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CsvHelper;
using System.Globalization;

namespace MyApp01
{
    public partial class Form1 : Form
    {
        List<Persona> registros = new List<Persona>();
        string path;
        bool open = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dgvInformacion_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Form2  editar = new Form2(
                dgvRegistros.Rows[e.RowIndex].Cells[1].Value.ToString(),
                dgvRegistros.Rows[e.RowIndex].Cells[2].Value.ToString()
                );
            if (editar.ShowDialog() == DialogResult.OK) {
                string nombre = editar.ActualizarNombre;
                string correo = editar.ActualizarCorreo;
                dgvRegistros.Rows[e.RowIndex].Cells[1].Value=nombre;
                dgvRegistros.Rows[e.RowIndex].Cells[2].Value= correo;
            }
        }

        private void btnCargar_Click(object sender, EventArgs e)
        {
            if (ofdCSV.ShowDialog() == DialogResult.OK)
            {
                path = ofdCSV.FileName;
                dgvRegistros.Rows.Clear();
                open = true;
                var reader = new StreamReader(ofdCSV.FileName);
                var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
                registros = csv.GetRecords<Persona>().ToList();
                //reader.Close();
                foreach (var registro in registros)
                {
                    dgvRegistros.Rows.Add(registro.id, registro.name, registro.email);
                }
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (open)
            {
                registros.Clear();
                foreach (DataGridViewRow row in dgvRegistros.Rows)
                {
                    // Ignora ultima fila vacia del dgv
                    if (!row.IsNewRow)
                    {
                        Persona p = new Persona();
                        p.id = Convert.ToInt32(row.Cells[0].Value);
                        p.name = row.Cells[1].Value.ToString();
                        p.email = row.Cells[2].Value.ToString();
                        registros.Add(p);
                    }
                }

                StreamWriter writer = new StreamWriter(path);
                CsvWriter csv = new CsvWriter(writer, CultureInfo.InvariantCulture);
                csv.WriteRecords(registros);
                writer.Close();
            }
        }
    }
}
