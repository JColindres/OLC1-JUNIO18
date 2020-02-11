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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
            
        }

        String tabulacion = "";

        public String agregarTab()
        {
            tabulacion = tabulacion + "    ";
            return tabulacion;
        }

        public String quitarTab()
        {
            tabulacion = tabulacion.Remove(0, 4);
            return tabulacion;
        }

        void ParseLine(string line)
        {
            Regex r = new Regex("([ \\t{}():;])");
            String[] tokens = r.Split(line);
            foreach (string token in tokens)
            {
                if (!token.Contains("") || !token.Contains(" "))
                {
                    if (token.Contains("{"))
                    {
                        agregarTab();
                        richTextBox2.SelectedText += token + " \n";
                    }
                    else if (token.Contains("}"))
                    {
                        quitarTab();
                        richTextBox2.SelectedText += "\n" + tabulacion + token + "\n"+ tabulacion;
                    }
                    else if (token.Contains(":"))
                    {
                        richTextBox2.SelectedText += token + "\n" + tabulacion;
                    }
                    else
                    {
                        richTextBox2.SelectedText += token + " ";
                    }
                }
            }
            richTextBox2.SelectedText += "\n" + tabulacion;
        }

        private void Rchtxt_TextChanged(object sender, EventArgs e)
        {
            String[] morado = new String[] { "Vacio", "Entero", "Decimal", "Texto", "Caracter", "Booleano" };
            int index = -1;
            int selectStart = this.richTextBox1.SelectionStart;
            foreach (string word in morado) {
                while ((index = this.richTextBox1.Text.IndexOf(word, (index + 1))) != -1)
                {
                    this.richTextBox1.Select((index ), word.Length);
                    this.richTextBox1.SelectionColor = Color.Purple;
                    this.richTextBox1.Select(selectStart, 0);
                    this.richTextBox1.SelectionColor = Color.Black;
                }
            }
            String[] azul = new String[] { "Retorno", "Es_verdadero", "Es_falso", "Mostrar", "Cambiar_A", "Para", "Hasta_que", "Si_no", "Si", "Mientras_que" };
            foreach (string word in azul)
            {
                while ((index = this.richTextBox1.Text.IndexOf(word, (index + 1))) != -1)
                {
                    this.richTextBox1.Select((index), word.Length);
                    this.richTextBox1.SelectionColor = Color.Blue;
                    this.richTextBox1.Select(selectStart, 0);
                    this.richTextBox1.SelectionColor = Color.Black;
                }
            }
            String[] anaranjado = new String[] { "Valor", "No_cumple" };
            foreach (string word in anaranjado)
            {
                while ((index = this.richTextBox1.Text.IndexOf(word, (index + 1))) != -1)
                {
                    this.richTextBox1.Select((index), word.Length);
                    this.richTextBox1.SelectionColor = Color.Orange;
                    this.richTextBox1.Select(selectStart, 0);
                    this.richTextBox1.SelectionColor = Color.Black;
                }
            }
            String[] amarillo = new String[] { "Romper", "Continuar" };
            foreach (string word in amarillo)
            {
                while ((index = this.richTextBox1.Text.IndexOf(word, (index + 1))) != -1)
                {
                    this.richTextBox1.Select((index), word.Length);
                    this.richTextBox1.SelectionColor = Color.YellowGreen;
                    this.richTextBox1.Select(selectStart, 0);
                    this.richTextBox1.SelectionColor = Color.Black;
                }
            }
            String[] rojo = new String[] { "Definir", "Importar" };
            foreach (string word in rojo)
            {
                while ((index = this.richTextBox1.Text.IndexOf(word, (index + 1))) != -1)
                {
                    this.richTextBox1.Select((index), word.Length);
                    this.richTextBox1.SelectionColor = Color.Red;
                    this.richTextBox1.Select(selectStart, 0);
                    this.richTextBox1.SelectionColor = Color.Black;
                }
            }
            String[] verde = new String[] { "Principal"};
            foreach (string word in verde)
            {
                while ((index = this.richTextBox1.Text.IndexOf(word, (index + 1))) != -1)
                {
                    this.richTextBox1.Select((index), word.Length);
                    this.richTextBox1.SelectionColor = Color.Green;
                    this.richTextBox1.Select(selectStart, 0);
                    this.richTextBox1.SelectionColor = Color.Black;
                }
            }
            String[] cyan = new String[] { "DibujarAST","DibujarEXP","DibujarTS"};
            foreach (string word in cyan)
            {
                while ((index = this.richTextBox1.Text.IndexOf(word, (index + 1))) != -1)
                {
                    this.richTextBox1.Select((index), word.Length);
                    this.richTextBox1.SelectionColor = Color.DarkCyan;
                    this.richTextBox1.Select(selectStart, 0);
                    this.richTextBox1.SelectionColor = Color.Black;
                }
            }
            updateNumberLabel();
        }

        private void Rchtxt2_TextChanged(object sender, EventArgs e)
        {
            String[] morado = new String[] { "Vacio", "Entero", "Decimal", "Texto", "Caracter", "Booleano" };
            int index = -1;
            int selectStart = this.richTextBox2.SelectionStart;
            foreach (string word in morado)
            {
                while ((index = this.richTextBox2.Text.IndexOf(word, (index + 1))) != -1)
                {
                    this.richTextBox2.Select((index), word.Length);
                    this.richTextBox2.SelectionColor = Color.Purple;
                    this.richTextBox2.Select(selectStart, 0);
                    this.richTextBox2.SelectionColor = Color.Black;
                }
            }
            String[] azul = new String[] { "Retorno", "Es_verdadero", "Es_falso", "Mostrar", "Cambiar_A", "Para", "Hasta_que", "Si_no", "Si", "Mientras_que" };
            foreach (string word in azul)
            {
                while ((index = this.richTextBox2.Text.IndexOf(word, (index + 1))) != -1)
                {
                    this.richTextBox2.Select((index), word.Length);
                    this.richTextBox2.SelectionColor = Color.Blue;
                    this.richTextBox2.Select(selectStart, 0);
                    this.richTextBox2.SelectionColor = Color.Black;
                }
            }
            String[] anaranjado = new String[] { "Valor", "No_cumple" };
            foreach (string word in anaranjado)
            {
                while ((index = this.richTextBox2.Text.IndexOf(word, (index + 1))) != -1)
                {
                    this.richTextBox2.Select((index), word.Length);
                    this.richTextBox2.SelectionColor = Color.Orange;
                    this.richTextBox2.Select(selectStart, 0);
                    this.richTextBox2.SelectionColor = Color.Black;
                }
            }
            String[] amarillo = new String[] { "Romper", "Continuar" };
            foreach (string word in amarillo)
            {
                while ((index = this.richTextBox2.Text.IndexOf(word, (index + 1))) != -1)
                {
                    this.richTextBox2.Select((index), word.Length);
                    this.richTextBox2.SelectionColor = Color.YellowGreen;
                    this.richTextBox2.Select(selectStart, 0);
                    this.richTextBox2.SelectionColor = Color.Black;
                }
            }
            String[] rojo = new String[] { "Definir", "Importar" };
            foreach (string word in rojo)
            {
                while ((index = this.richTextBox2.Text.IndexOf(word, (index + 1))) != -1)
                {
                    this.richTextBox2.Select((index), word.Length);
                    this.richTextBox2.SelectionColor = Color.Red;
                    this.richTextBox2.Select(selectStart, 0);
                    this.richTextBox2.SelectionColor = Color.Black;
                }
            }
            String[] verde = new String[] { "Principal" };
            foreach (string word in verde)
            {
                while ((index = this.richTextBox2.Text.IndexOf(word, (index + 1))) != -1)
                {
                    this.richTextBox2.Select((index), word.Length);
                    this.richTextBox2.SelectionColor = Color.Green;
                    this.richTextBox2.Select(selectStart, 0);
                    this.richTextBox2.SelectionColor = Color.Black;
                }
            }
            String[] cyan = new String[] { "DibujarAST", "DibujarEXP", "DibujarTS" };
            foreach (string word in cyan)
            {
                while ((index = this.richTextBox1.Text.IndexOf(word, (index + 1))) != -1)
                {
                    this.richTextBox1.Select((index), word.Length);
                    this.richTextBox1.SelectionColor = Color.DarkCyan;
                    this.richTextBox1.Select(selectStart, 0);
                    this.richTextBox1.SelectionColor = Color.Black;
                }
            }
            updateNumberLabel2();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            richTextBox2.Text = "";
            String inputLanguage = richTextBox1.Text;
            Regex r = new Regex("\\n");
            string[] lines = r.Split(inputLanguage);
            foreach (string l in lines)
            {
                ParseLine(l);
            }
            Gramatica gramatica = new Gramatica();
            LanguageData lenguaje = new LanguageData(gramatica);
            Parser parser = new Parser(lenguaje);
            ParseTree arbol = parser.Parse(richTextBox1.Text);
            ParseTreeNode resultado = arbol.Root;
            Sintactico.generarImagen(resultado);
            Sintactico.generarOtraImagen(resultado);
            if (resultado != null)
            {
                label1.Text = "La cadena es correcta";
                dataGridView1.Visible = false;
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
                DataRow fila;
                for (int i = 0; i < arbol.ParserMessages.Count; i++)
                {
                    fila = error.NewRow();
                    fila["No."] = i + 1;
                    fila["Error"] = arbol.ParserMessages[i].Message.ToString();
                    fila["Fila"] = (arbol.ParserMessages[i].Location.Line + 1).ToString();
                    fila["Columna"] = (arbol.ParserMessages[i].Location.Column + 1).ToString();
                    error.Rows.Add(fila);
                }
                dataGridView1.DataSource = error;
                dataGridView1.Visible = true;
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK &&      openFileDialog1.FileName.Length > 0)
            {
                richTextBox1.LoadFile(openFileDialog1.FileName, RichTextBoxStreamType.PlainText);
            }
        }
        
        private void richTextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            cambio1();
        }

        private void richTextBox1_Click(object sender, EventArgs e)
        {
            cambio1();
        }

        private void richTextBox2_Click(object sender, EventArgs e)
        {
            cambio2();
        }

        private void richTextBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            cambio2();
        }

        public void cambio1()
        {
            int posicion = richTextBox1.SelectionStart;
            int linea = richTextBox1.GetLineFromCharIndex(posicion) + 1;
            int columna = posicion - richTextBox1.GetFirstCharIndexOfCurrentLine() + 1;
            label2.Text = "Linea: " + linea + " Columna: " + columna;
            label2.Visible = true;
        }

        public void cambio2()
        {
            int posicion = richTextBox2.SelectionStart;
            int linea = richTextBox2.GetLineFromCharIndex(posicion) + 1;
            int columna = posicion - richTextBox2.GetFirstCharIndexOfCurrentLine() + 1;
            label3.Text = "Linea: " + linea + " Columna: " + columna;
            label3.Visible = true;
        }

        private void updateNumberLabel()
        {
            Point pos = new Point(0, 0);
            int firstIndex = richTextBox1.GetCharIndexFromPosition(pos);
            int firstLine = richTextBox1.GetLineFromCharIndex(firstIndex);
            
            pos.X = ClientRectangle.Width;
            pos.Y = ClientRectangle.Height;
            int lastIndex = richTextBox1.GetCharIndexFromPosition(pos);
            int lastLine = richTextBox1.GetLineFromCharIndex(lastIndex);
            
            pos = richTextBox1.GetPositionFromCharIndex(lastIndex);
            
            label4.Text = "";
            for (int i = firstLine; i <= lastLine + 1; i++)
            {
                label4.Text += i + 1 + "\n";
            }

        }

        private void updateNumberLabel2()
        {
            Point pos = new Point(0, 0);
            int firstIndex = richTextBox2.GetCharIndexFromPosition(pos);
            int firstLine = richTextBox2.GetLineFromCharIndex(firstIndex);
            
            pos.X = ClientRectangle.Width;
            pos.Y = ClientRectangle.Height;
            int lastIndex = richTextBox2.GetCharIndexFromPosition(pos);
            int lastLine = richTextBox2.GetLineFromCharIndex(lastIndex);
            
            pos = richTextBox2.GetPositionFromCharIndex(lastIndex);
            
            label5.Text = "";
            for (int i = firstLine; i <= lastLine + 1; i++)
            {
                label5.Text += i + 1 + "\n";
            }

        }

        private void richTextBox1_VScroll(object sender, EventArgs e)
        {
            updateNumberLabel();
        }

        private void richTextBox2_VScroll(object sender, EventArgs e)
        {
            updateNumberLabel2();
        }
    }
}
