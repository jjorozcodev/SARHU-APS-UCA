using System;
using Negocio;

namespace SARHU.sarhu.catalogos
{
    public partial class programas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            System.Data.DataTable data = NG_Departamentos.Instanciar().Obtener();

            string currentrow = "";

            foreach (System.Data.DataRow row in data.Rows)
            {
                System.Diagnostics.Debug.WriteLine(row[0] + " / " + row[1]);
            }
        }
    }
}