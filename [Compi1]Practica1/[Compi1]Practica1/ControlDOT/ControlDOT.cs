using System;
using Irony.Parsing;

namespace _Compi1_Practica1.ControlDOT
{
    public class ControlDOT
    {
        /*
         *digraph G{ 
         * nodo0[label="etiqueta"];
         * nodo1[label="hijo1"];
         * nodo2[label="hijo2"];
         * nodo0->nodo1;
         * nodo0->nodo2;
         * }
         */

        private static int contador;
        private static String grafo;

        public static String getDOT(ParseTreeNode raiz)
        {
            try
            {
                grafo = "digraph G{";
                grafo += "nodo0[label=" + '"' + escapar(raiz.ToString()) + '"' + "];";
                contador = 1;
                recorrerAST("nodo0", raiz);
                grafo += "}";
                return grafo;
            }
            catch (Exception e)
            {
                return "error" + e;
            }
        }

        private static void recorrerAST(String padre, ParseTreeNode hijos)
        {
            foreach (ParseTreeNode hijo in hijos.ChildNodes)
            {
                String nombreHijo = "nodo" + contador.ToString();
                grafo += nombreHijo + "[label=" + '"' + escapar(hijo.ToString()) + '"' + "];";
                grafo += padre + "->" + nombreHijo + ";\n";
                contador++;
                recorrerAST(nombreHijo, hijo);
            }
        }

        public static String getDOT2(ParseTreeNode raiz)
        {
            try
            {
                grafo = "digraph G{";
                grafo += "nodo0[label=" + '"' + escapar(raiz.ToString()) + '"' + "];";
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
                    case "PROGRAMA":
                        recorrerASA("nodo0",hijo);                        
                        break;
                    case "CUERPO":
                        recorrerASA("nodo0",hijo);
                        break;
                    case "ASIGNACION":
                        recorrerASA("nodo0", hijo);
                        break;
                    case "DECLARACION":
                        recorrerASA("nodo0", hijo);
                        break;
                    case "METODO":
                        recorrerASA("nodo0", hijo);
                        break;
                    case "FUNCION":
                        recorrerASA("nodo0", hijo);
                        break;
                    case "PRINCIPAL":
                        recorrerASA("nodo0", hijo);
                        break;
                    case "ATRIBUTOS":
                        recorrerASA("nodo0", hijo);
                        break;
                    case "ATRIBUTO":
                        recorrerASA("nodo0", hijo);
                        break;
                    case "SI":
                        String nombreHijo11 = "nodo" + contador.ToString();
                        grafo += nombreHijo11 + "[label=" + '"' + escapar(hijo.ChildNodes[0].ToString()) + '"' + "];";
                        grafo += padre + "->" + nombreHijo11 + ";\n";
                        contador++;
                        recorrerASA(nombreHijo11, hijo);
                        break;
                    case "SINO":
                        recorrerASA("nodo0", hijo);
                        break;
                    case "INTERRUMPIR":
                        recorrerASA("nodo0", hijo);
                        break;
                    case "CASOS":
                        recorrerASA("nodo0", hijo);
                        break;
                    case "CASO":
                        recorrerASA("nodo0", hijo);
                        break;
                    case "DEFECTO":
                        recorrerASA("nodo0", hijo);
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
                        if (hijo.ChildNodes.Count == 1 && hijo.ChildNodes[0].Term.Name == "EXPR")
                        {
                            recorrerASA(padre, hijo);
                        }
                        else if (hijo.ChildNodes.Count == 1 && hijo.ChildNodes[0].Term.Name == "EXPL")
                        {
                            recorrerASA(padre, hijo);
                        }
                        else if (hijo.ChildNodes.Count == 3)
                        {
                            String nombreHijo = "nodo" + contador.ToString();
                            grafo += nombreHijo + "[label=" + '"' + escapar(hijo.ChildNodes[1].ToString()) + '"' + "];";
                            grafo += padre + "->" + nombreHijo + ";\n";
                            contador++;
                            recorrerASA(nombreHijo, hijo);
                        }
                        else if (hijo.ChildNodes.Count == 2)
                        {
                            String nombreHijo = "nodo" + contador.ToString();
                            grafo += nombreHijo + "[label=" + '"' + escapar(hijo.ChildNodes[0].ToString()) + '"' + "];";
                            grafo += padre + "->" + nombreHijo + ";\n";
                            contador++;
                            recorrerASA(nombreHijo, hijo);
                        }
                        break;
                    case "EXPR":
                        if (hijo.ChildNodes.Count == 1)
                        {
                            recorrerASA(padre, hijo);
                        }
                        else if (hijo.ChildNodes.Count == 3)
                        {
                            String nombreHijo = "nodo" + contador.ToString();
                            grafo += nombreHijo + "[label=" + '"' + escapar(hijo.ChildNodes[1].ToString()) + '"' + "];";
                            grafo += padre + "->" + nombreHijo + ";\n";
                            contador++;
                            recorrerASA(nombreHijo, hijo);
                        }
                        break;
                    case "E":
                        if (hijo.ChildNodes.Count == 3 )
                        {
                            String nombreHijo = "nodo" + contador.ToString();
                            grafo += nombreHijo + "[label=" + '"' + escapar(hijo.ChildNodes[1].ToString()) + '"' + "];";
                            grafo += padre + "->" + nombreHijo + ";\n";
                            contador++;
                            recorrerASA(nombreHijo, hijo);
                        }
                        else if(hijo.ChildNodes.Count == 1 && hijo.ChildNodes[0].Term.Name != "E" && hijo.ChildNodes[0].Term.Name != "LLAMADA")
                        {
                            String nombreHijo = "nodo" + contador.ToString();
                            grafo += nombreHijo + "[label=" + '"' + escapar(hijo.ChildNodes[0].ToString()) + '"' + "];";
                            grafo += padre + "->" + nombreHijo + ";\n";
                            contador++;
                        }
                        else if (hijo.ChildNodes.Count == 1 && hijo.ChildNodes[0].Term.Name == "E")
                        {
                            recorrerASA(padre, hijo);
                        }
                        else if (hijo.ChildNodes.Count == 2)
                        {
                            recorrerASA(padre, hijo);
                        }
                        else if (hijo.ChildNodes.Count == 1 && hijo.ChildNodes[0].Term.Name == "LLAMADA")
                        {
                            recorrerASA(padre, hijo);
                        }
                        break;
                    case "LLAMADA":
                        String nombreHijo0 = "nodo" + contador.ToString();
                        grafo += nombreHijo0 + "[label=" + '"' + escapar((hijo.ChildNodes[0]).ToString()) + '"' + "];";
                        grafo += padre + "->" + nombreHijo0 + ";\n";
                        contador++;
                        break;/*
                    case "doble":
                        String nombreHijo2 = "nodo" + contador.ToString();
                        grafo += nombreHijo2 + "[label=" + '"' + escapar(hijo.ToString()) + '"' + "];";
                        grafo += padre + "->" + nombreHijo2 + ";\n";
                        contador++;
                        break;
                    case "id":
                        String nombreHijo3 = "nodo" + contador.ToString();
                        grafo += nombreHijo3 + "[label=" + '"' + escapar(hijo.ToString()) + '"' + "];";
                        grafo += padre + "->" + nombreHijo3 + ";\n";
                        contador++;
                        break;*/
                }
            }
        }

        private static String escapar(String cadena)
        {
            cadena = cadena.Replace("\\", "\\\\");
            cadena = cadena.Replace("\"", "\\\"");
            return cadena;
        }
    }
}
