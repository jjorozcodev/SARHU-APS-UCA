using Datos;
using Entidades;
using System.Collections.Generic;

namespace Negocio
{
    public class NG_INSS
    {
        //GLOBALES
        private static DT_INSS dtINSS = DT_INSS.Instanciar();

        private static NG_INSS ngINSS = null;

        private NG_INSS()
        {
            //Singleton
        }

        public static NG_INSS Instanciar()
        {
            if (ngINSS == null)
            {
                ngINSS = new NG_INSS();
            }
            return ngINSS;
        }

        public INSS Consultar(int id)
        {
            return dtINSS.Consultar(id);
        }

        public bool Editar(INSS obj)
        {
            return dtINSS.Editar(obj);
        }

        public List<INSS> Listar()
        {
            return dtINSS.Listar();
        }
    }
}
