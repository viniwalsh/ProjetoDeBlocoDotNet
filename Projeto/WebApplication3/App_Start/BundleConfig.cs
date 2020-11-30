using System.Web;
using System.Web.Optimization;

namespace WebApplication3
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
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));

            // Custom bundle
            // Only used for profiles
            bundles.Add(new ScriptBundle("~/bundles/profilefileuploader").Include(
                      "~/Scripts/profileFileUploader.js"));

            // Only used for posts
            bundles.Add(new ScriptBundle("~/bundles/postfileuploader").Include(
                      "~/Scripts/postFileUploader.js"));

            // Tether for Bootstrap 4.x.x
            bundles.Add(new ScriptBundle("~/bundles/tether").Include(
                      "~/Scripts/tether/tether.js"));
        }
    }
}