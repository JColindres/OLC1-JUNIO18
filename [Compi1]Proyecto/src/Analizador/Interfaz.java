/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package Analizador;

import Analisis.Lexico;
import Analisis.Sintactico;
import Analisis.TablaSimbolos;
import AnalisisJava.LexicoJava;
import AnalisisJava.SintacticoJava;
import java.io.BufferedReader;
import java.io.BufferedWriter;
import java.io.File;
import java.io.FileNotFoundException;
import java.io.FileWriter;
import java.io.IOException;
import java.io.StringReader;
import java.util.ArrayList;
import java.util.Scanner;
import java.util.logging.Level;
import java.util.logging.Logger;
import javax.swing.JFileChooser;
import javax.swing.JScrollPane;
import javax.swing.text.BadLocationException;
import javax.swing.tree.DefaultMutableTreeNode;
import javax.swing.tree.DefaultTreeModel;

/**
 *
 * @author piplo10
 */
public class Interfaz extends javax.swing.JFrame {

    DefaultTreeModel model;

    public Interfaz() {
        initComponents();
        model = (DefaultTreeModel) jTree1.getModel();
        lineas();
    }

    @SuppressWarnings("unchecked")
    // <editor-fold defaultstate="collapsed" desc="Generated Code">//GEN-BEGIN:initComponents
    private void initComponents() {

        jTabbedPane1 = new javax.swing.JTabbedPane();
        jScrollPane1 = new javax.swing.JScrollPane();
        jTextArea1 = new javax.swing.JTextArea();
        jScrollPane6 = new javax.swing.JScrollPane();
        jTextArea5 = new javax.swing.JTextArea();
        jScrollPane7 = new javax.swing.JScrollPane();
        jTextArea6 = new javax.swing.JTextArea();
        jTabbedPane2 = new javax.swing.JTabbedPane();
        jScrollPane2 = new javax.swing.JScrollPane();
        jTextArea2 = new javax.swing.JTextArea();
        jTabbedPane3 = new javax.swing.JTabbedPane();
        jScrollPane3 = new javax.swing.JScrollPane();
        jTextArea3 = new javax.swing.JTextArea();
        Fila = new java.awt.Label();
        FilaVB = new java.awt.Label();
        FilaJava = new java.awt.Label();
        Fila1 = new java.awt.Label();
        jTabbedPane4 = new javax.swing.JTabbedPane();
        jScrollPane4 = new javax.swing.JScrollPane();
        jTextArea4 = new javax.swing.JTextArea();
        Fila2 = new java.awt.Label();
        ColumnaVB = new java.awt.Label();
        Fila3 = new java.awt.Label();
        ColumnaJava = new java.awt.Label();
        jScrollPane5 = new javax.swing.JScrollPane();
        jTree1 = new javax.swing.JTree();
        jMenuBar1 = new javax.swing.JMenuBar();
        jMenu1 = new javax.swing.JMenu();
        jMenuItem1 = new javax.swing.JMenuItem();
        jMenuItem2 = new javax.swing.JMenuItem();
        jMenuItem3 = new javax.swing.JMenuItem();
        jMenu4 = new javax.swing.JMenu();
        jMenuItem4 = new javax.swing.JMenuItem();
        jMenuItem5 = new javax.swing.JMenuItem();
        jMenu2 = new javax.swing.JMenu();
        jMenuItem6 = new javax.swing.JMenuItem();
        jMenuItem7 = new javax.swing.JMenuItem();

        setDefaultCloseOperation(javax.swing.WindowConstants.EXIT_ON_CLOSE);

        jTextArea1.setColumns(20);
        jTextArea1.setRows(5);
        jTextArea1.addCaretListener(new javax.swing.event.CaretListener() {
            public void caretUpdate(javax.swing.event.CaretEvent evt) {
                jTextArea1CaretUpdate(evt);
            }
        });
        jScrollPane1.setViewportView(jTextArea1);

        jTabbedPane1.addTab("CPReport", jScrollPane1);

        jTextArea5.setColumns(20);
        jTextArea5.setRows(5);
        jScrollPane6.setViewportView(jTextArea5);

        jTabbedPane1.addTab("Archivo 1", jScrollPane6);

        jTextArea6.setColumns(20);
        jTextArea6.setRows(5);
        jScrollPane7.setViewportView(jTextArea6);

        jTabbedPane1.addTab("Archivo 2", jScrollPane7);

        jTextArea2.setColumns(20);
        jTextArea2.setRows(5);
        jTextArea2.addCaretListener(new javax.swing.event.CaretListener() {
            public void caretUpdate(javax.swing.event.CaretEvent evt) {
                jTextArea2CaretUpdate(evt);
            }
        });
        jScrollPane2.setViewportView(jTextArea2);

        jTabbedPane2.addTab("Consola", jScrollPane2);

        jTextArea3.setColumns(20);
        jTextArea3.setRows(5);
        jScrollPane3.setViewportView(jTextArea3);

        jTabbedPane3.addTab("Errores Sintacticos", jScrollPane3);

        Fila.setText("Fila:");

        FilaVB.setText("0");

        FilaJava.setText("0");

        Fila1.setText("Fila:");

        jTextArea4.setColumns(20);
        jTextArea4.setRows(5);
        jScrollPane4.setViewportView(jTextArea4);

        jTabbedPane4.addTab("Errores Lexicos", jScrollPane4);

        Fila2.setText("Columna:");

        ColumnaVB.setText("0");

        Fila3.setText("Columna:");

        ColumnaJava.setText("0");

        javax.swing.tree.DefaultMutableTreeNode treeNode1 = new javax.swing.tree.DefaultMutableTreeNode("root");
        jTree1.setModel(new javax.swing.tree.DefaultTreeModel(treeNode1));
        jTree1.setRootVisible(false);
        jScrollPane5.setViewportView(jTree1);

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

        jMenuItem4.setText("Analizar Proyectos");
        jMenuItem4.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                jMenuItem4ActionPerformed(evt);
            }
        });
        jMenu4.add(jMenuItem4);

        jMenuItem5.setText("Analizar");
        jMenuItem5.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                jMenuItem5ActionPerformed(evt);
            }
        });
        jMenu4.add(jMenuItem5);

        jMenuBar1.add(jMenu4);

        jMenu2.setText("Reporte");

        jMenuItem6.setText("Arbol Json");
        jMenuItem6.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                jMenuItem6ActionPerformed(evt);
            }
        });
        jMenu2.add(jMenuItem6);

        jMenuItem7.setText("html");
        jMenuItem7.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                jMenuItem7ActionPerformed(evt);
            }
        });
        jMenu2.add(jMenuItem7);

        jMenuBar1.add(jMenu2);

        setJMenuBar(jMenuBar1);

        javax.swing.GroupLayout layout = new javax.swing.GroupLayout(getContentPane());
        getContentPane().setLayout(layout);
        layout.setHorizontalGroup(
            layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
            .addGroup(layout.createSequentialGroup()
                .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
                    .addGroup(layout.createSequentialGroup()
                        .addContainerGap()
                        .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING, false)
                            .addComponent(jTabbedPane3)
                            .addComponent(jTabbedPane1, javax.swing.GroupLayout.DEFAULT_SIZE, 400, Short.MAX_VALUE)))
                    .addGroup(layout.createSequentialGroup()
                        .addGap(82, 82, 82)
                        .addComponent(Fila, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE)
                        .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED)
                        .addComponent(FilaVB, javax.swing.GroupLayout.PREFERRED_SIZE, 38, javax.swing.GroupLayout.PREFERRED_SIZE)
                        .addGap(49, 49, 49)
                        .addComponent(Fila2, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE)
                        .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED)
                        .addComponent(ColumnaVB, javax.swing.GroupLayout.PREFERRED_SIZE, 38, javax.swing.GroupLayout.PREFERRED_SIZE)))
                .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.UNRELATED)
                .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING, false)
                    .addComponent(jTabbedPane2, javax.swing.GroupLayout.DEFAULT_SIZE, 400, Short.MAX_VALUE)
                    .addComponent(jTabbedPane4)
                    .addGroup(javax.swing.GroupLayout.Alignment.TRAILING, layout.createSequentialGroup()
                        .addComponent(Fila1, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE)
                        .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED)
                        .addComponent(FilaJava, javax.swing.GroupLayout.PREFERRED_SIZE, 32, javax.swing.GroupLayout.PREFERRED_SIZE)
                        .addGap(50, 50, 50)
                        .addComponent(Fila3, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE)
                        .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED)
                        .addComponent(ColumnaJava, javax.swing.GroupLayout.PREFERRED_SIZE, 38, javax.swing.GroupLayout.PREFERRED_SIZE)
                        .addGap(81, 81, 81))
                    .addComponent(jScrollPane5))
                .addContainerGap(javax.swing.GroupLayout.DEFAULT_SIZE, Short.MAX_VALUE))
        );
        layout.setVerticalGroup(
            layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
            .addGroup(layout.createSequentialGroup()
                .addContainerGap()
                .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
                    .addGroup(layout.createSequentialGroup()
                        .addComponent(jTabbedPane1, javax.swing.GroupLayout.PREFERRED_SIZE, 400, javax.swing.GroupLayout.PREFERRED_SIZE)
                        .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED, javax.swing.GroupLayout.DEFAULT_SIZE, Short.MAX_VALUE)
                        .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
                            .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
                                .addGroup(javax.swing.GroupLayout.Alignment.TRAILING, layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
                                    .addComponent(Fila, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE)
                                    .addComponent(FilaVB, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE))
                                .addComponent(Fila2, javax.swing.GroupLayout.Alignment.TRAILING, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE))
                            .addComponent(ColumnaVB, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE)))
                    .addGroup(layout.createSequentialGroup()
                        .addComponent(jTabbedPane2, javax.swing.GroupLayout.PREFERRED_SIZE, 196, javax.swing.GroupLayout.PREFERRED_SIZE)
                        .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED)
                        .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
                            .addComponent(Fila1, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE)
                            .addComponent(FilaJava, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE)
                            .addComponent(Fila3, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE)
                            .addComponent(ColumnaJava, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE))
                        .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED)
                        .addComponent(jScrollPane5, javax.swing.GroupLayout.PREFERRED_SIZE, 184, javax.swing.GroupLayout.PREFERRED_SIZE)
                        .addGap(0, 0, Short.MAX_VALUE)))
                .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.TRAILING)
                    .addComponent(jTabbedPane3, javax.swing.GroupLayout.PREFERRED_SIZE, 194, javax.swing.GroupLayout.PREFERRED_SIZE)
                    .addComponent(jTabbedPane4, javax.swing.GroupLayout.PREFERRED_SIZE, 194, javax.swing.GroupLayout.PREFERRED_SIZE))
                .addContainerGap())
        );

        jTabbedPane2.getAccessibleContext().setAccessibleName("Java");
        FilaVB.getAccessibleContext().setAccessibleName("FilaVB");
        FilaJava.getAccessibleContext().setAccessibleName("FilaJava");

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

        SintacticoJava sin = new SintacticoJava();

        String entrada1 = jTextArea5.getText();
        JAVA(entrada1);

        String[] repCo1 = sin.COMENTARIOS.split("\\|");
        String[] repCl1 = sin.CLASES.split(",");
        String[] repMe1 = sin.METODOS.split(",");
        String[] repVa1 = sin.VARIABLES.split(",");

        sin.score = 0;
        sin.clases = " ";
        sin.metodos = " ";
        sin.variables = " ";
        sin.comentarios = " ";
        sin.SCORE = " ";
        sin.CLASES = " ";
        sin.METODOS = " ";
        sin.VARIABLES = " ";
        sin.COMENTARIOS = " ";

        String entrada2 = jTextArea6.getText();
        JAVA(entrada2);

        String[] repCo2 = sin.COMENTARIOS.split("\\|");
        String[] repCl2 = sin.CLASES.split(",");
        String[] repMe2 = sin.METODOS.split(",");
        String[] repVa2 = sin.VARIABLES.split(",");

        sin.score = 0;
        sin.clases = " ";
        sin.metodos = " ";
        sin.variables = " ";
        sin.comentarios = " ";
        sin.SCORE = " ";
        sin.CLASES = " ";
        sin.METODOS = " ";
        sin.VARIABLES = " ";
        sin.COMENTARIOS = " ";

        ArrayList repetidosCom = new ArrayList();
        ArrayList repetidosCla = new ArrayList();
        ArrayList repetidosMet = new ArrayList();
        ArrayList<String> repetidosVar = new ArrayList<String>();

        for (int i = 0; i < repCl1.length; i++) {

            for (int j = 0; j < repCl2.length; j++) {

                if (repCl1[i] == null ? repCl2[j] == null : repCl1[i].equals(repCl2[j])) {

                    repetidosCla.add(repCl1[i]);
                    System.out.println("Hay clase repetida:" + repCl1[i]);
                }
            }

        }

        for (int i = 0; i < repMe1.length; i++) {

            for (int j = 0; j < repMe2.length; j++) {

                if (repMe1[i] == null ? repMe2[j] == null : repMe1[i].equals(repMe2[j])) {

                    if(!repetidosMet.contains(repMe1[i])){
                    repetidosMet.add(repMe1[i]);
                    System.out.println("Hay metodo repetido:" + repMe1[i]);
                    }
                }
            }

        }

        for (int i = 0; i < repVa1.length; i++) {

            for (int j = 0; j < repVa2.length; j++) {

                if (repVa1[i] == null ? repVa2[j] == null : repVa1[i].equals(repVa2[j])) {

                    //for (int k = 0; k < repetidosVar.size() - 1; k++) {
                    if (!repetidosVar.contains(repVa1[i])) {
                        repetidosVar.add(repVa1[i]);
                        System.out.println("Hay variable repetida:" + repVa1[i]);
                    }
                    //}
                }
            }

        }

        for (int i = 0; i < repCo1.length; i++) {

            //System.out.println(repCo2[i]);
            for (int j = 0; j < repCo2.length; j++) {

                if (repCo1[i] == null ? repCo2[j] == null : repCo1[i].equals(repCo2[j])) {

                    if(!repetidosCom.contains(repCo1[i])){
                    repetidosCom.add(repCo1[i]);
                    System.out.println("Hay comentario repetido:" + repCo2[j]);
                    }
                }
            }

        }

        double score = 2;
        double clasesrep, sumclases, comentariosrep, sumcomentarios, metodosrep, summetodos, variablesrep, sumvariables;
        clasesrep = repetidosCla.size();
        sumclases = repCl1.length + repCl2.length;
        comentariosrep = repetidosCom.size();
        sumcomentarios = repCo1.length + repCo2.length;
        metodosrep = repetidosMet.size();
        summetodos = repMe1.length + repMe2.length;
        variablesrep = repetidosVar.size();
        sumvariables = repVa1.length + repVa2.length;
        score = (double) (clasesrep / sumclases + comentariosrep / sumcomentarios + metodosrep / summetodos + variablesrep / sumvariables) * 0.25;
        System.out.println(score);
        sin.SCORE = score + ",";

        for (int i = 0; i < repetidosCla.size(); i++) {

            sin.CLASES += repetidosCla.get(i) + ",";
        }
        for (int i = 0; i < repetidosCom.size(); i++) {

            sin.COMENTARIOS += repetidosCom.get(i) + "|";
        }
        for (int i = 0; i < repetidosMet.size(); i++) {

            sin.METODOS += repetidosMet.get(i) + ",";
        }
        for (int i = 0; i < repetidosVar.size(); i++) {

            sin.VARIABLES += repetidosVar.get(i) + ",";
        }

        File fileName0 = new File("score.txt");
        try {
            BufferedWriter outFile = new BufferedWriter(new FileWriter(fileName0));
            outFile.write(sin.SCORE);
            outFile.close();
        } catch (IOException ex) {
        }
        File fileName = new File("clases.txt");
        try {
            BufferedWriter outFile = new BufferedWriter(new FileWriter(fileName));
            outFile.write(sin.CLASES);
            outFile.close();
        } catch (IOException ex) {
        }
        File fileName2 = new File("metodos.txt");
        try {
            BufferedWriter outFile = new BufferedWriter(new FileWriter(fileName2));
            outFile.write(sin.METODOS);
            outFile.close();
        } catch (IOException ex) {
        }
        File fileName3 = new File("variables.txt");
        try {
            BufferedWriter outFile = new BufferedWriter(new FileWriter(fileName3));
            outFile.write(sin.VARIABLES);
            outFile.close();
        } catch (IOException ex) {
        }
        File fileName4 = new File("comentarios.txt");
        try {
            BufferedWriter outFile = new BufferedWriter(new FileWriter(fileName4));
            outFile.write(sin.COMENTARIOS);
            outFile.close();
        } catch (IOException ex) {
        }
    }//GEN-LAST:event_jMenuItem4ActionPerformed

    public void JAVA(String entrada) {
        LexicoJava lex = new LexicoJava(new BufferedReader(new StringReader(entrada)));
        SintacticoJava sin = new SintacticoJava(lex);
        try {

            sin.parse();
            jTextArea2.setText("");
            jTextArea3.setText("");
            jTextArea4.setText("");
            for (int x = 0; x < sin.al.size(); x++) {
                jTextArea2.append((String) sin.al.get(x));
            }
            jTextArea2.append(sin.json);
            jTextArea3.setText("---------------Errores Sintacticos---------------\n\n");
            for (int x = 0; x < sin.erroresS.size(); x++) {
                jTextArea3.append((String) sin.erroresS.get(x) + "\n");
            }
            for (int x = 0; x < sin.erroresS1.size(); x++) {
                jTextArea3.append((String) sin.erroresS1.get(x) + "\n");
            }
            jTextArea4.setText("---------------Errores Lexicos-------------------\n\n");
            for (int x = 0; x < lex.erroresL.size(); x++) {
                jTextArea4.append((String) lex.erroresL.get(x));
            }
            jTextArea3.append("\n");
            jTextArea4.append("\n");

        } catch (Exception ex) {

            Logger.getLogger(Interfaz.class.getName()).log(Level.SEVERE, null, ex);

        }
    }

    private void jMenuItem2ActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_jMenuItem2ActionPerformed

        final JFileChooser SaveAs = new JFileChooser();
        SaveAs.setApproveButtonText("Guardar");

        File fileName = new File(SaveAs.getSelectedFile() + ".html");
        try {
            if (fileName == null) {
                return;
            }
            BufferedWriter outFile = new BufferedWriter(new FileWriter(fileName));
            outFile.write(jTextArea1.getText());

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

    private void jTextArea2CaretUpdate(javax.swing.event.CaretEvent evt) {//GEN-FIRST:event_jTextArea2CaretUpdate
        int pos = evt.getDot();
        try {
            int fila = jTextArea2.getLineOfOffset(pos) + 1;
            int columna = pos - jTextArea2.getLineStartOffset(fila - 1) + 1;
            FilaJava.setText(fila + "");
            ColumnaJava.setText(columna + "");
        } catch (BadLocationException ex) {
            Logger.getLogger(Interfaz.class.getName()).log(Level.SEVERE, null, ex);
        }
    }//GEN-LAST:event_jTextArea2CaretUpdate

    private void jMenuItem5ActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_jMenuItem5ActionPerformed
        // TODO add your handling code here:

        String entrada = jTextArea1.getText();
        TablaSimbolos ts = new TablaSimbolos();
        Lexico lex = new Lexico(new BufferedReader(new StringReader(entrada)),ts);
        Sintactico sin = new Sintactico(lex);
        try {

            sin.parse();
            jTextArea2.setText("");
            jTextArea3.setText("");
            jTextArea4.setText("");
            for (int x = 0; x < sin.al.size(); x++) {
                jTextArea2.append((String) sin.al.get(x));
            }
            jTextArea3.setText("---------------Errores Sintacticos---------------\n\n");
            for (int x = 0; x < sin.erroresS.size(); x++) {
                jTextArea3.append((String) sin.erroresS.get(x) + "\n");
            }
            for (int x = 0; x < sin.erroresS1.size(); x++) {
                jTextArea3.append((String) sin.erroresS1.get(x) + "\n");
            }
            jTextArea4.setText("---------------Errores Lexicos-------------------\n\n");
            for (int x = 0; x < lex.erroresL.size(); x++) {
                jTextArea4.append((String) lex.erroresL.get(x));
            }
            jTextArea2.append("\n");
            jTextArea3.append("\n");
            jTextArea4.append("\n");
            ts.imprimir();

        } catch (Exception ex) {

            Logger.getLogger(Interfaz.class.getName()).log(Level.SEVERE, null, ex);

        }
    }//GEN-LAST:event_jMenuItem5ActionPerformed

    DefaultMutableTreeNode selectednode;
    private void jMenuItem6ActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_jMenuItem6ActionPerformed

        //DefaultMutableTreeNode root = new DefaultMutableTreeNode("Json");
        DefaultTreeModel model = (DefaultTreeModel) jTree1.getModel();
        DefaultMutableTreeNode root = (DefaultMutableTreeNode) model.getRoot();
        DefaultMutableTreeNode json = new DefaultMutableTreeNode(new DefaultMutableTreeNode("Json"));
        DefaultMutableTreeNode SCORE = new DefaultMutableTreeNode(new DefaultMutableTreeNode("Score"));
        DefaultMutableTreeNode CLASES = new DefaultMutableTreeNode(new DefaultMutableTreeNode("Clases"));
        DefaultMutableTreeNode METODOS = new DefaultMutableTreeNode(new DefaultMutableTreeNode("Metodos"));
        DefaultMutableTreeNode VARIABLES = new DefaultMutableTreeNode(new DefaultMutableTreeNode("Variables"));
        DefaultMutableTreeNode COMENTARIOS = new DefaultMutableTreeNode(new DefaultMutableTreeNode("Comentarios"));
        root.add(json);
        json.add(SCORE);
        json.add(CLASES);
        json.add(METODOS);
        json.add(VARIABLES);
        json.add(COMENTARIOS);
        model.reload();

        StringBuilder sb0 = new StringBuilder();
        String pathScore = "C:\\Users\\pablo\\Desktop\\Compi Junio\\[Compi1]Proyecto\\score.txt";
        File c0 = new File(pathScore);
        try {
            Scanner archivoScore = new Scanner(c0);
            while (archivoScore.hasNext()) {

                sb0.append(archivoScore.nextLine());
                sb0.append("\n");
            }
            archivoScore.close();
            String score = sb0.toString();
            String[] partsScore = score.split(",");
            for (int x = 0; x < partsScore.length - 1; x++) {
                if (!partsScore[x].equals("") || !partsScore[x].equals(" ")) {

                    SCORE.add(new DefaultMutableTreeNode(partsScore[x]));
                    model.reload();
                }
            }

        } catch (FileNotFoundException ex) {
            Logger.getLogger(Interfaz.class.getName()).log(Level.SEVERE, null, ex);
        }

        StringBuilder sb = new StringBuilder();
        String pathClases = "C:\\Users\\pablo\\Desktop\\Compi Junio\\[Compi1]Proyecto\\clases.txt";
        File c = new File(pathClases);
        try {
            Scanner archivoClase = new Scanner(c);
            while (archivoClase.hasNext()) {

                sb.append(archivoClase.nextLine());
                sb.append("\n");
            }
            archivoClase.close();
            String clases = sb.toString();
            String[] partsClases = clases.split(",");
            for (int x = 0; x < partsClases.length - 1; x++) {
                if (!partsClases[x].equals("") || !partsClases[x].equals(" ")) {

                    CLASES.add(new DefaultMutableTreeNode(partsClases[x]));
                    model.reload();
                }
            }

        } catch (FileNotFoundException ex) {
            Logger.getLogger(Interfaz.class.getName()).log(Level.SEVERE, null, ex);
        }

        StringBuilder sb2 = new StringBuilder();
        String pathMetodos = "C:\\Users\\pablo\\Desktop\\Compi Junio\\[Compi1]Proyecto\\metodos.txt";
        File c2 = new File(pathMetodos);
        try {
            Scanner archivoMetodos = new Scanner(c2);
            while (archivoMetodos.hasNext()) {

                sb2.append(archivoMetodos.nextLine());
                sb2.append("\n");
            }
            archivoMetodos.close();
            String metodos = sb2.toString();
            String[] partsMetodos = metodos.split(",");
            for (int x = 0; x < partsMetodos.length - 1; x++) {
                if (!partsMetodos[x].equals("") || !partsMetodos[x].equals(" ")) {

                    METODOS.add(new DefaultMutableTreeNode(partsMetodos[x]));
                    model.reload();
                }
            }

        } catch (FileNotFoundException ex) {
            Logger.getLogger(Interfaz.class.getName()).log(Level.SEVERE, null, ex);
        }

        StringBuilder sb3 = new StringBuilder();
        String pathVariables = "C:\\Users\\pablo\\Desktop\\Compi Junio\\[Compi1]Proyecto\\variables.txt";
        File c3 = new File(pathVariables);
        try {
            Scanner archivoVariables = new Scanner(c3);
            while (archivoVariables.hasNext()) {

                sb3.append(archivoVariables.nextLine());
                sb3.append("\n");
            }
            archivoVariables.close();
            String variables = sb3.toString();
            String[] partsVariables = variables.split(",");
            for (int x = 0; x < partsVariables.length - 1; x++) {
                if (!partsVariables[x].equals("") || !partsVariables[x].equals(" ")) {

                    VARIABLES.add(new DefaultMutableTreeNode(partsVariables[x]));
                    model.reload();
                }
            }

        } catch (FileNotFoundException ex) {
            Logger.getLogger(Interfaz.class.getName()).log(Level.SEVERE, null, ex);
        }

        StringBuilder sb4 = new StringBuilder();
        String pathComentarios = "C:\\Users\\pablo\\Desktop\\Compi Junio\\[Compi1]Proyecto\\comentarios.txt";
        File c4 = new File(pathComentarios);
        try {
            Scanner archivoComentarios = new Scanner(c4);
            while (archivoComentarios.hasNext()) {

                sb4.append(archivoComentarios.nextLine());
                sb4.append("\n");
            }
            archivoComentarios.close();
            String comentarios = sb4.toString();
            String[] partsComentarios = comentarios.split("\\|");
            for (int x = 0; x < partsComentarios.length - 1; x++) {
                if (!partsComentarios[x].equals("") || !partsComentarios[x].equals(" ")) {

                    COMENTARIOS.add(new DefaultMutableTreeNode(partsComentarios[x]));
                    model.reload();
                }
            }

        } catch (FileNotFoundException ex) {
            Logger.getLogger(Interfaz.class.getName()).log(Level.SEVERE, null, ex);
        }

    }//GEN-LAST:event_jMenuItem6ActionPerformed

    public void lineas() {

        JScrollPane jsp;
        jsp = new JScrollPane(jTextArea1);
        TextLineNumber linea = new TextLineNumber(jTextArea1);
        jsp.setRowHeaderView(linea);
        jTabbedPane1.removeAll();
        jTabbedPane1.addTab("CPReport", jsp);

        JScrollPane jsp3;
        jsp3 = new JScrollPane(jTextArea5);
        TextLineNumber linea3 = new TextLineNumber(jTextArea5);
        jsp3.setRowHeaderView(linea3);
        jTabbedPane1.addTab("Archivo 1", jsp3);

        JScrollPane jsp4;
        jsp4 = new JScrollPane(jTextArea6);
        TextLineNumber linea4 = new TextLineNumber(jTextArea6);
        jsp4.setRowHeaderView(linea4);
        jTabbedPane1.addTab("Archivo 2", jsp4);

        JScrollPane jsp2;
        jsp2 = new JScrollPane(jTextArea2);
        TextLineNumber linea2 = new TextLineNumber(jTextArea2);
        jsp2.setRowHeaderView(linea2);
        jTabbedPane2.removeAll();
        jTabbedPane2.addTab("Consola", jsp2);
    }
    private void jMenuItem7ActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_jMenuItem7ActionPerformed
        // TODO add your handling code here:
    }//GEN-LAST:event_jMenuItem7ActionPerformed

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
        //</editor-fold>

        /* Create and display the form */
        java.awt.EventQueue.invokeLater(new Runnable() {
            public void run() {
                new Interfaz().setVisible(true);
            }
        });
    }


    // Variables declaration - do not modify//GEN-BEGIN:variables
    private java.awt.Label ColumnaJava;
    private java.awt.Label ColumnaVB;
    private java.awt.Label Fila;
    private java.awt.Label Fila1;
    private java.awt.Label Fila2;
    private java.awt.Label Fila3;
    private java.awt.Label FilaJava;
    private java.awt.Label FilaVB;
    private javax.swing.JMenu jMenu1;
    private javax.swing.JMenu jMenu2;
    private javax.swing.JMenu jMenu4;
    private javax.swing.JMenuBar jMenuBar1;
    private javax.swing.JMenuItem jMenuItem1;
    private javax.swing.JMenuItem jMenuItem2;
    private javax.swing.JMenuItem jMenuItem3;
    private javax.swing.JMenuItem jMenuItem4;
    private javax.swing.JMenuItem jMenuItem5;
    private javax.swing.JMenuItem jMenuItem6;
    private javax.swing.JMenuItem jMenuItem7;
    private javax.swing.JScrollPane jScrollPane1;
    private javax.swing.JScrollPane jScrollPane2;
    private javax.swing.JScrollPane jScrollPane3;
    private javax.swing.JScrollPane jScrollPane4;
    private javax.swing.JScrollPane jScrollPane5;
    private javax.swing.JScrollPane jScrollPane6;
    private javax.swing.JScrollPane jScrollPane7;
    private javax.swing.JTabbedPane jTabbedPane1;
    private javax.swing.JTabbedPane jTabbedPane2;
    private javax.swing.JTabbedPane jTabbedPane3;
    private javax.swing.JTabbedPane jTabbedPane4;
    private javax.swing.JTextArea jTextArea1;
    private javax.swing.JTextArea jTextArea2;
    private javax.swing.JTextArea jTextArea3;
    private javax.swing.JTextArea jTextArea4;
    private javax.swing.JTextArea jTextArea5;
    private javax.swing.JTextArea jTextArea6;
    private javax.swing.JTree jTree1;
    // End of variables declaration//GEN-END:variables
}
