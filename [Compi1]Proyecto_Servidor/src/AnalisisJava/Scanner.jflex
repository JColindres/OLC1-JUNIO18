
package Analisis;
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

//------------------------------------------------------------------------
//EXPRESIONES REGULARES

entero =[0-9]+ 
decimal =[0-9]+ "."? [0-9]*
cadena =[\"] [^\"\n]* [\"\n]
letra =[a-zA-ZÑñ]+
iden ={letra}({letra}|{entero}|"_")*({letra}|{entero})*
caracter="'"[^]"'"
bool=("verdadero"|"falso"|"1"|"0")
%state COMENTARIO1,COMENTARIO2


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
    public String nomb = "no sirve";

%}

%%

//RESERVADAS
<YYINITIAL> "import"            {return new Symbol(sym.resImport,yycolumn,yyline,yytext());}
<YYINITIAL> "private"            {return new Symbol(sym.resPrivate,yycolumn,yyline,yytext());}
<YYINITIAL> "public"            {return new Symbol(sym.resPublic,yycolumn,yyline,yytext());}
<YYINITIAL> "protected"            {return new Symbol(sym.resProtected,yycolumn,yyline,yytext());}
<YYINITIAL> "final"            {return new Symbol(sym.resFinal,yycolumn,yyline,yytext());}
<YYINITIAL> "class"            {return new Symbol(sym.resClass,yycolumn,yyline,yytext());}
<YYINITIAL> "int"            {return new Symbol(sym.resInt,yycolumn,yyline,yytext());}
<YYINITIAL> "boolean"            {return new Symbol(sym.resBoolean,yycolumn,yyline,yytext());}
<YYINITIAL> "String"            {return new Symbol(sym.resString,yycolumn,yyline,yytext());}
<YYINITIAL> "char"            {return new Symbol(sym.resChar,yycolumn,yyline,yytext());}
<YYINITIAL> "double"            {return new Symbol(sym.resDouble,yycolumn,yyline,yytext());}
<YYINITIAL> "long"            {return new Symbol(sym.resLong,yycolumn,yyline,yytext());}
<YYINITIAL> "Object"            {return new Symbol(sym.resObject,yycolumn,yyline,yytext());}
<YYINITIAL> "if"            {return new Symbol(sym.resIf,yycolumn,yyline,yytext());}
<YYINITIAL> "else"            {return new Symbol(sym.resElse,yycolumn,yyline,yytext());}
<YYINITIAL> "for"            {return new Symbol(sym.resFor,yycolumn,yyline,yytext());}
<YYINITIAL> "while"            {return new Symbol(sym.resWhile,yycolumn,yyline,yytext());}
<YYINITIAL> "do"            {return new Symbol(sym.resDo,yycolumn,yyline,yytext());}
<YYINITIAL> "switch"            {return new Symbol(sym.resSwitch,yycolumn,yyline,yytext());}
<YYINITIAL> "case"            {return new Symbol(sym.resCase,yycolumn,yyline,yytext());}
<YYINITIAL> "break"            {return new Symbol(sym.resBreak,yycolumn,yyline,yytext());}
<YYINITIAL> "return"            {return new Symbol(sym.resReturn,yycolumn,yyline,yytext());}
<YYINITIAL> "default"            {return new Symbol(sym.resDefault,yycolumn,yyline,yytext());}
<YYINITIAL> "void"            {return new Symbol(sym.resVoid,yycolumn,yyline,yytext());}
<YYINITIAL> "static"            {return new Symbol(sym.resStatic,yycolumn,yyline,yytext());}


//SIMBOLOS
<YYINITIAL> "+"              {return new Symbol(sym.mas,yycolumn,yyline,yytext());}     
<YYINITIAL> "-"              {return new Symbol(sym.menos,yycolumn,yyline,yytext());}     
<YYINITIAL> "*"              {return new Symbol(sym.mul,yycolumn,yyline,yytext());}     
<YYINITIAL> "/"              {return new Symbol(sym.div,yycolumn,yyline,yytext());}    
<YYINITIAL> "%"              {return new Symbol(sym.modulo,yycolumn,yyline,yytext());}  

