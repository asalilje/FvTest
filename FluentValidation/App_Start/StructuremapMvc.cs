using System.Web.Mvc;
using FVTest.App_Start;
using FVTest.DependencyResolution;
using StructureMap;

[assembly: WebActivator.PreApplicationStartMethod(typeof(StructuremapMvc), "Start")]

namespace FVTest.App_Start {
    
	public static class StructuremapMvc {
        
		public static void Start() {
            var container = IoC.Initialize();
            DependencyResolver.SetResolver(new SmDependencyResolver(container));
        }

    }

}