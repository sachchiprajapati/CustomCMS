using System.Web;
using System.Web.Optimization;

namespace CustomCMS
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            #region Other
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));
            #endregion

            #region Login
            bundles.Add(new StyleBundle("~/Login/css").Include(
                       "~/Content/bower_components/bootstrap/dist/css/bootstrap.min.css",
                       "~/Content/bower_components/font-awesome/css/font-awesome.min.css",
                       "~/Content/bower_components/Ionicons/css/ionicons.min.css",
                       "~/Content/dist/css/AdminLTE.min.css",
                       "~/Content/plugins/iCheck/square/blue.css"));

            bundles.Add(new StyleBundle("~/Login/js").Include(
                       "~/Content/bower_components/jquery/dist/jquery.min.js",
                       "~/Content/bower_components/bootstrap/dist/js/bootstrap.min.js",
                       "~/Content/plugins/iCheck/icheck.min.js"));
            #endregion

            #region Admin Panel 
            bundles.Add(new StyleBundle("~/Admin/css").Include(
                        "~/Content/bower_components/bootstrap/dist/css/bootstrap.css",
                        "~/Content/bower_components/font-awesome/css/font-awesome.css",
                        "~/Content/bower_components/Ionicons/css/ionicons.css",
                        "~/Content/bower_components/datatables.net-bs/css/dataTables.bootstrap.min.css",
                        "~/Content/dist/css/adminlte.min.css",
                        "~/Content/dist/css/skins/_all-skins.min.css"
                        //"~/Content/bower_components/morris.js/morris.css",
                        //"~/Content/bower_components/jvectormap/jquery-jvectormap.css",
                        //"~/Content/bower_components/bootstrap-datepicker/dist/css/bootstrap-datepicker.min.css",
                        //"~/Content/bower_components/bootstrap-daterangepicker/daterangepicker.css",
                        //"~/Content/plugins/bootstrap-wysihtml5/bootstrap3-wysihtml5.min.css"
                        ));

            bundles.Add(new StyleBundle("~/Admin/js").Include(
                        "~/Content/bower_components/jquery/dist/jquery.min.js",
                        "~/Content/bower_components/jquery-ui/jquery-ui.min.js",
                        "~/Content/bower_components/bootstrap/dist/js/bootstrap.min.js",
                        "~/Content/bower_components/datatables.net/js/jquery.dataTables.min.js",
                        "~/Content/bower_components/datatables.net-bs/js/dataTables.bootstrap.min.js",
                        "~/Content/dist/js/adminlte.min.js"));
            #endregion
        }
    }
}
