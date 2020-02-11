using Irony.Parsing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _Compi1_Proyecto2.Analizador
{
    public class Funcion
    {
        public String nombre;
        public String id;//cuando hay sobrecarga el id es importante y para generarlo se concatena el nombre del metodo con todos los tipos de los parametros
        public String tipo;
        public String ambito;
        public Object retorno;
        public ParseTreeNode raiz;

        public Funcion(String tipo, String nombre, String ambito, Object retorno, ParseTreeNode raiz)
        {
            this.nombre = nombre;
            this.tipo = tipo;
            this.raiz = raiz;
            this.retorno = retorno;
            //this.id=generarId(raiz.childNodes[3]);

        }

        public string generarId(ParseTreeNode parametros)
        {
            //aqui es donde se recorre la lista de parametros y se concatena el tipo de cada uno
            return "";
        }
    }
}
