using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Castle.Facilities.WcfIntegration;
using Castle.MicroKernel.SubSystems.Configuration;
using Readify.Service.Contracts;
using Readify.Service.Impl;

namespace Readify.Web.Installers
{
	public class WcfServicesInstaller : IWindsorInstaller
	{
		public void Install(IWindsorContainer container, IConfigurationStore store)
		{
			container.AddFacility<WcfFacility>();
			container.RegisterWcfService<IRedPill, RedPill>();
		}
	}

	public static class WcfExtensions
	{
		public static void RegisterWcfService<TInterface, TImpl>(this IWindsorContainer container)
			where TImpl : TInterface
			where TInterface: class
		{
			var service = typeof(TInterface).Name;
			container.Register(Component.For<TInterface>()
								.ImplementedBy<TImpl>()
								.Named(service)
								.LifeStyle.PerWcfOperation());
		}
	}
}