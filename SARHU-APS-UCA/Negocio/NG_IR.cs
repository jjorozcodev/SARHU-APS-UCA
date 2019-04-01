using Datos;
using Entidades;
using System.Collections.Generic;

namespace Negocio
{
    public class NG_IR
    {
        //GLOBALES
        private static DT_IR dtIR = DT_IR.Instanciar();

        private static NG_IR ngIR = null;

        private NG_IR()
        {
            //Singleton
        }

        public static NG_IR Instanciar()
        {
            if (ngIR == null)
            {
                ngIR = new NG_IR();
            }
            return ngIR;
        }

        public IR Consultar(int id)
        {
            return dtIR.Consultar(id);
        }

        public bool Editar(IR obj)
        {
            return dtIR.Editar(obj);
        }

        public List<IR> Listar()
        {
            return dtIR.Listar();
        }
    }
}

