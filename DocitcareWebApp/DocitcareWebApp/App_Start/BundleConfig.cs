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
                        "~/Scripts/jquery-{version}.js",
                        "~/Scripts/moment.js",
                        "~/Scripts/jquery-3.4.1.js"));

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
                      "~/Content/Theme/app-assets/vendors/js/vendors.min.js",
                      "~/Content/Theme/app-assets/js/scripts/forms/form-login-register.js",
                      "~/Content/Theme/app-assets/vendors/js/forms/validation/jqBootstrapValidation.js",
                      "~/Content/Theme/app-assets/vendors/js/forms/icheck/icheck.min.js",
                      "~/Content/Theme/app-assets/js/core/app-menu.js",
                      "~/Content/Theme/app-assets/js/core/app.js",
                       "~/Content/Theme/app-assets/vendors/js/charts/apexcharts/apexcharts.min.js",
                       "~/Content/Theme/app-assets/js/scripts/cards/card-statistics.js",
                       "~/Content/Theme/app-assets/vendors/js/tables/datatable/datatables.min.js",
                       "~/Content/Theme/app-assets/vendors/js/tables/datatable/dataTables.responsive.min.js",
                       "~/Content/Theme/app-assets/js/scripts/tables/datatables-extensions/datatable-responsive.js",
                      "~/Content/Theme/app-assets/vendors/js/tables/datatable/dataTables.colReorder.min.js",
                      "~/Content/Theme/app-assets/vendors/js/tables/buttons.colVis.min.js",
                      "~/Content/Theme/app-assets/vendors/js/tables/datatable/dataTables.buttons.min.js",
                      "~/Content/Theme/app-assets/vendors/js/tables/datatable/buttons.bootstrap4.min.js",
                      "~/Content/Theme/app-assets/vendors/js/tables/datatable/dataTables.fixedHeader.min.js",
                      "~/Content/Theme/app-assets/vendors/js/forms/select/select2.full.min.js",
                      "~/Content/Theme/app-assets/js/scripts/forms/select/form-select2.js",
                       "~/Content/Theme/app-assets/js/scripts/modal/components-modal.js",
                       "~/Scripts/bootstrap-datetimepicker.js"

                     ));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css",
                      "~/Content/Theme/app-assets/css/bootstrap.css",
                      "~/Content/Theme/app-assets/css/bootstrap-extended.css",
                      "~/Content/Theme/app-assets/vendors/css/vendors.min.css",
                      "~/Content/Theme/app-assets/css/pages/login-register.css",
                      "~/Content/Theme/app-assets/vendors/css/forms/icheck/icheck.css",
                      "~/Content/Theme/app-assets/vendors/css/forms/icheck/custom.css",
                      "~/Content/Theme/app-assets/css/colors.css",
                      "~/Content/Theme/app-assets/css/components.css",
                      "~/Content/Theme/app-assets/css/core/colors/palette-gradient.css",
                      "~/Content/Theme/app-assets/css/core/menu/menu-types/vertical-menu.css",
                      "~/Content/Theme/app-assets/fonts/simple-line-icons/style.min.css",
                      "~/Content/Theme/app-assets/css/pages/card-statistics.css",
                      "~/Content/Theme/app-assets/css/pages/vertical-timeline.css",
                      "~/Content/Theme/assets/css/style.css",
                      "~/Content/Theme/app-assets/vendors/css/tables/datatable/datatables.min.css",
                      "~/Content/Theme/app-assets/vendors/css/tables/extensions/responsive.dataTables.min.css",
                      "~/Content/Theme/app-assets/vendors/css/tables/extensions/colReorder.dataTables.min.css",
                      "~/Content/Theme/app-assets/vendors/css/tables/extensions/buttons.dataTables.min.css",
                      "~/Content/Theme/app-assets/vendors/css/tables/datatable/buttons.bootstrap4.min.css",
                      "~/Content/Theme/app-assets/vendors/css/tables/extensions/fixedHeader.dataTables.min.css",
                      "~/Content/Theme/app-assets/vendors/css/forms/selects/select2.min.css",
                      "~/Content/bootstrap-datetimepicker.css"

                      ));




        }
    }
}
