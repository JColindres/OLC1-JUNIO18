/* -----------------------------
		0000_____0000__0000000000000__0000___________0000000000000
		0000_____0000__0000000000000__0000___________0000000000000
		0000_____0000__0000000000000__0000___________0000000000000
		0000_____0000__0000_____0000__0000___________0000_____0000
		0000_____0000__0000_____0000__0000___________0000_____0000
		0000_____0000__0000_____0000__0000___________0000_____0000
		0000_____0000__0000_____0000__0000___________0000_____0000
		0000000000000__0000_____0000__0000___________0000000000000
		0000000000000__0000_____0000__0000___________0000000000000
		0000000000000__0000_____0000__0000___________0000000000000
		0000_____0000__0000_____0000__0000___________0000_____0000
		0000_____0000__0000_____0000__0000___________0000_____0000
		0000_____0000__0000_____0000__0000___________0000_____0000
		0000_____0000__0000000000000__0000000000000__0000_____0000
		0000_____0000__0000000000000__0000000000000__0000_____0000
		0000_____0000__0000000000000__0000000000000__0000_____0000		
	------------------------------*/


	//En esta clase se crear diferentes cursos sobre la clase estudiante
	//Cada una de las clases tendra su respectiva informacion


public class Estudiante{
    private String name;
    private String apellido;
    private int carnet;
    private Carrera carrera;
    
    private int contador=0;
    private Curso curso1,curso2,curso3,curso4,curso5;

    public Estudiante(String nombreAux,String apellido2,int carneAux,int codigoCarrera){
        name=nombreAux;
        apellido=apellido2;
        carnet=carneAux;
        crear_Carrera(codigoCarrera);
        crear_cursos();
    }


    private void crear_Carrera(int codigoCarrera){
        carrera=new Carrera(codigoCarrera);
    }

    public String crear_cursos(){
        String info="";
        String c1,c2,c3,c4,c5;
        Double n1,n2,n3,n4,n5;

        c1="Compi"+"ladores"+2*3/6;
        c2="Estructuras de datos";
        c3="Organizacion "+"computacional";
        c4="Idioma tecnico "+contador;
        c5="Quimica General 1";

        n1=90.1;
        n2=87.6;
        n3=68.0;
        n4=95;
        n5=100;

        for(int i=0;i<5;i++){
            switch(i){
                case 0:
                    curso1=new Curso(c1,getCodigo()+i,n1);
                    break;
                case 1:
                    curso2=new Curso(c2,getCodigo()+i,n2);
                    break;
                case 2:
                    curso3=new Curso(c3,getCodigo()+i,n3);
                    break;
                case 4:
                    curso4=new Curso(c4,getCodigo()+i,n4);
                    break;
                case 5:
                    curso5=new Curso(c5,getCodigo(i,n5));
                    break;
            }
        }

        double promedio=getPromedio(n1,n2,n3,n4,n5);
        info="[{curso:"+curso1+", nota:"+n1+"},"+"{curso:"+curso2+", nota:"+n2+"},"+"{curso:"+curso1+", nota:"+n1+"}]";
        return info;
    }

    public int getCodigo(){
        if(contador<3 && contador>=0){
            contador++;
        }else{
            contador=contador+1;
        }
        return contador;
    }

    public double getPromedio(double n1,double n2,double n3,double n4,double n5){
        double promedio=(n1+n2+n3+n4+n5)/contador;
        if(promedio>=80.2){
            return promedio;
        }else{
            return promedio;
        }
    }

    public void Setname(String nombreAux){
        name=nombreAux;
    }

    public void setApellido(String apellido2){
        apellido=apellido2;
    }

    public void setCarne(int carneAux){
        carnet=carneAux;
    }

    public String getFullName(){
        String nameCompleto=name+" "+apellido;
        return nameCompleto;
    }


}