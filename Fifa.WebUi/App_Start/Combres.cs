[assembly: WebActivator.PreApplicationStartMethod(typeof(Fifa.WebUi.App_Start.Combres), "PreStart")]
namespace Fifa.WebUi.App_Start {
	using System.Web.Routing;
	using global::Combres;
	
    public static class Combres {
        public static void PreStart() {
            RouteTable.Routes.AddCombresRoute("Combres");
        }
    }
}