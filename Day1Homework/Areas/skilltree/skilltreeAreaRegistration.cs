using System.Web.Mvc;

namespace Day1Homework.Areas.skilltree
{
    public class skilltreeAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "skilltree";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "skilltree_default",
                "skilltree/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}