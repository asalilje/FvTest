using System.Reflection;
using FVTest;
using FluentValidation;
using StructureMap;
using StructureMap.Configuration.DSL;

namespace FVTest.DependencyResolution {
    
	public static class IoC {
        
		public static IContainer Initialize() {
            ObjectFactory.Initialize(x =>
                        {
                            x.Scan(scan =>
                                    {
                                        scan.TheCallingAssembly();
                                        scan.WithDefaultConventions();
                                    });
							x.AddRegistry(new ValidatorRegistry());
                        });
            return ObjectFactory.Container;
        }

	}

	public class ValidatorRegistry : Registry
	{
		public ValidatorRegistry()
		{
			
			AssemblyScanner.FindValidatorsInAssembly(Assembly.GetExecutingAssembly())
				.ForEach(result => For(result.InterfaceType).Singleton().Use(result.ValidatorType));
				 
		}
	}

}