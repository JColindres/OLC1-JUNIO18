using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Irony.Ast;
using Irony.Parsing;

namespace _Compi1_Practica1.Analizador
{
    public class OtraGramatica : Grammar
    {
        public OtraGramatica() : base(caseSensitive: true)
        {
            #region ER
            NumberLiteral doble = new NumberLiteral("doble");
            IdentifierTerminal id = new IdentifierTerminal("id");
            StringLiteral cadena = TerminalFactory.CreateCSharpString("cadena");
            StringLiteral carac = TerminalFactory.CreateCSharpChar("cadena");
            ConstantTerminal booleano = new ConstantTerminal("booleano");
            booleano.Add("true", true);
            booleano.Add("false", false);
            CommentTerminal comentario2 = new CommentTerminal("comentario2", "</", "/>");
            CommentTerminal comentario1 = new CommentTerminal("comentario1", "-->", "\n", "\r\n");
            base.NonGrammarTerminals.Add(comentario2);
            base.NonGrammarTerminals.Add(comentario1);
            #endregion

            #region Terminales
            var mas = ToTerm("+");
            var menos = ToTerm("-");
            var mul = ToTerm("*");
            var div = ToTerm("/");
            var mod = ToTerm("%");
            var pot = ToTerm("^");
            var parA = ToTerm("(");
            var parC = ToTerm(")");
            var corA = ToTerm("[");
            var corC = ToTerm("]");
            var llavA = ToTerm("{");
            var llavC = ToTerm("}");
            var pYc = ToTerm(";");
            var dosPuntos = ToTerm(":");
            var coma = ToTerm(",");
            var asig = ToTerm("=");
            var igual = ToTerm("=");
            var mayor = ToTerm(">");
            var menor = ToTerm("<");
            var mayorIgual = ToTerm(">=");
            var menorIgual = ToTerm("<=");
            var igualIgual = ToTerm("==");
            var noIgual = ToTerm("!=");
            var diferecia = ToTerm("~");
            var Mostrar = ToTerm("Mostrar");
            var resInt = ToTerm("Entero");
            var resDouble = ToTerm("Decimal");
            var resString = ToTerm("Texto");
            var resChar = ToTerm("Caracter");
            var resBool = ToTerm("Booleano");
            var resVoid = ToTerm("Vacio");
            var OR = ToTerm("||");
            var AND = ToTerm("&&");
            var NOT = ToTerm("!");
            var resReturn = ToTerm("Retorno");
            var Es_verdadero = ToTerm("Es_verdadero");
            var Es_false = ToTerm("Es_falso");
            var Cambiar_A = ToTerm("Cambiar_A");
            var Valor = ToTerm("Valor");
            var No_cumple = ToTerm("No_cumple");
            var Para = ToTerm("Para");
            var Hasta_que = ToTerm("Hasta_que");
            var Mientras = ToTerm("Mientras_que");
            var Romper = ToTerm("Romper");
            var Continuar = ToTerm("Continuar");
            var DibujarAST = ToTerm("DibujarAST");
            var DibujarEXP = ToTerm("DibujarEXP");
            var DibujarTS = ToTerm("DibujarTS");
            var Principal = ToTerm("Principal");
            var Importar = ToTerm("Importar");
            var Definir = ToTerm("Definir");
            #endregion

            #region No Terminales
            NonTerminal S = new NonTerminal("S"),
                E = new NonTerminal("E"),
                EXPR = new NonTerminal("EXPR"),
                EXPL = new NonTerminal("EXPL"),
                PROGRAMA = new NonTerminal("PROGRAMA"),
                CUERPOS = new NonTerminal("CUERPOS"),
                CUERPO = new NonTerminal("CUERPO"),
                ATRIBUTOS = new NonTerminal("ATRIBUTOS"),
                ATRIBUTO = new NonTerminal("ATRIBUTO"),
                DECLARACION = new NonTerminal("DECLARACION"),
                ASIGNACION = new NonTerminal("ASIGNACION"),
                PRINCIPAL = new NonTerminal("PRINCIPAL"),
                METODO = new NonTerminal("METODO"),
                FUNCION = new NonTerminal("FUNCION"),
                TIPO = new NonTerminal("TIPO"),
                MOSTRAR = new NonTerminal("MOSTRAR"),
                DIBUJAR = new NonTerminal("DIBUJAR"),
                LISTA_ID = new NonTerminal("LISTA_ID"),
                LISTA_PARAM = new NonTerminal("LISTA_PARAM"),
                DECLA = new NonTerminal("DECLA"),
                UNICO = new NonTerminal("UNICO"),
                UNICOS = new NonTerminal("UNICOS"),
                LLAMADA = new NonTerminal("LLAMADA"),
                LLAMFUNC = new NonTerminal("LLAMFUNC"),
                OPERANDO = new NonTerminal("OPERANDO"),
                RETORNO = new NonTerminal("RETORNO"),
                RETORN = new NonTerminal("RETORN"),
                SI = new NonTerminal("SI"),
                SINO = new NonTerminal("SINO"),
                SINO_SI = new NonTerminal("SINO_SI"),
                SINOSI = new NonTerminal("SINOSI"),
                INTERRUMPIR = new NonTerminal("INTERRUMPIR"),
                CASO = new NonTerminal("CASO"),
                CASOS = new NonTerminal("CASOS"),
                DEFECTO = new NonTerminal("DEFECTO"),
                MIENTRAS = new NonTerminal("MIENTRAS"),
                HACER = new NonTerminal("HACER"),
                SALIR = new NonTerminal("SALIR"),
                DEFINIR = new NonTerminal("DEFINIR"),
                IMPORTAR = new NonTerminal("IMPORTAR"),
                IMPORTE = new NonTerminal("IMPORTE");
            #endregion

            #region Gramatica
            S.Rule = PROGRAMA;

            PROGRAMA.Rule = CUERPO;

            CUERPO.Rule = MakePlusRule(CUERPO, CUERPOS);

            CUERPOS.Rule = METODO
                | FUNCION
                | PRINCIPAL
                | DEFINIR
                | IMPORTAR
                | DECLARACION
                | ASIGNACION;
            CUERPOS.ErrorRule = SyntaxError + llavC;
            CUERPOS.ErrorRule = SyntaxError + pYc;

            IMPORTAR.Rule = Importar + IMPORTE;

            IMPORTE.Rule = MakePlusRule(IMPORTE, ToTerm("."), E);

            DEFINIR.Rule = Definir + E;

            ATRIBUTOS.Rule = MakePlusRule(ATRIBUTOS, ATRIBUTO)
                | Empty;

            ATRIBUTO.Rule = DECLARACION
                | ASIGNACION
                | DIBUJAR
                | LLAMFUNC
                | SALIR
                | SI
                | INTERRUMPIR
                | MIENTRAS
                | HACER;
            ATRIBUTO.ErrorRule = SyntaxError + pYc;
            ATRIBUTO.ErrorRule = SyntaxError + llavC;

            METODO.Rule = resVoid + id + parA + LISTA_PARAM + parC + llavA + ATRIBUTOS + llavC;

            FUNCION.Rule = TIPO + id + parA + LISTA_PARAM + parC + llavA + ATRIBUTOS + RETORN + llavC;

            PRINCIPAL.Rule = resVoid + Principal + parA + parC + llavA + ATRIBUTOS + llavC;

            RETORN.Rule = RETORNO;

            RETORNO.Rule = resReturn + EXPL + pYc;

            SALIR.Rule = Romper + pYc;

            DECLARACION.Rule = TIPO + LISTA_ID + pYc;

            DECLA.Rule = TIPO + id;

            ASIGNACION.Rule = TIPO + id + asig + EXPL + pYc
                | id + asig + EXPL + pYc;

            DIBUJAR.Rule = DibujarAST + parA + E + parC + pYc
                        | DibujarEXP + parA + E + parC + pYc
                        | DibujarTS + parA + E + parC + pYc;

            LISTA_ID.Rule = MakePlusRule(LISTA_ID, coma, id);

            LISTA_PARAM.Rule = MakePlusRule(LISTA_PARAM, coma, DECLA)
                | MakePlusRule(LISTA_PARAM, coma, E)
                | Empty;

            UNICO.Rule = MakePlusRule(UNICO, OPERANDO, UNICOS);

            UNICOS.Rule = E;

            LLAMADA.Rule = id + parA + LISTA_PARAM + parC;

            LLAMFUNC.Rule = LLAMADA + pYc;

            SI.Rule = Es_verdadero + parA + EXPL + parC + llavA + ATRIBUTOS + llavC + SINO;

            SINO.Rule = Es_false + llavA + ATRIBUTOS + llavC
                    | Empty;

            INTERRUMPIR.Rule = Cambiar_A + parA + E + parC + llavA + CASOS + DEFECTO + llavC;

            CASOS.Rule = MakePlusRule(CASOS, CASO)
                | Empty;

            CASO.Rule = Valor + E + dosPuntos + ATRIBUTOS;

            DEFECTO.Rule = No_cumple + dosPuntos + ATRIBUTOS
                | Empty;

            MIENTRAS.Rule = Mientras + parA + EXPL + parC + llavA + ATRIBUTOS + llavC;

            HACER.Rule = Hasta_que + parA + EXPL + parC + llavA + ATRIBUTOS + llavC;

            OPERANDO.Rule = mas | menos | mul | div | pot | mod;

            TIPO.Rule = resInt
                | resDouble
                | resString
                | resChar
                | resBool;

            E.Rule = E + mas + E
                | E + menos + E
                | E + mul + E
                | E + div + E
                | E + mod + E
                | E + pot + E
                | parA + E + parC
                | menos + E
                | LLAMADA
                | id
                | doble
                | cadena
                | booleano
                | carac;

            EXPR.Rule = E + mayor + E
                | E + menor + E
                | E + mayorIgual + E
                | E + menorIgual + E
                | E + igualIgual + E
                | E + noIgual + E
                | E;

            EXPL.Rule = EXPL + OR + EXPL
                | EXPL + AND + EXPL
                | NOT + EXPL
                | EXPR;
            #endregion

            #region Preferencias
            this.Root = S;
            this.MarkTransient(PROGRAMA, CUERPO, ATRIBUTO, ATRIBUTOS, DECLARACION, ASIGNACION, PRINCIPAL, METODO, FUNCION, TIPO, MOSTRAR, DIBUJAR, LISTA_ID, 
                               LISTA_PARAM, DECLA, UNICO, UNICOS, LLAMADA, LLAMFUNC, OPERANDO, RETORNO, RETORN, SI, SINO, SINO_SI, SINOSI, INTERRUMPIR, CASO, CASOS, DEFECTO,
                               MIENTRAS, HACER, SALIR, DEFINIR, IMPORTAR, IMPORTE, CUERPOS);
            this.RegisterOperators(1, Associativity.Left, mas, menos);
            this.RegisterOperators(2, Associativity.Left, mul, div, mod);
            this.RegisterOperators(3, Associativity.Right, pot);
            this.RegisterOperators(4, "==", "!=", "<", ">", "<=", ">=");
            this.RegisterOperators(5, Associativity.Left, OR);
            this.RegisterOperators(6, Associativity.Left, AND);
            this.RegisterOperators(7, Associativity.Left, NOT);
            this.RegisterOperators(8, "(", ")");
            this.MarkPunctuation("(", ")", ",", ";", "[", "]", "=", "{", "}");
            #endregion
        }
    }
}
