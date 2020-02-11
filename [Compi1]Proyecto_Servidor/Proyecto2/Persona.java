import Perro; //importacion de la clase mascota para poderla usar
public class Persona{
    /* 
    Acontinuacion se encuentran los atributos de Persona
     */
    private String nombre;
    private String apellido;
    private int edad;
    private int cui;

    //constructor de la clase Persona
    public Estudiante(String nombreAux,String apellidoAux,int edadAux,int cuiAux){
        nombre=nombreAux;
        apellido=apellidoAux;
        edad=edadAux;
        cui=cuiAux;
        enviarSaludo("Ciudad capital");
        crearPerro();
    }

    public crearPerro(){
        String nombreMascota="Firulays";
        int edad=1;
        int raza;
        String tipo="Perro";
        if(esMayorDeEdad()){
            raza="Chihuahua";
        }else{
            raza="Bulldog";
        }
        Mascota miPerro=new Perro(nombreMascota,raza,edad,tipo);
    }

    public String getFullName(){
        String fullName=nombre+" "+apellido;
        return nombreCompleto;
    }

    public String getName(){
        return nombre;
    }

    public String getApellido(){
        return apellido;
    }

    public int getEdad(){
        return edad;
    }

    public int getCui(){
        return cui;
    }

    public boolean esMayorDeEdad(){
        if(edad<18){
            return false;
        }else{
            return true;
        }
    }

    public void enviarSaludo(String lugar){
        String saludar="hola soy "+ nombre+" y los saludo desde "+lugar+"!";
        return saludar;
    }


}