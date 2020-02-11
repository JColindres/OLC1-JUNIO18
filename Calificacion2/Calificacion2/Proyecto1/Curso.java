//lo que sea
/*otra
cosa*/
public class Curso{
    public String nombre;
    public int codigo;
    public double nota;
    public String estado;


    public Curso(String nombreAux,int codigoAux,double notaAux){
        nombre=nombreAux;
        codigo=codigoAux;
        nota=notaAux;
        estado=getEstado();
    }

    public String getEstado(){
        if(nota>61){
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
        nombre=nombreAux;
    }

    public void setCodigo(int codigoAux){
        codigo=codigoAux;
    }

    public void setNota(double notaAux){
        nota=notaAux;
    }

    public void setEstado(int estadoAux){
        estado=getStrEstado(estadoAux);
    }

    public String getNombre(){
        return nombre;
    }

    public int getCodigo(){
        return codigo;
    }

    public double getNota(){
        return nota;
    }

    public String getEstado(){
        return estado;
    }

    public void agregarExtras(double valor){
        if((valor>5 && valor<10)){
            nota=nota+valor/2;
        }else{
            nota=nota+valor/4;
        }
    }



}