using System;
using System.Web;
using Canea.Common.UI.DependencyInjection;
using Canea.Common.UI.View;
using Canea.Framework.Web.UI.WebForms.Application;
using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;

namespace User.UI
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            var container = new CaneaWebContainer();
            //new WebServiceDependencies().RegisterDependencies(container);
            new FrameworkWebDependencies(container).RegisterDependencies();
            IServiceLocator serviceLocator = new UnityServiceLocator(container);
            ServiceLocator.SetLocatorProvider(() => serviceLocator);
            container.RegisterPerWebSession<StateRegistry>("StateRegistry");
        }
    }
}