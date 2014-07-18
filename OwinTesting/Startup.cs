namespace OwinTesting
{
    using System.Diagnostics;
    using Nancy;
    using Nancy.Bootstrapper;
    using Nancy.TinyIoc;
    using Owin;

    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseNancy(options => options.Bootstrapper = new MyBootstrapper());
        }
    }

    public class MyBootstrapper : DefaultNancyBootstrapper
    {
        protected override void RequestStartup(TinyIoCContainer container, IPipelines pipelines, NancyContext context)
        {
            base.RequestStartup(container, pipelines, context);
            Debug.WriteLine("Hi there");
        }
    }

    public class HomeModule : NancyModule
    {
        public HomeModule()
        {
            Get["/"] = _ => "Boo";
        }
    }
}
