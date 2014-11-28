using System.Web;
using System.Web.Optimization;

namespace Classified
{
    public class BundleConfig
    {
        // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include(
                        "~/Scripts/jquery-ui-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.unobtrusive*",
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new StyleBundle("~/Content/css").Include("~/Content/site.css"));

            bundles.Add(new StyleBundle("~/Content/themes/base/css").Include(
                        "~/Content/themes/base/jquery.ui.core.css",
                        "~/Content/themes/base/jquery.ui.resizable.css",
                        "~/Content/themes/base/jquery.ui.selectable.css",
                        "~/Content/themes/base/jquery.ui.accordion.css",
                        "~/Content/themes/base/jquery.ui.autocomplete.css",
                        "~/Content/themes/base/jquery.ui.button.css",
                        "~/Content/themes/base/jquery.ui.dialog.css",
                        "~/Content/themes/base/jquery.ui.slider.css",
                        "~/Content/themes/base/jquery.ui.tabs.css",
                        "~/Content/themes/base/jquery.ui.datepicker.css",
                        "~/Content/themes/base/jquery.ui.progressbar.css",
                        "~/Content/themes/base/jquery.ui.theme.css"));

            bundles.Add(new StyleBundle("~/assest/css").Include(
            "~/assets/css/bootstrap.min.css",
            "~/assets/css/main.css",
            "~/assets/css/green.css",
            "~/assets/css/owl.carousel.css",
            "~/assets/css/owl.transitions.css",
            "~/assets/css/lightbox.css",
            "~/assets/css/animate.min.css",
            "~/assets/css/rateit.css",
            "~/assets/css/bootstrap-select.min.css",
            "~/assets/css/config.css",
            "~/assets/css/green.css",
            "~/assets/css/red.css",
            "~/assets/css/orange.css",
            "~/assets/css/dark-green.css",
            "~/assets/css/blue.css",
            "~/assets/css/font-awesome.min.css"));

            bundles.Add(new ScriptBundle("~/assets/js").Include(
                       "~/assets/js/jquery-1.11.1.min.js",
                       "~/assets/js/bootstrap.min.js",
                       "~/assets/js/bootstrap-hover-dropdown.min.js",
                       "~/assets/js/owl.carousel.min.js",
                       "~/assets/js/echo.min.js",
                       "~/assets/js/jquery.easing-1.3.min.js",
                       "~/assets/js/bootstrap-slider.min.js",
                       "~/assets/js/jquery.rateit.min.js",
                       "~/assets/js/lightbox.min.js",
                       "~/assets/js/bootstrap-select.min.js",
                       "~/assets/js/wow.min.js",
                       "~/assets/js/scripts.js",
                       "~/switchstylesheet/switchstylesheet.js"));
        }
    }
}