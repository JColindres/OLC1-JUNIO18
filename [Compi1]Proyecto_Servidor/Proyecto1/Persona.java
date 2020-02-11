import Mascota; //importacion de la clase mascota para poderla usar
public class Persona{
    /* 
    Acontinuacion se encuentran los atributos de Persona
    los cuales son:
    nombre
    apellido
    edad
    dpi
     */
    private String nombre;
    private String apellido;
    private int edad;
    private int dpi;

    //constructor de la clase
    public Estudiante(String nombre2,String apellido2,int edad2,int dpi2){
        nombre=nombre2;
        apellido=apellido2;
        edad=edad2;
        dpi=dpi2;
        saludar("Tikal");
        crearMascota();
    }

    public crearMascota(){
        String nombreMascota="Firulays";
        int edad=1;
        int raza;
        String tipo="Perro";
        if(esMayorDeEdad()){
            raza="Chihuahua";
        }else{
            raza="Bulldog";
        }
        Mascota mascota=new Mascota(nombreMascota,raza,edad,tipo);
    }

    public String getNombreCompleto(){
        String nombreCompleto=nombre+" "+apellido;
        return nombreCompleto;
    }

    public String getNombre(){
        return nombre;
    }

    public String getApellido(){
        return apellido;
    }

    public int getEdad(){
        return edad;
    }

    public int getdpi(){
        return dpi;
    }

    public boolean esMayorDeEdad(){
        if(edad<18){
            return false;
        }else{
            return true;
        }
    }

    public void saludar(String lugar){
        String saludo="hola soy "+ nombre+" y los saludo desde "+lugar;
        return saludo+"!";
    }


}