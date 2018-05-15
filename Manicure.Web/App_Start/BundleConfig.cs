using System.Web.Optimization;

namespace Manicure.Web
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.IgnoreList.Clear();

            //bundles.Add(new ScriptBundle("~/script/jquery").Include(
            //    "~/Scripts/jquery-{version}.js"));

            //bundles.Add(new StyleBundle("~/style/air-datepicker").Include(
            //    "~/Content/datepicker.min.css"));
        }

    }
}