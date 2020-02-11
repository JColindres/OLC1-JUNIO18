/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package Interfaz;

/**
 *
 * @author Luis
 */
public class Basico {
    //a continuacion se declara el metodo principal de la clase
    
    public String cadena1;
    private String cadena2,cadena3;
    
    protected int numero1=5;
    private char car1,car2,car3,car4;
    public boolean istrue=true;
    private boolean isflase=false;
    double dicimalunico=0.0;
    
    
    public static void main(String[] args) {
        /** Realizaremos acciones basicas en este metodo**/
        System.err.println("Estamos en el metodo rincipal");
    }
    
    public String funcion_cadena(){
        return "Hola mundo";
    }
    
    private void suma(){
        //aca se ralizar una suma
        //se realizan comentarios
    }
    
    public double funcion_decimal(){
        /*muchos
        cometnario
        multi 
        linea
        para este texto
        */
        return 0.0;
    }
    
    protected void metodo2(){
    
    }
    
    private char metodo_Caracteres(){
        return 'a';
    }
}
