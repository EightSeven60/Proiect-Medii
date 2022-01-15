using System.Web;
using System.Web.Optimization;
using Restaurant.Models;

namespace Restaurant
{
    public class BundleConfig
    {

        
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            /*ProdusModel p = new ProdusModel
            {
                Cantitate = 2,
                Gramaj = 500,
                Nume = "Suc cola",
                Unitate_masura = "ml"

            };

            MeniuModel m = new MeniuModel();
            m.Nume = "Cartofi";
            m.Pret = 22.5;
            m.Idproduse = "1 2";
            using (ProdusDbContext pdb = new ProdusDbContext())
            {
                pdb.Produse.Add(p);
                pdb.SaveChanges();
            }
            using (MeniuDbContext mdb = new MeniuDbContext())
            {
                mdb.Meniuri.Add(m);
                mdb.SaveChanges();
            }*/

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

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));
        }
    }
}
