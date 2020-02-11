//* Inicio de la clase motor 2  */
public class Motor_2{


	String tipo1_2,tipo2_2,tipo3_2,tipo4_2;
	double vel1,vel2,vel3,vel4,vel5;
	//la lista de variables anterior es repetida
	int numero_cilindros2;
	int cil1_2,cil2_2,cil3_2,cil4_2,cil5;
	String mensaje;
	//la variable cil5 es repetida

	//variables de funcionamiento
	private boolean encendido2;
	/* La clase motor se instanciara en 
	la clase carro, para que esta pueda hacer uso de la misma - no es copia */

	//Declaramos los metodos propios de la clase motor - no es copia

		/* ============================= Colocar el Motor On-Fire - no copia =======================================*/
	public void encenderMotor2(){
		if(encendido2){
			mensaje=("El motor ya se encuntra encendido.");
		}

		if(!encendido2){
			encendido2=true;
			mensaje=("Encendiendo...");
			mensaje=("RRRRRUUUM... RRRRRUUUM...");
			mensaje=("El motor fue encendido correctamente.");
		}
	}

	/* ============================= Calibrar Cilindros =======================================*/
	//el comentario de arriba es repetido
	private void calibrarCilindros2(){
		int numero_cilindros2 = 10;
		int cilindro=0;
		//variable cilindro repetida
		while (cilindro <= numero_cilindros2){	
			mensaje=("Calibrando Cilindro No."+cilindro);
			mensaje=("Phss... Phss... Phss... ");
			mensaje=("El cilindro se calibro correctamente.");
			cilindro = cilindro + 1;
		}
	}


	public void acelerar_A2(int  km_hora_2){

		if(km_hora_2 == 100){
			int tmp2=0000;
			mensaje=("Aceleranding...");
			while( tmp2 <= km_hora_2){
				mensaje=("Aceleracion -> "+tmp2);
				tmp2 = tmp2 + 1;
			}
			mensaje=("Se logro la aceleracion maxima (y).");
		}


		if(km_hora_2 == 200){
			int tmp2=0000;
			mensaje=("Aceleranding...");
			while( tmp2 <= km_hora_2){
				mensaje=("Aceleracion -> "+tmp2);
				tmp2 = tmp2 + 1;
			}
			mensaje=("Se logro la aceleracion maxima (y).");
		}

		if(km_hora_2 == 300 ){
			int tmp2 =0000;
			mensaje=("Aceleranding...");
			while( tmp2 <= km_hora_2){
				mensaje=("Aceleracion -> "+tmp2);
				tmp2 = tmp2 + 1;
			}
			mensaje=("Se logro la aceleracion maxima (y).");
		}

		if(km_hora_2 >= 400 && km_hora_2 <= 600){
			int tmp2 =0000;
			mensaje=("Aceleranding...");
			while( tmp2 <= km_hora_2){
				mensaje=("Aceleracion -> "+tmp2);
				tmp2 = tmp2 + 1;
			}
			mensaje=("Se logro la aceleracion maxima (y).");
		}
	}


	public void limiteVelocidad2 ( double velocidad ){

		if(velocidad <= 20){
			mensaje=("Estableciendo limite...");
			vel1 = 20;  
			mensaje=("Limite Establecido.");
		}

		if(velocidad > 20 && velocidad <= 40){
		mensaje=("Estableciendo limite...");
			vel2 = 40;  
			mensaje=("Limite Establecido.");
		}

		if(velocidad > 40 && velocidad <= 60){
			mensaje=("Estableciendo limite...");
			vel3 = 60;  
			mensaje=("Limite Establecido.");
		}

		if( velocidad > 60 && velocidad <= 80){
			mensaje=("Estableciendo limite...");
			vel4 = 80;  
			mensaje=("Limite Establecido.");
		}

		if(velocidad > 80 && velocidad <= 100){
			mensaje=("Estableciendo limite...");
			vel5 = 100;  
			mensaje=("Limite Establecido.");		
		}		

	}

}