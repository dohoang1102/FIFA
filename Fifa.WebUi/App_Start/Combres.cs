using System.Web.Routing;

using Combres;

using WebActivator;

[assembly: PreApplicationStartMethod(typeof(Fifa.WebUi.App_Start.Combres), "PreStart")]

namespace Fifa.WebUi.App_Start
{
    /// <summary>
    /// The combres.
    /// </summary>
    public static class Combres
    {
        #region Public Methods

        /// <summary>
        /// The pre start.
        /// </summary>
        public static void PreStart()
        {
            RouteTable.Routes.AddCombresRoute("Combres");
        }

        #endregion
    }
}