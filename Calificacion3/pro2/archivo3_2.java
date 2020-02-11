/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package calificacion2;

/**
 *
 * @author jorge
 */
public class archivo3 {
 
     int temperatura =0;
 boolean nevado=true;
 String mensaje="";
 
 
 
public void anidados(){
if (temperatura > 15) {
    if (temperatura > 25) {
        // Si la temperatura es mayor que 25 ...
        mensaje=("A la playa!!!");
    } else {
        mensaje=("A la montaña!!!");
    }
} else if (temperatura < 5) {
    if (nevado) {
        mensaje=("A esquiar!!!");
    }
} else {
    mensaje=("A descansar... zZz");
}
}    


public void ifs(){

    int diasHastaFinSemanas = 0;
    int dia=6;
if (dia > 1 && dia < 7) {
    if (dia < 6) {
        diasHastaFinSemanas=diasHastaFinSemanas+1;
        if (dia < 5) {
            diasHastaFinSemanas=diasHastaFinSemanas+1;
            if (dia < 4) {
               diasHastaFinSemanas=diasHastaFinSemanas+1;
                if (dia < 3) {
                    diasHastaFinSemanas=diasHastaFinSemanas+1;
                }
            }
        }
    }           
    mensaje=("Dia laboral: Dias restantes hasta el fin de semana: " + diasHastaFinSemanas);
} else if (dia == 1 || dia == 7) {
    mensaje=("Fin de semana");
} else {
    mensaje=("La semana solo tiene 7 dias");
}
}

public void switchs(){

int dia = 4;
String tipoVehiculo = "coche";
switch (dia) {
    case 1:
        mensaje=("Domingo");
        switch (tipoVehiculo) {
    case "coche":
        mensaje=("Puedes pasar de 00:00 a 08:00");
        break;
    case "camion":
        mensaje=("Puedes pasar de 08:00 a 16:00");
        break;
    case "moto":
        mensaje=("Puedes pasar de 16:00 a 24:00");
        break;
    default:
       mensaje=("No se puede pasar con un " + tipoVehiculo);
        break;
        }
        break;
    case 2:
        mensaje=("Lunes");
          switch (tipoVehiculo) {
    case "coche":
        mensaje=("Puedes pasar de 00:00 a 08:00");
        break;
    case "camion":
        mensaje=("Puedes pasar de 08:00 a 16:00");
        break;
    case "moto":
        mensaje=("Puedes pasar de 16:00 a 24:00");
        break;
    default:
       mensaje=("No se puede pasar con un " + tipoVehiculo);
        break;
        }
        break;
    case 3:
       mensaje=("Martes");
          switch (tipoVehiculo) {
    case "coche":
        mensaje=("Puedes pasar de 00:00 a 08:00");
        break;
    case "camion":
        mensaje=("Puedes pasar de 08:00 a 16:00");
        break;
    case "moto":
        mensaje=("Puedes pasar de 16:00 a 24:00");
        break;
    default:
       mensaje=("No se puede pasar con un " + tipoVehiculo);
        break;
        }
        break;
    case 4:
        mensaje=("Miercoles");
          switch (tipoVehiculo) {
    case "coche":
        mensaje=("Puedes pasar de 00:00 a 08:00");
        break;
    case "camion":
        mensaje=("Puedes pasar de 08:00 a 16:00");
        break;
    case "moto":
        mensaje=("Puedes pasar de 16:00 a 24:00");
        break;
    default:
       mensaje=("No se puede pasar con un " + tipoVehiculo);
        break;
        }
        break;
    case 5:
       mensaje=("Jueves");
          switch (tipoVehiculo) {
    case "coche":
        mensaje=("Puedes pasar de 00:00 a 08:00");
        break;
    case "camion":
        mensaje=("Puedes pasar de 08:00 a 16:00");
        break;
    case "moto":
        mensaje=("Puedes pasar de 16:00 a 24:00");
        break;
    default:
       mensaje=("No se puede pasar con un " + tipoVehiculo);
        break;
        }
        break;
    case 6:
        mensaje=("Viernes");
          switch (tipoVehiculo) {
    case "coche":
        mensaje=("Puedes pasar de 00:00 a 08:00");
        break;
    case "camion":
        mensaje=("Puedes pasar de 08:00 a 16:00");
        break;
    case "moto":
        mensaje=("Puedes pasar de 16:00 a 24:00");
        break;
    default:
       mensaje=("No se puede pasar con un " + tipoVehiculo);
        break;
        }
        break;
    case 7:
        mensaje=("Sabado");
          switch (tipoVehiculo) {
    case "coche":
        mensaje=("Puedes pasar de 00:00 a 08:00");
        break;
    case "camion":
        mensaje=("Puedes pasar de 08:00 a 16:00");
        break;
    case "moto":
        mensaje=("Puedes pasar de 16:00 a 24:00");
        break;
    default:
       mensaje=("No se puede pasar con un " + tipoVehiculo);
        break;
        }
        break;
    // default: es opcional
}
}
    
    
}
