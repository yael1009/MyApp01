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

        bool save = false;
        bool cambios = false;
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
                }
                rctTexto.SaveFile(path,RichTextBoxStreamType.PlainText);
                guardarToolStripMenuItem.Enabled=false;
            }
        }

        private void rctTexto_TextChanged(object sender, EventArgs e)
        {
            cambios = true;
        }

        private void guardarComoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(sfdGuardar.ShowDialog() == DialogResult.OK)
            {
                path=sfdGuardar.FileName;
                rctTexto.SaveFile(path, RichTextBoxStreamType.PlainText);
                guardarToolStripMenuItem.Enabled=true;
                save = true;
            }
        }

        private void nuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rctTexto.Clear();
            rctTexto.Focus();
            path = null;//""
            save = false;
            //guardarToolStripMenuItem.Enabled = true;//Se puede omitir por el text change
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
