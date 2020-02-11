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
public class archivo2 {
  
    
    
    void Anidar(int arreglo)
    {
        for(int i = 0; i < 8 - 1; i++)
        {
            for(int j = 0; j <9  - 1; j++)
            {
                if (i < j)
                {
                    int tmp = j;
                    arreglo = arreglo;
                    arreglo = tmp;
                }
            }
        }
        for(int i = 0;i < 8; i++)
        {
         arreglo=arreglo+1;
        }
    }
  
   String mensaje=""; 
    public void dimeSiEdadEsCritica(int edad) {

        switch (edad) {

            case 0:
               mensaje="acaba de nacer";
            break;

            case 18: mensaje=("Está justo en la mayoría de edad"); 
            break;

            case 65: mensaje=("Está en la edad de jubilación");
            break;

            default: mensaje=("La edad no es crítica"); 
            break;

        }

    }
 
    void evaluar ( int numero ) {
 switch(numero) {
 case 1: 
     salida("Uno");
     break;
 case 2: 
     salida("Dos");
     break;
 case 3: 
     salida("Tres");
     break;
 case 4: 
     salida("Cuatro");
     break;
 case 5: 
 case 6: 
     salida("Cinco o seis");
     break;
 default: 
     salida("Otro ");
     break;
 }

    }

void salida ( String cadena ) {
 mensaje=(cadena);
    }
    
}
