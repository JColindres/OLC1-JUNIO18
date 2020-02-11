/* Lengajes y compiladore 1 -   1er Semestre 2018*/
/*El comentario de arriba es copia */

/* Se creara la clase carro donde se instansiaran otras clases, como motor y otros - esta no es copia  */

public class Carro_2 {    

    //Campos de la clase2
    private String marca2;
    private String modelo2;
    private int  numero_puertas2;
    private boolean enVenta2;
    public double precio2;
    public String placa2;
    public Motor_2 motor1;
    public String mensaje;

    /*
    Definicion de los metodos de la clase carro, por medio de estos vamos a darle funcionalidades
    Espesificas a la clase - Esta no  es copia
    */

    public void  instalarMotor2(){
        motor1 = new Motor_2();
    }

    public void crearCarro2 (String placaE, double precioE, boolean enVentaE) {
        placa2 =  placaE;
        precio2 = precioE;
        enVenta2 = enVentaE;
        if ( placa2 == "NULL" ) {
            //VALIDAMOS QUE LA PLACA TENGA UN VALO CORRECTO
            //el comentario de arriba es copia 
            mensaje=("El valor de placa no es correcto, debe corregirlo.");
            placa2 = "Sin placa";
        } 

        if(precio2 < 0 ){
            mensaje=("El precio del vehiculo es incorrecto, debe corregirlo.");
            precio2  = 000;
        }     

    } //Cierre del método2

    /*Aca vamos  colocar los metodos que actualizan y establecen la informacion del vehiculo 
      esta no es copia 
    */

    public void setMarca2 (String marc) { 
        marca2 = marc;
    } //Método de acceso2

     public void setModelo2 (String model) { 
        modelo2 = model;
    } //Método de acceso2
    
    public void setPuertas2 (int number) { 
        numero_puertas2 = number; 
    } //Método de acceso2

    public void actualizarPrecio2 (double nuevo_precio) { 
        precio2 = nuevo_precio;

    } //Método de actualizacion2

    public void actualizarPlaca2 (String nueva_placa) { 
        placa2 = nueva_placa;

    } //Método de actualizacion2

    public void actualizarEstado2 (boolean nuevo_estado){
        enVenta2 =nuevo_estado;

    } //Método de actualizacion2

    

} //Cierre de la clase
//el comentario de arriba es repetido