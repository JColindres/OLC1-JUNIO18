/* Lengajes y compiladore 1 -   1er Semestre 2018 
  no es copia
*/

/* Se creara la clase carro donde se instansiaran otras clases, como motor y otros  - no es copia */

public class Carro { //clase repetida, solo cambia el nombre del archivo   

    //Campos de la clase2
    private String marca;
    //la variables anterios es repetida
    private String modelo2;
    private int  numero_puertas2;
    private boolean enVenta2;
    public double precio; 
    //la variable anterios es repetida
    public String placa2;
    public Motor motor1;
    public String mensaje;
    //El objeto motor es repetido

    /*
    Definicion de los metodos de la clase carro, por medio de estos vamos a darle funcionalidades
    Espesificas a la clase - no es copia
    */

    public void  instalarMotor(){
        motor1 = new Motor();
    }

    public void crearCarro2 (String placaE, double precioE, boolean enVentaE) {
        placa2 =  placaE;
        precio = precioE;
        enVenta2 = enVentaE;
        if ( placa == "NULL" ) {
            //VALIDAMOS QUE LA PLACA TENGA UN VALO CORRECTO - no es copia 
            mensaje=("El valor de placa no es correcto, debe corregirlo.");
            placa2 = "Sin placa";
        } 

        if(precio < 0 ){
            mensaje=("El precio del vehiculo es incorrecto, debe corregirlo.");
            precio  = 000;
        }     

    } //Cierre del método2

    /*Aca vamos  colocar los metodos que actualizan y establecen la informacion del vehiculo
        no es copia
    */

    public void setMarca (String marc) { //metodo repetido
        marca = marc;
    } //Método de acceso2

     public void setModelo2 (String model) { 
        modelo2 = model;
    } //Método de acceso2
    
    public void setPuertas2 (int number) { 
        numero_puertas2 = number; 
    } //Método de acceso2

    public void actualizarPrecio (double nuevo_precio) {  //metodo repetido 
        precio = nuevo_precio;

    } //Método de actualizacion2

    public void actualizarPlaca (String nueva_placa2) { // no  es repetido por que el parametro cambia  
        placa2 = nueva_placa;

    } //Método de actualizacion2

    public void actualizarEstado(boolean nuevo_estado2){ // no es repetido por que el parametro cambia
        enVenta2 =nuevo_estado;

    } //Método de actualizacion2

    

} //Cierre de la clase2