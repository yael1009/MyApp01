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
    public partial class FormConfiguarar : Form
    {
        public DateTime hora {  get; set; }
        public FormConfiguarar()
        {
            InitializeComponent();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            hora = dtpConfigura.Value;

            this.DialogResult = DialogResult.OK;

            this.Close();
        }
    }
}
