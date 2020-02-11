/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package Analizador;

import Analisis.Lexico;
import Analisis.Sintactico;
import java.awt.Color;
import java.awt.FileDialog;
import java.awt.GridLayout;
import java.awt.Point;
import java.awt.Rectangle;
import java.awt.TextArea;
import java.awt.event.ActionListener;
import java.io.BufferedReader;
import java.io.BufferedWriter;
import java.io.File;
import java.io.FileNotFoundException;
import java.io.FileReader;
import java.io.FileWriter;
import java.io.IOException;
import java.io.InputStreamReader;
import java.io.PrintWriter;
import java.io.StringReader;
import java.util.ArrayList;
import java.util.Scanner;
import java.util.logging.Level;
import java.util.logging.Logger;
import javax.swing.JButton;
import javax.swing.JFileChooser;
import javax.swing.JMenu;
import javax.swing.JTextArea;
import javax.swing.event.CaretEvent;
import javax.swing.filechooser.FileFilter;
import javax.swing.text.BadLocationException;

/**
 *
 * @author piplo10
 */
public class Interfaz extends javax.swing.JFrame {

    int DimensionX = 0;
    int DimensionY = 0;
    int TamX = 0;
    int TamY = 0;
    static final int TableroX = 500;
    static final int TableroY = 500;
    //Matriz de botones
    JButton[][] MatrizBotones;

    public Interfaz() {
        initComponents();
    }

