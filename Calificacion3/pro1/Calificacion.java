/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package calificicacion;

/**
 *
 * @author jorge
 */
public class Calificicacion {

    /**
     * @param args the command line arguments
     */
   
    
    public int suma(int op1, int op2){
int op3= op1+op2;
return op3;	
}
 
       public int resta(int op1, int op2){
int op3= op1-op2;
return op3;	
}
       
       public int mult(int op1, int op2){
int op3= op1*op2;
return op3;	
}
  
          public int div(int op1, int op2){
int op3= op1/op2;
return op3;	
}
    
public int fibonacci(int n)
{
    if (n>1){
       return fibonacci(n-1) + fibonacci(n-2);  //función recursiva
    }
    else if (n==0 || n==1){  // caso base
        return 0;
    }
    else{ //error
        return -1; 
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

public void calculadora(){
int c= suma(2,3);
c= resta(2,3);
c= mult(2,3);
c= div(mult(2,3),resta(2,3));
c= fibonacci(suma(2,3));
c= fibonacciCiclos(mult(2,3));
}


}