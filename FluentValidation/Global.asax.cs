using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using FVTest.Models.Validators;
using FluentValidation.Mvc;

namespace FVTest
{
	// Note: For instructions on enabling IIS6 or IIS7 classic mode, 
	// visit http://go.microsoft.com/?LinkId=9394801

	public class MvcApplication : System.Web.HttpApplication
	{
		protected void Application_Start()
		{
			
			AreaRegistration.RegisterAllAreas();

			WebApiConfig.Register(GlobalConfiguration.Configuration);
			FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
			RouteConfig.RegisterRoutes(RouteTable.Routes);
			BundleConfig.RegisterBundles(BundleTable.Bundles);


			//Configure FluentValidation to use StructureMap
			var factory = new StructuremapValidatorFactory();
 
			//Tell MVC to use FluentValidation for validation
			ModelValidatorProviders.Providers.Add(new FluentValidationModelValidatorProvider(factory));        
			DataAnnotationsModelValidatorProvider.AddImplicitRequiredAttributeForValueTypes = false;
		
		}
	}
}