//lo que sea
/*otra
cosa*/
public class Clase{
    public String nombreClase;
    public int codigo;
    public double notaClase;
    public String estadoClase;


    public Clase(String nombreAux,int codigoAux,double notaClaseAux){
        nombreClase=nombreAux;
        codigo=codigoAux;
        notaClase=notaClaseAux;
        estadoClase=getestadoClase();
    }

    public String getestadoClase(){
        if(notaClase>61){
            return getStrEstado(11);
        }else{
            return getStrEstado(2);
        }
    }


    public string getStrEstado(int valor){
        char c1,c2,c3,c4,c5,c6,c7,c8;
        String estadoAux="";
        c1='A'; c2='p'; c3='r'; c4='o'; c5='b'; c6='a';c7='d';c8='o';
        if(valor==0 || valor>10){
            estadoAux=c1+c2+c3+c4+c5+c6+c7+c8;
        }else{
            estadoAux="No"+c1+c2+c3+c4+c5+c6+c7+c8;
        }

    }

    public void setNombre(String nombreAux){
        nombreClase=nombreAux;
    }

    public void setCodigo(int codigoAux){
        codigo=codigoAux;
    }

    public void setNota(double notaClaseAux){
        notaClase=notaClaseAux;
    }

    public void setEstadoClase(int estadoAux){
        estadoClase=getStrEstado(estadoAux);
    }

    public String getnombreClase(){
        return nombreClase;
    }

    public int getCodigo(){
        return codigo;
    }

    public double getnotaClase(){
        return notaClase;
    }

    public String getestadoClase(){
        return estadoClase;
    }

    public void actualizarNota(double valor){
        if((valor>5 && valor<10)){
            notaClase=notaClase+valor/2;
        }else{
            notaClase=notaClase+valor/4;
        }
    }


}