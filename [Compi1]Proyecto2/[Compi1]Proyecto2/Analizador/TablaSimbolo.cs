using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _Compi1_Proyecto2.Analizador
{
    public class TablaSimbolo
    {
        private List<Simbolo> simbolos;

        public TablaSimbolo()
        {
            simbolos = new List<Simbolo>();
        }

        public Boolean addSimbolo(Simbolo simbolo)
        {
            if (!existe(simbolo.nombre))
            {
                simbolos.Add(simbolo);
                return true;
            }
            return false;
        }

        public Boolean removeSimbolo(String nombre)
        {
            foreach (Simbolo s in simbolos)
            {
                if (s.nombre == nombre)
                {
                    simbolos.Remove(s);
                    return true;
                }

            }
            return false;
        }

        public Boolean vaciar()
        {
            simbolos.Clear();
            return true;
        }

        public Simbolo getSimbolo(String nombre)
        {
            foreach (Simbolo s in simbolos)
            {
                if (nombre == s.nombre)
                {
                    return s;
                }
            }
            return null;
        }

        //verifica primero si existe el simbolo en la tabla local, si no existe se va a la tabla global a verificar
        public Simbolo getSimbolo(String nombre, TablaSimbolo global)
        {
            Boolean estado = false;
            Simbolo simbolo = null;
            foreach (Simbolo s in simbolos)
            {
                if (nombre == s.nombre)
                {
                    simbolo = s;
                    estado = true;
                }
            }
            if (estado)
            {
                return simbolo;
            }
            else
            {
                foreach (Simbolo s in global.simbolos)
                {
                    if (nombre == s.nombre)
                    {
                        return s;
                    }
                }
            }
            return null;
        }

        public Boolean existe(String nombre)
        {
            foreach (Simbolo s in simbolos)
            {
                if (s.nombre == nombre)
                {
                    return true;
                }

            }
            return false;
        }

        public void cambiarAmbito(TablaSimbolo principal)
        {
            foreach (Simbolo s in principal.simbolos)
            {
                simbolos.Add(s);
            }
        }
    }
}
