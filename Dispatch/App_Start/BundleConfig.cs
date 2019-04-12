using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.UI;

namespace Dispatch {
    public class BundleConfig {
        // Para obter mais informações sobre o Agrupamento, visite https://go.microsoft.com/fwlink/?LinkID=303951
        public static void RegisterBundles(BundleCollection bundles) {
            bundles.Add(new ScriptBundle("~/bundles/Js").Include(
                            "~/Scripts/jquery-3.3.1.min.js",
                            "~/Scripts/bootstrap.min.js",
                            "~/Scripts/moment.min.js",
                            "~/Scripts/Chart.min.js",
                            "~/Scripts/tooplate-scripts.js"
                            ).IncludeDirectory("~/Scripts",".js"));

            bundles.Add(new StyleBundle("~/bundles/Css").Include(
                            "~/Content/bootstrap.min.css",
                            "~/Content/templatemo-style.css"
                            ).IncludeDirectory("~/Content", ".css"));

        }
    }
}