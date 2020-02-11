import java.util.Scanner;


public class Clase1{

	static Scanner sc = new Scanner(System.in);
	private int variable1 = 10/5+3;
	public void metodo1 (){
		System.out.println("el factorial de 5" + "es: "+factorial(variable1));
	int variable2 = sc.nextInt();
	System.out.println("------------------------------");
	System.out.println("El factorial de " + variable2 + " es: "+factorial(variable2));
	}
	public int factorial (int num){
	if(num==0){
		return 1

	}
	Else{
		return num*factorial(num-1)

	}

	}

}