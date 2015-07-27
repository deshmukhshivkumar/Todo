using System.Web;
using System.Web.Optimization;

namespace MvcAppVs2013
{
    public class BundleConfig
    {
        // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {

            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                "~/Scripts/jquery.validate*",
                "~/Scripts/jquery.validate.unobtrusive*"
                        ));

            bundles.Add(new ScriptBundle("~/bundles/Bootstarp").Include(
                "~/Scripts/bootstrap.js"
                ));

            bundles.Add(new StyleBundle("~/CssBundle/Bootstrap").Include(
                    "~/Content/bootstrap*"                
                ));
        }
    }
}