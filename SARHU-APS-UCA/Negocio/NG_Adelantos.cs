using Datos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Data;

namespace Negocio
{
    public class NG_Adelantos
    {
        //GLOBALES
        private static DT_Adelantos dtAdelantos = DT_Adelantos.Instanciar();
        private static NG_Empleados ngEmpleados = NG_Empleados.Instanciar();

        private static NG_Adelantos ngAdelantos = null;

        private NG_Adelantos()
        {
            //Singleton
        }

        public static NG_Adelantos Instanciar()
        {
            if (ngAdelantos == null)
            {
                ngAdelantos = new NG_Adelantos();
            }
            return ngAdelantos;
        }

        public int AgregarObtenerID(Adelanto obj)
        {
            return dtAdelantos.Agregar(obj);
        }

        public bool Agregar(Adelanto obj)
        {
            return (dtAdelantos.Agregar(obj) > 0);
        }

        public bool Borrar(int id)
        {
            return dtAdelantos.Borrar(id);
        }

        public Adelanto Consultar(int id)
        {
            return dtAdelantos.Consultar(id);
        }

        public bool Editar(Adelanto obj)
        {
            return dtAdelantos.Editar(obj);
        }

        public List<Adelanto> Listar()
        {
            return dtAdelantos.Listar();
        }

        public List<Adelanto> ListarPorEstado(bool estado)
        {
            return dtAdelantos.ListarPorEstado(estado);
        }

        public int CantidadAdelantosActivas()
        {
            List<Adelanto> adelnts = this.ListarPorEstado(true);
            int cantidadAdelntsActivos = adelnts.Count;
            return cantidadAdelntsActivos;
        }

        public DataTable VisualizarAdelantos()
        {
            DataTable vistaAdelantos = new DataTable();
            vistaAdelantos.Columns.Add("Id", typeof(int));
            vistaAdelantos.Columns.Add("Empleado", typeof(string));
            vistaAdelantos.Columns.Add("FechaEntrega", typeof(DateTime));
            vistaAdelantos.Columns.Add("FechaDeduccion", typeof(DateTime));
            vistaAdelantos.Columns.Add("Descripcion", typeof(string));
            vistaAdelantos.Columns.Add("Monto", typeof(Decimal));

            List<Adelanto> adelantosActivas = this.ListarPorEstado(true);

            foreach (Adelanto a in adelantosActivas)
            {
                Empleado e = ngEmpleados.Consultar(a.EmpleadoId);
                // TODO: recuperar ID

                vistaAdelantos.Rows.Add(a.Id, e.Nombres, a.FechaDeduccion, a.FechaDeduccion, a.Descripcion, a.Monto);
            }

            return vistaAdelantos;
        }
    }
}
