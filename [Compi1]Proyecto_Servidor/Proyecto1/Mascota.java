public class Mascota{
    public String nombre;
    public String raza;
    public String tipo;
    public String edad;

    public Mascota(String nombreAux,String razaAux,String tipoAux,int edadAux){
        nombre=nombreAux;
        raza=razaAux;
        tipoAux=tipoAux;
        edad=edadAux;
    }

    public String getInfo(){
        String info="nombre:"+nombre+" raza:"+raza+" tipo:"+tipo+" edad:"+edad;
        return info;
    }
}