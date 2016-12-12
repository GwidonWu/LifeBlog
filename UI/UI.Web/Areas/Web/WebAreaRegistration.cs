using System.Web.Mvc;

namespace UI.Web.Areas.Web
{
    public class WebAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Web";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Web_default",
                "Web/{controller}/{action}" + ".html",
                new { action = "Index"},
                new string[] { "UI.Web.Areas.Web.Controllers" }
            );
            context.MapRoute(
                "Web_default2",
                "Web/{controller}/{action}/{id}" + ".html",
                new { action = "Index", id = UrlParameter.Optional },
                new string[] {"UI.Web.Areas.Web.Controllers"}
            );
        }
    }
}