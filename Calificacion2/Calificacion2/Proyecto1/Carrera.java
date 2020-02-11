public class Carrera{
    private String nombre;
    private int codigo;

    public Carrera(int codigoAux){
        nombre="Ingenieria" + getStrCarrera(codigoAux);
        codigo=codigoAux;
    }

    protected String getStrCarrera(int codigoAux){
        switch(codigoAux){
            case 0:
                return "Civil";
            case 1:
                return "Sistemas";
            case 2:
                return "Industrial";
            case 3:
                return "Quimica";
            default:
                return "Mecanica";
        }
    }

    public String getNombre(){
        return nombre;
    }

    public int getCodigo(){
        int codigoAux=codigo;
        return codigoAux;
    }

    public void setNombre(String nombreAux){
        nombre=nombreAux;
    }

    public void setCodigo(String codigoAux){
        codigo=codigoAux;
    }


}