using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Combres;
using log4net;

namespace Fifa.WebUi
{
    /// <summary>
    /// The mvc application.
    /// </summary>
    public class MvcApplication : HttpApplication
    {
        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="MvcApplication"/> class.
        /// </summary>
        public MvcApplication()
        {
            Error += MvcApplication_Error;
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// The register global filters.
        /// </summary>
        /// <param name="filters">
        /// The filters.
        /// </param>
        public void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        /// <summary>
        /// The register routes.
        /// </summary>
        /// <param name="routes">
        /// The routes.
        /// </param>
        public void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{*aspx}", new { aspx = @".*\.aspx(/.*)?" });
            routes.IgnoreRoute("{*favicon}", new { favicon = @"(.*/)?favicon.ico(/.*)?" });
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Default", 
                // Route name
                "{controller}/{action}/{id}", 
                // URL with parameters
                new { controller = "Home", action = "Index", id = UrlParameter.Optional } // Parameter defaults
                );
        }

        #endregion

        #region Methods

        /// <summary>
        /// The application_ start.
        /// </summary>
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);

            RouteTable.Routes.AddCombresRoute("CombresRoute");
        }

        /// <summary>
        /// The mvc application_ error.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void MvcApplication_Error(object sender, EventArgs e)
        {
            LogManager.GetLogger(typeof(MvcApplication))
                .Error("Unhandled exception.", Context.Server.GetLastError());
        }

        #endregion
    }
}