using Datos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Data;

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
            if (string.IsNullOrEmpty(obj.Foto))
            {
                obj.Foto = "../../Content/Imagenes/profile.png";
            }
            return dtEmpleados.Agregar(obj);
        }

        public bool Agregar(Empleado obj)
        {
            if (string.IsNullOrEmpty(obj.Foto))
            {
                obj.Foto = "../../Content/Imagenes/profile.png";
            }
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

        public DataTable ListarEmpleadosProgramas()
        {
            DataTable dtEmpleadosVista = new DataTable();

            dtEmpleadosVista.Columns.Add("Id", typeof(int));
            dtEmpleadosVista.Columns.Add("Codigo", typeof(string));
            dtEmpleadosVista.Columns.Add("Nombres", typeof(string));
            dtEmpleadosVista.Columns.Add("Apellidos", typeof(string));
            dtEmpleadosVista.Columns.Add("ProgramaLocalidad", typeof(string));

            foreach (Empleado e in this.ListarPorEstado(true))
            {
                Localidad l = NG_Localidades.Instanciar().Consultar(e.LocalidadId);

                DataRow dr = dtEmpleadosVista.NewRow();

                dr["Id"] = e.Id;
                dr["Codigo"] = e.Codigo;
                dr["Nombres"] = e.Nombres;
                dr["Apellidos"] = e.Apellidos;
                dr["ProgramaLocalidad"] = l.Alias;

                dtEmpleadosVista.Rows.Add(dr);
            }

            return dtEmpleadosVista;
        }


        public int CantidadEmpleadosActivos()
        {
            List<Empleado> empl = this.ListarPorEstado(true);
            int cantidadEmplActivos = empl.Count;
            return cantidadEmplActivos;
        }
        
        public int CantidadEmpleadosVarones()
        {
            List<Empleado> empls = this.ListarPorEstado(true);
            int contador = 0;
            foreach(Empleado e in empls)
            {
                if (e.Sexo)
                {
                    contador++;
                }
            }
            return contador;
        }

        public string GenerarCodigoEmpleado(DateTime FechaIngreso, string Nombres, string Apellidos, string Cedula)
        {
            string year = FechaIngreso.ToString("yy");
            string mes = FechaIngreso.ToString("MM");
            string subNombre = Nombres.Substring(0, 1);
            string subApellido = Apellidos.Substring(0, 1);
            string ID = Cedula.Substring((Cedula.Length - 3), 3);

            return year + mes + subNombre + subApellido + ID;
        }
    }
}
