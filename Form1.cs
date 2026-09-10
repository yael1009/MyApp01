using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WMPLib;


namespace MyApp01
{
    public partial class Form1 : Form
    {
        DateTime tiempo;
        public Form1()
        {
            InitializeComponent();
        }

        private void configurarAlarmaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormConfiguarar ventanaAlarma = new FormConfiguarar();
            if(ventanaAlarma.ShowDialog() == DialogResult.OK)
            {
                tiempo = ventanaAlarma.hora;
                MessageBox.Show(tiempo.ToString());
            }
        }

        private void tmrReloj_Tick(object sender, EventArgs e)
        {
            lblReloj.Text = DateTime.Now.ToLongTimeString();
            if (DateTime.Now.ToLongTimeString() == tiempo.ToLongTimeString())
            {
//                wmp.URL = @"C:\Users\rober\Music\4K YouTube to MP3\Soy un cacahuate pero mal hecho.mp3";
                wmp.URL = @"C:\Users\rober\Music\4K YouTube to MP3\MÚSICA TUTORIAL YUYA SIN COPYRIGHT(FREE).mp3";

                wmp.Ctlcontrols.play();
            }
        }
    }
}
