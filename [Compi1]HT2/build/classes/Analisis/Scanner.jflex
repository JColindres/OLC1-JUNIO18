
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
<YYINITIAL> "Panel"          {return new Symbol(sym.resPanel,yycolumn,yyline,yytext());}
<YYINITIAL> "Dibujar"        {return new Symbol(sym.Dibujar,yycolumn,yyline,yytext());}
<YYINITIAL> "Rojo"           {return new Symbol(sym.Rojo,yycolumn,yyline,yytext());}
<YYINITIAL> "Azul"           {return new Symbol(sym.Azul,yycolumn,yyline,yytext());}
<YYINITIAL> "Amarillo"       {return new Symbol(sym.Amarillo,yycolumn,yyline,yytext());}
<YYINITIAL> "Naranja"        {return new Symbol(sym.Naranja,yycolumn,yyline,yytext());}
<YYINITIAL> "Verde"          {return new Symbol(sym.Verde,yycolumn,yyline,yytext());}
<YYINITIAL> "Morado"         {return new Symbol(sym.Morado,yycolumn,yyline,yytext());}
<YYINITIAL> "Blanco"         {return new Symbol(sym.Blanco,yycolumn,yyline,yytext());}
<YYINITIAL> "Negro"          {return new Symbol(sym.Negro,yycolumn,yyline,yytext());}


//SIMBOLOS
<YYINITIAL> ","              {return new Symbol(sym.coma,yycolumn,yyline,yytext());}
<YYINITIAL> ":"              {return new Symbol(sym.dosPuntos,yycolumn,yyline,yytext());}  
<YYINITIAL> "("              {return new Symbol(sym.parA,yycolumn,yyline,yytext());}
<YYINITIAL> ")"              {return new Symbol(sym.parC,yycolumn,yyline,yytext());} 
<YYINITIAL> "["              {return new Symbol(sym.corA,yycolumn,yyline,yytext());}
<YYINITIAL> "]"              {return new Symbol(sym.corC,yycolumn,yyline,yytext());}
<YYINITIAL> "="              {return new Symbol(sym.igual,yycolumn,yyline,yytext());}

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



