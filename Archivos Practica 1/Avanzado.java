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
public class Avanzado {
   
    
    int temperatura=10;
    String mensaje="";
    
    public static void main() {
        //comentario 1
        //comentario 2
        /***
         * 
         * esto es asi
         * 
         */ 
        
    }
    
   
    public void metodo_vanzado1(){
        int a=5;
        int b;
        int c;
        String cad="nada";
        switch(a){
            case 5:
                int d;
            case 10:
                int j;
                    break;
            case 20:
                String cad1;
                    break;
                    
            case 25:
                String cad2;
            default:
                
                System.out.println("cadena"+cad+"+"+a);
        
        }
    }
    
    public void metodo_avanzado2(int j, char y){
        metodo_vanzado1();
        metodo_avanzado2(15,'d');
        metodo_vanzado1();
    }
    
    
    private int numero(int a, int b){
    
        for (int i = 0; i < 10; i++) {
            i=i+i;
            System.out.println("Interfaz");
            
        }
        return 100;
    }
    
    
    public void anido(){
        
        for (int i = 0; i < 10; i++) {
            
            for (int j = 0; j < 10; j++) {
                for (int k = 0; k < 10; k++) {
                    System.out.println("Encontro 3 for anidados");
                }
            }
        }
        
        
        if (true|| false) {

                for (int i = 0; i < 10; i++) {
                
                    switch(i){
                        case 1:
                            continue;
                            case 2:
                                continue;
                                case 4:
                                    break;
                                    default:
                                        do {                                            
                                            while (true) {
                                                int k= numero(5, 5*numero(5, 5*numero(2,10)));
                                            }
                                        } while (true);
                    }
            }
        
        
        if (temperatura > 15) {
           if (temperatura > 25) {
               // Si la temperatura es mayor que 25 ...
               mensaje=("A la playa!!!");
           } else {
               mensaje=("A la montaña!!!");
           }
        } else {
            if (true) {
                 mensaje=("A esquiar!!!");
             }
        }
       
        }
         
        
    }
    
    
    public int fibonacciCiclos(int n)
    {
      int fibo1=1;
      int fibo2=1; 
            for(int i=2;i<=n;i++){
                 fibo2 = fibo1 + fibo2;
                 fibo1 = fibo2 - fibo1;
            }
            return fibo2;
    }
    
}
