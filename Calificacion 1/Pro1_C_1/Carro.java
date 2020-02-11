/* Lengajes y compiladore 1 -   1er Semestre 2018*/

/* Se creara la clase carro donde se instansiaran otras clases, como motor y otros  */

public class Carro {    

    //Campos de la clase
    private String marca;
    private String modelo;
    private int  numero_puertas;
    private boolean enVenta;
    public double precio;
    public String placa;
    public Motor motor1;
    public String mensaje;

    /*
    Definicion de los metodos de la clase carro, por medio de estos vamos a darle funcionalidades
    Espesificas a la clase
    */

    public void  instalarMotor(){
        //motor1 = new Motor();
    }

    public void crearCarro (String placaE, double precioE, boolean enVentaE) {
        placa =  placaE;
        precio = precioE;
        enVenta = enVentaE;
        if ( placa == "NULL" ) {
            //VALIDAMOS QUE LA PLACA TENGA UN VALO CORRECTO 
            mensaje=("El valor de placa no es correcto, debe corregirlo.");
            placa = "Sin placa";
        } 

        if(precio < 0 ){
            mensaje=("El precio del vehiculo es incorrecto, debe corregirlo.");
            precio  = 000;
        }     

    } //Cierre del método

    /*Aca vamos  colocar los metodos que actualizan y establecen la informacion del vehiculo*/

    public void setMarca (String marc) { 
        marca = marc;
    } //Método de acceso

     public void setModelo (String model) { 
        modelo = model;
    } //Método de acceso
    
    public void setPuertas (int number) { 
        numero_puertas = number; 
    } //Método de acceso

    public void actualizarPrecio (double nuevo_precio) { 
        precio = nuevo_precio;

    } //Método de actualizacion

    public void actualizarPlaca (String nueva_placa) { 
        placa = nueva_placa;

    } //Método de actualizacion

    public void actualizarEstado(boolean nuevo_estado){
        enVenta =nuevo_estado;

    } //Método de actualizacion

    

}