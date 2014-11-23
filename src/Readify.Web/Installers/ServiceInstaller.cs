using Castle.Facilities.WcfIntegration;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Readify.Contracts;
using Readify.Impl;
using Readify.Service.Contracts;

namespace Readify.Web.Installers
{
	public class ServiceInstaller : IWindsorInstaller
	{
		public void Install(IWindsorContainer container, IConfigurationStore store)
		{
			container.Register(Component.For<IStringReverser>().ImplementedBy<StringReverser>().LifestyleTransient());
			container.Register(Component.For<IFibonacciCalculator>().ImplementedBy<FibonacciCalculator>().LifestyleTransient());
			container.Register(Component.For<ITriangleService>().ImplementedBy<TriangleService>().LifestyleTransient());
		}
	}
}