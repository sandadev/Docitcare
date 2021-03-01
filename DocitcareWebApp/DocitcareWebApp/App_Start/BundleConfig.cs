using System.Web;
using System.Web.Optimization;

namespace DocitcareWebApp
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));
            //vendor theme js

            bundles.Add(new ScriptBundle("~/bundles/vendor").Include(
                      "~/Content/Theme/vendors/js/vendors.min.js",
                      "~/Content/Theme/vendors/js/form-login-register.js",
                      "~/Content/Theme/vendors/js/forms/validation/jqBootstrapValidation.js",
                      "~/Content/Theme/vendors/js/forms/icheck/icheck.min.js",
                      "~/Content/Theme/vendors/js/app-menu.js",
                      "~/Content/Theme/vendors/js/app.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/bootstrap-extended.css",
                      "~/Content/site.css",
                      "~/Content/Theme/vendors/css/bootstrap.css",
                      "~/Content/Theme/vendors/css/bootstrap-extended.css",
                      "~/Content/Theme/vendors/css/vendors.min.css",
                      "~/Content/Theme/vendors/css/login-register.css",
                      "~/Content/Theme/vendors/css/forms/icheck/icheck.css",
                       "~/Content/Theme/vendors/css/forms/icheck/custom.css",
                       "~/Content/Theme/vendors/css/colors.css",
                       "~/Content/Theme/vendors/css/components.css",
                        "~/Content/Theme/vendors/css/palette-gradient.css",
                         "~/Content/Theme/vendors/css/vertical-menu-modern.css",
                         "~/Content/Theme/vendors/css/style.css"));

        }
    }
}
