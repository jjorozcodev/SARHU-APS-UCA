using System;
using System.Collections.Generic;
using Datos;
using Entidades;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Negocio
{
    public class NG_Puestos
    {

        private static NG_Puestos ngPuestos = null;
        private DT_Puestos dtPuesto = DT_Puestos.Instanciar();
        private DT_Funciones dtFunciones = DT_Funciones.Instanciar();
        private static DataTable dTablePuestoFunciones = new DataTable();
      


        private NG_Puestos()
        {
            //Singleton
        }


        public static NG_Puestos Instanciar()
        {
            if (ngPuestos == null)
            {
                ngPuestos = new NG_Puestos();
            }
            return ngPuestos;
        }


        public int AgregarPuesto(Puesto puesto)
        {

            return DT_Puestos.Instanciar().Agregar(puesto);
        }

        public void AgregarPuestoFuncion(List<int> funcionesId, int idPuesto)
        {

            foreach (int id in funcionesId)
            {
                dtPuesto.AgregarPuestoFunciones(id,idPuesto);
            }


        }

        public List<Puesto> ListarPuesto(bool Estado)
        {

            return dtPuesto.ListarPorEstado(Estado);

        }

        public List<Puesto> Listar()
        {
            return dtPuesto.Listar();
        }

        public bool EditarPuesto(Puesto puestos)
        {

            return dtPuesto.Editar(puestos);
        }

        public bool Eliminar(int id, List<int> funcionesID) {

            foreach (int idfuncion in funcionesID)
            {
                EliminarFuncionPuesto(id, idfuncion);
            }

           
            return dtPuesto.Borrar(id);

        }

        public void EliminarFuncionPuesto(int idPuesto, int idFuncion)
        {
            dtPuesto.EliminarFuncionesPuesto(idPuesto, idFuncion);

        }

        public Puesto Consultar(int id)
        {

            return dtPuesto.Consultar(id);
        }

        public DataTable ListarPuestoFunciones(int idPuesto)
        {
            dTablePuestoFunciones = new DataTable();
            InitDataTable();

            DataTable tablePuestosFunciones = dtPuesto.ListarPuestosFunciones();
            List<Funcion> ltFunciones = new List<Funcion>();

            ltFunciones = dtFunciones.Listar();

            foreach (DataRow row in tablePuestosFunciones.Rows)
            {

                if (idPuesto == int.Parse(row["puesto_id"].ToString()))
                {
                    foreach (Funcion item in ltFunciones)
                    {
                        if (item.Id == int.Parse(row["funcion_id"].ToString()))
                        {
                            dTablePuestoFunciones.Rows.Add(row["funcion_id"], item.Nombre);
                            
                        }
                       
                    }
                   
                   
                }              
                                
            }

            return dTablePuestoFunciones;


        }

        private void InitDataTable()
        {
            dTablePuestoFunciones.Columns.Add("Id", typeof(int));
            dTablePuestoFunciones.Columns.Add("Nombre", typeof(string));

        }
    }
}
