using Entidades;
using Negocio;
using System;

namespace SARHU.sarhu
{
    public partial class inicio : System.Web.UI.Page
    {
        private NG_Organizacion ngOrg = NG_Organizacion.Instanciar();
        private NG_Programas ngProg = NG_Programas.Instanciar();
        protected Organizacion org = null;
        protected int cantProgAct = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            org = ngOrg.Obtener();
            cantProgAct = ngProg.CantidadProgramasActivos();
        }
    }
}