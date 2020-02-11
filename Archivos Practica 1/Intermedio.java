/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package Interfaz;

import java.applet.Applet;
import javax.swing.ButtonGroup;
import javax.jws.*;

/**
 *
 * @author Luis
 */
public class Intermedio {
    
    public static void main(String[] args) {
        ///metodo principal del archivo intermedio ///
        
        int j=0;
        j=j+j+j;
        char c = 'h';
        char d = 'o';
    }
    
    public void metodo_aritmeticas (int a, int b, int c){
        int suma= a+b+c;
        int resta= a-b-c-15;
        double multiplicacion = 5*5*(10+2);
        double division = (5*(-1)+10)/2;
    }
    
    
    public void metodo_relacionales_logicas(int num1, int num2){
        
        boolean mayor= 55>68;
        boolean menor= 10*2>(-3)*8;
        boolean igual = 5*5==5/5;
        boolean diferente =num1!=num2;
        boolean may_igual = num1*5-(10+2)<= 100;
        boolean men_igual = num2*(5*5)>= -1;
        
        boolean logica_and = igual && diferente && may_igual;
        boolean logica_or = may_igual || men_igual || igual ;
        boolean logica_not = !(may_igual);
       
        boolean convinada = logica_and || logica_not || !( may_igual && men_igual );
        return;
    }
    
    
    public void validar_Sentencias(boolean uno, int dos, char tres, double  cuatro){
  
        if(5>10 ||uno){
           // esta dentro del primer if de validacion
        }else
        {
            //esta en el else de validacio
        }
        
        if(dos==2){
            int valor=100*0;
            int valor2=valor*5;
        }
        
        do {            
            //esta dentro del while
            dos=dos+dos;
            int a;
            break;
        } while (uno);
        
        while(true || false && !true ){
            boolean prueba;
            prueba = true;
            continue;
        
        }
      
    }
    
}
