public class Carrera{
    private String nombre;
    private int codigo;

    public Carrera(int codigo2){
        nombre="Ingenieria" + getCadenaCarrera(codigo2);
        codigo=codigo2;
    }

    protected String getCadenaCarrera(int codigo2){
        switch(codigo2){
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

    public String getNombreCarrera(){
        return nombre;
    }

    public int getCodigo(){
        int codigo2=codigo;
        return codigo2;
    }

    public void setNombre(String nombreAux){
        nombre=nombreAux;
    }

    public void setCodigo(String codigo2){
        codigo=codigo2;
    }


}