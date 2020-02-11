
package Analisis;
import java.io.Reader;
import java_cup.runtime.Symbol;
import java.util.LinkedList;
import java.util.ArrayList;

%%
%cupsym sym
%class Lexico
%cup
%public
%unicode
%line
%column
%char
%ignorecase

//------------------------------------------------------------------------
//EXPRESIONES REGULARES

entero =[0-9]+ 
decimal =[0-9]+ "."? [0-9]*
cadena =[\"] [^\"\n]* [\"\n]
letra =[a-zA-ZÑñ]+
iden ={letra}({letra}|{entero}|"_"|" ")*({letra}|{entero})*
//texto ={letra}({letra}|{entero}|"."|" ")*
caracter="'"[^]"'"
bool=("verdadero"|"falso"|"1"|"0")
comilla =[\"]
%state COMENTARIO1,COMENTARIO2,ATRIBUTO


//-------------------------------------------------------------------------

%{
    //codigo de java
    String nombre;
    public void imprimir(String dato,String cadena){
    	//System.out.println(dato+" : "+cadena);
    }
    public void imprimir(String cadena){
    	//System.out.println(cadena+" soy reservada");
    }

    public ArrayList erroresL = new ArrayList();
    Sintactico sin = new Sintactico();

    private TablaSimbolos tabla;
    public Lexico(Reader in, TablaSimbolos t){
        this(in);
        this.tabla =t;
    }

%}

%%

//RESERVADAS
<YYINITIAL> "<html>"          {return new Symbol(sym.htmlA,yycolumn,yyline,yytext());}     
<YYINITIAL> "</html>"         {return new Symbol(sym.htmlC,yycolumn,yyline,yytext());}     
<YYINITIAL> "<head>"          {return new Symbol(sym.headA,yycolumn,yyline,yytext());}     
<YYINITIAL> "</head>"         {return new Symbol(sym.headC,yycolumn,yyline,yytext());}     
<YYINITIAL> "<body"          {return new Symbol(sym.bodyA,yycolumn,yyline,yytext());}     
<YYINITIAL> "</body>"         {return new Symbol(sym.bodyC,yycolumn,yyline,yytext());}     
<YYINITIAL> "<h1"             {return new Symbol(sym.h1A,yycolumn,yyline,yytext());}     
<YYINITIAL> "</h1>"           {return new Symbol(sym.h1C,yycolumn,yyline,yytext());}     
<YYINITIAL> "<h2"             {return new Symbol(sym.h2A,yycolumn,yyline,yytext());}     
<YYINITIAL> "</h2>"           {return new Symbol(sym.h2C,yycolumn,yyline,yytext());}     
<YYINITIAL> "<h3"             {return new Symbol(sym.h3A,yycolumn,yyline,yytext());}     
<YYINITIAL> "</h3>"           {return new Symbol(sym.h3C,yycolumn,yyline,yytext());}     
<YYINITIAL> "<h4"             {return new Symbol(sym.h4A,yycolumn,yyline,yytext());}     
<YYINITIAL> "</h4>"           {return new Symbol(sym.h4C,yycolumn,yyline,yytext());}     
<YYINITIAL> "<h5"             {return new Symbol(sym.h5A,yycolumn,yyline,yytext());}     
<YYINITIAL> "</h5>"           {return new Symbol(sym.h5C,yycolumn,yyline,yytext());}     
<YYINITIAL> "<h6"             {return new Symbol(sym.h6A,yycolumn,yyline,yytext());}     
<YYINITIAL> "</h6>"           {return new Symbol(sym.h6C,yycolumn,yyline,yytext());}     
<YYINITIAL> "<title>"         {return new Symbol(sym.titleA,yycolumn,yyline,yytext());}     
<YYINITIAL> "</title>"        {return new Symbol(sym.titleC,yycolumn,yyline,yytext());}     
<YYINITIAL> "<table"          {return new Symbol(sym.tableA,yycolumn,yyline,yytext());}     
<YYINITIAL> "</table>"        {return new Symbol(sym.tableC,yycolumn,yyline,yytext());}     
<YYINITIAL> "<th"             {return new Symbol(sym.thA,yycolumn,yyline,yytext());}     
<YYINITIAL> "</th>"           {return new Symbol(sym.thC,yycolumn,yyline,yytext());}     
<YYINITIAL> "<td"             {return new Symbol(sym.tdA,yycolumn,yyline,yytext());}     
<YYINITIAL> "</td>"           {return new Symbol(sym.tdC,yycolumn,yyline,yytext());}     
<YYINITIAL> "<tr"             {return new Symbol(sym.trA,yycolumn,yyline,yytext());}     
<YYINITIAL> "</tr>"           {return new Symbol(sym.trC,yycolumn,yyline,yytext());}     
<YYINITIAL> "<div"            {return new Symbol(sym.divA,yycolumn,yyline,yytext());}     
<YYINITIAL> "</div>"          {return new Symbol(sym.divC,yycolumn,yyline,yytext());}     
<YYINITIAL> "<p"              {return new Symbol(sym.pA,yycolumn,yyline,yytext());}     
<YYINITIAL> "</p>"            {return new Symbol(sym.pC,yycolumn,yyline,yytext());}     
<YYINITIAL> "<br>"            {return new Symbol(sym.br,yycolumn,yyline,yytext());}     
<YYINITIAL> "<hr>"            {return new Symbol(sym.hr,yycolumn,yyline,yytext());}     
<YYINITIAL> "color"           {return new Symbol(sym.col,yycolumn,yyline,yytext());}     
<YYINITIAL> "textcolor"       {return new Symbol(sym.txtcol,yycolumn,yyline,yytext());}     
<YYINITIAL> "align"           {return new Symbol(sym.alig,yycolumn,yyline,yytext());}     
<YYINITIAL> "font"            {return new Symbol(sym.fon,yycolumn,yyline,yytext());}     
<YYINITIAL> "rojo"            {return new Symbol(sym.rojo,yycolumn,yyline,yytext());}     
<YYINITIAL> "amarillo"        {return new Symbol(sym.amarillo,yycolumn,yyline,yytext());}     
<YYINITIAL> "azul"            {return new Symbol(sym.azul,yycolumn,yyline,yytext());}     
<YYINITIAL> "verde"           {return new Symbol(sym.verde,yycolumn,yyline,yytext());}     
<YYINITIAL> "gris"            {return new Symbol(sym.gris,yycolumn,yyline,yytext());}     
<YYINITIAL> "anaranjado"      {return new Symbol(sym.anaranjado,yycolumn,yyline,yytext());}     
<YYINITIAL> "morado"          {return new Symbol(sym.morado,yycolumn,yyline,yytext());}     
<YYINITIAL> "izquierda"       {return new Symbol(sym.izquierda,yycolumn,yyline,yytext());}     
<YYINITIAL> "derecha"         {return new Symbol(sym.derecha,yycolumn,yyline,yytext());}     
<YYINITIAL> "centrado"        {return new Symbol(sym.centrado,yycolumn,yyline,yytext());}     
<YYINITIAL> "agency fb"       {return new Symbol(sym.afb,yycolumn,yyline,yytext());}     
<YYINITIAL> "antiqua"         {return new Symbol(sym.antiq,yycolumn,yyline,yytext());}     
<YYINITIAL> "architect"       {return new Symbol(sym.archi,yycolumn,yyline,yytext());}     
<YYINITIAL> "arial"           {return new Symbol(sym.arial,yycolumn,yyline,yytext());}     
<YYINITIAL> "bankfuturistic"  {return new Symbol(sym.bf,yycolumn,yyline,yytext());}     
<YYINITIAL> "bankgothic"      {return new Symbol(sym.bg,yycolumn,yyline,yytext());}     
<YYINITIAL> "blackletter"     {return new Symbol(sym.bl,yycolumn,yyline,yytext());}     
<YYINITIAL> "blagovest"       {return new Symbol(sym.bv,yycolumn,yyline,yytext());}     
<YYINITIAL> "calibri"         {return new Symbol(sym.calib,yycolumn,yyline,yytext());}     
<YYINITIAL> "comic sans ms"   {return new Symbol(sym.csm,yycolumn,yyline,yytext());}     
<YYINITIAL> "courier"         {return new Symbol(sym.cour,yycolumn,yyline,yytext());}     
<YYINITIAL> "cursive"         {return new Symbol(sym.curs,yycolumn,yyline,yytext());}     
<YYINITIAL> "decorative"      {return new Symbol(sym.deco,yycolumn,yyline,yytext());}     
<YYINITIAL> "fantasy"         {return new Symbol(sym.fanta,yycolumn,yyline,yytext());}     
<YYINITIAL> "franktur"        {return new Symbol(sym.frank,yycolumn,yyline,yytext());}     
<YYINITIAL> "garamond"        {return new Symbol(sym.garam,yycolumn,yyline,yytext());}     
<YYINITIAL> "georgia"         {return new Symbol(sym.georg,yycolumn,yyline,yytext());}     
<YYINITIAL> "helvetica"       {return new Symbol(sym.helve,yycolumn,yyline,yytext());}     
<YYINITIAL> "impact"          {return new Symbol(sym.impact,yycolumn,yyline,yytext());}     
<YYINITIAL> "minion"          {return new Symbol(sym.minion,yycolumn,yyline,yytext());}     
<YYINITIAL> "modern"          {return new Symbol(sym.modern,yycolumn,yyline,yytext());}     
<YYINITIAL> "monospace"       {return new Symbol(sym.monos,yycolumn,yyline,yytext());}     
<YYINITIAL> "open sans"       {return new Symbol(sym.os,yycolumn,yyline,yytext());}     
<YYINITIAL> "palatino"        {return new Symbol(sym.pala,yycolumn,yyline,yytext());}     
<YYINITIAL> "roman"           {return new Symbol(sym.roman,yycolumn,yyline,yytext());}     
<YYINITIAL> "sans-serif"      {return new Symbol(sym.sanss,yycolumn,yyline,yytext());}     
<YYINITIAL> "serif"           {return new Symbol(sym.serif,yycolumn,yyline,yytext());}     
<YYINITIAL> "script"          {return new Symbol(sym.scri,yycolumn,yyline,yytext());}     
<YYINITIAL> "swiss"           {return new Symbol(sym.swss,yycolumn,yyline,yytext());}     
<YYINITIAL> "times"           {return new Symbol(sym.tms,yycolumn,yyline,yytext());}     
<YYINITIAL> "times new roman" {return new Symbol(sym.tnr,yycolumn,yyline,yytext());}     
<YYINITIAL> "tw cen mt"       {return new Symbol(sym.tcm,yycolumn,yyline,yytext());}     
<YYINITIAL> "verdana"         {return new Symbol(sym.ver,yycolumn,yyline,yytext());}     

<YYINITIAL> "String"          {return new Symbol(sym.resString,yycolumn,yyline,yytext());}
<YYINITIAL> "int"             {return new Symbol(sym.resInt,yycolumn,yyline,yytext());}
<YYINITIAL> "Double"          {return new Symbol(sym.resDouble,yycolumn,yyline,yytext());}
<YYINITIAL> "char"            {return new Symbol(sym.resChar,yycolumn,yyline,yytext());}
<YYINITIAL> "boolean"         {return new Symbol(sym.resBoolean,yycolumn,yyline,yytext());}

<YYINITIAL> "Print"           {return new Symbol(sym.resPrint,yycolumn,yyline,yytext());}
<YYINITIAL> "RESULT"          {return new Symbol(sym.resResult,yycolumn,yyline,yytext());}
<YYINITIAL> "score"           {return new Symbol(sym.resScore,yycolumn,yyline,yytext());}
<YYINITIAL> "variables"       {return new Symbol(sym.resVar,yycolumn,yyline,yytext());}
<YYINITIAL> "metodos"         {return new Symbol(sym.resMet,yycolumn,yyline,yytext());}
<YYINITIAL> "clases"          {return new Symbol(sym.resClases,yycolumn,yyline,yytext());}
<YYINITIAL> "nombre"          {return new Symbol(sym.resNom,yycolumn,yyline,yytext());}
<YYINITIAL> "cantidad"        {return new Symbol(sym.resCant,yycolumn,yyline,yytext());}

//SIMBOLOS
<YYINITIAL> "+"               {return new Symbol(sym.mas,yycolumn,yyline,yytext());}     
<YYINITIAL> "-"               {return new Symbol(sym.menos,yycolumn,yyline,yytext());}     
<YYINITIAL> "*"               {return new Symbol(sym.mul,yycolumn,yyline,yytext());}     
<YYINITIAL> "/"               {return new Symbol(sym.div,yycolumn,yyline,yytext());}    
<YYINITIAL> "%"               {return new Symbol(sym.modulo,yycolumn,yyline,yytext());}  

<YYINITIAL> "<"               {return new Symbol(sym.menorq,yycolumn,yyline,yytext());}
<YYINITIAL> "<="              {return new Symbol(sym.menorIgual,yycolumn,yyline,yytext());}
<YYINITIAL> ">"               {return new Symbol(sym.mayorq,yycolumn,yyline,yytext());}
<YYINITIAL> ">="              {return new Symbol(sym.mayorIgual,yycolumn,yyline,yytext());}
<YYINITIAL> "=="              {return new Symbol(sym.igualIgual,yycolumn,yyline,yytext());} 
<YYINITIAL> "!="              {return new Symbol(sym.noIgual,yycolumn,yyline,yytext());} 
<YYINITIAL> "="               {return new Symbol(sym.igual,yycolumn,yyline,yytext());} 
<YYINITIAL> ";"               {return new Symbol(sym.puntoYcoma,yycolumn,yyline,yytext());}
<YYINITIAL> "("               {return new Symbol(sym.parA,yycolumn,yyline,yytext());}
<YYINITIAL> ")"               {return new Symbol(sym.parC,yycolumn,yyline,yytext());}
<YYINITIAL> "["               {return new Symbol(sym.corA,yycolumn,yyline,yytext());}
<YYINITIAL> "]"               {return new Symbol(sym.corC,yycolumn,yyline,yytext());}
<YYINITIAL> "."               {return new Symbol(sym.punto,yycolumn,yyline,yytext());}

<YYINITIAL> "++"              {return new Symbol(sym.incre,yycolumn,yyline,yytext());}     
<YYINITIAL> "--"              {return new Symbol(sym.decre,yycolumn,yyline,yytext());}     

<YYINITIAL> "+="              {return new Symbol(sym.masIgual,yycolumn,yyline,yytext());}     
<YYINITIAL> "-="              {return new Symbol(sym.menosIgual,yycolumn,yyline,yytext());}     
<YYINITIAL> "*="              {return new Symbol(sym.mulIgual,yycolumn,yyline,yytext());}     

<YYINITIAL> "$$"              {return new Symbol(sym.dobleDolar,yycolumn,yyline,yytext());}
<YYINITIAL> "&&"              {return new Symbol(sym.and,yycolumn,yyline,yytext());}
<YYINITIAL> "||"              {return new Symbol(sym.or,yycolumn,yyline,yytext());}
<YYINITIAL> "!"               {return new Symbol(sym.not,yycolumn,yyline,yytext());}

<YYINITIAL> {entero}          {return new Symbol(sym.entero,yycolumn,yyline,new Integer(yytext()));}
<YYINITIAL> {decimal}         {return new Symbol(sym.decimal,yycolumn,yyline,yytext());}
<YYINITIAL> {cadena}          {return new Symbol(sym.cadena,yycolumn,yyline,yytext());}
<YYINITIAL> {bool}            {return new Symbol(sym.bool,yycolumn,yyline,yytext());}
<YYINITIAL> {iden}            {Simbolo s;if((s=tabla.buscar(yytext()))==null)s=tabla.insertar(yytext());return new Symbol(sym.iden,yycolumn,yyline,yytext());}
<YYINITIAL> {caracter}        {return new Symbol(sym.caracter,yycolumn,yyline,yytext());}
<YYINITIAL> {comilla}         {return new Symbol(sym.comia,yycolumn,yyline,yytext());}


/* COMENTARIOS */
<YYINITIAL> "</"    {yybegin(COMENTARIO1);sin.al.add("comentario multilinea");}
<COMENTARIO1> [\n] {}
<COMENTARIO1> [^"/>"] {}
<COMENTARIO1> "/>" {yybegin(YYINITIAL);}

<YYINITIAL> "->" {yybegin(COMENTARIO2);sin.al.add("comentario de una linea");}
<COMENTARIO2> [^\n] {}
<COMENTARIO2> [\n] {yybegin(YYINITIAL);}

/* ATRIBUTOS 
<YYINITIAL> {comilla}         {yybegin(ATRIBUTO);}
<ATRIBUTO> "color"           {return new Symbol(sym.col,yycolumn,yyline,yytext());}     
<ATRIBUTO> "textcolor"       {return new Symbol(sym.txtcol,yycolumn,yyline,yytext());}     
<ATRIBUTO> "align"           {return new Symbol(sym.alig,yycolumn,yyline,yytext());}     
<ATRIBUTO> "font"            {return new Symbol(sym.fon,yycolumn,yyline,yytext());}     
<ATRIBUTO> "rojo"            {return new Symbol(sym.rojo,yycolumn,yyline,yytext());}     
<ATRIBUTO> "amarillo"        {return new Symbol(sym.amarillo,yycolumn,yyline,yytext());}     
<ATRIBUTO> "azul"            {return new Symbol(sym.azul,yycolumn,yyline,yytext());}     
<ATRIBUTO> "verde"           {return new Symbol(sym.verde,yycolumn,yyline,yytext());}     
<ATRIBUTO> "gris"            {return new Symbol(sym.gris,yycolumn,yyline,yytext());}     
<ATRIBUTO> "anaranjado"      {return new Symbol(sym.anaranjado,yycolumn,yyline,yytext());}     
<ATRIBUTO> "morado"          {return new Symbol(sym.morado,yycolumn,yyline,yytext());}     
<ATRIBUTO> "izquierda"       {return new Symbol(sym.izquierda,yycolumn,yyline,yytext());}     
<ATRIBUTO> "derecha"         {return new Symbol(sym.derecha,yycolumn,yyline,yytext());}     
<ATRIBUTO> "centrado"        {return new Symbol(sym.centrado,yycolumn,yyline,yytext());}     
<ATRIBUTO> "agency fb"       {return new Symbol(sym.afb,yycolumn,yyline,yytext());}     
<ATRIBUTO> "antiqua"         {return new Symbol(sym.antiq,yycolumn,yyline,yytext());}     
<ATRIBUTO> "architect"       {return new Symbol(sym.archi,yycolumn,yyline,yytext());}     
<ATRIBUTO> "arial"           {return new Symbol(sym.arial,yycolumn,yyline,yytext());}     
<ATRIBUTO> "bankfuturistic"  {return new Symbol(sym.bf,yycolumn,yyline,yytext());}     
<ATRIBUTO> "bankgothic"      {return new Symbol(sym.bg,yycolumn,yyline,yytext());}     
<ATRIBUTO> "blackletter"     {return new Symbol(sym.bl,yycolumn,yyline,yytext());}     
<ATRIBUTO> "blagovest"       {return new Symbol(sym.bv,yycolumn,yyline,yytext());}     
<ATRIBUTO> "calibri"         {return new Symbol(sym.calib,yycolumn,yyline,yytext());}     
<ATRIBUTO> "comic sans ms"   {return new Symbol(sym.csm,yycolumn,yyline,yytext());}     
<ATRIBUTO> "courier"         {return new Symbol(sym.cour,yycolumn,yyline,yytext());}     
<ATRIBUTO> "cursive"         {return new Symbol(sym.curs,yycolumn,yyline,yytext());}     
<ATRIBUTO> "decorative"      {return new Symbol(sym.deco,yycolumn,yyline,yytext());}     
<ATRIBUTO> "fantasy"         {return new Symbol(sym.fanta,yycolumn,yyline,yytext());}     
<ATRIBUTO> "franktur"        {return new Symbol(sym.frank,yycolumn,yyline,yytext());}     
<ATRIBUTO> "garamond"        {return new Symbol(sym.garam,yycolumn,yyline,yytext());}     
<ATRIBUTO> "georgia"         {return new Symbol(sym.georg,yycolumn,yyline,yytext());}     
<ATRIBUTO> "helvetica"       {return new Symbol(sym.helve,yycolumn,yyline,yytext());}     
<ATRIBUTO> "impact"          {return new Symbol(sym.impact,yycolumn,yyline,yytext());}     
<ATRIBUTO> "minion"          {return new Symbol(sym.minion,yycolumn,yyline,yytext());}     
<ATRIBUTO> "modern"          {return new Symbol(sym.modern,yycolumn,yyline,yytext());}     
<ATRIBUTO> "monospace"       {return new Symbol(sym.monos,yycolumn,yyline,yytext());}     
<ATRIBUTO> "open sans"       {return new Symbol(sym.os,yycolumn,yyline,yytext());}     
<ATRIBUTO> "palatino"        {return new Symbol(sym.pala,yycolumn,yyline,yytext());}     
<ATRIBUTO> "roman"           {return new Symbol(sym.roman,yycolumn,yyline,yytext());}     
<ATRIBUTO> "sans-serif"      {return new Symbol(sym.sanss,yycolumn,yyline,yytext());}     
<ATRIBUTO> "serif"           {return new Symbol(sym.serif,yycolumn,yyline,yytext());}     
<ATRIBUTO> "script"          {return new Symbol(sym.scri,yycolumn,yyline,yytext());}     
<ATRIBUTO> "swiss"           {return new Symbol(sym.swss,yycolumn,yyline,yytext());}     
<ATRIBUTO> "times"           {return new Symbol(sym.tms,yycolumn,yyline,yytext());}     
<ATRIBUTO> "times new roman" {return new Symbol(sym.tnr,yycolumn,yyline,yytext());}     
<ATRIBUTO> "tw cen mt"       {return new Symbol(sym.tcm,yycolumn,yyline,yytext());}     
<ATRIBUTO> "verdana"         {return new Symbol(sym.ver,yycolumn,yyline,yytext());}     
*/

/* BLANCOS */
<YYINITIAL> [ \t\r\f\n]+     {/* Se ignoran */}


/* Cualquier Otro   ERROR LEXICO*/
.   {
	System.err.println("Error lexico: "+yytext()+ " Linea:"+(yyline+1)+" Columna:"+(yycolumn+1));

        erroresL.add("Error lexico: "+yytext()+ " Linea:"+(yyline+1)+" Columna:"+(yycolumn+1)+"\n");

	}



