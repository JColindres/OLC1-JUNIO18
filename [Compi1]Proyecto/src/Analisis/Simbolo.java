/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package Analisis;

/**
 *
 * @author pablo
 */
public class Simbolo {
    String nombre;
    private Object valor;
    public Simbolo(String nombre, Object valor){
    
        this.nombre = nombre;
        this.valor = valor;
    }
    
    public Object getValor(){
    
        return valor;
    }
    
    public void setValor(Object valor){
        
        this.valor = valor;
    }
}
