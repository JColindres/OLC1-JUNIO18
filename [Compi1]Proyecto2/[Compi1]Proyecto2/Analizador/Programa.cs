using Irony.Parsing;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _Compi1_Proyecto2.Analizador
{
    public class Programa
    {
        public static List<Metodo> metodos;
        public static List<Funcion> funciones;
        public static TablaSimbolo tablaGlobal;
        public static TablaSimbolo tablaLocal;
        public static Metodo met;
        public static Funcion func;
        public RichTextBox consola;
        public RichTextBox consola2;
        public static Stack<String> pilaAmbito;
        String lista;
        public double incerteza = 0.5;
        Resultado Otroresultado;
        Resultado case1;
        Resultado paraelpara;
        Boolean romp = false; Boolean cont = false;
        private static int contador;
        private static String grafo;
        private static int numero;
        public static ArrayList elTipo;
        public static ArrayList elValor;
        Resultado palMetyFunc;
        public static StreamWriter sw;

        public Programa(RichTextBox consola, RichTextBox consola2,ParseTreeNode raiz)
        {
            sw = new StreamWriter("C:/Users/pablo/Desktop/CompiJunio/[Compi1]Proyecto2/Imagenes.html");
            sw.WriteLine("<html>");
            sw.WriteLine("<title>Reporte de Imagenes</title>");
            sw.WriteLine("<body background="+"\"" + "large-background-1024x724.jpg" + "\"" +">");
            sw.WriteLine("<h1><center>Reporte de Imagenes</center></h1>");
            sw.WriteLine("<center><table border=\"2\">");
            sw.WriteLine("<tr>");
            sw.WriteLine("<th>Tipo</th>");
            sw.WriteLine("<th>Nombre</th>");
            sw.WriteLine("<th>Imagen</th>");
            sw.WriteLine("</tr>");
            this.consola = consola;
            this.consola2 = consola2;
            metodos = new List<Metodo>();
            funciones = new List<Funcion>();
            tablaGlobal = new TablaSimbolo();
            pilaAmbito = new Stack<string>();
            primeraEjecucion(raiz.ChildNodes[0].ChildNodes[0]);
            Metodo principal = buscarPrincipal();
            if (principal != null)
            {
                tablaLocal = new TablaSimbolo();
                pilaAmbito.Push("Principal");
                ejecutar(principal.raiz.ChildNodes[2]);
                pilaAmbito.Pop();
            }
            else
            {
                consola.Text = consola.Text + "\n" + "No hay metodo principal";
                Form1.erroresSem.Add("No hay metodo principal");
                Form1.fila.Add(raiz.Span.Location.Line + 1);
                Form1.columna.Add(raiz.Span.Location.Column + 1);
            }
            sw.WriteLine("</table></center>");
            sw.WriteLine("</body>");
            sw.WriteLine("</html>");
            sw.Close();
        }

        public void primeraEjecucion(ParseTreeNode raiz)
        {
            String tipoAccion = "";
            String tipo;
            String nombre;
            String ambito;
            Array listaID;
            Resultado resultado;
            foreach (ParseTreeNode nodo in raiz.ChildNodes)
            {
                tipoAccion = nodo.Term.Name;
                switch (tipoAccion)
                {
                    case "DEFINIR":
                        if (nodo.ChildNodes[1].Term.Name == "numero")
                        {
                            incerteza = Double.Parse(nodo.ChildNodes[1].Token.Text + "");
                        }
                        break;
                    case "METODO":
                        tipo = nodo.ChildNodes[0].Token.Text;
                        nombre = nodo.ChildNodes[1].Token.Text;
                        ambito = "global";

                        Metodo m = new Metodo(tipo, nombre, ambito, nodo);
                        if (!existeMetodo(nombre))
                        {
                            metodos.Add(m);
                            //ejecutar(nodo.ChildNodes[2]);
                        }
                        else
                        {
                            consola.Text = consola.Text + "\n" + "El metodo " + nombre + " ya existe";
                            Form1.erroresSem.Add("La metodo " + nombre + " ya existe.");
                            Form1.fila.Add(nodo.Span.Location.Line + 1);
                            Form1.columna.Add(nodo.Span.Location.Column + 1);
                        }
                        break;
                    case "FUNCION":
                        tipo = nodo.ChildNodes[0].Token.Text;
                        nombre = nodo.ChildNodes[1].Token.Text;
                        ambito = "global";
                        Funcion f = new Funcion(tipo, nombre, ambito, null, nodo);
                        if (!existeFuncion(nombre))
                        {
                            funciones.Add(f);
                            //ejecutar(nodo.ChildNodes[2]);
                        }
                        else
                        {
                            consola.Text = consola.Text + "\n" + "La funcion " + nombre + " ya existe";
                            Form1.erroresSem.Add("La funcion " + nombre + " ya existe.");
                            Form1.fila.Add(nodo.Span.Location.Line + 1);
                            Form1.columna.Add(nodo.Span.Location.Column + 1);
                        }
                        break;
                    case "PRINCIPAL":
                        tipo = nodo.ChildNodes[0].Token.Text;
                        nombre = nodo.ChildNodes[1].Token.Text;
                        ambito = "global";

                        Metodo prin = new Metodo(tipo, nombre, ambito, nodo);
                        if (!existeMetodo(nombre))
                        {
                            metodos.Add(prin);
                        }
                        else
                        {
                            consola.Text = consola.Text + "\n" + "El metodo " + nombre + " ya existe";
                            Form1.erroresSem.Add("La metodo " + nombre + " ya existe.");
                            Form1.fila.Add(nodo.Span.Location.Line + 1);
                            Form1.columna.Add(nodo.Span.Location.Column + 1);
                        }

                        break;
                    case "DECLARACION":
                        lista = "";
                        ejecutar(nodo.ChildNodes[1]);
                        tipo = nodo.ChildNodes[0].Token.Text;
                        ambito = "global";
                        listaID = lista.Split(',');
                        foreach (string item in listaID)
                        {
                            try
                            {
                                if (item.ToString() != "")
                                {
                                    nombre = item.ToString();
                                    Simbolo simbolo = new Simbolo(tipo, nombre, ambito, null);
                                    Boolean estado = tablaGlobal.addSimbolo(simbolo);
                                    if (!estado)
                                    {
                                        consola.Text = consola.Text + "\n" + "La variable " + nombre + " ya existe.";
                                        Form1.erroresSem.Add("La variable " + nombre + " ya existe.");
                                        Form1.fila.Add(nodo.Span.Location.Line + 1);
                                        Form1.columna.Add(nodo.Span.Location.Column + 1);
                                    }
                                    else
                                    {
                                        consola.Text = consola.Text + "\n" + "Se guardo la variable " + nombre + ".";
                                    }
                                }
                                else
                                {
                                    break;
                                }
                            }
                            catch (Exception e) { consola.Text = consola.Text + "\n" + e; }
                        }
                        break;
                    case "ASIGNACION":
                        if (nodo.ChildNodes[0].Token.Text == "Entero" || nodo.ChildNodes[0].Token.Text == "Decimal" || nodo.ChildNodes[0].Token.Text == "Texto" || nodo.ChildNodes[0].Token.Text == "Caracter" || nodo.ChildNodes[0].Token.Text == "Booleano")
                        {
                            lista = "";
                            ejecutar(nodo.ChildNodes[1]);
                            tipo = nodo.ChildNodes[0].Token.Text;
                            resultado = relacional(nodo.ChildNodes[2]);
                            ambito = "global";
                            listaID = lista.Split(',');
                            if (resultado == null)
                            {
                                consola.Text = consola.Text + "\n" + "El tipo de variable no coincide";
                                Form1.erroresSem.Add("El tipo de variable no coincide");
                                Form1.fila.Add(nodo.Span.Location.Line + 1);
                                Form1.columna.Add(nodo.Span.Location.Column + 1);
                            }
                            else
                            {
                                foreach (string item in listaID)
                                {
                                    try
                                    {
                                        if (item.ToString() != "")
                                        {
                                            nombre = item.ToString();
                                            Simbolo simbolo = new Simbolo(tipo, nombre, ambito, resultado.valor);
                                            Boolean estado = tablaGlobal.addSimbolo(simbolo);
                                            if (!estado)
                                            {
                                                consola.Text = consola.Text + "\n" + "La variable " + nombre + " ya existe.";
                                                Form1.erroresSem.Add("La variable " + nombre + " ya existe.");
                                                Form1.fila.Add(nodo.Span.Location.Line + 1);
                                                Form1.columna.Add(nodo.Span.Location.Column + 1);
                                            }
                                            else
                                            {
                                                consola.Text = consola.Text + "\n" + "Se guardo la variable " + nombre + "= " + resultado.valor;
                                            }
                                        }
                                        else
                                        {
                                            break;
                                        }
                                    }
                                    catch (Exception e) { consola.Text = consola.Text + "\n" + e; }
                                }
                            }
                        }
                        else
                        {
                            nombre = nodo.ChildNodes[0].Token.Text;
                            ambito = "global";
                            Boolean estado1 = tablaGlobal.existe(nombre);
                            if (estado1)
                            {
                                resultado = relacional(nodo.ChildNodes[1]);
                                if (resultado == null)
                                {
                                    consola.Text = consola.Text + "\n" + "El tipo de variable no coincide";
                                    Form1.erroresSem.Add("El tipo de variable no coincide");
                                    Form1.fila.Add(nodo.Span.Location.Line + 1);
                                    Form1.columna.Add(nodo.Span.Location.Column + 1);
                                }
                                else
                                {
                                    tablaGlobal.removeSimbolo(nombre);
                                    Simbolo simbolo = new Simbolo(resultado.tipo, nombre, ambito, resultado.valor);
                                    Boolean estado = tablaGlobal.addSimbolo(simbolo);
                                    if (!estado)
                                    {
                                        consola.Text = consola.Text + "\n" + "La variable " + nombre + " no existe.";
                                        Form1.erroresSem.Add("La variable " + nombre + " no existe.");
                                        Form1.fila.Add(nodo.Span.Location.Line + 1);
                                        Form1.columna.Add(nodo.Span.Location.Column + 1);
                                    }
                                    else
                                    {
                                        consola.Text = consola.Text + "\n" + "Se actualizo la variable " + nombre + " = " + resultado.valor + ".";
                                    }
                                }
                            }
                            else
                            {
                                consola.Text = consola.Text + "\n" + "La variable " + nombre + " no existe.";
                                Form1.erroresSem.Add("La variable " + nombre + " no existe.");
                                Form1.fila.Add(nodo.Span.Location.Line + 1);
                                Form1.columna.Add(nodo.Span.Location.Column + 1);
                            }
                        }
                        break;
                }
            }
        }

        public Resultado ejecutar(ParseTreeNode raiz)
        {
            String tipoAccion = "";
            String tipo;
            String nombre;
            String ambito;
            Array listaID;
            Resultado resultado;
            foreach (ParseTreeNode nodo in raiz.ChildNodes)
            {
                tipoAccion = nodo.Term.Name;
                switch (tipoAccion)
                {
                    case "DECLARACION":
                        lista = "";
                        ejecutar(nodo.ChildNodes[1]);
                        tipo = nodo.ChildNodes[0].Token.Text;
                        ambito = "local";
                        listaID = lista.Split(',');
                        foreach (string item in listaID)
                        {
                            try
                            {
                                if (item.ToString() != "")
                                {
                                    nombre = item.ToString();
                                    Simbolo simbolo = new Simbolo(tipo, nombre, ambito, null);
                                    if (tablaGlobal.getSimbolo(nombre) == null)
                                    {
                                        Boolean estado = tablaLocal.addSimbolo(simbolo);
                                        if (!estado)
                                        {
                                            consola.Text = consola.Text + "\n" + "La variable " + nombre + " ya existe.";
                                            Form1.erroresSem.Add("La variable " + nombre + " ya existe.");
                                            Form1.fila.Add(nodo.Span.Location.Line + 1);
                                            Form1.columna.Add(nodo.Span.Location.Column + 1);
                                        }
                                        else
                                        {
                                            consola.Text = consola.Text + "\n" + "Se guardo la variable " + nombre + ".";
                                        }
                                    }
                                    else
                                    {
                                        consola.Text = consola.Text + "\n" + "La variable " + nombre + " ya existe.";
                                        Form1.erroresSem.Add("La variable " + nombre + " ya existe.");
                                        Form1.fila.Add(nodo.Span.Location.Line + 1);
                                        Form1.columna.Add(nodo.Span.Location.Column + 1);
                                    }
                                }
                                else
                                {
                                    break;
                                }
                            }
                            catch (Exception e) { consola.Text = consola.Text + "\n" + e; }
                        }
                        break;
                    case "DECLA":
                        tipo = nodo.ChildNodes[0].Token.Text;
                        ambito = "local";
                        nombre = nodo.ChildNodes[1].Token.Text;
                        Simbolo sim = new Simbolo(tipo, nombre, ambito, null);
                        Boolean est = tablaLocal.addSimbolo(sim);
                        if (!est)
                        {
                            consola.Text = consola.Text + "\n" + "La variable " + nombre + " ya existe.";
                            Form1.erroresSem.Add("La variable " + nombre + " ya existe.");
                            Form1.fila.Add(nodo.Span.Location.Line + 1);
                            Form1.columna.Add(nodo.Span.Location.Column + 1);
                        }
                        else
                        {
                            consola.Text = consola.Text + "\n" + "Se guardo la variable " + nombre + ".";
                        }
                        break;
                    case "ASIGNACION":
                        if (nodo.ChildNodes[0].Token.Text == "Entero" || nodo.ChildNodes[0].Token.Text == "Decimal" || nodo.ChildNodes[0].Token.Text == "Texto" || nodo.ChildNodes[0].Token.Text == "Caracter" || nodo.ChildNodes[0].Token.Text == "Booleano")
                        {
                            lista = "";
                            ejecutar(nodo.ChildNodes[1]);
                            tipo = nodo.ChildNodes[0].Token.Text;
                            resultado = relacional(nodo.ChildNodes[2]);
                            ambito = "local";
                            listaID = lista.Split(',');
                            if (resultado == null)
                            {
                                consola.Text = consola.Text + "\n" + "El tipo de variable no coincide";
                                Form1.erroresSem.Add("EL tipo de variable no coincide");
                                Form1.fila.Add(nodo.Span.Location.Line + 1);
                                Form1.columna.Add(nodo.Span.Location.Column + 1);
                            }
                            else
                            {
                                foreach (string item in listaID)
                                {
                                    try
                                    {
                                        if (item.ToString() != "")
                                        {
                                            nombre = item.ToString();
                                            Simbolo simbolo = new Simbolo(tipo, nombre, ambito, resultado.valor);
                                            Boolean estado = tablaLocal.addSimbolo(simbolo);
                                            if (!estado)
                                            {
                                                consola.Text = consola.Text + "\n" + "La variable " + nombre + " ya existe.";
                                                Form1.erroresSem.Add("La variable " + nombre + " ya existe.");
                                                Form1.fila.Add(nodo.Span.Location.Line + 1);
                                                Form1.columna.Add(nodo.Span.Location.Column + 1);
                                            }
                                            else
                                            {
                                                consola.Text = consola.Text + "\n" + "Se guardo la variable " + nombre + "= " + resultado.valor;
                                            }
                                        }
                                        else
                                        {
                                            break;
                                        }
                                    }
                                    catch (Exception e) { consola.Text = consola.Text + "\n" + e; }
                                }
                            }
                        }
                        else
                        {
                            nombre = nodo.ChildNodes[0].Token.Text;
                            ambito = "global";
                            Boolean estado1 = tablaGlobal.existe(nombre);
                            Boolean estado2 = tablaLocal.existe(nombre);
                            if (estado1)
                            {
                                resultado = relacional(nodo.ChildNodes[1]);
                                if (resultado == null)
                                {
                                    consola.Text = consola.Text + "\n" + "El tipo de variable no coincide";
                                    Form1.erroresSem.Add("El tipo de variable no coincide");
                                    Form1.fila.Add(nodo.Span.Location.Line + 1);
                                    Form1.columna.Add(nodo.Span.Location.Column + 1);
                                }
                                else
                                {
                                    tablaGlobal.removeSimbolo(nombre);
                                    Simbolo simbolo = new Simbolo(resultado.tipo, nombre, ambito, resultado.valor);
                                    Boolean estado = tablaGlobal.addSimbolo(simbolo);
                                    if (!estado)
                                    {
                                        consola.Text = consola.Text + "\n" + "La variable " + nombre + " no existe.";
                                        Form1.erroresSem.Add("La variable " + nombre + " no existe.");
                                        Form1.fila.Add(nodo.Span.Location.Line + 1);
                                        Form1.columna.Add(nodo.Span.Location.Column + 1);
                                    }
                                    else
                                    {
                                        consola.Text = consola.Text + "\n" + "Se actualizo la variable " + nombre + " = " + resultado.valor + ".";
                                    }
                                }
                            }
                            else if (estado2)
                            {
                                resultado = relacional(nodo.ChildNodes[1]);
                                if (resultado == null)
                                {
                                    consola.Text = consola.Text + "\n" + "El tipo de variable no coincide";
                                    Form1.erroresSem.Add("El tipo de variable no coincide");
                                    Form1.fila.Add(nodo.Span.Location.Line + 1);
                                    Form1.columna.Add(nodo.Span.Location.Column + 1);
                                }
                                else
                                {
                                    tablaLocal.removeSimbolo(nombre);
                                    Simbolo simbolo = new Simbolo(resultado.tipo, nombre, "local", resultado.valor);
                                    Boolean estado = tablaLocal.addSimbolo(simbolo);
                                    if (!estado)
                                    {
                                        consola.Text = consola.Text + "\n" + "La variable " + nombre + " no existe.";
                                        Form1.erroresSem.Add("La variable " + nombre + " no existe.");
                                        Form1.fila.Add(nodo.Span.Location.Line + 1);
                                        Form1.columna.Add(nodo.Span.Location.Column + 1);
                                    }
                                    else
                                    {
                                        consola.Text = consola.Text + "\n" + "Se actualizo la variable " + nombre + " = " + resultado.valor + ".";
                                    }
                                }
                            }
                            else
                            {
                                consola.Text = consola.Text + "\n" + "La variable " + nombre + " no existe.";
                                Form1.erroresSem.Add("La variable " + nombre + " no existe.");
                                Form1.fila.Add(nodo.Span.Location.Line + 1);
                                Form1.columna.Add(nodo.Span.Location.Column + 1);
                            }
                        }
                        break;
                    case "id":
                        lista = lista + nodo.Token.Text.Replace("\"", "") + ",";
                        break;
                    case "E":
                        resultado = operar(nodo.ChildNodes[0]);
                        TablaSimbolo auxE = tablaGlobal;
                        tablaGlobal = new TablaSimbolo();
                        tablaGlobal.cambiarAmbito(auxE);
                        if (resultado == null)
                        {
                            consola.Text = consola.Text + "\n" + "El tipo de variable no coincide";
                            Form1.erroresSem.Add("El tipo de variable no coincide");
                            Form1.fila.Add(nodo.Span.Location.Line + 1);
                            Form1.columna.Add(nodo.Span.Location.Column + 1);
                        }
                        tablaGlobal = auxE;
                        break;
                    case "SI":
                        resultado = relacional(nodo.ChildNodes[1]);
                        TablaSimbolo aux = tablaLocal;
                        //creo una nueva tabla para cambiar al ambito if
                        tablaLocal = new TablaSimbolo();
                        tablaLocal.cambiarAmbito(aux);
                        if (resultado == null)
                        {
                            consola.Text = consola.Text + "\n" + "El tipo de variable no coincide";
                            Form1.erroresSem.Add("El tipo de variable no coincide");
                            Form1.fila.Add(nodo.Span.Location.Line + 1);
                            Form1.columna.Add(nodo.Span.Location.Column + 1);
                        }
                        else
                        {
                            if (Boolean.Parse(resultado.valor + ""))
                            {
                                ejecutar(nodo.ChildNodes[2]);
                            }
                            else
                            {
                                if (nodo.ChildNodes[3].ChildNodes.Count > 0)
                                {
                                    ejecutar(nodo.ChildNodes[3].ChildNodes[1]);
                                }
                            }
                        }
                        tablaLocal = aux;
                        break;
                    case "MIENTRAS":
                        romp = false; cont = false;
                        resultado = relacional(nodo.ChildNodes[1]);
                        TablaSimbolo aux2 = tablaLocal;
                        tablaLocal = new TablaSimbolo();
                        tablaLocal.cambiarAmbito(aux2);
                        if (resultado == null)
                        {
                            consola.Text = consola.Text + "\n" + "El tipo de variable no coincide";
                            Form1.erroresSem.Add("El tipo de variable no coincide");
                            Form1.fila.Add(nodo.Span.Location.Line + 1);
                            Form1.columna.Add(nodo.Span.Location.Column + 1);
                        }
                        else
                        {
                            while (Boolean.Parse(resultado.valor + ""))
                            {
                                resultado = relacional(nodo.ChildNodes[1]);
                                ejecutar(nodo.ChildNodes[2]);                               
                                resultado = relacional(nodo.ChildNodes[1]);
                                if (romp) { break; }
                                if (cont) { continue; }

                            }
                        }
                        tablaLocal = aux2;
                        break;
                    case "INTERRUMPIR":
                        resultado = operar(nodo.ChildNodes[1]);
                        TablaSimbolo aux2x = tablaLocal;
                        tablaLocal = new TablaSimbolo();
                        tablaLocal.cambiarAmbito(aux2x);
                        Boolean seHizo = false;
                        for (int i = 0; i < nodo.ChildNodes[2].ChildNodes.Count; i++)
                        {
                            case1 = operar(nodo.ChildNodes[2].ChildNodes[i].ChildNodes[1]);
                            if (case1.valor.ToString() == resultado.valor.ToString())
                            {
                                romp = false; cont = false;
                                ejecutar(nodo.ChildNodes[2].ChildNodes[i].ChildNodes[2]);
                                seHizo = true;
                                if (romp) { break; }
                            }
                        }
                        if (seHizo == false && nodo.ChildNodes[3].ChildNodes[0].Token.Text == "No_cumple")
                        {
                            romp = false; cont = false;
                            ejecutar(nodo.ChildNodes[3].ChildNodes[1]);
                            if (romp) { break; }
                        }
                        tablaLocal = aux2x;
                        break;
                    case "PARA":
                        romp = false; cont = false;
                        resultado = new Resultado(null, null);
                        tipo = nodo.ChildNodes[1].ChildNodes[0].Token.Text;
                        nombre = nodo.ChildNodes[1].ChildNodes[1].ChildNodes[0].Token.Text;
                        resultado = relacional(nodo.ChildNodes[1].ChildNodes[2]);
                        Simbolo so = new Simbolo(resultado.tipo, nombre, "local", resultado.valor);
                        Boolean epale = tablaLocal.addSimbolo(so);
                        paraelpara = relacional(nodo.ChildNodes[2]);
                        TablaSimbolo aux22x = tablaLocal;
                        tablaLocal = new TablaSimbolo();
                        tablaLocal.cambiarAmbito(aux22x);
                        if (paraelpara == null)
                        {
                            consola.Text = consola.Text + "\n" + "El tipo de variable no coincide";
                            Form1.erroresSem.Add("El tipo de variable no coincide");
                            Form1.fila.Add(nodo.Span.Location.Line + 1);
                            Form1.columna.Add(nodo.Span.Location.Column + 1);
                        }
                        else
                        {
                            do
                            {
                                paraelpara = relacional(nodo.ChildNodes[2]);
                                ejecutar(nodo.ChildNodes[4]);
                                if (nodo.ChildNodes[3].ChildNodes[0].Token.Text == "++")
                                {
                                    resultado.valor = Double.Parse(resultado.valor + "") + 1;
                                    tablaLocal.removeSimbolo(nombre);
                                    Simbolo so2 = new Simbolo(resultado.tipo, nombre, "local", resultado.valor);
                                    Boolean epale2 = tablaLocal.addSimbolo(so2);
                                }
                                else
                                {
                                    resultado.valor = Double.Parse(resultado.valor + "") - 1;
                                    tablaLocal.removeSimbolo(nombre);
                                    Simbolo so2 = new Simbolo(resultado.tipo, nombre, "local", resultado.valor);
                                    Boolean epale2 = tablaLocal.addSimbolo(so2);
                                }
                                paraelpara = relacional(nodo.ChildNodes[2]);
                                if (romp) { break; }
                                if (cont) { continue; }
                            } while (Boolean.Parse(paraelpara.valor + ""));
                        }
                        tablaLocal = aux22x;
                        break;
                    case "HACER":
                        romp = false; cont = false;
                        resultado = relacional(nodo.ChildNodes[1]);
                        TablaSimbolo aux24 = tablaLocal;
                        tablaLocal = new TablaSimbolo();
                        tablaLocal.cambiarAmbito(aux24);
                        if (resultado == null)
                        {
                            consola.Text = consola.Text + "\n" + "El tipo de variable no coincide";
                            Form1.erroresSem.Add("El tipo de variable no coincide");
                            Form1.fila.Add(nodo.Span.Location.Line + 1);
                            Form1.columna.Add(nodo.Span.Location.Column + 1);
                        }
                        else
                        {
                            do
                            {
                                resultado = relacional(nodo.ChildNodes[1]);
                                ejecutar(nodo.ChildNodes[2]);
                                resultado = relacional(nodo.ChildNodes[1]);
                                if (romp) { break; }
                                if (cont) { continue; }

                            } while (!Boolean.Parse(resultado.valor + ""));
                        }
                        tablaLocal = aux24;
                        break;
                    case "MOSTRAR":
                        ParseTreeNode auxiliar;
                        ArrayList most = new ArrayList();
                        String laCadena = "";
                        laCadena = nodo.ChildNodes[1].Token.Text;
                        if (nodo.ChildNodes.Count == 3) {
                            if (nodo.ChildNodes[2].ChildNodes.Count > 0)
                            {
                                auxiliar = nodo.ChildNodes[2];
                                for (int i = 0; i < auxiliar.ChildNodes.Count; i++)
                                {
                                    most.Add(operar(auxiliar.ChildNodes[i]).valor);
                                }

                                for (int x = 0; x < most.Count; x++)
                                {
                                    laCadena = laCadena.Replace("{" + x + "}", most[x].ToString());
                                }
                            }
                        }
                        laCadena = laCadena.Replace("\"", "");
                        consola.Text = consola.Text + "\n" + laCadena;
                        consola2.Text = consola2.Text + "\n" + laCadena;
                        break;
                    case "LLAMFUNC":
                        elTipo = new ArrayList();
                        elValor = new ArrayList();
                        if (nodo.ChildNodes[0].ChildNodes[1].ChildNodes.Count > 0)
                        {
                            for (int i = 0; i < nodo.ChildNodes[0].ChildNodes[1].ChildNodes.Count; i++)
                            {
                                palMetyFunc = operar(nodo.ChildNodes[0].ChildNodes[1].ChildNodes[i].ChildNodes[0]);
                                elTipo.Add(palMetyFunc.tipo);
                                elValor.Add(palMetyFunc.valor);
                            }
                        }
                        met = buscarMetodo(nodo.ChildNodes[0].ChildNodes[0].Token.Text);
                        func = buscarFuncion(nodo.ChildNodes[0].ChildNodes[0].Token.Text);
                        if (met != null)
                        {
                            tablaLocal = new TablaSimbolo();
                            pilaAmbito.Push(nodo.ChildNodes[0].ChildNodes[0].Token.Text);
                            if (nodo.ChildNodes[0].ChildNodes[1].ChildNodes.Count > 0 && nodo.ChildNodes[0].ChildNodes[1].ChildNodes.Count == met.raiz.ChildNodes[2].ChildNodes.Count)
                            {
                                for (int i = 0; i < nodo.ChildNodes[0].ChildNodes[1].ChildNodes.Count; i++)
                                {
                                    String nombrej = met.raiz.ChildNodes[2].ChildNodes[i].ChildNodes[1].Token.Text;
                                    Simbolo simj = new Simbolo(elTipo[i].ToString(), nombrej, "local", elValor[i].ToString());
                                    Boolean estj = tablaLocal.addSimbolo(simj);
                                    if (!estj)
                                    {
                                        consola.Text = consola.Text + "\n" + "La variable " + nombrej + " ya existe.";
                                        Form1.erroresSem.Add("La variable " + nombrej + " ya existe.");
                                        Form1.fila.Add(raiz.Span.Location.Line + 1);
                                        Form1.columna.Add(raiz.Span.Location.Column + 1);
                                    }
                                    else
                                    {
                                        consola.Text = consola.Text + "\n" + "Se guardo la variable " + nombrej + ".";
                                    }
                                }
                            }
                            ejecutar(met.raiz.ChildNodes[3]);
                            pilaAmbito.Pop();
                        }
                        else if (func != null)
                        {
                            tablaLocal = new TablaSimbolo();
                            pilaAmbito.Push(nodo.ChildNodes[0].ChildNodes[0].Token.Text);
                            if (nodo.ChildNodes[0].ChildNodes[1].ChildNodes.Count > 0 && nodo.ChildNodes[0].ChildNodes[1].ChildNodes.Count == func.raiz.ChildNodes[2].ChildNodes.Count)
                            {
                                for (int i = 0; i < nodo.ChildNodes[0].ChildNodes[1].ChildNodes.Count; i++)
                                {
                                    String nombrej = func.raiz.ChildNodes[2].ChildNodes[i].ChildNodes[1].Token.Text;
                                    Simbolo simj = new Simbolo(elTipo[i].ToString(), nombrej, "local", elValor[i].ToString());
                                    Boolean estj = tablaLocal.addSimbolo(simj);
                                    if (!estj)
                                    {
                                        consola.Text = consola.Text + "\n" + "La variable " + nombrej + " ya existe.";
                                        Form1.erroresSem.Add("La variable " + nombrej + " ya existe.");
                                        Form1.fila.Add(raiz.Span.Location.Line + 1);
                                        Form1.columna.Add(raiz.Span.Location.Column + 1);
                                    }
                                    else
                                    {
                                        consola.Text = consola.Text + "\n" + "Se guardo la variable " + nombrej + ".";
                                    }
                                }
                            }
                            ejecutar(func.raiz.ChildNodes[3]);
                            resultado = Otroresultado;
                            pilaAmbito.Pop();
                            if (resultado != null)
                            {
                                consola.Text = consola.Text + "\n" + "Se retorna: " + resultado.valor;
                                return resultado;
                            }
                            else
                            {
                                Form1.erroresSem.Add("Error en el retorno");
                                Form1.fila.Add(nodo.Span.Location.Line + 1);
                                Form1.columna.Add(nodo.Span.Location.Column + 1);
                            }
                        }
                        else
                        {
                            consola.Text = consola.Text + "\n" + "No existe el metodo o funcion a llamar";
                            Form1.erroresSem.Add("No existe el metodo o funcion a llamar");
                            Form1.fila.Add(nodo.Span.Location.Line + 1);
                            Form1.columna.Add(nodo.Span.Location.Column + 1);
                        }
                        break;
                    case "DIBUJAR":
                        switch (nodo.ChildNodes[0].Term.Name)
                        {
                            case "DibujarAST":
                                met = buscarMetodo(nodo.ChildNodes[1].Token.Text);
                                func = buscarFuncion(nodo.ChildNodes[1].Token.Text);
                                if (met != null)
                                {
                                    tablaLocal = new TablaSimbolo();
                                    pilaAmbito.Push(nodo.ChildNodes[1].Token.Text);
                                    Sintactico.generarImagenAST(met.raiz, nodo.ChildNodes[1].Token.Text);
                                    pilaAmbito.Pop();
                                }
                                else if (func != null)
                                {
                                    tablaLocal = new TablaSimbolo();
                                    pilaAmbito.Push(nodo.ChildNodes[1].Token.Text);
                                    Sintactico.generarImagenAST(met.raiz, nodo.ChildNodes[1].Token.Text);
                                    pilaAmbito.Pop();
                                }
                                else
                                {
                                    consola.Text = consola.Text + "\n" + "No existe el metodo o funcion a llamar";
                                    Form1.erroresSem.Add("No existe el metodo o funcion a llamar");
                                    Form1.fila.Add(nodo.Span.Location.Line + 1);
                                    Form1.columna.Add(nodo.Span.Location.Column + 1);
                                }
                                break;
                            case "DibujarEXP":
                                numero++;
                                Sintactico.generarImagenEXP(nodo.ChildNodes[1], numero);
                                break;
                            case "DibujarTS":
                                break;
                        }
                        break;
                    case "SALIR":
                        if (nodo.ChildNodes[0].Token.Text == "Continuar")
                        {
                            cont = true;
                        }
                        else if (nodo.ChildNodes[0].Token.Text == "Romper")
                        {
                            romp = true;
                        }
                        break;
                    case "RETORNO":
                        func = new Funcion(null, null, null, null, null);
                        resultado = relacional(nodo.ChildNodes[1]);
                        Otroresultado = resultado;
                        if (resultado == null)
                        {
                            consola.Text = consola.Text + "\n" + "Retorno no valido";
                            Form1.erroresSem.Add("Retorno no valido");
                            Form1.fila.Add(nodo.Span.Location.Line + 1);
                            Form1.columna.Add(nodo.Span.Location.Column + 1);
                            return resultado;
                        }
                        else
                        {
                            consola.Text = consola.Text + "\n" + "Se retorna: " + resultado.valor;
                            func.retorno = resultado.valor;
                            return resultado;
                        }
                    case "ATRIBUTO":
                        ejecutar(nodo);
                        break;
                }
            }
            return null;
        }

        public Metodo buscarPrincipal()
        {
            foreach (Metodo m in metodos)
            {
                if (m.nombre == "Principal")
                {
                    return m;
                }

            }

            return null;
        }

        public static Metodo buscarMetodo(String nombre)
        {
            foreach (Metodo m in metodos)
            {
                if (m.nombre == nombre)
                {
                    return m;
                }

            }

            return null;
        }

        public static Funcion buscarFuncion(String nombre)
        {
            foreach (Funcion f in funciones)
            {
                if (f.nombre == nombre)
                {
                    return f;
                }

            }

            return null;
        }

        public Boolean existeMetodo(String nombre)
        {
            foreach (Metodo m in metodos)
            {
                if (nombre == m.nombre)
                {
                    return true;
                }
            }

            return false;

        }

        public Boolean existeFuncion(String nombre)
        {
            foreach (Funcion f in funciones)
            {
                if (nombre == f.nombre)
                {
                    return true;
                }
            }

            return false;

        }

        public Resultado operar(ParseTreeNode raiz)
        {
            Resultado resultado1 = null;
            Resultado resultado2 = null;
            Resultado resultado = null;

            switch (raiz.Term.Name)
            {
                case "E":
                    if (raiz.ChildNodes.Count == 3)
                    {
                        resultado1 = operar(raiz.ChildNodes[0]);
                        resultado2 = operar(raiz.ChildNodes[2]);
                    }
                    else if (raiz.ChildNodes.Count == 2)
                    {
                        resultado = operar(raiz.ChildNodes[1]);
                        resultado.valor = 0 - Double.Parse(resultado.valor + "");
                        return resultado;
                    }
                    else
                    {
                        return operar(raiz.ChildNodes[0]);
                    }
                    break;
                case "numero":
                    return new Resultado("Decimal", raiz.Token.Text);
                case "cadena":
                    String cadena = raiz.Token.Text.Replace("\"", "");
                    return new Resultado("Texto", cadena);
                case "caracter":
                    String carac = raiz.Token.Text.Replace("\'", "");
                    return new Resultado("Caracter", carac);
                case "booleano":
                    return new Resultado("Booleano", raiz.Token.Text);
                case "id":
                    String iden = raiz.Token.Text.Replace("\"", "");
                    if (tablaGlobal.getSimbolo(iden) != null)
                    {
                        return new Resultado(tablaGlobal.getSimbolo(iden).tipo, tablaGlobal.getSimbolo(iden).valor);
                    }
                    else if (tablaLocal.getSimbolo(iden) != null)
                    {
                        return new Resultado(tablaLocal.getSimbolo(iden).tipo, tablaLocal.getSimbolo(iden).valor);
                    }
                    else
                    {
                        return null;
                    }
                case "LLAMADA":
                    elTipo = new ArrayList();
                    elValor = new ArrayList();
                    
                    func = buscarFuncion(raiz.ChildNodes[0].Token.Text);
                    if (func != null && raiz.ChildNodes[0].Token.Text != "factorial" && raiz.ChildNodes[0].Token.Text != "fibonacci" && raiz.ChildNodes[0].Token.Text != "permutacion" && raiz.ChildNodes[0].Token.Text != "division")
                    {
                        if (raiz.ChildNodes[1].ChildNodes.Count > 0)
                        {
                            for (int i = 0; i < raiz.ChildNodes[1].ChildNodes.Count; i++)
                            {
                                palMetyFunc = operar(raiz.ChildNodes[1].ChildNodes[i].ChildNodes[0]);
                                elTipo.Add(palMetyFunc.tipo);
                                elValor.Add(palMetyFunc.valor);
                            }
                        }
                        tablaLocal = new TablaSimbolo();
                        pilaAmbito.Push(raiz.ChildNodes[0].Token.Text);
                        if (raiz.ChildNodes[1].ChildNodes.Count > 0 && raiz.ChildNodes[1].ChildNodes.Count == func.raiz.ChildNodes[2].ChildNodes.Count)
                        {
                            for (int i = 0; i < raiz.ChildNodes[1].ChildNodes.Count; i++)
                            {
                                String nombre = func.raiz.ChildNodes[2].ChildNodes[i].ChildNodes[1].Token.Text;
                                Simbolo sim = new Simbolo(elTipo[i].ToString(), nombre, "local", elValor[i].ToString());
                                Boolean est = tablaLocal.addSimbolo(sim);
                                if (!est)
                                {
                                    consola.Text = consola.Text + "\n" + "La variable " + nombre + " ya existe.";
                                    Form1.erroresSem.Add("La variable " + nombre + " ya existe.");
                                    Form1.fila.Add(raiz.Span.Location.Line + 1);
                                    Form1.columna.Add(raiz.Span.Location.Column + 1);
                                }
                                else
                                {
                                    consola.Text = consola.Text + "\n" + "Se guardo la variable " + nombre + ".";
                                }
                            }
                        }
                        ejecutar(func.raiz.ChildNodes[3]);
                        resultado = Otroresultado;
                        pilaAmbito.Pop();
                        if (resultado != null)
                        {
                            consola.Text = consola.Text + "\n" + "Se retorna: " + resultado.valor;
                            return resultado;
                        }
                        else
                        {
                            Form1.erroresSem.Add("Error en el retorno");
                            Form1.fila.Add(raiz.Span.Location.Line + 1);
                            Form1.columna.Add(raiz.Span.Location.Column + 1);
                        }
                    }
                    else if (raiz.ChildNodes[0].Token.Text == "factorial")
                    {
                        Otroresultado = new Resultado("Entero", factorial(Int32.Parse(operar(raiz.ChildNodes[1].ChildNodes[0]).valor.ToString())));
                        resultado = Otroresultado;
                        if (resultado != null)
                        {
                            consola.Text = consola.Text + "\n" + "Se retorna: " + resultado.valor;
                            return resultado;
                        }
                    }
                    else if (raiz.ChildNodes[0].Token.Text == "fibonacci")
                    {
                        Otroresultado = new Resultado("Entero", fibonacci(Int32.Parse(operar(raiz.ChildNodes[1].ChildNodes[0]).valor.ToString())));
                        resultado = Otroresultado;
                        if (resultado != null)
                        {
                            consola.Text = consola.Text + "\n" + "Se retorna: " + resultado.valor;
                            return resultado;
                        }
                    }
                    else if (raiz.ChildNodes[0].Token.Text == "permutacion")
                    {
                        Otroresultado = new Resultado("Entero", permutacion(Int32.Parse(operar(raiz.ChildNodes[1].ChildNodes[0]).valor.ToString()), Int32.Parse(operar(raiz.ChildNodes[1].ChildNodes[1]).valor.ToString())));
                        resultado = Otroresultado;
                        if (resultado != null)
                        {
                            consola.Text = consola.Text + "\n" + "Se retorna: " + resultado.valor;
                            return resultado;
                        }
                    }
                    else if (raiz.ChildNodes[0].Token.Text == "division")
                    {
                        Otroresultado = new Resultado("Decimal", division(Int32.Parse(operar(raiz.ChildNodes[1].ChildNodes[0]).valor.ToString()), Int32.Parse(operar(raiz.ChildNodes[1].ChildNodes[1]).valor.ToString())));
                        resultado = Otroresultado;
                        if (resultado != null)
                        {
                            consola.Text = consola.Text + "\n" + "Se retorna: " + resultado.valor;
                            return resultado;
                        }
                    }
                    else
                    {
                        consola.Text = consola.Text + "\n" + "No existe el metodo o funcion a llamar";
                        Form1.erroresSem.Add("No existe el metodo o funcion a llamar");
                        Form1.fila.Add(raiz.Span.Location.Line + 1);
                        Form1.columna.Add(raiz.Span.Location.Column + 1);
                    }
                    break;
            }

            String operacion = raiz.ChildNodes[1].Token.Text;
            String tipo1;
            String tipo2;
            if (resultado1 != null && resultado2 != null)
            {
                switch (operacion)
                {
                    case "+":
                        tipo1 = resultado1.tipo;
                        switch (tipo1)
                        {
                            case "Decimal":
                                tipo2 = resultado2.tipo;
                                switch (tipo2)
                                {
                                    case "Entero":
                                        return new Resultado("Decimal", Double.Parse(resultado1.valor + "") + Double.Parse(resultado2.valor + ""));

                                    case "Decimal":
                                        return new Resultado("Decimal", Double.Parse(resultado1.valor + "") + Double.Parse(resultado2.valor + ""));

                                    case "Texto":
                                        return new Resultado("Texto", Double.Parse(resultado1.valor + "") + (String)resultado2.valor);

                                    case "Caracter":
                                        String uno = resultado2.valor.ToString();
                                        char[] dos = uno.ToCharArray();
                                        resultado2.valor = (int)dos[0] + "";
                                        return new Resultado("Decimal", Double.Parse(resultado1.valor + "") + Double.Parse(resultado2.valor + ""));

                                    case "Booleano":
                                        Double res2;
                                        if (resultado2.valor.ToString() == "true" || resultado2.valor.ToString() == "True")
                                        {
                                            res2 = 1;
                                        }
                                        else
                                        {
                                            res2 = 0;
                                        }
                                        return new Resultado("Decimal", Double.Parse(resultado1.valor + "") + res2);

                                }
                                break;
                            case "Entero":
                                tipo2 = resultado2.tipo;
                                switch (tipo2)
                                {
                                    case "Entero":
                                        return new Resultado("Entero", Double.Parse(resultado1.valor + "") + Double.Parse(resultado2.valor + ""));

                                    case "Decimal":
                                        return new Resultado("Decimal", Double.Parse(resultado1.valor + "") + Double.Parse(resultado2.valor + ""));

                                    case "Texto":
                                        return new Resultado("Texto", Double.Parse(resultado1.valor + "") + (String)resultado2.valor);

                                    case "Caracter":
                                        String uno = resultado2.valor.ToString();
                                        char[] dos = uno.ToCharArray();
                                        resultado2.valor = (int)dos[0] + "";
                                        return new Resultado("Entero", Double.Parse(resultado1.valor + "") + Double.Parse(resultado2.valor + ""));

                                    case "Booleano":
                                        Double res2;
                                        if (resultado2.valor.ToString() == "true" || resultado2.valor.ToString() == "True")
                                        {
                                            res2 = 1;
                                        }
                                        else
                                        {
                                            res2 = 0;
                                        }
                                        return new Resultado("Entero", Double.Parse(resultado1.valor + "") + res2);
                                }
                                break;
                            case "Texto":
                                tipo2 = resultado2.tipo;
                                switch (tipo2)
                                {
                                    case "Entero":
                                        return new Resultado("Texto", (String)resultado1.valor + Double.Parse(resultado2.valor + ""));

                                    case "Decimal":
                                        return new Resultado("Texto", (String)resultado1.valor + Double.Parse(resultado2.valor + ""));

                                    case "Texto":
                                        return new Resultado("Texto", (String)resultado1.valor + (String)resultado2.valor);

                                    case "Caracter":
                                        return new Resultado("Texto", (String)resultado1.valor + (String)resultado2.valor);

                                    case "Booleano":
                                        return new Resultado("Texto", (String)resultado1.valor + resultado2.valor.ToString());

                                }
                                break;
                            case "Caracter":
                                tipo2 = resultado2.tipo;
                                switch (tipo2)
                                {
                                    case "Entero":
                                        String uno1 = resultado1.valor.ToString();
                                        char[] dos1 = uno1.ToCharArray();
                                        resultado1.valor = (int)dos1[0] + "";
                                        return new Resultado("Entero", Double.Parse(resultado1.valor + "") + Double.Parse(resultado2.valor + ""));

                                    case "Decimal":
                                        String uno0 = resultado1.valor.ToString();
                                        char[] dos0 = uno0.ToCharArray();
                                        resultado1.valor = (int)dos0[0] + "";
                                        return new Resultado("Decimal", Double.Parse(resultado1.valor + "") + Double.Parse(resultado2.valor + ""));

                                    case "Texto":
                                        return new Resultado("Texto", (String)resultado1.valor + (String)resultado2.valor);

                                    case "Caracter":
                                        String uno2 = resultado1.valor.ToString();
                                        char[] dos2 = uno2.ToCharArray();
                                        resultado1.valor = (int)dos2[0] + "";
                                        String uno3 = resultado2.valor.ToString();
                                        char[] dos3 = uno3.ToCharArray();
                                        resultado2.valor = (int)dos3[0] + "";
                                        return new Resultado("Entero", Double.Parse(resultado1.valor + "") + Double.Parse(resultado2.valor + ""));

                                    case "Booleano":
                                        String uno = resultado1.valor.ToString();
                                        char[] dos = uno.ToCharArray();
                                        resultado1.valor = (int)dos[0] + "";
                                        Double res2;
                                        if (resultado2.valor.ToString() == "true" || resultado2.valor.ToString() == "True")
                                        {
                                            res2 = 1;
                                        }
                                        else
                                        {
                                            res2 = 0;
                                        }
                                        return new Resultado("Entero", Double.Parse(resultado1.valor + "") + res2);

                                }
                                break;
                            case "Booleano":
                                tipo2 = resultado2.tipo;
                                Double res;
                                if (resultado1.valor.ToString() == "true" || resultado1.valor.ToString() == "True")
                                {
                                    res = 1;
                                }
                                else
                                {
                                    res = 0;
                                }
                                switch (tipo2)
                                {
                                    case "Entero":
                                        return new Resultado("Entero", res + Double.Parse(resultado2.valor + ""));

                                    case "Decimal":
                                        return new Resultado("Decimal", res + Double.Parse(resultado2.valor + ""));

                                    case "Texto":
                                        return new Resultado("Texto", (String)resultado1.valor + (String)resultado2.valor);

                                    case "Caracter":
                                        String uno = resultado2.valor.ToString();
                                        char[] dos = uno.ToCharArray();
                                        resultado2.valor = (int)dos[0] + "";
                                        return new Resultado("Entero", res + Double.Parse(resultado2.valor + ""));

                                    case "Booleano":
                                        return new Resultado("Booleano", (Boolean)resultado1.valor || (Boolean)resultado2.valor);
                                }
                                break;
                        }

                        break;
                    case "*":
                        tipo1 = resultado1.tipo;
                        switch (tipo1)
                        {
                            case "Decimal":
                                tipo2 = resultado2.tipo;
                                switch (tipo2)
                                {
                                    case "Entero":
                                        return new Resultado("Decimal", Double.Parse(resultado1.valor + "") * Double.Parse(resultado2.valor + ""));

                                    case "Decimal":
                                        return new Resultado("Decimal", Double.Parse(resultado1.valor + "") * Double.Parse(resultado2.valor + ""));

                                    case "Texto":
                                        break;
                                    case "Caracter":
                                        String uno = resultado2.valor.ToString();
                                        char[] dos = uno.ToCharArray();
                                        resultado2.valor = (int)dos[0] + "";
                                        return new Resultado("Decimal", Double.Parse(resultado1.valor + "") * Double.Parse(resultado2.valor + ""));

                                    case "Booleano":
                                        Double res2;
                                        if (resultado2.valor.ToString() == "true" || resultado2.valor.ToString() == "True")
                                        {
                                            res2 = 1;
                                        }
                                        else
                                        {
                                            res2 = 0;
                                        }
                                        return new Resultado("Decimal", Double.Parse(resultado1.valor + "") * res2);

                                }
                                break;
                            case "Entero":
                                tipo2 = resultado2.tipo;
                                switch (tipo2)
                                {
                                    case "Entero":
                                        return new Resultado("Entero", Double.Parse(resultado1.valor + "") * Double.Parse(resultado2.valor + ""));

                                    case "Decimal":
                                        return new Resultado("Decimal", Double.Parse(resultado1.valor + "") * Double.Parse(resultado2.valor + ""));

                                    case "Texto":
                                        break;
                                    case "Caracter":
                                        String uno = resultado2.valor.ToString();
                                        char[] dos = uno.ToCharArray();
                                        resultado2.valor = (int)dos[0] + "";
                                        return new Resultado("Entero", Double.Parse(resultado1.valor + "") * Double.Parse(resultado2.valor + ""));

                                    case "Booleano":
                                        Double res2;
                                        if (resultado2.valor.ToString() == "true" || resultado2.valor.ToString() == "True")
                                        {
                                            res2 = 1;
                                        }
                                        else
                                        {
                                            res2 = 0;
                                        }
                                        return new Resultado("Entero", Double.Parse(resultado1.valor + "") * res2);
                                }
                                break;
                            case "Texto":
                                tipo2 = resultado2.tipo;
                                switch (tipo2)
                                {
                                    case "Entero":
                                        break;
                                    case "Decimal":
                                        break;
                                    case "Texto":
                                        break;
                                    case "Caracter":
                                        break;
                                    case "Booleano":
                                        break;
                                }
                                break;
                            case "Caracter":
                                tipo2 = resultado2.tipo;
                                switch (tipo2)
                                {
                                    case "Entero":
                                        String uno1 = resultado1.valor.ToString();
                                        char[] dos1 = uno1.ToCharArray();
                                        resultado1.valor = (int)dos1[0] + "";
                                        return new Resultado("Entero", Double.Parse(resultado1.valor + "") * Double.Parse(resultado2.valor + ""));

                                    case "Decimal":
                                        String uno0 = resultado1.valor.ToString();
                                        char[] dos0 = uno0.ToCharArray();
                                        resultado1.valor = (int)dos0[0] + "";
                                        return new Resultado("Decimal", Double.Parse(resultado1.valor + "") * Double.Parse(resultado2.valor + ""));

                                    case "Texto":
                                        break;
                                    case "Caracter":
                                        String uno2 = resultado1.valor.ToString();
                                        char[] dos2 = uno2.ToCharArray();
                                        resultado1.valor = (int)dos2[0] + "";
                                        String uno3 = resultado2.valor.ToString();
                                        char[] dos3 = uno3.ToCharArray();
                                        resultado2.valor = (int)dos3[0] + "";
                                        return new Resultado("Entero", Double.Parse(resultado1.valor + "") * Double.Parse(resultado2.valor + ""));

                                    case "Booleano":
                                        String uno = resultado1.valor.ToString();
                                        char[] dos = uno.ToCharArray();
                                        resultado1.valor = (int)dos[0] + "";
                                        Double res2;
                                        if (resultado2.valor.ToString() == "true" || resultado2.valor.ToString() == "True")
                                        {
                                            res2 = 1;
                                        }
                                        else
                                        {
                                            res2 = 0;
                                        }
                                        return new Resultado("Entero", Double.Parse(resultado1.valor + "") * res2);

                                }
                                break;
                            case "Booleano":
                                tipo2 = resultado2.tipo;
                                Double res;
                                if (resultado1.valor.ToString() == "true" || resultado1.valor.ToString() == "True")
                                {
                                    res = 1;
                                }
                                else
                                {
                                    res = 0;
                                }
                                switch (tipo2)
                                {
                                    case "Entero":
                                        return new Resultado("Entero", res * Double.Parse(resultado2.valor + ""));

                                    case "Decimal":
                                        return new Resultado("Decimal", res * Double.Parse(resultado2.valor + ""));

                                    case "Texto":
                                        break;
                                    case "Caracter":
                                        String uno = resultado2.valor.ToString();
                                        char[] dos = uno.ToCharArray();
                                        resultado2.valor = (int)dos[0] + "";
                                        return new Resultado("Entero", res * Double.Parse(resultado2.valor + ""));

                                    case "Booleano":
                                        return new Resultado("Booleano", (Boolean)resultado1.valor && (Boolean)resultado2.valor);
                                }
                                break;
                        }
                        break;
                    case "/":
                        tipo1 = resultado1.tipo;
                        switch (tipo1)
                        {
                            case "Decimal":
                                tipo2 = resultado2.tipo;
                                switch (tipo2)
                                {
                                    case "Entero":
                                        return new Resultado("Decimal", Double.Parse(resultado1.valor + "") / Double.Parse(resultado2.valor + ""));

                                    case "Decimal":
                                        return new Resultado("Decimal", Double.Parse(resultado1.valor + "") / Double.Parse(resultado2.valor + ""));

                                    case "Texto":
                                        break;
                                    case "Caracter":
                                        String uno = resultado2.valor.ToString();
                                        char[] dos = uno.ToCharArray();
                                        resultado2.valor = (int)dos[0] + "";
                                        return new Resultado("Decimal", Double.Parse(resultado1.valor + "") / Double.Parse(resultado2.valor + ""));

                                    case "Booleano":
                                        Double res2;
                                        if (resultado2.valor.ToString() == "true" || resultado2.valor.ToString() == "True")
                                        {
                                            res2 = 1;
                                        }
                                        else
                                        {
                                            res2 = 0;
                                        }
                                        return new Resultado("Decimal", Double.Parse(resultado1.valor + "") / res2);

                                }
                                break;
                            case "Entero":
                                tipo2 = resultado2.tipo;
                                switch (tipo2)
                                {
                                    case "Entero":
                                        return new Resultado("Entero", Double.Parse(resultado1.valor + "") / Double.Parse(resultado2.valor + ""));

                                    case "Decimal":
                                        return new Resultado("Decimal", Double.Parse(resultado1.valor + "") / Double.Parse(resultado2.valor + ""));

                                    case "Texto":
                                        break;
                                    case "Caracter":
                                        String uno = resultado2.valor.ToString();
                                        char[] dos = uno.ToCharArray();
                                        resultado2.valor = (int)dos[0] + "";
                                        return new Resultado("Entero", Double.Parse(resultado1.valor + "") / Double.Parse(resultado2.valor + ""));

                                    case "Booleano":
                                        Double res2;
                                        if (resultado2.valor.ToString() == "true" || resultado2.valor.ToString() == "True")
                                        {
                                            res2 = 1;
                                        }
                                        else
                                        {
                                            res2 = 0;
                                        }
                                        return new Resultado("Entero", Double.Parse(resultado1.valor + "") / res2);
                                }
                                break;
                            case "Texto":
                                tipo2 = resultado2.tipo;
                                switch (tipo2)
                                {
                                    case "Entero":
                                        break;
                                    case "Decimal":
                                        break;
                                    case "Texto":
                                        break;
                                    case "Caracter":
                                        break;
                                    case "Booleano":
                                        break;
                                }
                                break;
                            case "Caracter":
                                tipo2 = resultado2.tipo;
                                switch (tipo2)
                                {
                                    case "Entero":
                                        String uno1 = resultado1.valor.ToString();
                                        char[] dos1 = uno1.ToCharArray();
                                        resultado1.valor = (int)dos1[0] + "";
                                        return new Resultado("Entero", Double.Parse(resultado1.valor + "") / Double.Parse(resultado2.valor + ""));

                                    case "Decimal":
                                        String uno0 = resultado1.valor.ToString();
                                        char[] dos0 = uno0.ToCharArray();
                                        resultado1.valor = (int)dos0[0] + "";
                                        return new Resultado("Decimal", Double.Parse(resultado1.valor + "") / Double.Parse(resultado2.valor + ""));

                                    case "Texto":
                                        break;
                                    case "Caracter":
                                        String uno2 = resultado1.valor.ToString();
                                        char[] dos2 = uno2.ToCharArray();
                                        resultado1.valor = (int)dos2[0] + "";
                                        String uno3 = resultado2.valor.ToString();
                                        char[] dos3 = uno3.ToCharArray();
                                        resultado2.valor = (int)dos3[0] + "";
                                        return new Resultado("Entero", Double.Parse(resultado1.valor + "") / Double.Parse(resultado2.valor + ""));

                                    case "Booleano":
                                        String uno = resultado1.valor.ToString();
                                        char[] dos = uno.ToCharArray();
                                        resultado1.valor = (int)dos[0] + "";
                                        Double res2;
                                        if (resultado2.valor.ToString() == "true" || resultado2.valor.ToString() == "True")
                                        {
                                            res2 = 1;
                                        }
                                        else
                                        {
                                            res2 = 0;
                                        }
                                        return new Resultado("Entero", Double.Parse(resultado1.valor + "") / res2);

                                }
                                break;
                            case "Booleano":
                                tipo2 = resultado2.tipo;
                                Double res;
                                if (resultado1.valor.ToString() == "true" || resultado1.valor.ToString() == "True")
                                {
                                    res = 1;
                                }
                                else
                                {
                                    res = 0;
                                }
                                switch (tipo2)
                                {
                                    case "Entero":
                                        return new Resultado("Entero", res / Double.Parse(resultado2.valor + ""));

                                    case "Decimal":
                                        return new Resultado("Decimal", res / Double.Parse(resultado2.valor + ""));

                                    case "Texto":
                                        break;
                                    case "Caracter":
                                        String uno = resultado2.valor.ToString();
                                        char[] dos = uno.ToCharArray();
                                        resultado2.valor = (int)dos[0] + "";
                                        return new Resultado("Entero", res / Double.Parse(resultado2.valor + ""));

                                    case "Booleano":
                                        Double res2;
                                        if (resultado2.valor.ToString() == "true" || resultado2.valor.ToString() == "True")
                                        {
                                            res2 = 1;
                                        }
                                        else
                                        {
                                            res2 = 0;
                                        }
                                        return new Resultado("Booleano", res / res2);
                                }
                                break;
                        }
                        break;
                    case "-":
                        tipo1 = resultado1.tipo;
                        switch (tipo1)
                        {
                            case "Decimal":
                                tipo2 = resultado2.tipo;
                                switch (tipo2)
                                {
                                    case "Entero":
                                        return new Resultado("Decimal", Double.Parse(resultado1.valor + "") - Double.Parse(resultado2.valor + ""));

                                    case "Decimal":
                                        return new Resultado("Decimal", Double.Parse(resultado1.valor + "") - Double.Parse(resultado2.valor + ""));

                                    case "Texto":
                                        break;
                                    case "Caracter":
                                        String uno = resultado2.valor.ToString();
                                        char[] dos = uno.ToCharArray();
                                        resultado2.valor = (int)dos[0] + "";
                                        return new Resultado("Decimal", Double.Parse(resultado1.valor + "") - Double.Parse(resultado2.valor + ""));

                                    case "Booleano":
                                        Double res2;
                                        if (resultado2.valor.ToString() == "true" || resultado2.valor.ToString() == "True")
                                        {
                                            res2 = 1;
                                        }
                                        else
                                        {
                                            res2 = 0;
                                        }
                                        return new Resultado("Decimal", Double.Parse(resultado1.valor + "") - res2);

                                }
                                break;
                            case "Entero":
                                tipo2 = resultado2.tipo;
                                switch (tipo2)
                                {
                                    case "Entero":
                                        return new Resultado("Entero", Double.Parse(resultado1.valor + "") - Double.Parse(resultado2.valor + ""));

                                    case "Decimal":
                                        return new Resultado("Decimal", Double.Parse(resultado1.valor + "") - Double.Parse(resultado2.valor + ""));

                                    case "Texto":
                                        break;
                                    case "Caracter":
                                        String uno = resultado2.valor.ToString();
                                        char[] dos = uno.ToCharArray();
                                        resultado2.valor = (int)dos[0] + "";
                                        return new Resultado("Entero", Double.Parse(resultado1.valor + "") - Double.Parse(resultado2.valor + ""));

                                    case "Booleano":
                                        Double res2;
                                        if (resultado2.valor.ToString() == "true" || resultado2.valor.ToString() == "True")
                                        {
                                            res2 = 1;
                                        }
                                        else
                                        {
                                            res2 = 0;
                                        }
                                        return new Resultado("Entero", Double.Parse(resultado1.valor + "") - res2);
                                }
                                break;
                            case "Texto":
                                tipo2 = resultado2.tipo;
                                switch (tipo2)
                                {
                                    case "Entero":
                                        break;
                                    case "Decimal":
                                        break;
                                    case "Texto":
                                        break;
                                    case "Caracter":
                                        break;
                                    case "Booleano":
                                        break;
                                }
                                break;
                            case "Caracter":
                                tipo2 = resultado2.tipo;
                                switch (tipo2)
                                {
                                    case "Entero":
                                        String uno1 = resultado1.valor.ToString();
                                        char[] dos1 = uno1.ToCharArray();
                                        resultado1.valor = (int)dos1[0] + "";
                                        return new Resultado("Entero", Double.Parse(resultado1.valor + "") - Double.Parse(resultado2.valor + ""));

                                    case "Decimal":
                                        String uno0 = resultado1.valor.ToString();
                                        char[] dos0 = uno0.ToCharArray();
                                        resultado1.valor = (int)dos0[0] + "";
                                        return new Resultado("Decimal", Double.Parse(resultado1.valor + "") - Double.Parse(resultado2.valor + ""));

                                    case "Texto":
                                        break;
                                    case "Caracter":
                                        String uno2 = resultado1.valor.ToString();
                                        char[] dos2 = uno2.ToCharArray();
                                        resultado1.valor = (int)dos2[0] + "";
                                        String uno3 = resultado2.valor.ToString();
                                        char[] dos3 = uno3.ToCharArray();
                                        resultado2.valor = (int)dos3[0] + "";
                                        return new Resultado("Entero", Double.Parse(resultado1.valor + "") - Double.Parse(resultado2.valor + ""));

                                    case "Booleano":
                                        String uno = resultado1.valor.ToString();
                                        char[] dos = uno.ToCharArray();
                                        resultado1.valor = (int)dos[0] + "";
                                        Double res2;
                                        if (resultado2.valor.ToString() == "true" || resultado2.valor.ToString() == "True")
                                        {
                                            res2 = 1;
                                        }
                                        else
                                        {
                                            res2 = 0;
                                        }
                                        return new Resultado("Entero", Double.Parse(resultado1.valor + "") - res2);

                                }
                                break;
                            case "Booleano":
                                tipo2 = resultado2.tipo;
                                Double res;
                                if (resultado1.valor.ToString() == "true" || resultado1.valor.ToString() == "True")
                                {
                                    res = 1;
                                }
                                else
                                {
                                    res = 0;
                                }
                                switch (tipo2)
                                {
                                    case "Entero":
                                        return new Resultado("Entero", res - Double.Parse(resultado2.valor + ""));

                                    case "Decimal":
                                        return new Resultado("Decimal", res - Double.Parse(resultado2.valor + ""));

                                    case "Texto":
                                        break;
                                    case "Caracter":
                                        String uno = resultado2.valor.ToString();
                                        char[] dos = uno.ToCharArray();
                                        resultado2.valor = (int)dos[0] + "";
                                        return new Resultado("Entero", res - Double.Parse(resultado2.valor + ""));

                                    case "Booleano":
                                        Double res2;
                                        if (resultado2.valor.ToString() == "true" || resultado2.valor.ToString() == "True")
                                        {
                                            res2 = 1;
                                        }
                                        else
                                        {
                                            res2 = 0;
                                        }
                                        return new Resultado("Booleano", res - res2);
                                }
                                break;
                        }
                        break;
                    case "^":
                        tipo1 = resultado1.tipo;
                        switch (tipo1)
                        {
                            case "Decimal":
                                tipo2 = resultado2.tipo;
                                switch (tipo2)
                                {
                                    case "Entero":
                                        return new Resultado("Decimal", Math.Pow(Double.Parse(resultado1.valor + ""), Double.Parse(resultado2.valor + "")));

                                    case "Decimal":
                                        return new Resultado("Decimal", Math.Pow(Double.Parse(resultado1.valor + ""), Double.Parse(resultado2.valor + "")));

                                    case "Texto":
                                        break;
                                    case "Caracter":
                                        String uno = resultado2.valor.ToString();
                                        char[] dos = uno.ToCharArray();
                                        resultado2.valor = (int)dos[0] + "";
                                        return new Resultado("Decimal", Math.Pow(Double.Parse(resultado1.valor + ""), Double.Parse(resultado2.valor + "")));

                                    case "Booleano":
                                        Double res2;
                                        if (resultado2.valor.ToString() == "true" || resultado2.valor.ToString() == "True")
                                        {
                                            res2 = 1;
                                        }
                                        else
                                        {
                                            res2 = 0;
                                        }
                                        return new Resultado("Decimal", Math.Pow(Double.Parse(resultado1.valor + ""), res2));

                                }
                                break;
                            case "Entero":
                                tipo2 = resultado2.tipo;
                                switch (tipo2)
                                {
                                    case "Entero":
                                        return new Resultado("Entero", Math.Pow(Double.Parse(resultado1.valor + ""), Double.Parse(resultado2.valor + "")));

                                    case "Decimal":
                                        return new Resultado("Decimal", Math.Pow(Double.Parse(resultado1.valor + ""), Double.Parse(resultado2.valor + "")));

                                    case "Texto":
                                        break;
                                    case "Caracter":
                                        String uno = resultado2.valor.ToString();
                                        char[] dos = uno.ToCharArray();
                                        resultado2.valor = (int)dos[0] + "";
                                        return new Resultado("Entero", Math.Pow(Double.Parse(resultado1.valor + ""), Double.Parse(resultado2.valor + "")));

                                    case "Booleano":
                                        Double res2;
                                        if (resultado2.valor.ToString() == "true" || resultado2.valor.ToString() == "True")
                                        {
                                            res2 = 1;
                                        }
                                        else
                                        {
                                            res2 = 0;
                                        }
                                        return new Resultado("Entero", Math.Pow(Double.Parse(resultado1.valor + ""), res2));
                                }
                                break;
                            case "Texto":
                                tipo2 = resultado2.tipo;
                                switch (tipo2)
                                {
                                    case "Entero":
                                        break;
                                    case "Decimal":
                                        break;
                                    case "Texto":
                                        break;
                                    case "Caracter":
                                        break;
                                    case "Booleano":
                                        break;
                                }
                                break;
                            case "Caracter":
                                tipo2 = resultado2.tipo;
                                switch (tipo2)
                                {
                                    case "Entero":
                                        String uno1 = resultado1.valor.ToString();
                                        char[] dos1 = uno1.ToCharArray();
                                        resultado1.valor = (int)dos1[0] + "";
                                        return new Resultado("Entero", Math.Pow(Double.Parse(resultado1.valor + ""), Double.Parse(resultado2.valor + "")));

                                    case "Decimal":
                                        String uno0 = resultado1.valor.ToString();
                                        char[] dos0 = uno0.ToCharArray();
                                        resultado1.valor = (int)dos0[0] + "";
                                        return new Resultado("Decimal", Math.Pow(Double.Parse(resultado1.valor + ""), Double.Parse(resultado2.valor + "")));

                                    case "Texto":
                                        break;
                                    case "Caracter":
                                        String uno2 = resultado1.valor.ToString();
                                        char[] dos2 = uno2.ToCharArray();
                                        resultado1.valor = (int)dos2[0] + "";
                                        String uno3 = resultado2.valor.ToString();
                                        char[] dos3 = uno3.ToCharArray();
                                        resultado2.valor = (int)dos3[0] + "";
                                        return new Resultado("Entero", Math.Pow(Double.Parse(resultado1.valor + ""), Double.Parse(resultado2.valor + "")));

                                    case "Booleano":
                                        String uno = resultado1.valor.ToString();
                                        char[] dos = uno.ToCharArray();
                                        resultado1.valor = (int)dos[0] + "";
                                        Double res2;
                                        if (resultado2.valor.ToString() == "true" || resultado2.valor.ToString() == "True")
                                        {
                                            res2 = 1;
                                        }
                                        else
                                        {
                                            res2 = 0;
                                        }
                                        return new Resultado("Entero", Math.Pow(Double.Parse(resultado1.valor + ""), res2));

                                }
                                break;
                            case "Booleano":
                                tipo2 = resultado2.tipo;
                                Double res;
                                if (resultado1.valor.ToString() == "true" || resultado1.valor.ToString() == "True")
                                {
                                    res = 1;
                                }
                                else
                                {
                                    res = 0;
                                }
                                switch (tipo2)
                                {
                                    case "Entero":
                                        return new Resultado("Entero", Math.Pow(res, Double.Parse(resultado2.valor + "")));

                                    case "Decimal":
                                        return new Resultado("Decimal", Math.Pow(res, Double.Parse(resultado2.valor + "")));

                                    case "Texto":
                                        break;
                                    case "Caracter":
                                        String uno = resultado2.valor.ToString();
                                        char[] dos = uno.ToCharArray();
                                        resultado2.valor = (int)dos[0] + "";
                                        return new Resultado("Entero", Math.Pow(res, Double.Parse(resultado2.valor + "")));

                                    case "Booleano":
                                        Double res2;
                                        if (resultado2.valor.ToString() == "true" || resultado2.valor.ToString() == "True")
                                        {
                                            res2 = 1;
                                        }
                                        else
                                        {
                                            res2 = 0;
                                        }
                                        return new Resultado("Booleano", Math.Pow(res, res2));
                                }
                                break;
                        }
                        break;
                    case "%":
                        tipo1 = resultado1.tipo;
                        switch (tipo1)
                        {
                            case "Decimal":
                                tipo2 = resultado2.tipo;
                                switch (tipo2)
                                {
                                    case "Entero":
                                        return new Resultado("Decimal", Double.Parse(resultado1.valor + "") % Double.Parse(resultado2.valor + ""));

                                    case "Decimal":
                                        return new Resultado("Decimal", Double.Parse(resultado1.valor + "") % Double.Parse(resultado2.valor + ""));

                                    case "Texto":
                                        break;
                                    case "Caracter":
                                        String uno = resultado2.valor.ToString();
                                        char[] dos = uno.ToCharArray();
                                        resultado2.valor = (int)dos[0] + "";
                                        return new Resultado("Decimal", Double.Parse(resultado1.valor + "") % Double.Parse(resultado2.valor + ""));

                                    case "Booleano":
                                        Double res2;
                                        if (resultado2.valor.ToString() == "true" || resultado2.valor.ToString() == "True")
                                        {
                                            res2 = 1;
                                        }
                                        else
                                        {
                                            res2 = 0;
                                        }
                                        return new Resultado("Decimal", Double.Parse(resultado1.valor + "") % res2);

                                }
                                break;
                            case "Entero":
                                tipo2 = resultado2.tipo;
                                switch (tipo2)
                                {
                                    case "Entero":
                                        return new Resultado("Entero", Double.Parse(resultado1.valor + "") % Double.Parse(resultado2.valor + ""));

                                    case "Decimal":
                                        return new Resultado("Decimal", Double.Parse(resultado1.valor + "") % Double.Parse(resultado2.valor + ""));

                                    case "Texto":
                                        break;
                                    case "Caracter":
                                        String uno = resultado2.valor.ToString();
                                        char[] dos = uno.ToCharArray();
                                        resultado2.valor = (int)dos[0] + "";
                                        return new Resultado("Entero", Double.Parse(resultado1.valor + "") % Double.Parse(resultado2.valor + ""));

                                    case "Booleano":
                                        Double res2;
                                        if (resultado2.valor.ToString() == "true" || resultado2.valor.ToString() == "True")
                                        {
                                            res2 = 1;
                                        }
                                        else
                                        {
                                            res2 = 0;
                                        }
                                        return new Resultado("Entero", Double.Parse(resultado1.valor + "") % res2);
                                }
                                break;
                            case "Texto":
                                tipo2 = resultado2.tipo;
                                switch (tipo2)
                                {
                                    case "Entero":
                                        break;
                                    case "Decimal":
                                        break;
                                    case "Texto":
                                        break;
                                    case "Caracter":
                                        break;
                                    case "Booleano":
                                        break;
                                }
                                break;
                            case "Caracter":
                                tipo2 = resultado2.tipo;
                                switch (tipo2)
                                {
                                    case "Entero":
                                        String uno1 = resultado1.valor.ToString();
                                        char[] dos1 = uno1.ToCharArray();
                                        resultado1.valor = (int)dos1[0] + "";
                                        return new Resultado("Entero", Double.Parse(resultado1.valor + "") % Double.Parse(resultado2.valor + ""));

                                    case "Decimal":
                                        String uno0 = resultado1.valor.ToString();
                                        char[] dos0 = uno0.ToCharArray();
                                        resultado1.valor = (int)dos0[0] + "";
                                        return new Resultado("Decimal", Double.Parse(resultado1.valor + "") % Double.Parse(resultado2.valor + ""));

                                    case "Texto":
                                        break;
                                    case "Caracter":
                                        String uno2 = resultado1.valor.ToString();
                                        char[] dos2 = uno2.ToCharArray();
                                        resultado1.valor = (int)dos2[0] + "";
                                        String uno3 = resultado2.valor.ToString();
                                        char[] dos3 = uno3.ToCharArray();
                                        resultado2.valor = (int)dos3[0] + "";
                                        return new Resultado("Entero", Double.Parse(resultado1.valor + "") % Double.Parse(resultado2.valor + ""));

                                    case "Booleano":
                                        String uno = resultado1.valor.ToString();
                                        char[] dos = uno.ToCharArray();
                                        resultado1.valor = (int)dos[0] + "";
                                        Double res2;
                                        if (resultado2.valor.ToString() == "true" || resultado2.valor.ToString() == "True")
                                        {
                                            res2 = 1;
                                        }
                                        else
                                        {
                                            res2 = 0;
                                        }
                                        return new Resultado("Entero", Double.Parse(resultado1.valor + "") % res2);

                                }
                                break;
                            case "Booleano":
                                tipo2 = resultado2.tipo;
                                Double res;
                                if (resultado1.valor.ToString() == "true" || resultado1.valor.ToString() == "True")
                                {
                                    res = 1;
                                }
                                else
                                {
                                    res = 0;
                                }
                                switch (tipo2)
                                {
                                    case "Entero":
                                        return new Resultado("Entero", res % Double.Parse(resultado2.valor + ""));

                                    case "Decimal":
                                        return new Resultado("Decimal", res % Double.Parse(resultado2.valor + ""));

                                    case "Texto":
                                        break;
                                    case "Caracter":
                                        String uno = resultado2.valor.ToString();
                                        char[] dos = uno.ToCharArray();
                                        resultado2.valor = (int)dos[0] + "";
                                        return new Resultado("Entero", res % Double.Parse(resultado2.valor + ""));

                                    case "Booleano":
                                        Double res2;
                                        if (resultado2.valor.ToString() == "true" || resultado2.valor.ToString() == "True")
                                        {
                                            res2 = 1;
                                        }
                                        else
                                        {
                                            res2 = 0;
                                        }
                                        return new Resultado("Booleano", res % res2);
                                }
                                break;
                        }
                        break;
                    case "id":
                        String iden = raiz.Token.Text.Replace("\"", "");
                        if (Programa.tablaGlobal.getSimbolo(iden) != null)
                        {
                            return new Resultado(Programa.tablaGlobal.getSimbolo(iden).tipo, Programa.tablaGlobal.getSimbolo(iden).valor);
                        }
                        else if (Programa.tablaLocal.getSimbolo(iden) != null)
                        {
                            return new Resultado(Programa.tablaLocal.getSimbolo(iden).tipo, Programa.tablaLocal.getSimbolo(iden).valor);
                        }
                        else
                        {
                            return null;
                        }
                    case "LLAMADAMETODO":
                        break;
                    case "numero":
                        return new Resultado("numero", raiz.Token.Text);
                    case "cadena":
                        return new Resultado("cadena", raiz.Token.Text);

                }
            }
            else
            {
                consola.Text = consola.Text + "\n" + "Las variables no pertenecen a su ambito";
                Form1.erroresSem.Add("Las variables no pertenecen a su ambito");
                Form1.fila.Add(raiz.Span.Location.Line + 1);
                Form1.columna.Add(raiz.Span.Location.Column + 1);
            }

            return null;

        }

        public Resultado relacional(ParseTreeNode raiz)
        {
            Resultado resultado1 = null;
            Resultado resultado2 = null;

            switch (raiz.Term.Name)
            {
                case "EXPL":
                    if (raiz.ChildNodes.Count == 3)
                    {
                        resultado1 = relacional(raiz.ChildNodes[0]);
                        resultado2 = relacional(raiz.ChildNodes[2]);
                        if (raiz.ChildNodes[1].Token.Text == "&&")
                        {
                            if (Convert.ToBoolean(resultado1.valor) && Convert.ToBoolean(resultado2.valor))
                            {
                                return new Resultado("Booleano", true);
                            }
                            else
                            {
                                return new Resultado("Booleano", false);
                            }
                        }
                        else if (raiz.ChildNodes[1].Token.Text == "||")
                        {
                            if (Convert.ToBoolean(resultado1.valor) || Convert.ToBoolean(resultado2.valor))
                            {
                                return new Resultado("Booleano", true);
                            }
                            else
                            {
                                return new Resultado("Booleano", false);
                            }
                        }
                    }
                    else if (raiz.ChildNodes.Count == 2)
                    {
                        resultado1 = relacional(raiz.ChildNodes[1]);
                        if (!Convert.ToBoolean(resultado1.valor))
                        {
                            return new Resultado("Booleano", true);
                        }
                        else
                        {
                            return new Resultado("Booleano", false);
                        }
                    }
                    else
                    {
                        return relacional(raiz.ChildNodes[0]);
                    }
                    break;
                case "EXPR":
                    if (raiz.ChildNodes.Count == 3)
                    {
                        resultado1 = operar(raiz.ChildNodes[0]);
                        resultado2 = operar(raiz.ChildNodes[2]);
                    }
                    else
                    {
                        return operar(raiz.ChildNodes[0]);
                    }
                    break;
            }


            String tipoRelacional = raiz.ChildNodes[1].Token.Text;
            String tipo1 = resultado1.tipo;
            String tipo2 = resultado2.tipo;
            String prim0 = resultado1.valor.ToString();
            char[] prim1 = prim0.ToCharArray();
            String seg0 = resultado2.valor.ToString();
            char[] seg1 = seg0.ToCharArray();
            double p = 0;
            double s = 0;

            foreach (char a in prim1)
            {
                p = p + (double)a;
            }

            foreach (char a in seg1)
            {
                s = s + (double)a;
            }

            if (resultado1 != null && resultado2 != null && (tipo1 == tipo2 || tipo1 == "Entero" && tipo2 == "Decimal" || tipo2 == "Entero" && tipo1 == "Decimal"))
            {
                switch (tipoRelacional)
                {
                    case "==":
                        if (tipo1 == "Booleano")
                        {
                            if (resultado1.valor.ToString().ToLower() == "true")
                            {
                                resultado1.valor = 1;
                            }
                            else
                            {
                                resultado1.valor = 0;
                            }
                        }

                        if (tipo2 == "Booleano")
                        {
                            if (resultado2.valor.ToString().ToLower() == "true")
                            {
                                resultado2.valor = 1;
                            }
                            else
                            {
                                resultado2.valor = 0;
                            }
                        }
                        if (resultado1.valor.ToString() == resultado2.valor.ToString())
                        {
                            return new Resultado("Booleano", true);
                        }
                        else
                        {
                            return new Resultado("Booleano", false);
                        }
                    case ">":
                        if (tipo1 == "Texto" || tipo1 == "Caracter")
                        {
                            return new Resultado("Booleano", p > s);
                        }
                        else
                        {
                            if (tipo1 == "Booleano")
                            {
                                if (resultado1.valor.ToString().ToLower() == "true")
                                {
                                    resultado1.valor = 1;
                                }
                                else
                                {
                                    resultado1.valor = 0;
                                }
                            }

                            if (tipo2 == "Booleano")
                            {
                                if (resultado2.valor.ToString().ToLower() == "true")
                                {
                                    resultado2.valor = 1;
                                }
                                else
                                {
                                    resultado2.valor = 0;
                                }
                            }
                            return new Resultado("Booleano", (Double.Parse(resultado1.valor + "") > Double.Parse(resultado2.valor + "")));
                        }
                    case "<":
                        if (tipo1 == "Texto" || tipo1 == "Caracter")
                        {
                            return new Resultado("Booleano", p < s);
                        }
                        else
                        {
                            if (tipo1 == "Booleano")
                            {
                                if (resultado1.valor.ToString().ToLower() == "true")
                                {
                                    resultado1.valor = 1;
                                }
                                else
                                {
                                    resultado1.valor = 0;
                                }
                            }

                            if (tipo2 == "Booleano")
                            {
                                if (resultado2.valor.ToString().ToLower() == "true")
                                {
                                    resultado2.valor = 1;
                                }
                                else
                                {
                                    resultado2.valor = 0;
                                }
                            }
                            return new Resultado("Booleano", (Double.Parse(resultado1.valor + "") < Double.Parse(resultado2.valor + "")));
                        }
                    case "<=":
                        if (tipo1 == "Texto" || tipo1 == "Caracter")
                        {
                            return new Resultado("Booleano", p <= s);
                        }
                        else
                        {
                            if (tipo1 == "Booleano")
                            {
                                if (resultado1.valor.ToString().ToLower() == "true")
                                {
                                    resultado1.valor = 1;
                                }
                                else
                                {
                                    resultado1.valor = 0;
                                }
                            }

                            if (tipo2 == "Booleano")
                            {
                                if (resultado2.valor.ToString().ToLower() == "true")
                                {
                                    resultado2.valor = 1;
                                }
                                else
                                {
                                    resultado2.valor = 0;
                                }
                            }
                            return new Resultado("Booleano", (Double.Parse(resultado1.valor + "") <= Double.Parse(resultado2.valor + "")));
                        }
                    case ">=":
                        if (tipo1 == "Texto" || tipo1 == "Caracter")
                        {
                            return new Resultado("Booleano", p >= s);
                        }
                        else
                        {
                            if (tipo1 == "Booleano")
                            {
                                if (resultado1.valor.ToString().ToLower() == "true")
                                {
                                    resultado1.valor = 1;
                                }
                                else
                                {
                                    resultado1.valor = 0;
                                }
                            }

                            if (tipo2 == "Booleano")
                            {
                                if (resultado2.valor.ToString().ToLower() == "true")
                                {
                                    resultado2.valor = 1;
                                }
                                else
                                {
                                    resultado2.valor = 0;
                                }
                            }
                            return new Resultado("Booleano", (Double.Parse(resultado1.valor + "") >= Double.Parse(resultado2.valor + "")));
                        }
                    case "!=":
                        if (tipo1 == "Texto" || tipo1 == "Caracter")
                        {
                            return new Resultado("Booleano", p != s);
                        }
                        else
                        {
                            if (tipo1 == "Booleano")
                            {
                                if (resultado1.valor.ToString().ToLower() == "true")
                                {
                                    resultado1.valor = 1;
                                }
                                else
                                {
                                    resultado1.valor = 0;
                                }
                            }

                            if (tipo2 == "Booleano")
                            {
                                if (resultado2.valor.ToString().ToLower() == "true")
                                {
                                    resultado2.valor = 1;
                                }
                                else
                                {
                                    resultado2.valor = 0;
                                }
                            }
                            return new Resultado("Booleano", (Double.Parse(resultado1.valor + "") != Double.Parse(resultado2.valor + "")));
                        }
                    case "~":
                        if (resultado1.tipo == "Texto" && resultado2.tipo == "Texto")
                        {
                            return new Resultado("Boolean", resultado1.valor.ToString().ToLower().Trim() == resultado2.valor.ToString().ToLower().Trim());
                        }
                        else
                        {
                            if (tipo1 == "Booleano")
                            {
                                if (resultado1.valor.ToString().ToLower() == "true")
                                {
                                    resultado1.valor = 1;
                                }
                                else
                                {
                                    resultado1.valor = 0;
                                }
                            }

                            if (tipo2 == "Booleano")
                            {
                                if (resultado2.valor.ToString().ToLower() == "true")
                                {
                                    resultado2.valor = 1;
                                }
                                else
                                {
                                    resultado2.valor = 0;
                                }
                            }
                            return new Resultado("Boolean", Math.Abs(Double.Parse(resultado1.valor + "") - Double.Parse(resultado2.valor + "")) <= incerteza);
                        }
                }
            }

            return null;
        }

        public static String DibujarAST(ParseTreeNode raiz)
        {
            String parametros = "";
            for (int i = 0; i < raiz.ChildNodes[2].ChildNodes.Count; i++)
            {
                parametros = parametros + raiz.ChildNodes[2].ChildNodes[i].ChildNodes[0].Token.Text + ",";
            }
            try
            {
                grafo = "digraph G{";
                grafo += "nodo0[label=" + '"' + escapar(raiz.ChildNodes[0].Token.Text+" : "+raiz.ChildNodes[1].Token.Text+" ("+parametros+")") + '"' + "];";
                contador = 1;
                recorrerASA("nodo0", raiz);
                grafo += "}";
                return grafo;
            }
            catch (Exception e)
            {
                return "error" + e;
            }
        }

        private static void recorrerASA(String padre, ParseTreeNode hijos)
        {
            String tipoAccion = "";
            foreach (ParseTreeNode hijo in hijos.ChildNodes)
            {
                tipoAccion = hijo.Term.Name;
                switch (tipoAccion)
                {
                    case "ASIGNACION":
                        if (hijo.ChildNodes.Count == 3)
                        {
                            String nombreHijo08 = "nodo" + contador.ToString();
                            grafo += nombreHijo08 + "[label=" + '"' + escapar("DECLARACION") + '"' + "];";
                            grafo += padre + "->" + nombreHijo08 + ";\n";
                            contador++;
                            recorrerASA(nombreHijo08, hijo);
                        }
                        else
                        {
                            String nombreHijo08 = "nodo" + contador.ToString();
                            grafo += nombreHijo08 + "[label=" + '"' + escapar("ASIGNACION") + '"' + "];";
                            grafo += padre + "->" + nombreHijo08 + ";\n";
                            contador++;
                            recorrerASA(nombreHijo08, hijo);
                        }
                        break;
                    case "DECLARACION":
                        String nombreHijo09 = "nodo" + contador.ToString();
                        grafo += nombreHijo09 + "[label=" + '"' + escapar("DECLARACION") + '"' + "];";
                        grafo += padre + "->" + nombreHijo09 + ";\n";
                        contador++;
                        recorrerASA(nombreHijo09, hijo);
                        break;
                    case "ATRIBUTOS":
                        String nombreHijo10 = "nodo" + contador.ToString();
                        grafo += nombreHijo10 + "[label=" + '"' + escapar("CUERPO") + '"' + "];";
                        grafo += padre + "->" + nombreHijo10 + ";\n";
                        contador++;
                        recorrerASA(nombreHijo10, hijo);
                        break;
                    case "ATRIBUTO":
                        recorrerASA(padre, hijo);
                        break;
                    case "SI":
                        String nombreHijo11 = "nodo" + contador.ToString();
                        grafo += nombreHijo11 + "[label=" + '"' + escapar(hijo.ChildNodes[0].ToString()) + '"' + "];";
                        grafo += padre + "->" + nombreHijo11 + ";\n";
                        contador++;
                        recorrerASA(nombreHijo11, hijo);
                        break;
                    case "SINO":
                        if (hijo.ChildNodes.Count == 2)
                        {
                            String nombreHijo12 = "nodo" + contador.ToString();
                            grafo += nombreHijo12 + "[label=" + '"' + escapar(hijo.ChildNodes[0].ToString()) + '"' + "];";
                            grafo += padre + "->" + nombreHijo12 + ";\n";
                            contador++;
                            recorrerASA(nombreHijo12, hijo);
                        }
                        break;
                    case "INTERRUMPIR":
                        String nombreHijo13 = "nodo" + contador.ToString();
                        grafo += nombreHijo13 + "[label=" + '"' + escapar(hijo.ChildNodes[0].ToString()) + '"' + "];";
                        grafo += padre + "->" + nombreHijo13 + ";\n";
                        contador++;
                        recorrerASA(nombreHijo13, hijo);
                        break;
                    case "CASOS":
                        if (hijo.ChildNodes.Count > 0)
                        {
                            String nombreHijo14 = "nodo" + contador.ToString();
                            grafo += nombreHijo14 + "[label=" + '"' + escapar(hijo.ToString()) + '"' + "];";
                            grafo += padre + "->" + nombreHijo14 + ";\n";
                            contador++;
                            recorrerASA(nombreHijo14, hijo);
                        }
                        break;
                    case "CASO":
                        String nombreHijo15 = "nodo" + contador.ToString();
                        grafo += nombreHijo15 + "[label=" + '"' + escapar(hijo.ChildNodes[0].ToString()) + '"' + "];";
                        grafo += padre + "->" + nombreHijo15 + ";\n";
                        contador++;
                        recorrerASA(nombreHijo15, hijo);
                        break;
                    case "DEFECTO":
                        String nombreHijo152 = "nodo" + contador.ToString();
                        grafo += nombreHijo152 + "[label=" + '"' + escapar(hijo.ChildNodes[0].ToString()) + '"' + "];";
                        grafo += padre + "->" + nombreHijo152 + ";\n";
                        contador++;
                        recorrerASA(nombreHijo152, hijo);
                        break;
                    case "MIENTRAS":
                        String nombreHijo16 = "nodo" + contador.ToString();
                        grafo += nombreHijo16 + "[label=" + '"' + escapar(hijo.ChildNodes[0].ToString()) + '"' + "];";
                        grafo += padre + "->" + nombreHijo16 + ";\n";
                        contador++;
                        recorrerASA(nombreHijo16, hijo);
                        break;
                    case "PARA":
                        String nombreHijo17 = "nodo" + contador.ToString();
                        grafo += nombreHijo17 + "[label=" + '"' + escapar(hijo.ChildNodes[0].ToString()) + '"' + "];";
                        grafo += padre + "->" + nombreHijo17 + ";\n";
                        contador++;
                        recorrerASA(nombreHijo17, hijo);
                        break;
                    case "HACER":
                        String nombreHijo18 = "nodo" + contador.ToString();
                        grafo += nombreHijo18 + "[label=" + '"' + escapar(hijo.ChildNodes[0].ToString()) + '"' + "];";
                        grafo += padre + "->" + nombreHijo18 + ";\n";
                        contador++;
                        recorrerASA(nombreHijo18, hijo);
                        break;
                    case "EXPL":
                        String nombreHijo19 = "nodo" + contador.ToString();
                        grafo += nombreHijo19 + "[label=" + '"' + escapar("EXPRESION") + '"' + "];";
                        grafo += padre + "->" + nombreHijo19 + ";\n";
                        contador++;
                        break;
                    case "EXPR":
                        String nombreHijo20 = "nodo" + contador.ToString();
                        grafo += nombreHijo20 + "[label=" + '"' + escapar("EXPRESION") + '"' + "];";
                        grafo += padre + "->" + nombreHijo20 + ";\n";
                        contador++;
                        break;
                    case "E":
                        String nombreHijo21 = "nodo" + contador.ToString();
                        grafo += nombreHijo21 + "[label=" + '"' + escapar("EXPRESION") + '"' + "];";
                        grafo += padre + "->" + nombreHijo21 + ";\n";
                        contador++;
                        break;
                    case "LLAMFUNC":
                        String nombreHijo22 = "nodo" + contador.ToString();
                        grafo += nombreHijo22 + "[label=" + '"' + escapar("LLAMADA") + '"' + "];";
                        grafo += padre + "->" + nombreHijo22 + ";\n";
                        contador++;
                        break;
                    case "LISTA_ID":
                        String nombreHijo23 = "nodo" + contador.ToString();
                        grafo += nombreHijo23 + "[label=" + '"' + escapar("LISTA_IDs") + '"' + "];";
                        grafo += padre + "->" + nombreHijo23 + ";\n";
                        contador++;
                        recorrerASA(nombreHijo23, hijo);
                        break;
                    case "id":
                        if (padre != "nodo0")
                        {
                            String nombreHijo24 = "nodo" + contador.ToString();
                            grafo += nombreHijo24 + "[label=" + '"' + escapar(hijo.ToString()) + '"' + "];";
                            grafo += padre + "->" + nombreHijo24 + ";\n";
                            contador++;
                        }
                        break;
                    case "OP":
                        if (hijo.ChildNodes[0].Token.Text == "++")
                        {
                            String nombreHijo08 = "nodo" + contador.ToString();
                            grafo += nombreHijo08 + "[label=" + '"' + escapar("INCREMENTO") + '"' + "];";
                            grafo += padre + "->" + nombreHijo08 + ";\n";
                            contador++;
                        }
                        else
                        {
                            String nombreHijo08 = "nodo" + contador.ToString();
                            grafo += nombreHijo08 + "[label=" + '"' + escapar("DECREMENTO") + '"' + "];";
                            grafo += padre + "->" + nombreHijo08 + ";\n";
                            contador++;
                        }
                        break;
                    case "RETORNO":
                        if (hijo.ChildNodes.Count == 2)
                        {
                            String nombreHijo08 = "nodo" + contador.ToString();
                            grafo += nombreHijo08 + "[label=" + '"' + escapar("RETORNO") + '"' + "];";
                            grafo += padre + "->" + nombreHijo08 + ";\n";
                            contador++;
                            recorrerASA(nombreHijo08, hijo);
                        }
                        else
                        {
                            String nombreHijo08 = "nodo" + contador.ToString();
                            grafo += nombreHijo08 + "[label=" + '"' + escapar("RETORNO") + '"' + "];";
                            grafo += padre + "->" + nombreHijo08 + ";\n";
                            contador++;
                        }
                        break;
                    case "MOSTRAR":
                        String nombreHijo07 = "nodo" + contador.ToString();
                        grafo += nombreHijo07 + "[label=" + '"' + escapar("MOSTRAR") + '"' + "];";
                        grafo += padre + "->" + nombreHijo07 + ";\n";
                        contador++;
                        String nombreHijo06 = "nodo" + contador.ToString();
                        grafo += nombreHijo06 + "[label=" + '"' + escapar("EXPRESION") + '"' + "];";
                        grafo += nombreHijo07 + "->" + nombreHijo06 + ";\n";
                        contador++;
                        break;
                    case "SALIR":
                        if (hijo.ChildNodes[0].Token.Text == "Continuar")
                        {
                            String nombreHijo08 = "nodo" + contador.ToString();
                            grafo += nombreHijo08 + "[label=" + '"' + escapar("CONTINUAR") + '"' + "];";
                            grafo += padre + "->" + nombreHijo08 + ";\n";
                            contador++;
                        }
                        else
                        {
                            String nombreHijo08 = "nodo" + contador.ToString();
                            grafo += nombreHijo08 + "[label=" + '"' + escapar("ROMPER") + '"' + "];";
                            grafo += padre + "->" + nombreHijo08 + ";\n";
                            contador++;
                        }
                        break;
                }
            }
        }

        private static String escapar(String cadena)
        {
            cadena = cadena.Replace("\\", "\\\\");
            cadena = cadena.Replace("\"", "\\\"");
            return cadena;
        }
        
        public static String DibujarEXP(ParseTreeNode raiz)
        {
            try
            {
                if (raiz.ChildNodes.Count == 3)
                {
                    grafo = "digraph G{";
                    grafo += "nodo0[label=" + '"' + escapar("Logico | " + raiz.ChildNodes[1].Token.Text) + '"' + "];";
                    contador = 1;
                    recorrerEXP("nodo0", raiz);
                    grafo += "}";
                    return grafo;
                }
                else if (raiz.ChildNodes.Count == 2)
                {
                    grafo = "digraph G{";
                    grafo += "nodo0[label=" + '"' + escapar("Logico | " + raiz.ChildNodes[0].Token.Text) + '"' + "];";
                    contador = 1;
                    recorrerEXP("nodo0", raiz);
                    grafo += "}";
                    return grafo;
                }
                else
                {
                    grafo = "digraph G{";
                    grafo += "nodo0[label=" + '"' + escapar("EXPRESION") + '"' + "];";
                    contador = 1;
                    recorrerEXP("nodo0", raiz);
                    grafo += "}";
                    return grafo;
                }
            }
            catch (Exception e)
            {
                return "error" + e;
            }
        }

        private static void recorrerEXP(String padre, ParseTreeNode hijos)
        {
            String tipoAccion = "";
            foreach (ParseTreeNode hijo in hijos.ChildNodes)
            {
                tipoAccion = hijo.Term.Name;
                switch (tipoAccion)
                {
                    case "EXPL":
                        if (hijo.ChildNodes.Count == 1 && hijo.ChildNodes[0].Term.Name == "EXPR")
                        {
                            recorrerEXP(padre, hijo);
                        }
                        else if (hijo.ChildNodes.Count == 1 && hijo.ChildNodes[0].Term.Name == "EXPL")
                        {
                            recorrerEXP(padre, hijo);
                        }
                        else if (hijo.ChildNodes.Count == 3)
                        {
                            String nombreHijo = "nodo" + contador.ToString();
                            grafo += nombreHijo + "[label=" + '"' + escapar("Logico | "+hijo.ChildNodes[1].Token.Text) + '"' + "];";
                            grafo += padre + "->" + nombreHijo + ";\n";
                            contador++;
                            recorrerEXP(nombreHijo, hijo);
                        }
                        else if (hijo.ChildNodes.Count == 2)
                        {
                            String nombreHijo = "nodo" + contador.ToString();
                            grafo += nombreHijo + "[label=" + '"' + escapar("Logico | " + hijo.ChildNodes[0].Token.Text) + '"' + "];";
                            grafo += padre + "->" + nombreHijo + ";\n";
                            contador++;
                            recorrerEXP(nombreHijo, hijo);
                        }
                        break;
                    case "EXPR":
                        if (hijo.ChildNodes.Count == 1)
                        {
                            recorrerEXP(padre, hijo);
                        }
                        else if (hijo.ChildNodes.Count == 3)
                        {
                            String nombreHijo = "nodo" + contador.ToString();
                            grafo += nombreHijo + "[label=" + '"' + escapar("Relacional | " + hijo.ChildNodes[1].Token.Text) + '"' + "];";
                            grafo += padre + "->" + nombreHijo + ";\n";
                            contador++;
                            recorrerEXP(nombreHijo, hijo);
                        }
                        break;
                    case "E":
                        if (hijo.ChildNodes.Count == 3)
                        {
                            String nombreHijo = "nodo" + contador.ToString();
                            grafo += nombreHijo + "[label=" + '"' + escapar("Aritmetica | " + hijo.ChildNodes[1].Token.Text) + '"' + "];";
                            grafo += padre + "->" + nombreHijo + ";\n";
                            contador++;
                            recorrerEXP(nombreHijo, hijo);
                        }
                        else if (hijo.ChildNodes.Count == 1 && hijo.ChildNodes[0].Term.Name != "E" && hijo.ChildNodes[0].Term.Name != "LLAMADA")
                        {
                            String tip = "";
                            if (hijo.ChildNodes[0].Term.Name == "id")
                            {
                                tip = "Variable";
                            }
                            else if (hijo.ChildNodes[0].Term.Name == "numero")
                            {
                                tip = "Numero";
                            }
                            else if (hijo.ChildNodes[0].Term.Name == "cadena")
                            {
                                tip = "Texto";
                            }
                            else if (hijo.ChildNodes[0].Term.Name == "caracter")
                            {
                                tip = "Caracter";
                            }
                            else if (hijo.ChildNodes[0].Term.Name == "booleano")
                            {
                                tip = "Booleano";
                            }
                            String nombreHijo = "nodo" + contador.ToString();
                            grafo += nombreHijo + "[label=" + '"' + escapar(tip + " | " +hijo.ChildNodes[0].Token.Text) + '"' + "];";
                            grafo += padre + "->" + nombreHijo + ";\n";
                            contador++;
                        }
                        else if (hijo.ChildNodes.Count == 1 && hijo.ChildNodes[0].Term.Name == "E")
                        {
                            recorrerEXP(padre, hijo);
                        }
                        else if (hijo.ChildNodes.Count == 2)
                        {
                            recorrerEXP(padre, hijo);
                        }
                        else if (hijo.ChildNodes.Count == 1 && hijo.ChildNodes[0].Term.Name == "LLAMADA")
                        {
                            recorrerEXP(padre, hijo);
                        }
                        break;
                    case "LLAMADA":
                        String nombreHijo0 = "nodo" + contador.ToString();
                        grafo += nombreHijo0 + "[label=" + '"' + escapar("Funcion | " + hijo.ChildNodes[0].Token.Text) + '"' + "];";
                        grafo += padre + "->" + nombreHijo0 + ";\n";
                        contador++;
                        break;
                }
            }
        }

        public int factorial(int val)
        {
            if(val <= 1){
                return 1;
            }
            else{
                return val*factorial(val - 1);
            }
        }

        public int fibonacci(int n)
        {
            if((n == 0) || (n == 1)){
                return 1;
            }
            else{
                return fibonacci(n - 1) + fibonacci(n - 2);
            }
        }

        public int permutacion(int n, int r)
        {
            int valor = factorial(n) / factorial(n - r);
            return valor;
        }

        public Double division(Double a, Double b)
        {
            if(b > a) {
                return 0;
            }
            else{
                return division(a - b, b) +1;
            }
        }

    }
}
