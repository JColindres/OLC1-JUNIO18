/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package ConexionServidor;

import AnalisisJava.Lexico;
import AnalisisJava.Sintactico;
import java.io.BufferedInputStream;
import java.io.BufferedOutputStream;
import java.io.BufferedReader;
import java.io.DataInputStream;
import java.io.File;
import java.io.FileOutputStream;
import java.io.FileReader;
import java.io.StringReader;
import java.net.ServerSocket;
import java.net.Socket;
import java.util.ArrayList;

/**
 *
 * @author piplo10
 */
public class Servidor extends Thread {

    public static ArrayList nomnom = new ArrayList<String>();

    Interfaz inter = new Interfaz();

    public void run() {

        ServerSocket ss;
        Socket concon;

        BufferedInputStream inp;
        BufferedOutputStream out;
        byte[] RD;
        int iiii;
        String archivo, recepcion, msg;

        try {
            ss = new ServerSocket(5000);
            while (true) {
                concon = ss.accept();
                System.out.println("Cliente conectado\n");
                RD = new byte[1024];

                inp = new BufferedInputStream(concon.getInputStream());
                DataInputStream dataStream = new DataInputStream(concon.getInputStream());

                msg = dataStream.readUTF();

                if (msg.equals("archivo")) {
                    recepcion = dataStream.readUTF();

                    archivo = dataStream.readUTF();

                    archivo = archivo.substring(archivo.indexOf('\\') + 1, archivo.length());

                    if (recepcion.equals("1")) {
                        archivo = "Proyecto1\\" + archivo;
                    } else if (recepcion.equals("2")) {
                        archivo = "Proyecto2\\" + archivo;
                    }
                    nomnom.add(archivo);

                    out = new BufferedOutputStream(new FileOutputStream(archivo));
                    while ((iiii = inp.read(RD)) != -1) {
                        out.write(RD, 0, iiii);
                    }
                    out.close();
                    dataStream.close();
                } else {

                    String pathArchivo1 = "C:\\Users\\pablo\\Documents\\1er-Sem-2018\\OLC1\\[OLC1]Proyecto_Servidor\\Proyecto1";
                    String arc, chain = "";
                    File sobre = new File(pathArchivo1);
                    File[] archivos = sobre.listFiles();

                    for (int i = 0; i < archivos.length; i++) {
                        if (archivos[i].isFile()) {
                            arc = archivos[i].getName();
                            if (arc.endsWith(".java") || arc.endsWith(".JAVA")) {
                                chain = muestraContenido(pathArchivo1 + "\\" + arc);
                                String datos = chain;
                                Lexico lex = new Lexico(new BufferedReader(new StringReader(datos)));
                                Sintactico sin = new Sintactico(lex);
                                inter.errores(datos);

                                try {
                                    sin.parse();
                                } catch (Exception e) {
                                }
                                System.out.println("Archivo Leido");
                            }
                        }
                    }

                    String pathArchivo2 = "C:\\Users\\pablo\\Documents\\1er-Sem-2018\\OLC1\\[OLC1]Proyecto_Servidor\\Proyecto2";
                    String archi, ghostrider = "";
                    File uppper = new File(pathArchivo2);
                    File[] masArchivos = uppper.listFiles();

                    for (int i = 0; i < masArchivos.length; i++) {
                        if (masArchivos[i].isFile()) {
                            archi = masArchivos[i].getName();
                            if (archi.endsWith(".java") || archi.endsWith(".JAVA")) {
                                ghostrider = muestraContenido(pathArchivo2 + "\\" + archi);
                                String datos = ghostrider;
                                Lexico lex = new Lexico(new BufferedReader(new StringReader(datos)));
                                Sintactico sin = new Sintactico(lex);
                                inter.errores(datos);

                                try {
                                    sin.parse();
                                } catch (Exception e) {
                                }
                                System.out.println("Archivo Leido");
                            }
                        }
                    }
                    System.out.println("Fin");

                }
            }
        } catch (Exception e) {
            System.err.println(e);
        }

    }

    public String muestraContenido(String archive) {
        String chain = " ";
        String finalChain = " ";
        try {
            FileReader fr = new FileReader(archive);
            BufferedReader br = new BufferedReader(fr);
            while ((chain = br.readLine()) != null) {
                finalChain = finalChain + chain + "\n";
            }
        } catch (Exception e) {
            System.err.println(e);
        }
        return (finalChain);
    }

}