    @SuppressWarnings("unchecked")
    // <editor-fold defaultstate="collapsed" desc="Generated Code">//GEN-BEGIN:initComponents
    private void initComponents() {

        jTabbedPane1 = new javax.swing.JTabbedPane();
        jScrollPane1 = new javax.swing.JScrollPane();
        jTextArea1 = new javax.swing.JTextArea();
        jTabbedPane3 = new javax.swing.JTabbedPane();
        jScrollPane3 = new javax.swing.JScrollPane();
        jTextArea3 = new javax.swing.JTextArea();
        Fila = new java.awt.Label();
        FilaVB = new java.awt.Label();
        jTabbedPane4 = new javax.swing.JTabbedPane();
        jScrollPane4 = new javax.swing.JScrollPane();
        jTextArea4 = new javax.swing.JTextArea();
        Fila2 = new java.awt.Label();
        ColumnaVB = new java.awt.Label();
        panel1 = new java.awt.Panel();
        jMenuBar1 = new javax.swing.JMenuBar();
        jMenu1 = new javax.swing.JMenu();
        jMenuItem1 = new javax.swing.JMenuItem();
        jMenuItem2 = new javax.swing.JMenuItem();
        jMenuItem3 = new javax.swing.JMenuItem();
        jMenu4 = new javax.swing.JMenu();
        jMenuItem4 = new javax.swing.JMenuItem();

        setDefaultCloseOperation(javax.swing.WindowConstants.EXIT_ON_CLOSE);

        jTextArea1.setColumns(20);
        jTextArea1.setRows(5);
        jTextArea1.addCaretListener(new javax.swing.event.CaretListener() {
            public void caretUpdate(javax.swing.event.CaretEvent evt) {
                jTextArea1CaretUpdate(evt);
            }
        });
        jScrollPane1.setViewportView(jTextArea1);

        jTabbedPane1.addTab("Entrada", jScrollPane1);

        jTextArea3.setColumns(20);
        jTextArea3.setRows(5);
        jScrollPane3.setViewportView(jTextArea3);

        jTabbedPane3.addTab("Errores Sintacticos", jScrollPane3);

        Fila.setText("Fila:");

        FilaVB.setText("0");

        jTextArea4.setColumns(20);
        jTextArea4.setRows(5);
        jScrollPane4.setViewportView(jTextArea4);

        jTabbedPane4.addTab("Errores Lexicos", jScrollPane4);

        Fila2.setText("Columna:");

        ColumnaVB.setText("0");

        javax.swing.GroupLayout panel1Layout = new javax.swing.GroupLayout(panel1);
        panel1.setLayout(panel1Layout);
        panel1Layout.setHorizontalGroup(
            panel1Layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
            .addGap(0, 0, Short.MAX_VALUE)
        );
        panel1Layout.setVerticalGroup(
            panel1Layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
            .addGap(0, 0, Short.MAX_VALUE)
        );

        jMenu1.setText("Archivo");

        jMenuItem1.setLabel("Abrir");
        jMenuItem1.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                jMenuItem1ActionPerformed(evt);
            }
        });
        jMenu1.add(jMenuItem1);

        jMenuItem2.setLabel("Guardar");
        jMenuItem2.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                jMenuItem2ActionPerformed(evt);
            }
        });
        jMenu1.add(jMenuItem2);

        jMenuItem3.setLabel("Salir");
        jMenuItem3.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                jMenuItem3ActionPerformed(evt);
            }
        });
        jMenu1.add(jMenuItem3);

        jMenuBar1.add(jMenu1);

        jMenu4.setText("Analisis");

        jMenuItem4.setText("Analizar");
        jMenuItem4.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                jMenuItem4ActionPerformed(evt);
            }
        });
        jMenu4.add(jMenuItem4);

        jMenuBar1.add(jMenu4);

        setJMenuBar(jMenuBar1);

        javax.swing.GroupLayout layout = new javax.swing.GroupLayout(getContentPane());
        getContentPane().setLayout(layout);
        layout.setHorizontalGroup(
            layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
            .addGroup(layout.createSequentialGroup()
                .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
                    .addGroup(layout.createSequentialGroup()
                        .addGap(82, 82, 82)
                        .addComponent(Fila, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE)
                        .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED)
                        .addComponent(FilaVB, javax.swing.GroupLayout.PREFERRED_SIZE, 38, javax.swing.GroupLayout.PREFERRED_SIZE)
                        .addGap(49, 49, 49)
                        .addComponent(Fila2, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE)
                        .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED)
                        .addComponent(ColumnaVB, javax.swing.GroupLayout.PREFERRED_SIZE, 38, javax.swing.GroupLayout.PREFERRED_SIZE))
                    .addGroup(layout.createSequentialGroup()
                        .addContainerGap()
                        .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING, false)
                            .addComponent(jTabbedPane3)
                            .addComponent(jTabbedPane1, javax.swing.GroupLayout.DEFAULT_SIZE, 400, Short.MAX_VALUE))
                        .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.UNRELATED)
                        .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
                            .addGroup(layout.createSequentialGroup()
                                .addComponent(jTabbedPane4, javax.swing.GroupLayout.PREFERRED_SIZE, 400, javax.swing.GroupLayout.PREFERRED_SIZE)
                                .addGap(0, 132, Short.MAX_VALUE))
                            .addComponent(panel1, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, Short.MAX_VALUE))))
                .addContainerGap())
        );
        layout.setVerticalGroup(
            layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
            .addGroup(layout.createSequentialGroup()
                .addContainerGap()
                .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING, false)
                    .addComponent(panel1, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, Short.MAX_VALUE)
                    .addComponent(jTabbedPane1, javax.swing.GroupLayout.DEFAULT_SIZE, 400, Short.MAX_VALUE))
                .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED, javax.swing.GroupLayout.DEFAULT_SIZE, Short.MAX_VALUE)
                .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
                    .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
                        .addGroup(javax.swing.GroupLayout.Alignment.TRAILING, layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
                            .addComponent(Fila, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE)
                            .addComponent(FilaVB, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE))
                        .addComponent(Fila2, javax.swing.GroupLayout.Alignment.TRAILING, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE))
                    .addComponent(ColumnaVB, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE))
                .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED)
                .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.TRAILING)
                    .addComponent(jTabbedPane3, javax.swing.GroupLayout.PREFERRED_SIZE, 194, javax.swing.GroupLayout.PREFERRED_SIZE)
                    .addComponent(jTabbedPane4, javax.swing.GroupLayout.PREFERRED_SIZE, 194, javax.swing.GroupLayout.PREFERRED_SIZE))
                .addContainerGap())
        );

        FilaVB.getAccessibleContext().setAccessibleName("FilaVB");

        pack();
    }// </editor-fold>//GEN-END:initComponents

    private void jMenuItem1ActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_jMenuItem1ActionPerformed

        JFileChooser fc = new JFileChooser();
        StringBuilder sb = new StringBuilder();
        if (fc.showOpenDialog(null) == JFileChooser.APPROVE_OPTION) {

            File file = fc.getSelectedFile();
            try {
                Scanner input = new Scanner(file);

                while (input.hasNext()) {

                    sb.append(input.nextLine());
                    sb.append("\n");
                }
                input.close();

            } catch (FileNotFoundException ex) {
                Logger.getLogger(Interfaz.class.getName()).log(Level.SEVERE, null, ex);
            }
        } else {
            sb.append("No se selecciono ningun archivo");
        }
        jTextArea1.setText(sb.toString());
    }//GEN-LAST:event_jMenuItem1ActionPerformed

    private void jMenuItem4ActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_jMenuItem4ActionPerformed

        String entrada = jTextArea1.getText();
        Lexico lex = new Lexico(new BufferedReader(new StringReader(entrada)));
        Sintactico sin = new Sintactico(lex);
        try {

            sin.parse();
            jTextArea3.setText("");
            jTextArea4.setText("");
            jTextArea3.setText("---------------Errores Sintacticos---------------\n\n");
            for (int x = 0; x < sin.erroresS.size(); x++) {
                jTextArea3.append((String) sin.erroresS.get(x) + "\n" + (String) sin.erroresS1.get(x));
            }
            jTextArea4.setText("---------------Errores Lexicos-------------------\n\n");
            for (int x = 0; x < lex.erroresL.size(); x++) {
                jTextArea4.append((String) lex.erroresL.get(x));
            }
            jTextArea3.append("\n");
            jTextArea4.append("\n");
            Sintactico ss = new Sintactico();
            DimensionX = ss.dimX;
            DimensionY = ss.dimY;
            MatrizBotones = new JButton[DimensionX][DimensionY];
            panel1.setLayout(new GridLayout(DimensionX, DimensionY));
            ObtenerTamanioObjetos(DimensionX, DimensionY);
            int contadorX, contadorY;
            for (contadorX = 0; contadorX < DimensionX; contadorX++) {
                //Se recorre la dimension Y desde 0 hasta DimensionY
                for (contadorY = 0; contadorY < DimensionY; contadorY++) {
                    //Se crea un nuevo objeto de tipo JButton
                    JButton btnNuevo = new JButton();

                    if ((contadorX == 0 && contadorY == 0) || (contadorX == 1 && contadorY == 0) || (contadorX == 2 && contadorY == 0) || (contadorX == 3 && contadorY == 0) || (contadorX == 4 && contadorY == 0)
                     || (contadorX == 2 && contadorY == 1) || (contadorX == 0 && contadorY == 2) || (contadorX == 0 && contadorY == 2) || (contadorX == 1 && contadorY == 2) || (contadorX == 2 && contadorY == 2)
                     || (contadorX == 3 && contadorY == 2) || (contadorX == 4 && contadorY == 2)) {
                        //Se le asignan sus dimensiones (ancho, alto)
                        btnNuevo.setSize(TamX, TamY);
                        btnNuevo.setBackground(Color.magenta);
                        //Se asigna un texto con la posición del botón en la matriz al botón, al tooltip del botón
                        btnNuevo.setToolTipText(Integer.toString(contadorX) + "," + Integer.toString(contadorY));
                        //Se agrega a la matriz el botón recien creado
                        MatrizBotones[contadorX][contadorY] = btnNuevo;
                        //Se agrega al panel 
                        panel1.add(MatrizBotones[contadorX][contadorY]);
                        //Se redibuja el panel
                        RedibujarTablero();
                    }else if ((contadorX == 0 && contadorY == 4) || (contadorX == 1 && contadorY == 4) || (contadorX == 2 && contadorY == 4) || (contadorX == 3 && contadorY == 4) || (contadorX == 4 && contadorY == 4)
                           || (contadorX == 0 && contadorY == 5) || (contadorX == 4 && contadorY == 5) || (contadorX == 0 && contadorY == 6) || (contadorX == 1 && contadorY == 6) || (contadorX == 2 && contadorY == 6)
                           || (contadorX == 2 && contadorY == 6) || (contadorX == 3 && contadorY == 6) || (contadorX == 4 && contadorY == 6)) {
                        //Se le asignan sus dimensiones (ancho, alto)
                        btnNuevo.setSize(TamX, TamY);
                        btnNuevo.setBackground(Color.yellow);
                        //Se asigna un texto con la posición del botón en la matriz al botón, al tooltip del botón
                        btnNuevo.setToolTipText(Integer.toString(contadorX) + "," + Integer.toString(contadorY));
                        //Se agrega a la matriz el botón recien creado
                        MatrizBotones[contadorX][contadorY] = btnNuevo;
                        //Se agrega al panel 
                        panel1.add(MatrizBotones[contadorX][contadorY]);
                        //Se redibuja el panel
                        RedibujarTablero();
                    }else if ((contadorX == 0 && contadorY == 8) || (contadorX == 1 && contadorY == 8) || (contadorX == 2 && contadorY == 8) || (contadorX == 3 && contadorY == 8) || (contadorX == 4 && contadorY == 8)
                           || (contadorX == 4 && contadorY == 9) || (contadorX == 4 && contadorY == 10)) {
                        //Se le asignan sus dimensiones (ancho, alto)
                        btnNuevo.setSize(TamX, TamY);
                        btnNuevo.setBackground(Color.green);
                        //Se asigna un texto con la posición del botón en la matriz al botón, al tooltip del botón
                        btnNuevo.setToolTipText(Integer.toString(contadorX) + "," + Integer.toString(contadorY));
                        //Se agrega a la matriz el botón recien creado
                        MatrizBotones[contadorX][contadorY] = btnNuevo;
                        //Se agrega al panel 
                        panel1.add(MatrizBotones[contadorX][contadorY]);
                        //Se redibuja el panel
                        RedibujarTablero();
                    }else if ((contadorX == 0 && contadorY == 12) || (contadorX == 1 && contadorY == 12) || (contadorX == 2 && contadorY == 12) || (contadorX == 3 && contadorY == 12) || (contadorX == 4 && contadorY == 12)
                           || (contadorX == 0 && contadorY == 13) || (contadorX == 2 && contadorY == 13) || (contadorX == 0 && contadorY == 14) || (contadorX == 1 && contadorY == 14) || (contadorX == 2 && contadorY == 14)
                           || (contadorX == 3 && contadorY == 14) || (contadorX == 4 && contadorY == 14)) {
                        //Se le asignan sus dimensiones (ancho, alto)
                        btnNuevo.setSize(TamX, TamY);
                        btnNuevo.setBackground(Color.red);
                        //Se asigna un texto con la posición del botón en la matriz al botón, al tooltip del botón
                        btnNuevo.setToolTipText(Integer.toString(contadorX) + "," + Integer.toString(contadorY));
                        //Se agrega a la matriz el botón recien creado
                        MatrizBotones[contadorX][contadorY] = btnNuevo;
                        //Se agrega al panel 
                        panel1.add(MatrizBotones[contadorX][contadorY]);
                        //Se redibuja el panel
                        RedibujarTablero();
                    }else {
                        //Se le asignan sus dimensiones (ancho, alto)
                        btnNuevo.setSize(TamX, TamY);
                        //Se asigna un texto con la posición del botón en la matriz al botón, al tooltip del botón
                        btnNuevo.setToolTipText(Integer.toString(contadorX) + "," + Integer.toString(contadorY));
                        //Se agrega a la matriz el botón recien creado
                        MatrizBotones[contadorX][contadorY] = btnNuevo;
                        //Se agrega al panel 
                        panel1.add(MatrizBotones[contadorX][contadorY]);
                        //Se redibuja el panel
                        RedibujarTablero();
                    }
                }//Fin For - Y
            }
        } catch (Exception ex) {

            Logger.getLogger(Interfaz.class.getName()).log(Level.SEVERE, null, ex);

        }


    }//GEN-LAST:event_jMenuItem4ActionPerformed

    private void RedibujarTablero() {
        //Se valida los componentes del elemento pnlTablero
        panel1.validate();
        //Se redibuja el elemento pnlTablero y sus componentes hijos
        panel1.repaint();
    }

    private void ObtenerTamanioObjetos(int cantX, int cantY) {

        TamX = TableroX / cantX;
        TamY = TableroY / cantY;

    }

    private void jMenuItem2ActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_jMenuItem2ActionPerformed

        final JFileChooser SaveAs = new JFileChooser();
        SaveAs.setApproveButtonText("Guardar");
        int actionDialog = SaveAs.showOpenDialog(this);

        File fileName = new File(SaveAs.getSelectedFile() + ".java");
        try {
            if (fileName == null) {
                return;
            }
            BufferedWriter outFile = new BufferedWriter(new FileWriter(fileName));
            outFile.write(jTextArea1.getText()); //put in textfile

            outFile.close();
        } catch (IOException ex) {
        }
    }//GEN-LAST:event_jMenuItem2ActionPerformed

    private void jMenuItem3ActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_jMenuItem3ActionPerformed
        System.exit(0);
    }//GEN-LAST:event_jMenuItem3ActionPerformed

    private void jTextArea1CaretUpdate(javax.swing.event.CaretEvent evt) {//GEN-FIRST:event_jTextArea1CaretUpdate
        int pos = evt.getDot();
        try {
            int fila = jTextArea1.getLineOfOffset(pos) + 1;
            int columna = pos - jTextArea1.getLineStartOffset(fila - 1) + 1;
            FilaVB.setText(fila + "");
            ColumnaVB.setText(columna + "");
        } catch (BadLocationException ex) {
            Logger.getLogger(Interfaz.class.getName()).log(Level.SEVERE, null, ex);
        }
    }//GEN-LAST:event_jTextArea1CaretUpdate

    /**
     * @param args the command line arguments
     */
    public static void main(String args[]) {
        /* Set the Nimbus look and feel */
        //<editor-fold defaultstate="collapsed" desc=" Look and feel setting code (optional) ">
        /* If Nimbus (introduced in Java SE 6) is not available, stay with the default look and feel.
         * For details see http://download.oracle.com/javase/tutorial/uiswing/lookandfeel/plaf.html 
         */
        try {
            for (javax.swing.UIManager.LookAndFeelInfo info : javax.swing.UIManager.getInstalledLookAndFeels()) {
                if ("Nimbus".equals(info.getName())) {
                    javax.swing.UIManager.setLookAndFeel(info.getClassName());
                    break;
                }
            }
        } catch (ClassNotFoundException ex) {
            java.util.logging.Logger.getLogger(Interfaz.class.getName()).log(java.util.logging.Level.SEVERE, null, ex);
        } catch (InstantiationException ex) {
            java.util.logging.Logger.getLogger(Interfaz.class.getName()).log(java.util.logging.Level.SEVERE, null, ex);
        } catch (IllegalAccessException ex) {
            java.util.logging.Logger.getLogger(Interfaz.class.getName()).log(java.util.logging.Level.SEVERE, null, ex);
        } catch (javax.swing.UnsupportedLookAndFeelException ex) {
            java.util.logging.Logger.getLogger(Interfaz.class.getName()).log(java.util.logging.Level.SEVERE, null, ex);
        }
        //</editor-fold>

        /* Create and display the form */
        java.awt.EventQueue.invokeLater(new Runnable() {
            public void run() {
                new Interfaz().setVisible(true);
            }
        });
    }

    // Variables declaration - do not modify//GEN-BEGIN:variables
    private java.awt.Label ColumnaVB;
    private java.awt.Label Fila;
    private java.awt.Label Fila2;
    private java.awt.Label FilaVB;
    private javax.swing.JMenu jMenu1;
    private javax.swing.JMenu jMenu4;
    private javax.swing.JMenuBar jMenuBar1;
    private javax.swing.JMenuItem jMenuItem1;
    private javax.swing.JMenuItem jMenuItem2;
    private javax.swing.JMenuItem jMenuItem3;
    private javax.swing.JMenuItem jMenuItem4;
    private javax.swing.JScrollPane jScrollPane1;
    private javax.swing.JScrollPane jScrollPane3;
    private javax.swing.JScrollPane jScrollPane4;
    private javax.swing.JTabbedPane jTabbedPane1;
    private javax.swing.JTabbedPane jTabbedPane3;
    private javax.swing.JTabbedPane jTabbedPane4;
    private javax.swing.JTextArea jTextArea1;
    private javax.swing.JTextArea jTextArea3;
    private javax.swing.JTextArea jTextArea4;
    private java.awt.Panel panel1;
    // End of variables declaration//GEN-END:variables
}
