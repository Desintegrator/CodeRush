using System.Web;
using System.Web.Optimization;

namespace MyWebsite
{
    public class BundleConfig
    {
        //Дополнительные сведения об объединении см. по адресу: http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Используйте версию Modernizr для разработчиков, чтобы учиться работать. Когда вы будете готовы перейти к работе,
            // используйте средство сборки на сайте http://modernizr.com, чтобы выбрать только нужные тесты.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new ScriptBundle("~/assets/js").Include(
          "~/Scripts/jquery.min.js",
          "~/Scripts/jquery.scrollex.min.js",
          "~/Scripts/jquery.scrolly.min.js",
          "~/Scripts/skel.min.js",
           "~/Scripts/util.js",
             "~/Scripts/ie/respond.min.js",
               "~/Scripts/main.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
              "~/Content/bootstrap.css",
              "~/Content/site.css"));

            bundles.Add(new StyleBundle("~/assets/css").Include(
                "~/font-awesome.min.css",
                "~/ie8.css",
                "~/ie9.css",
                "~/main.css"));
        }
    }
}
