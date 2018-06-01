using System.Web;
using System.Web.Optimization;

namespace shanuMVCUserRoles
{
	public class BundleConfig
	{
		// For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
		public static void RegisterBundles(BundleCollection bundles)
		{
			bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
						"~/Scripts/jquery-{version}.js",
                        "~/Content/plugins/datatables/jquery.dataTables.js",
                        "~/Content/plugins/datatables/dataTables.bootstrap.min.js"));

			bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
						"~/Scripts/jquery.validate*"));

			// Use the development version of Modernizr to develop with and learn from. Then, when you're
			// ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
			bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
						"~/Scripts/modernizr-*"));

			bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
					  "~/Scripts/bootstrap.js",
					  "~/Scripts/respond.js",
                    "~/Content/dist/js/app.min.js"));

			bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap/css/bootstrap.min.css",
                      "~/Content/dist/css/skins/_all-skins.min.css",
                      "~/Content/dist/css/AdminLTE.min.css",
                       "~/Content/plugins/datatables/dataTables.bootstrap.css"));
		}
	}
}
