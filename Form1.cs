using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyApp01
{
    public partial class Form1 : Form
    {

        bool save = false;
        //bool cambios = false;
        String path;
        public Form1()
        {
            InitializeComponent();
        }

        private void abrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /*DialogResult ds;
            ds = ofpAbrir.ShowDialog();*/

            if(ofpAbrir.ShowDialog() == DialogResult.OK)
            {
                path = ofpAbrir.FileName;
                save = true;
                rctTexto.LoadFile(ofpAbrir.FileName, RichTextBoxStreamType.PlainText);
                guardarToolStripMenuItem.Enabled = true;
                tmrAutoguardado.Enabled = true;
            }

        }

        private void guardarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(save  == false)
            {
                if (sfdGuardar.ShowDialog() == DialogResult.OK)
                {
                    path = sfdGuardar.FileName;
                    save = true;
                    tmrAutoguardado.Enabled = true;
                }
            }
            rctTexto.SaveFile(path, RichTextBoxStreamType.PlainText);
            guardarToolStripMenuItem.Enabled = false;
        }

        private void rctTexto_TextChanged(object sender, EventArgs e)
        {
            guardarToolStripMenuItem.Enabled = true;
            //cambios = true;
        }

        private void guardarComoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(sfdGuardar.ShowDialog() == DialogResult.OK)
            {
                path=sfdGuardar.FileName;
                rctTexto.SaveFile(path, RichTextBoxStreamType.PlainText);
                guardarToolStripMenuItem.Enabled=true;
                save = true;
                tmrAutoguardado.Enabled = true;
            }
        }

        private void nuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rctTexto.Clear();
            rctTexto.Focus();
            path = null;//""
            save = false;
            tmrAutoguardado.Enabled = false;
            //guardarToolStripMenuItem.Enabled = true;//Se puede omitir por el text change
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /*private void tmrReloj_Tick(object sender, EventArgs e)
        {
            //lblReloj.Text = DateTime.Now.ToShortTimeString();
            //lblReloj.Text = DateTime.Now.ToLongTimeString();
            contador++;
            DateTime tiempo = DateTime.Now;
            lblReloj.Text = tiempo.ToString("HH:mm:ss");
            lblFecha.Text = tiempo.ToString("MM:dd:yyyy");
            if (contador == 60)
            {
                minutos++;
                contador = 0;
            }
            lblEjecucion.Text = "Tiempo en ejecucion " + minutos.ToString() + " minutos";

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
        }*/

        private async void tmrAutoguardado_Tick(object sender, EventArgs e)
        {
            rctTexto.SaveFile(path, RichTextBoxStreamType.PlainText);
            guardarToolStripMenuItem.Enabled = false;

            lblAutoguardado.Visible = true;
            Task.Delay(2000);
            lblAutoguardado.Visible=false;
        }
    }
}
