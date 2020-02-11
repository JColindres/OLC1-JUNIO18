using _Compi1_Proyecto2.Analizador;
using Irony.Parsing;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _Compi1_Proyecto2
{
    public partial class Form1 : Form
    {
        public static ArrayList erroresSem = new ArrayList();
        public static ArrayList fila = new ArrayList();
        public static ArrayList columna = new ArrayList();

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            richTextBox2.Text = "";
            richTextBox3.Text = "Analizando...";
            Gramatica gramatica = new Gramatica();
            LanguageData lenguaje = new LanguageData(gramatica);
            Parser parser = new Parser(lenguaje);
            ParseTree arbol = parser.Parse(richTextBox1.Text);
            ParseTreeNode resultado = arbol.Root;
            Sintactico.generarImagen(resultado);
            if (resultado != null)
            {
                label1.Text = "La cadena es correcta";
                Programa p = new Programa(richTextBox2, richTextBox3,resultado);
                if (erroresSem.Count == 0)
                {
                    dataGridView1.Visible = false;
                }
                else
                {
                    DataTable error = new DataTable();
                    error.Clear();
                    error.Columns.Add("No.");
                    error.Columns.Add("Error");
                    error.Columns.Add("Fila");
                    error.Columns.Add("Columna");
                    DataRow filaa;
                    StreamWriter sw = new StreamWriter("C:/Users/pablo/Desktop/CompiJunio/[Compi1]Proyecto2/Reporte.html");
                    sw.WriteLine("<html>");
                    sw.WriteLine("<title>Reporte de Errores</title>");
                    sw.WriteLine("<body background=" + "\"" + "large-background-1024x724.jpg" + "\"" + ">");
                    sw.WriteLine("<h1><center>Reporte de Errores</center></h1>");
                    sw.WriteLine("<center><table border=\"2\">");
                    sw.WriteLine("<tr>");
                    sw.WriteLine("<th>No.</th>");
                    sw.WriteLine("<th>Error</th>");
                    sw.WriteLine("<th>Fila</th>");
                    sw.WriteLine("<th>Columna</th>");
                    sw.WriteLine("</tr>");
                    for (int i = 0; i < erroresSem.Count; i++)
                    {
                        filaa = error.NewRow();
                        filaa["No."] = i + 1;
                        filaa["Error"] = "Semantico: " + erroresSem[i];
                        filaa["Fila"] = fila[i];
                        filaa["Columna"] = columna[i];
                        error.Rows.Add(filaa);
                        sw.WriteLine("<tr>");
                        sw.WriteLine("<th>" + (i + 1) + "</th>");
                        sw.WriteLine("<th>" + "Semantico: " + erroresSem[i] + "</th>");
                        sw.WriteLine("<th>" + fila[i] + "</th>");
                        sw.WriteLine("<th>" + columna[i] + "</th>");
                        sw.WriteLine("</tr>");

                    }
                    sw.WriteLine("</table></center>");
                    sw.WriteLine("</body>");
                    sw.WriteLine("</html>");
                    sw.Close();
                    dataGridView1.DataSource = error;
                    dataGridView1.Visible = true;
                    erroresSem.Clear();
                    fila.Clear();
                    columna.Clear();
                }
                Bitmap myBitmap = new Bitmap("C:/Users/pablo/Desktop/CompiJunio/[Compi1]Proyecto2/[Compi1]Proyecto2/imagenes/AST.png");  
                //Image im = Image.FromFile("C:/Users/pablo/Desktop/CompiJunio/[Compi1]Proyecto2/[Compi1]Proyecto2/imagenes/AST.png");
                myBitmap.SetResolution(20, 20);
                Bitmap pp = new Bitmap(myBitmap);
                Clipboard.SetImage(pp);
                richTextBox4.Paste();
            }
            else
            {
                label1.Text = "La cadena es incorrecta";
                DataTable error = new DataTable();
                error.Clear();
                error.Columns.Add("No.");
                error.Columns.Add("Error");
                error.Columns.Add("Fila");
                error.Columns.Add("Columna");
                DataRow filaa;
                StreamWriter sw = new StreamWriter("C:/Users/pablo/Desktop/CompiJunio/[Compi1]Proyecto2/Reporte.html");
                sw.WriteLine("<html>");
                sw.WriteLine("<title>Reporte de Errores</title>");
                sw.WriteLine("<body background=" + "\"" + "large-background-1024x724.jpg" + "\"" + ">");
                sw.WriteLine("<h1><center>Reporte de Errores</center></h1>");
                sw.WriteLine("<center><table border=\"2\">");
                sw.WriteLine("<tr>");
                sw.WriteLine("<th>No.</th>");
                sw.WriteLine("<th>Error</th>");
                sw.WriteLine("<th>Fila</th>");
                sw.WriteLine("<th>Columna</th>");
                sw.WriteLine("</tr>");
                int j = 0;
                for (int i = 0; i < arbol.ParserMessages.Count; i++)
                {
                    filaa = error.NewRow();
                    filaa["No."] = i + 1;
                    filaa["Error"] = arbol.ParserMessages[i].Message.ToString();
                    filaa["Fila"] = (arbol.ParserMessages[i].Location.Line + 1).ToString();
                    filaa["Columna"] = (arbol.ParserMessages[i].Location.Column + 1).ToString();
                    error.Rows.Add(filaa);
                    j = i + 1;
                    sw.WriteLine("<tr>");
                    sw.WriteLine("<th>" + j + "</th>");
                    sw.WriteLine("<th>" + arbol.ParserMessages[i].Message.ToString() + "</th>");
                    sw.WriteLine("<th>" + (arbol.ParserMessages[i].Location.Line + 1).ToString() + "</th>");
                    sw.WriteLine("<th>" + (arbol.ParserMessages[i].Location.Line + 1).ToString() + "</th>");
                    sw.WriteLine("</tr>");
                }
                for (int i = 0; i < erroresSem.Count; i++)
                {
                    filaa = error.NewRow();
                    filaa["No."] = j + 1;
                    filaa["Error"] = "Semantico: " + erroresSem[i];
                    filaa["Fila"] = fila[i];
                    filaa["Columna"] = columna[i];
                    error.Rows.Add(filaa);
                    sw.WriteLine("<tr>");
                    sw.WriteLine("<th>" + (j + 1) + "</th>");
                    sw.WriteLine("<th>" + "Semantico: " + erroresSem[i] + "</th>");
                    sw.WriteLine("<th>" + fila[i] + "</th>");
                    sw.WriteLine("<th>" + columna[i] + "</th>");
                    sw.WriteLine("</tr>");

                }
                sw.WriteLine("</table></center>");
                sw.WriteLine("</body>");
                sw.WriteLine("</html>");
                sw.Close();
                dataGridView1.DataSource = error;
                dataGridView1.Visible = true;
                erroresSem.Clear();
                fila.Clear();
                columna.Clear();
            }
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            int posicion = richTextBox1.SelectionStart;
            int linea = richTextBox1.GetLineFromCharIndex(posicion) + 1;
            int columna = posicion - richTextBox1.GetFirstCharIndexOfCurrentLine() + 1;
            label2.Text = "Linea: " + linea + " Columna: " + columna;
            label2.Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK && openFileDialog1.FileName.Length > 0)
            {
                richTextBox1.LoadFile(openFileDialog1.FileName, RichTextBoxStreamType.PlainText);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (richTextBox1.Visible == true)
            {
                richTextBox1.Text = "";
                richTextBox1.Visible = false;
            }
            else if (richTextBox1.Visible == false)
            {
                richTextBox1.Text = "";
                richTextBox1.Visible = true;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            StreamWriter s = new StreamWriter("C:/Users/pablo/Desktop/CompiJunio/[Compi1]Proyecto2/copia.txt");
            s.WriteLine(richTextBox1.Text);
            s.Close();
            MessageBox.Show("Se guardo una copia");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Process.Start("chrome.exe", "C:\\Users\\pablo\\Desktop\\CompiJunio\\[Compi1]Proyecto2\\Reporte.html");
            Process.Start("chrome.exe", "C:\\Users\\pablo\\Desktop\\CompiJunio\\[Compi1]Proyecto2\\Imagenes.html");
        }
    }
}
