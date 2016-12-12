using System;
using System.Collections.Generic;
using System.ComponentModel.Composition.Hosting;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using UI.Web.Utility;

namespace UI.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            MefInit();
            AutoMaperInit();
        }

        /// <summary>
        /// MEF初始化
        /// </summary>
        private void MefInit()
        {
            DirectoryCatalog catalog = new DirectoryCatalog(AppDomain.CurrentDomain.SetupInformation.PrivateBinPath);
            MefDependencySolver solver = new MefDependencySolver(catalog);
            DependencyResolver.SetResolver(solver);
            System.Web.Http.GlobalConfiguration.Configuration.DependencyResolver = solver;
        }


        private void AutoMaperInit()
        {
            Configuration.Configure();
            //在程序启动时对所有的配置进行严格的验证  
            // Mapper.AssertConfigurationIsValid(); 
        }
    }
}
