public class Motor{


	String tipo1,tipo2,tipo3,tipo4,men;
	double vel1,vel2,vel3,vel4,vel5;
	int numero_cilindros;
	int cil1,cil2,cil3,cil4,cil5;

	//variables de funcionamiento
	private boolean encendido;
	/* La clase motor se instanciara en 
	la clase carro, para que esta pueda hacer uso de la misma*/

	//Declaramos los metodos propios de la clase motor

		/* ============================= Colocar el Motor On-Fire =======================================*/
	public void encenderMotor(){
		if(encendido){
			men=("El motor ya se encuntra encendido.");
		}

		if(!encendido){
			encendido=true;
			men=("Encendiendo...");
			men=("RRRRRUUUM... RRRRRUUUM...");
			men=("El motor fue encendido correctamente.");
		}
	}

	/* ============================= Calibrar Cilindros =======================================*/
	private void calibrarCilindros(){
		int numero_cilindros = 10;
		int cilindro=0;
		while (cilindro <= numero_cilindros){	
			men=("Calibrando Cilindro No."+cilindro);
			men=("Phss... Phss... Phss... ");
			men=("El cilindro se calibro correctamente.");
			cilindro = cilindro + 1;
		}
	}


	public void acelerar_A(int  km_hora_2){

		if(km_hora_2 == 100){
			int tmp=0000;
			System.out.println("Aceleranding...");
			while( tmp <= km_hora_2){
				men=("Aceleracion -> "+tmp);
				cilindro = cilindro + 1;
			}
			men=("Se logro la aceleracion maxima (y).");
		}


		if(km_hora_2 == 200){
			int tmp=0000;
			men=("Aceleranding...");
			while( tmp <= km_hora_2){
				men=("Aceleracion -> "+tmp);
				cilindro = cilindro + 1;
			}
			men=("Se logro la aceleracion maxima (y).");
		}

		if(km_hora_2 == 300 ){
			int tmp=0000;
			men=("Aceleranding...");
			while( tmp <= km_hora_2){
				men=("Aceleracion -> "+tmp);
				cilindro = cilindro + 1;
			}
			men=("Se logro la aceleracion maxima (y).");
		}

		if(km_hora_2 >= 400 && km_hora_2 <= 600){
			int tmp=0000;
			System.out.println("Aceleranding...");
			while( tmp <= km_hora_2){
				men=("Aceleracion -> "+tmp);
				cilindro = cilindro + 1;
			}
			men=("Se logro la aceleracion maxima (y).");
		}
	}


	public void limiteVelocidad( double velocidad ){

		if(velocidad <= 20){
			men=("Estableciendo limite...");
			vel1 = 20;  
			men=("Limite Establecido.");
		}

		if(velocidad > 20 && velocidad <= 40){
			men=("Estableciendo limite...");
			vel2 = 40;  
			men=("Limite Establecido.");
		}

		if(velocidad > 40 && velocidad <= 60){
			men=("Estableciendo limite...");
			vel3 = 60;  
			men=("Limite Establecido.");
		}

		if( velocidad > 60 && velocidad <= 80){
			men=("Estableciendo limite...");
			vel4 = 80;  
			men=("Limite Establecido.");
		}

		if(velocidad > 80 && velocidad <= 100){
			men=("Estableciendo limite...");
			vel5 = 100;  
			men=("Limite Establecido.");		
		}		

	}

}