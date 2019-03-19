using System;

namespace SARHU.sarhu
{
    public partial class inicio : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Negocio.NG_Areas.Instanciar();
        }
    }
}