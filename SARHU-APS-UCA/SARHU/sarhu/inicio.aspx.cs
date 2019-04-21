using Entidades;
using Negocio;
using System;

namespace SARHU.sarhu
{
    public partial class inicio : System.Web.UI.Page
    {
        private NG_Organizacion ngOrg = NG_Organizacion.Instanciar();
        protected Organizacion org = null;
        protected int cantProgAct = 0;
        protected int cantLocAct = 0;
        protected int cantEmpl = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            org = ngOrg.Obtener();
            cantProgAct = NG_Programas.Instanciar().CantidadProgramasActivos();
            cantLocAct = NG_Localidades.Instanciar().CantidadLocalidadesActivas();
            cantEmpl = NG_Empleados.Instanciar().CantidadEmpleadosActivos();

        }
    }
}