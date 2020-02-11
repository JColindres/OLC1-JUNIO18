/* Esta clase es una copia exacta de la otra clase garaje*/
public class Garaje {

	/* -----------------------------
		0000_____0000__0000000000000__0000___________0000000000000
		0000_____0000__0000000000000__0000___________0000000000000
		0000_____0000__0000000000000__0000___________0000000000000
		0000_____0000__0000_____0000__0000___________0000_____0000
		0000_____0000__0000_____0000__0000___________0000_____0000
		0000_____0000__0000_____0000__0000___________0000_____0000
		0000_____0000__0000_____0000__0000___________0000_____0000
		0000000000000__0000_____0000__0000___________0000000000000
		0000000000000__0000_____0000__0000___________0000000000000
		0000000000000__0000_____0000__0000___________0000000000000
		0000_____0000__0000_____0000__0000___________0000_____0000
		0000_____0000__0000_____0000__0000___________0000_____0000
		0000_____0000__0000_____0000__0000___________0000_____0000
		0000_____0000__0000000000000__0000000000000__0000_____0000
		0000_____0000__0000000000000__0000000000000__0000_____0000
		0000_____0000__0000000000000__0000000000000__0000_____0000		
	------------------------------*/


	//En esta clase se crear diferentes vehiculos 
	//Los vhiculos seran ordenados en el garage

	Carro 	pos1,pos2,pos3,
		 	pos4,pos5,pos6,
		 	pos7,pos8,pos9;

	char 	cab1,cab2,cab3,cab4,
			cab5,cab6,cab7,cab8;

    
    String id_garage;
    String direccion;
    int capacidad;
    String mensaje;
    public Carro car1,car2,car3,car4,car5,car6,car7,car8,car9,car10,car11,car12,car13,car14,car15,car16,car17;


    public void agregarVehiculo( Carro cars){
    	int numero_parqueos = capacidad;
    	do{
    		numero_parqueos=numero_parqueos -1;
    		pos1 = cars;
    		pos2 = pos1;
    		pos3 = pos2;
    		pos4 = pos3;
    		pos5 = pos4;
    		pos6 = pos5;
    		pos7 = pos6;
    		pos8 = pos7;
    		pos9 = pos8;
    		pos1 = pos9;
    		cab1 = 'O'; cab3 = 'L'; cab4 = 'L'; cab5 = 'L'; cab6 = 'L'; cab7 = 'L'; cab8 = 'L';
    	}
    	while(numero_parqueos>00000);
    	mensaje=("Vehiculo agregado correctamente.");
    }

    public vois estacionarVehiculo( Carro cars){
    	int numero_parqueos = capacidad;
    	do{
    		numero_parqueos= numero_parqueos -1;
    		pos1 = cars;
    		pos2 = pos1;
    		pos3 = pos2;
    		pos4 = pos3;
    		pos5 = pos4;
    		pos6 = pos5;
    		pos7 = pos6;
    		pos8 = pos7;
    		pos9 = pos8;
    		cab1 = 'O'; cab2='O'; cab3 = 'O'; cab4 = 'O'; cab5 = 'L'; cab6 = 'L'; cab7 = 'L'; cab8 = 'L';
    	}
    	while(numero_parqueos > 00000);
    	mensaje=("Vehiculo agregado correctamente.");
    }

    /*
    		*********************************************
    		*********************************************
			* AREA DE LIMPIEZA Y ORDENAMIENTO DE GARAJE *
			*********************************************
			*********************************************
	
    */

    private void LimpiarGarage(){
    	mensaje=("Preparando el sistema de LIMPIEZA.");
    	String salida = "Asignando operaciones automaticas.";
    	mensaje=(salida);
    	int minutos_trabajo = 150;
    	do{
    		int segundos_trabajo = 15;
    		while(segundos_trabajo>0){
    			mensaje=("Ralizando limpieza interna, Segundo actual -> "+segundos_trabajo);
    			segundos_trabajo = segundos_trabajo -1;
    		}
    		mensaje=("Realizando limpieza externa, Minuto actual -> "+minutos_trabajo);
    		minutos_trabajo = minutos_trabajo - 2 ;
    	}while(minutos_trabajo>100);

    }

    private void ordenarVehiculos(){
    	int i =  15 + capacidad;
    	int j =  10 + capacidad;
    	do{
    		do{
    			Carro car_tmp= pos1;
    			mensaje=("El automovil se encuntra en la posicion -> " + i + "," + j);
    			j = j-1;
    		}while(j>0);
    		i=i-1;
    	}while( i>0);
    	mensaje=("Se llevo a cabo el ordenamiento de vehiculos.");
    }


}