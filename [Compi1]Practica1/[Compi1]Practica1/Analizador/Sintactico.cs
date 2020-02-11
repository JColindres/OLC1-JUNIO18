using System;
using Irony.Parsing;
using WINGRAPHVIZLib;
using _Compi1_Practica1.ControlDOT;
using System.Windows.Forms;

namespace _Compi1_Practica1.Analizador
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
                img.Save("C:/Users/pablo/Desktop/Compi Junio/[Compi1]Practica1/[Compi1]Practica1/imagenes/AST.png");
                MessageBox.Show("Se creó el AST.");
            }
            catch (Exception)
            {
                MessageBox.Show("No se creó el AST.");
            }
        }

        public static void generarOtraImagen(ParseTreeNode raiz)
        {
            try
            {
                String grafo_en_DOT = ControlDOT.ControlDOT.getDOT2(raiz);
                DOT dot = new DOT();
                BinaryImage img = dot.ToPNG(grafo_en_DOT);
                img.Save("C:/Users/pablo/Desktop/Compi Junio/[Compi1]Practica1/[Compi1]Practica1/imagenes/ASA.png");
                MessageBox.Show("Se creó el ASA.");
            }
            catch (Exception)
            {
                MessageBox.Show("No se creó el ASA.");
            }
        }
    }
}
