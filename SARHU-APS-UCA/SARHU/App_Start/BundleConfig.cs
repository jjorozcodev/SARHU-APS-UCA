using System.Web.Optimization;

namespace SARHU
{
    public class BundleConfig
    {
        // Para obtener más información sobre la unión, visite http://go.microsoft.com/fwlink/?LinkID=303951
        
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/bundles/css").
                Include(
                "~/Content/vendor/bootstrap/css/bootstrap.min.css",
                "~/Content/vendor/metisMenu/metisMenu.min.css",
                "~/Content/dist/css/sb-admin-2.css",
                "~/Content/vendor/morrisjs/morris.css",
                "~/Content/vendor/font-awesome/css/font-awesome.min.css",
                "~/Content/vendor/datatables-plugins/dataTables.bootstrap.css",
                "~/Content/vendor/datatables-responsive/dataTables.responsive.css",
                "~/Content/DiseñoSARHU.css"));

            bundles.Add(new ScriptBundle("~/bundles/js").
                Include(
                "~/Content/vendor/jquery/jquery.min.js",
                "~/Content/vendor/bootstrap/js/bootstrap.min.js",
                "~/Content/vendor/metisMenu/metisMenu.min.js",
                "~/Content/vendor/raphael/raphael.min.js",
                "~/Content/vendor/morrisjs/morris.min.js",
                "~/Content/data/morris-data.js",
                "~/Content/dist/js/sb-admin-2.js",
                "~/Content/vendor/datatables/js/jquery.dataTables.min.js",
                "~/Content/vendor/datatables-plugins/dataTables.bootstrap.min.js",
                "~/Content/vendor/datatables-responsive/dataTables.responsive.js",
                "~/Content/maskedinput/jquery.maskedinput.min.js",
                "~/Content/maskedinput/jquery-1.8.3.min.js",
                "~/Content/js/parallax.min.js",
                "~/Content/js/parallax.js"));
        }
    }
}