using System;
using Irony.Parsing;
using WINGRAPHVIZLib;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace _Compi1_Proyecto2.Analizador
{
    public class Sintactico
    {
        public static ParseTreeNode analizar(String cadena)
        {
            Gramatica gramatica = new Gramatica();
            LanguageData lenguaje = new LanguageData(gramatica);
            Parser parser = new Parser(lenguaje);
            ParseTree arbol = parser.Parse(cadena);
            ParseTreeNode raiz = arbol.Root;
            generarImagen(raiz);
            return arbol.Root;
        }

        public static void generarImagen(ParseTreeNode raiz)
        {
            try
            {
                String grafo_en_DOT = ControlDOT.ControlDOT.getDOT(raiz);
                DOT dot = new DOT();
                BinaryImage img = dot.ToPNG(grafo_en_DOT);
                img.Save("C:/Users/pablo/Desktop/CompiJunio/[Compi1]Proyecto2/[Compi1]Proyecto2/imagenes/AST.png");
                MessageBox.Show("Se creó el AST.");
            }
            catch (Exception)
            {
                MessageBox.Show("No se creó el AST.");
            }
        }

        public static void generarImagenAST(ParseTreeNode raiz, String nombre)
        {
            try
            {
                String grafo_en_DOT = Programa.DibujarAST(raiz);
                DOT dot = new DOT();
                BinaryImage img = dot.ToPNG(grafo_en_DOT);
                img.Save("C:/Users/pablo/Desktop/CompiJunio/[Compi1]Proyecto2/[Compi1]Proyecto2/imagenes/AST"+nombre+".png");
                MessageBox.Show("Se creó el AST del "+nombre+".");
                Programa.sw.WriteLine("<tr>");
                Programa.sw.WriteLine("<th>DibujarAST: AST de una funcion en particular</th>");
                Programa.sw.WriteLine("<th>AST_" + nombre + "</th>");
                Programa.sw.WriteLine("<th><img src=" + "\"" + "[Compi1]Proyecto2/imagenes/AST" + nombre + ".png" + "\"" + "></th>");
                Programa.sw.WriteLine("</tr>");
            }
            catch (Exception)
            {
                MessageBox.Show("No se creó el AST del " + nombre + ".");
            }
        }

        public static void generarImagenEXP(ParseTreeNode raiz, int numero)
        {
            try
            {
                String grafo_en_DOT = Programa.DibujarEXP(raiz);
                DOT dot = new DOT();
                BinaryImage img = dot.ToPNG(grafo_en_DOT);
                img.Save("C:/Users/pablo/Desktop/CompiJunio/[Compi1]Proyecto2/[Compi1]Proyecto2/imagenes/EXP" + numero + ".png");
                MessageBox.Show("Se creó el EXP" + numero + ".");
                Programa.sw.WriteLine("<tr>");
                Programa.sw.WriteLine("<th>DibujarEXP: AST de una expresion en particular</th>");
                Programa.sw.WriteLine("<th>EXP_" + numero + "</th>");
                Programa.sw.WriteLine("<th><img src=" + "\"" + "[Compi1]Proyecto2/imagenes/EXP" + numero + ".png" +"\"" + "></th>");
                Programa.sw.WriteLine("</tr>");
            }
            catch (Exception)
            {
                MessageBox.Show("No se creó el EXP" + numero + ".");
            }
        }
    }
}
