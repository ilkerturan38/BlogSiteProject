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
            // Authorize (Giri� Yap�lmas� Gereken Sayfada - Giri� Yap�lmas� Kontrol�) ��lemini her ActionResult (View) sayfalar� i�in tek tek tan�mlamak yerine B�t�n Proje Baz�nda tan�mlad�k.
            
            GlobalFilters.Filters.Add(new AuthorizeAttribute()); 
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
