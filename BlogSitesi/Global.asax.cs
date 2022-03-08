using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace BlogSitesi
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            // Authorize (Giriþ Yapýlmasý Gereken Sayfada - Giriþ Yapýlmasý Kontrolü) Ýþlemini her ActionResult (View) sayfalarý için tek tek tanýmlamak yerine Bütün Proje Bazýnda tanýmladýk.
            
            GlobalFilters.Filters.Add(new AuthorizeAttribute()); 
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
