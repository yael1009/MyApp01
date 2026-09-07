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
        int contador;
        int minutos;
        bool bandera=false;

        public Form1()
        {
            InitializeComponent();
        }

        private void tmrReloj_Tick(object sender, EventArgs e)
        {
            //lblReloj.Text = DateTime.Now.ToShortTimeString();
            //lblReloj.Text = DateTime.Now.ToLongTimeString();
            contador++;
            DateTime tiempo  = DateTime.Now;
            lblReloj.Text = tiempo.ToString("HH:mm:ss");
            lblFecha.Text = tiempo.ToString("MM:dd:yyyy");
            if (contador == 60) {
                minutos++;
                contador = 0;
            }
            lblEjecucion.Text = "Tiempo en ejecucion " + minutos.ToString()  + " minutos";

        }

        private void btnEncender_Click(object sender, EventArgs e)
        {
            if (bandera == false)
            {
                bandera = true;
                btnEncender.Text = "Apagar";
                tmrReloj.Enabled = true;
            }
            else
            {
                bandera = false;
                btnEncender.Text = "Encender";
                tmrReloj.Enabled = false;
            }
        }
    }
}
