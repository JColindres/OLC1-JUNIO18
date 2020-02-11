/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package Analisis;

/**
 *
 * @author piplo10
 */
public class Generacion {

    public static void main(String[] args) {
        Compilar();
    }
    
    private static void Compilar() {
        try {
            String ruta = "src/Analisis/";
            String opcFlex[] = {ruta + "Scanner.jflex", "-d", ruta};
            jflex.Main.generate(opcFlex);
            
            String opcCUP[] = {"-destdir", ruta, "-parser", "Sintactico", ruta + "Parser.cup"};
            java_cup.Main.main(opcCUP);
        } catch (Exception e) {
            e.printStackTrace();
        }

    }
    
}
