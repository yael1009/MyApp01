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
                // Limpiamos la lista global para vaciar los datos viejos
                registros.Clear();

                // Recorremos fila por fila el DataGridView para actualizar la lista
                foreach (DataGridViewRow row in dgvRegistros.Rows)
                {
                    // Ignoramos la fila vacía del final que usa el DataGridView para crear nuevos registros
                    if (!row.IsNewRow)
                    {
                        // Creamos un nuevo objeto Persona leyendo el valor de cada celda de la fila
                        Persona p = new Persona();
                        p.id = Convert.ToInt32(row.Cells[0].Value);
                        p.name = row.Cells[1].Value.ToString();
                        p.email = row.Cells[2].Value.ToString();

                        // Agregamos la persona a la lista
                        registros.Add(p);
                    }
                }

                // Abrimos el archivo en modo escritura usando la ruta guardada en la variable 'path'
                var writer = new StreamWriter(path);

                // Inicializamos CsvWriter pasándole el stream y la configuración regional
                var csv = new CsvWriter(writer, CultureInfo.InvariantCulture);

                // Escribimos toda la lista de registros actualizada en el archivo CSV
                csv.WriteRecords(registros);

                // Cerramos el escritor para guardar los cambios y liberar el archivo
                writer.Close();
            }
        }
    }
}
