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

namespace MyApp01
{
    public partial class Form1 : Form
    {
        List<Persona> registros = new List<Persona>();

        public Form1()
        {
            InitializeComponent();
        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dgvInformacion_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Form  editar = new Form2(
                dgvRegistros.Rows[e.RowIndex].Cells[1].Value.ToString()
                dgvRegistros.Rows[e.RowIndex].Cells[2].Value.ToString()
                );
            editar.Show();
        }

        private void btnCargar_Click(object sender, EventArgs e)
        {
            if (ofdCSV.ShowDialog() == DialogResult.OK)
            {
                var reader = new StreamReader(ofdCSV.FileName);
                var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
                registros = csv.GetRecords<Persona>().ToList();
                foreach (var registro in registros)
                {
                    dgvRegistros.Rows.Add(registro.id, registro.name, registro.email);
                }
            }
        }
    }
}
