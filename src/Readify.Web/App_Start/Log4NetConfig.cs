namespace Readify.Web
{
	public class Log4NetConfig
	{
		public static void Register()
		{
			log4net.Config.XmlConfigurator.Configure();
		}
	}
}