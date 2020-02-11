using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Irony.Ast;
using Irony.Parsing;
using _Compi1_Practica1.Analizador;
using System.Runtime.InteropServices;

namespace _Compi1_Practica1
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);
               

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void barraTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle,0x112,0xf012,0);
        }

        private void abrirPanel(object Formhijo)
        {
            if (this.panelContenedor.Controls.Count > 0)
            {
                this.panelContenedor.Controls.RemoveAt(0);
            }
            Form f = Formhijo as Form;
            f.Dock = DockStyle.Fill;
            f.TopLevel = false;
            this.panelContenedor.Controls.Add(f);
            this.panelContenedor.Tag = f;
            f.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            abrirPanel(new Form2());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            abrirPanel(new Form3());
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (menuVertical.Width != 200)
            {
                menuVertical.Width = 200;
            }
            else
            {
                menuVertical.Width = 50;
            }
        }
    }
}
