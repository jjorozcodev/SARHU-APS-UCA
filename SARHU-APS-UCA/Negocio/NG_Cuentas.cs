using Datos;
using Entidades;
using System.Collections.Generic;

namespace Negocio
{
    public class NG_Cuentas
    {
        //GLOBALES
        private static DT_Cuentas dtCuentas = DT_Cuentas.Instanciar();

        private static NG_Cuentas ngCuentas = null;

        private NG_Cuentas()
        {
            //Singleton
        }

        public static NG_Cuentas Instanciar()
        {
            if (ngCuentas == null)
            {
                ngCuentas = new NG_Cuentas();
            }
            return ngCuentas;
        }

        public int AgregarObtenerID(Cuenta obj)
        {
            return dtCuentas.Agregar(obj);
        }

        public bool Agregar(Cuenta obj)
        {
            return (dtCuentas.Agregar(obj) > 0);
        }

        public bool Borrar(int id)
        {
            return dtCuentas.Borrar(id);
        }

        public Cuenta Consultar(int id)
        {
            return dtCuentas.Consultar(id);
        }

        public bool Editar(Cuenta obj)
        {
            return dtCuentas.Editar(obj);
        }

        public List<Cuenta> Listar()
        {
            return dtCuentas.Listar();
        }

        public List<Cuenta> ListarPorEstado(bool estado)
        {
            return dtCuentas.ListarPorEstado(estado);
        }
    }
}
