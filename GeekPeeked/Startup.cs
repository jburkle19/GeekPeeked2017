using System.Web.Mvc;
using Owin;
using Autofac;
using Autofac.Integration.Mvc;
using Microsoft.Owin;
using GeekPeeked.Models;
using GeekPeeked.Repositories;
using GeekPeeked.Repositories.Interfaces;

[assembly: OwinStartup(typeof(GeekPeeked.Startup))]

namespace GeekPeeked
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<GeekPeekedDbContext>().AsSelf().InstancePerRequest();
            
            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            // register repositories
            builder.RegisterType<ContestRepository>().As<IContestRespoitory>().InstancePerRequest();
            builder.RegisterType<AcademyAwardsContestRepository>().As<IAcademyAwardsContestRepository>().InstancePerRequest();

            var container = builder.Build();

            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

            app.UseAutofacMiddleware(container);
            app.UseAutofacMvc();
        }
    }
}
