import java.util.Scanner;


public class Archivo3{

	static Scanner sc = new Scanner(System.in);
	public static void main(String[] args){
		TercerArchivo();

	}
	void TercerArchivo (){
		private int op = 0;
	while(op!=8){
		System.out.println("Seleccione una opcion");
	System.out.println("2. Crear Matriz");
	System.out.println("1. Mostrar Transpuesta");
	System.out.println("4. Sumar Matrices");
	System.out.println("3. Serie Fibonacci");
	System.out.println("8. Salir");
	op = sc.nextInt();
	switch(op) {
		case 2:
		System.out.println("Ingrese la cantidad de filas");
	private int filas = sc.nextInt();
	System.out.println("Ingrese la cantidad de columnas");
	private int col = sc.nextInt();
	private int [][] matriz = new int [filas][col];
	for(int i = 0; i < 5; i = i + (1) ){
		for(int j = 0; j < 5; j = j + (1) ){
		matriz[i][j] = i*2;

	}

	}
	System.out.println("Imprimir valores de las matrices");
	private String impresionMatriz = "";
	for(int i = 0; i < 5; i = i + (1) ){
		impresionMatriz = "";
	for(int j = 0; j < 5; j = j + (1) ){
		impresionMatriz = impresionMatriz + "[" + matriz[i]j;

	}
	System.out.println(impresionMatriz);

	}
	break;
		case 1:
		System.out.println("Ingrese la cantidad de filas");
	private int filas = sc.nextInt();
	System.out.println("Ingrese la cantidad de columnas");
	private int col = sc.nextInt();
	private int [][][][] matriz = new int [filas][col];
	for(int i = 0; i < 5; i = i + (1) ){
		for(int j = 0; j < 5; j = j + (1) ){
		matriz[i][j] = i*2;

	}

	}
	System.out.println("-----------VALORES MATRIZ-----------");
	private String impresionMatriz = "";
	for(int i = 0; i < 5; i = i + (1) ){
		impresionMatriz = "";
	for(int j = 0; j < 5; j = j + (1) ){
		impresionMatriz = impresionMatriz + "[" + matriz[i]j;

	}
	System.out.println(impresionMatriz);

	}
	System.out.println("-----------VALORES TRANSPUESTA-----------");
	private String impresionMatrizT = "";
	for(int i = 0; i < 5; i = i + (1) ){
		impresionMatrizT = "";
	for(int j = 0; j < 5; j = j + (1) ){
		impresionMatrizT = impresionMatrizT + "[" + matriz[j]i;

	}
	System.out.println(impresionMatrizT);

	}
	break;
		case 4:
		System.out.println("Ingrese la cantidad de filas");
	private int filas1 = sc.nextInt();
	System.out.println("Ingrese la cantidad de columnas");
	private int col1 = sc.nextInt();
	private int [][][][] matriz1 = new int [filas1][col1];
	for(int i = 0; i < 5; i = i + (1) ){
		for(int j = 0; j < 5; j = j + (1) ){
		matriz1[i][j] = i*2;

	}

	}
	private int [][][][] matriz2 = new int [filas1][col1];
	for(int i = 0; i < 5; i = i + (1) ){
		for(int j = 0; j < 5; j = j + (1) ){
		matriz2[i][j] = i*j;

	}

	}
	System.out.println("----------MATRIZ1----------");
	private String impresionMatriz1 = "";
	for(int i = 0; i < 5; i = i + (1) ){
		impresionMatriz1 = "";
	for(int j = 0; j < 5; j = j + (1) ){
		impresionMatriz1 = impresionMatriz1 + "[" + matriz1[i]j;

	}
	System.out.println(impresionMatriz1);

	}
	System.out.println("----------MATRIZ2----------");
	System.out.println("Imprimir valores de las matrices");
	private String impresionMatriz2 = "";
	for(int i = 0; i < 5; i = i + (1) ){
		impresionMatriz2 = "";
	for(int j = 0; j < 5; j = j + (1) ){
		impresionMatriz2 = impresionMatriz2 + "[" + matriz2[i]j;

	}
	System.out.println(impresionMatriz2);

	}
	System.out.println("----------MATRIZ1 + MATRIZ2----------");
	for(int i = 0; i < 5; i = i + (1) ){
		impresionMatriz2 = "";
	for(int j = 0; j < 5; j = j + (1) ){
		impresionMatriz2 = impresionMatriz2 + "[" + matriz1[i]j+matriz2[i]j;

	}
	System.out.println(impresionMatriz2);

	}
	break;
		case 3:
		System.out.println("Ingrese el numero limite de la serie");

