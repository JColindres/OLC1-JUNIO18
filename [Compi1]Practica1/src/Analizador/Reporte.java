/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package Analizador;

import Analisis.Lexico;
import Analisis.Sintactico;
import java.io.BufferedReader;
import java.io.FileWriter;
import java.io.PrintWriter;
import java.io.StringReader;

/**
 *
 * @author pablo
 */
public class Reporte {
    
    public void Crear(){
    
        Sintactico sin = new Sintactico();
        FileWriter f = null;
        PrintWriter p =null;
        try{
        
            f = new FileWriter("Reporte.html");
            p = new PrintWriter(f);
            p.println("<html>");
            p.println("<title>Repeticiones</title>");
            p.println("<body>");
            p.println("<center>Sentencias</center>");
            p.println("<center><table border=\"2\">");
            p.println("<tr>");
            p.println("<th>Repeticiones</th>");
            p.println("<th>Tipos de Sentencia</th>");
            p.println("<th>Descripcion</th>");
            p.println("</tr>");
            p.println("<tr>");
            p.println("<th>"+sin.metodo+"</th>");
            p.println("<th>Metodos</th>");
            p.println("<th>Los metodos son aquellos que realizan procesos y operaciones. Pueden tener parametros y no devuelven ningun tipo de valor.</th>");
            p.println("</tr>");
            p.println("<tr>");
            p.println("<th>"+sin.funcionInt+"</th>");
            p.println("<th>Funcion Entera</th>");
            p.println("<th>Funcion que realiza procesos y operaciones devolviendo un resultado de tipo entero.</th>");
            p.println("</tr>");
            p.println("<tr>");
            p.println("<th>"+sin.funcionDouble+"</th>");
            p.println("<th>Funcion Decimal</th>");
            p.println("<th>Funcion que realiza procesos y operaciones devolviendo un resultado de tipo decimal.</th>");
            p.println("</tr>");
            p.println("<tr>");
            p.println("<th>"+sin.funcionBool+"</th>");
            p.println("<th>Funcion Booleana</th>");
            p.println("<th>Funcion que realiza procesos y operaciones devolviendo un resultado de tipo booleana.</th>");
            p.println("</tr>");
            p.println("<tr>");
            p.println("<th>"+sin.funcionChar+"</th>");
            p.println("<th>Funcion Caracter</tqh>");
            p.println("<th>Funcion que realiza procesos y operaciones devolviendo un resultado de tipo caracter.</th>");
            p.println("</tr>");
            p.println("<tr>");
            p.println("<th>"+sin.funcionString+"</th>");
            p.println("<th>Funcion Texto</th>");
            p.println("<th>Funcion que realiza procesos y operaciones devolviendo un resultado de tipo texto.</th>");
            p.println("</tr>");
            p.println("<tr>");
            p.println("<th>"+sin.declaInt+"</th>");
            p.println("<th>Declaracion de entero</th>");
            p.println("<th>Declaracion de variables que sirve para almacenar valores de tipo entero.</th>");
            p.println("</tr>");
            p.println("<tr>");
            p.println("<th>"+sin.declaDouble+"</th>");
            p.println("<th>Declaracion de decimal</th>");
            p.println("<th>Declaracion de variables que sirve para almacenar valores de tipo decimal.</th>");
            p.println("</tr>");
            p.println("<tr>");
            p.println("<th>"+sin.declaBool+"</th>");
            p.println("<th>Declaracion de booleano</th>");
            p.println("<th>Declaracion de variables que sirve para almacenar valores de tipo booleano.</th>");
            p.println("</tr>");
            p.println("<tr>");
            p.println("<th>"+sin.declaChar+"</th>");
            p.println("<th>Declaracion de caracter</th>");
            p.println("<th>Declaracion de variables que sirve para almacenar valores de tipo caracter.</th>");
            p.println("</tr>");
            p.println("<tr>");
            p.println("<th>"+sin.declaString+"</th>");
            p.println("<th>Declaracion de texto</th>");
            p.println("<th>Declaracion de variables que sirve para almacenar valores de tipo texto.</th>");
            p.println("</tr>");
            p.println("<tr>");
            p.println("<th>"+sin.declaAsigInt+"</th>");
            p.println("<th>Declaracion y Asignacion de entero</th>");
            p.println("<th>Las variables almacenan un valor de tipo entero al momento de declararla.</th>");
            p.println("</tr>");
            p.println("<tr>");
            p.println("<th>"+sin.declaAsigDouble+"</th>");
            p.println("<th>Declaracion y Asignacion de decimal</th>");
            p.println("<th>Las variables almacenan un valor de tipo decimal al momento de declararla.</th>");
            p.println("</tr>");
            p.println("<tr>");
            p.println("<th>"+sin.declaAsigBool+"</th>");
            p.println("<th>Declaracion y Asignacion de booleano</th>");
            p.println("<th>Las variables almacenan un valor de tipo booleano al momento de declararla.</th>");
            p.println("</tr>");
            p.println("<tr>");
            p.println("<th>"+sin.declaAsigChar+"</th>");
            p.println("<th>Declaracion y Asignacion de caracter</th>");
            p.println("<th>Las variables almacenan un valor de tipo caracter al momento de declararla.</th>");
            p.println("</tr>");
            p.println("<tr>");
            p.println("<th>"+sin.declaAsigString+"</th>");
            p.println("<th>Declaracion y Asignacion de Texto</th>");
            p.println("<th>Las variables almacenan un valor de tipo texto al momento de declararla.</th>");
            p.println("</tr>");
            p.println("<tr>");
            p.println("<th>"+sin.si+"</th>");
            p.println("<th>Sentencia Si</th>");
            p.println("<th>Sentencia para ejecutar acciones si la condicion es verdadera.</th>");
            p.println("</tr>");
            p.println("<tr>");
            p.println("<th>"+sin.sino+"</th>");
            p.println("<th>Sentencia Sino</th>");
            p.println("<th>Sentencia para ejecutar acciones si la condicion de la sentencia si es falsa.</th>");
            p.println("</tr>");
            p.println("<tr>");
            p.println("<th>"+sin.para+"</th>");
            p.println("<th>Sentencia Para</th>");
            p.println("<th>Sentencia para ejecutar acciones un numero determinado de veces, tiene una inicializacion, una finalizacion y un incremento.</th>");
            p.println("</tr>");
            p.println("<tr>");
            p.println("<th>"+sin.mientras+"</th>");
            p.println("<th>Sentencia mientras</th>");
            p.println("<th>Sentencia para ejecutar acciones mientras cumpla con una condicion.</th>");
            p.println("</tr>");
            p.println("<tr>");
            p.println("<th>"+sin.hacer+"</th>");
            p.println("<th>Sentencia Hacer-Mientras</th>");
            p.println("<th>Sentencia para ejecutar acciones al menos una vez y es reejuctada cada vez que la condicion se evalua a verdadera.</th>");
            p.println("</tr>");
            p.println("<tr>");
            p.println("<th>"+sin.selecc+"</th>");
            p.println("<th>Sentencia Seleccionar</th>");
            p.println("<th>Sentencia que se utiliza para agilizar la toma de decisiones multiples.</th>");
            p.println("</tr>");
            p.println("<tr>");
            p.println("<th>"+sin.continuar+"</th>");
            p.println("<th>Sentencia Continuar</th>");
            p.println("<th>Es un tipo de control de bucles. Esta sentencia se salta al siguiente ciclo de la iteracion.</th>");
            p.println("</tr>");
            p.println("<tr>");
            p.println("<th>"+sin.interrumpir+"</th>");
            p.println("<th>Sentencia Interrumpir</th>");
            p.println("<th>Es un tipo de control de bucles. Esta sentencia rompe la iteracion de dicho bucle.</th>");
            p.println("</tr>");
            p.println("</table></center>");
            p.println("</body>");
            p.println("</html>");
        
        }catch(Exception e){
        
        }finally{        
            try{            
                if(null != f){
                    f.close();
                }
                }catch(Exception ex){
                
                }
            }
        
        
    
    }
    
}
