using Castle.Windsor;
using Castle.Windsor.Installer;

namespace Readify.Web
{
	public class CastleConfig
	{
		public static void Register(WindsorContainer container)
		{
			container.Install(FromAssembly.This());
		} 
	}
}