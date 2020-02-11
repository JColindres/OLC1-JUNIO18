
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


%}

%%

//RESERVADAS
<YYINITIAL> "N"              {return new Symbol(sym.Norte,yycolumn,yyline,yytext());}
<YYINITIAL> "O"              {return new Symbol(sym.Oeste,yycolumn,yyline,yytext());}
<YYINITIAL> "S"              {return new Symbol(sym.Sur,yycolumn,yyline,yytext());}
<YYINITIAL> "E"              {return new Symbol(sym.Este,yycolumn,yyline,yytext());}


//SIMBOLOS
<YYINITIAL> ","              {return new Symbol(sym.coma,yycolumn,yyline,yytext());}
<YYINITIAL> ":"              {return new Symbol(sym.dosPuntos,yycolumn,yyline,yytext());}  
<YYINITIAL> "("              {return new Symbol(sym.parA,yycolumn,yyline,yytext());}
<YYINITIAL> ")"              {return new Symbol(sym.parC,yycolumn,yyline,yytext());}

<YYINITIAL> {entero}         {return new Symbol(sym.entero,yycolumn,yyline,yytext());}
<YYINITIAL> {cadena}         {return new Symbol(sym.cadena,yycolumn,yyline,yytext());}
<YYINITIAL> {iden}           {return new Symbol(sym.iden,yycolumn,yyline,yytext());}

 

/* COMENTARIOS */
<YYINITIAL> "/*"    {yybegin(COMENTARIO1);sin.al.add("comentario multilinea ");}
<COMENTARIO1> [\n] {}
<COMENTARIO1> [^"*/"] {}
<COMENTARIO1> "*/" {yybegin(YYINITIAL);}

<YYINITIAL> "//" {yybegin(COMENTARIO2);sin.al.add("comentario de una linea ");}
<COMENTARIO2> [^\n] {}
<COMENTARIO2> [\n] {yybegin(YYINITIAL);}

/* BLANCOS */
<YYINITIAL> [ \t\r\f\n]+     {/* Se ignoran */}


/* Cualquier Otro   ERROR LEXICO*/
.   {
	System.err.println("Error lexico: "+yytext()+ " Linea:"+(yyline+1)+" Columna:"+(yycolumn+1));
        
        erroresL.add("Error lexico: "+yytext()+ " Linea:"+(yyline+1)+" Columna:"+(yycolumn+1)+"\n");

	}



