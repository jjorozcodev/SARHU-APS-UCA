using Datos;
using Entidades;
using System.Collections.Generic;

namespace Negocio
{
    public class NG_Empleados
    {
        //GLOBALES
        private static DT_Empleados dtEmpleados = DT_Empleados.Instanciar();

        private static NG_Empleados ngEmpleados = null;

        private NG_Empleados()
        {
            //Singleton
        }

        public static NG_Empleados Instanciar()
        {
            if (ngEmpleados == null)
            {
                ngEmpleados = new NG_Empleados();
            }
            return ngEmpleados;
        }

        public int AgregarObtenerID(Empleado obj)
        {
            return dtEmpleados.Agregar(obj);
        }

        public bool Agregar(Empleado obj)
        {
            return (dtEmpleados.Agregar(obj) > 0);
        }

        public bool Borrar(int id)
        {
            return dtEmpleados.Borrar(id);
        }

        public Empleado Consultar(int id)
        {
            return dtEmpleados.Consultar(id);
        }

        public bool Editar(Empleado obj)
        {
            return dtEmpleados.Editar(obj);
        }

        public List<Empleado> Listar()
        {
            return dtEmpleados.Listar();
        }

        public List<Empleado> ListarPorEstado(bool estado)
        {
            return dtEmpleados.ListarPorEstado(estado);
        }

        public int CantidadEmpleadosActivos()
        {
            List<Empleado> empl = this.ListarPorEstado(true);
            int cantidadEmplActivos = empl.Count;
            return cantidadEmplActivos;
        }
    }
}