<YYINITIAL> "<"              {return new Symbol(sym.menorq,yycolumn,yyline,yytext());}
<YYINITIAL> "<="             {return new Symbol(sym.menorIgual,yycolumn,yyline,yytext());}
<YYINITIAL> ">"              {return new Symbol(sym.mayorq,yycolumn,yyline,yytext());}
<YYINITIAL> ">="             {return new Symbol(sym.mayorIgual,yycolumn,yyline,yytext());}
<YYINITIAL> "="              {return new Symbol(sym.igual,yycolumn,yyline,yytext());} 
<YYINITIAL> ","              {return new Symbol(sym.coma,yycolumn,yyline,yytext());}
<YYINITIAL> ";"              {return new Symbol(sym.puntoYcoma,yycolumn,yyline,yytext());}
<YYINITIAL> ":"              {return new Symbol(sym.dosPuntos,yycolumn,yyline,yytext());}  
<YYINITIAL> "("              {return new Symbol(sym.parentesisA,yycolumn,yyline,yytext());}
<YYINITIAL> ")"              {return new Symbol(sym.parentesisC,yycolumn,yyline,yytext());}
<YYINITIAL> "["              {return new Symbol(sym.corA,yycolumn,yyline,yytext());}
<YYINITIAL> "]"              {return new Symbol(sym.corC,yycolumn,yyline,yytext());}
<YYINITIAL> "{"              {return new Symbol(sym.parA,yycolumn,yyline,yytext());}
<YYINITIAL> "}"              {return new Symbol(sym.parC,yycolumn,yyline,yytext());}
<YYINITIAL> "."              {return new Symbol(sym.punto,yycolumn,yyline,yytext());}

<YYINITIAL> "++"              {return new Symbol(sym.incre,yycolumn,yyline,yytext());}     
<YYINITIAL> "--"              {return new Symbol(sym.decre,yycolumn,yyline,yytext());}     

<YYINITIAL> "&&"            {return new Symbol(sym.and,yycolumn,yyline,yytext());}
<YYINITIAL> "||"             {return new Symbol(sym.or,yycolumn,yyline,yytext());}
<YYINITIAL> "!"            {return new Symbol(sym.not,yycolumn,yyline,yytext());}

<YYINITIAL> {entero}         {return new Symbol(sym.entero,yycolumn,yyline,yytext());}
<YYINITIAL> {decimal}        {return new Symbol(sym.decimal,yycolumn,yyline,yytext());}
<YYINITIAL> {cadena}         {return new Symbol(sym.cadena,yycolumn,yyline,yytext());}
<YYINITIAL> {bool}           {return new Symbol(sym.bool,yycolumn,yyline,yytext());}
<YYINITIAL> {iden}           {return new Symbol(sym.iden,yycolumn,yyline,yytext());}
<YYINITIAL> {caracter}       {return new Symbol(sym.caracter,yycolumn,yyline,yytext());}

 

/* COMENTARIOS */
<YYINITIAL> "/*"    {yybegin(COMENTARIO1);sin.al.add("comentario multilinea ");System.out.println("comentario multilinea ");}
<COMENTARIO1> [\n] {}
<COMENTARIO1> [^"*/"] {Sintactico alv = new Sintactico();alv.COMENTARIOS+=""+yytext();}
<COMENTARIO1> "*/" {yybegin(YYINITIAL);}

<YYINITIAL> "//" {yybegin(COMENTARIO2);sin.al.add("comentario de una linea ");System.out.println("comentario multilinea ");}
<COMENTARIO2> [^\n] {Sintactico alv = new Sintactico();alv.COMENTARIOS+=""+yytext();}
<COMENTARIO2> [\n] {yybegin(YYINITIAL);}

/* BLANCOS */
<YYINITIAL> [ \t\r\f\n]+     {/* Se ignoran */}


/* Cualquier Otro   ERROR LEXICO*/
.   {
	System.err.println("Error lexico: "+yytext()+ " Linea:"+(yyline+1)+" Columna:"+(yycolumn+1));

        erroresL.add("Error lexico: "+yytext()+ " Linea:"+(yyline+1)+" Columna:"+(yycolumn+1)+"\n");

	}



