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
                "~/Content/bootstrap.min.css",
                "~/Content/metisMenu.min.css",
                "~/Content/sb-admin-2.css",
                "~/Content/font-awesome.min.css",
                "~/Content/dataTables.bootstrap.css",
                "~/Content/dataTables.responsive.css",
                "~/Content/SARHU.css"));

            bundles.Add(new ScriptBundle("~/bundles/js").Include(
                "~/Scripts/jquery.min.js",
                "~/Scripts/bootstrap.min.js",
                "~/Scripts/metisMenu.min.js",
                "~/Scripts/sb-admin-2.js",
                "~/Scripts/jquery.dataTables.min.js",
                "~/Scripts/dataTables.bootstrap.min.js",
                "~/Scripts/dataTables.responsive.js",
                "~/Scripts/jquery.maskedinput.min.js",
                "~/Scripts/jquery-1.8.3.min.js"));
        }
    }
}