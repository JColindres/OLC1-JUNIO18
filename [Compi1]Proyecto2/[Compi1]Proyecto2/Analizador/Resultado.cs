﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _Compi1_Proyecto2.Analizador
{
    public class Resultado
    {
        public Object valor;
        public String tipo;

        public Resultado(String tipo, Object valor)
        {
            this.tipo = tipo;
            this.valor = valor;
        }
    }
}
