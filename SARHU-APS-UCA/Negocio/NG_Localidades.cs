﻿using Datos;
using Entidades;
using System.Collections.Generic;
using System.Data;

namespace Negocio
{
    public class NG_Localidades
    {
        //GLOBALES
        private static DT_Localidades dtLocalidades = DT_Localidades.Instanciar();
        private static NG_Programas ngProgramas = NG_Programas.Instanciar();
        private static NG_Departamentos ngDepartamentos = NG_Departamentos.Instanciar();
        private static NG_Municipios ngMunicipios = NG_Municipios.Instanciar();
        private static NG_Empleados ngEmpleado = NG_Empleados.Instanciar();
        private static NG_Localidades ngLocalidades = null;

        private NG_Localidades()
        {
            //Singleton
        }

        public static NG_Localidades Instanciar()
        {
            if (ngLocalidades == null)
            {
                ngLocalidades = new NG_Localidades();
            }
            return ngLocalidades;
        }

        public int AgregarObtenerID(Localidad obj)
        {
            return dtLocalidades.Agregar(obj);
        }

        public bool Agregar(Localidad obj)
        {
            return (dtLocalidades.Agregar(obj) > 0);
        }

        public bool Borrar(int id)
        {
            return dtLocalidades.Borrar(id);
        }

        public Localidad Consultar(int id)
        {
            return dtLocalidades.Consultar(id);
        }

        public bool Editar(Localidad obj)
        {
            return dtLocalidades.Editar(obj);
        }

        public List<Localidad> Listar()
        {
            return dtLocalidades.Listar();
        }

        public List<Localidad> ListarPorEstado(bool estado)
        {
            return dtLocalidades.ListarPorEstado(estado);
        }

        public int CantidadLocalidadesActivas()
        {
            List<Localidad> lcldds = this.ListarPorEstado(true);
            int cantidadLocsActivos = lcldds.Count;
            return cantidadLocsActivos;
        }
   
        public List<Empleado> RecuperarEmpleadosPorLocalidad(int idLocalidad)
         {
             List<Empleado> empleado = new List<Empleado>();


                 foreach (Empleado emp in ngEmpleado.ListarPorEstado(true))
                 {
                     if (idLocalidad == emp.LocalidadId)
                     {
                         empleado.Add(emp);
                     }
                 }           

             return empleado;
         }


        public Empleado RecuperarDirectorLocalidad(int idLocalidad)
        {
            Empleado empleado = new Empleado();
            foreach (Localidad local in ListarPorEstado(true))
            {
                if (idLocalidad == local.Id)
                {
                    foreach (Empleado emp in ngEmpleado.ListarPorEstado(true))
                    {
                        if (local.DirectorId == emp.Id)
                        {
                            empleado = emp;
                        }
                    }
                }

            }
            return empleado;
        }

        public DataTable VisualizarLocalidades()
        {
            DataTable vistaLocalidades = new DataTable();
            vistaLocalidades.Columns.Add("Id", typeof(int));
            vistaLocalidades.Columns.Add("Programa", typeof(string));
            vistaLocalidades.Columns.Add("Departamento", typeof(string));
            vistaLocalidades.Columns.Add("Director", typeof(string));
            vistaLocalidades.Columns.Add("Telefono", typeof(string));

            List<Localidad> localidadesActivas = this.ListarPorEstado(true);

            foreach (Localidad l in localidadesActivas)
            {
                Programa p = ngProgramas.Consultar(l.ProgramaId);
                Departamento d = ngMunicipios.ObtenerDepartamento(l.MunicipioId);
                Empleado emp = RecuperarDirectorLocalidad(l.Id);
                // TODO: Director recuperar ID

                vistaLocalidades.Rows.Add(l.Id, p.Nombre, d.Nombre, emp.Nombres, l.Telefono);
            }

            return vistaLocalidades;
        }
    }
}
