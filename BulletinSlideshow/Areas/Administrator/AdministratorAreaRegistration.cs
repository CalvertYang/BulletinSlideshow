using System.Web.Mvc;

namespace BulletinSlideshow.Areas.Administrator
{
    public class AdministratorAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Administrator";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Administrator",
                "Administrator/{controller}/{action}/{id}",
                new { controller = "Information", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
