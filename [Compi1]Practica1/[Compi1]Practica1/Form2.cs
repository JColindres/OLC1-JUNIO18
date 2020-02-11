using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _Compi1_Practica1
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                Bitmap image1 = (Bitmap)Image.FromFile(@"C:/Users/pablo/Desktop/Compi Junio/[Compi1]Practica1/[Compi1]Practica1/imagenes/AST.png", true);

                TextureBrush texture = new TextureBrush(image1);
                texture.WrapMode = System.Drawing.Drawing2D.WrapMode.Tile;
                pictureBox2.Image = texture.Image;
                pictureBox2.Visible = true;

            }
            catch (System.IO.FileNotFoundException)
            {
                MessageBox.Show("There was an error opening the bitmap." +
                    "Please check the path.");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Bitmap image1 = (Bitmap)Image.FromFile(@"C:/Users/pablo/Desktop/Compi Junio/[Compi1]Practica1/[Compi1]Practica1/imagenes/ASA.png", true);

                TextureBrush texture = new TextureBrush(image1);
                texture.WrapMode = System.Drawing.Drawing2D.WrapMode.Tile;
                pictureBox2.Image = texture.Image;
                pictureBox2.Visible = true;

            }
            catch (System.IO.FileNotFoundException)
            {
                MessageBox.Show("There was an error opening the bitmap." +
                    "Please check the path.");
            }
        }
    }
}
