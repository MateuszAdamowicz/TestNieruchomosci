using System.Web.Optimization;

namespace nieruchomości.App_Start
{
    public class BundleConfig
    {
         public static void RegisterBundles(BundleCollection bundles)
         {
            bundles.Add(new ScriptBundle("~/bundles/angular").Include(
                        "~/Scripts/angular.js",
                        "~/Scripts/angular-resource.js",
                        "~/Scripts/angular-route.js"));

            bundles.Add(new ScriptBundle("~/bundles/app").Include(
                        "~/Scripts/app/app.js",
                        "~/Scripts/app/dirPagination.js"
                        //"~/Scripts/app/services.js",
                        //"~/Scripts/app/directives.js",
                        //"~/Scripts/app/house.js",
                        //"~/Scripts/app/flat.js",
                        //"~/Scripts/app/land.js"
                        ));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                "~/Scripts/jquery.validate.unobtrusive.js",
                "~/Scripts/jquery.validate.js"));
         }
    }
}