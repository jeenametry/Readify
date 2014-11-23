using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Castle.Windsor;

namespace Readify.Web
{
	public class MvcApplication : HttpApplication
	{
		private static readonly WindsorContainer _container = new WindsorContainer();
		

		protected void Application_Start()
		{
			Log4NetConfig.Register();
			CastleConfig.Register(_container);

			AreaRegistration.RegisterAllAreas();
			FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
			RouteConfig.RegisterRoutes(RouteTable.Routes);
			BundleConfig.RegisterBundles(BundleTable.Bundles);
		}
	}
}
