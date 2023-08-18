
using Autofac.Extensions.DependencyInjection;
using Autofac;
using TodoList.Application;
using AutoMapper;
using TodoList.Infrastructure;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc.Core;

public class Program
{
    public static async Task Main(string[] args)
    {
        var host = Host.CreateDefaultBuilder(args)
      .UseServiceProviderFactory(new AutofacServiceProviderFactory())
      .ConfigureWebHostDefaults(webHostBuilder => {
          webHostBuilder
            .UseContentRoot(Directory.GetCurrentDirectory())
            .UseIISIntegration()
            .UseStartup<Startup>();
      })
      .Build();

        await host.RunAsync();
    }
}


public class Startup
{
    public Startup(IWebHostEnvironment env)
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(env.ContentRootPath)
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
            .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
            .AddEnvironmentVariables();
        this.Configuration = builder.Build();
    }

    public IConfiguration Configuration { get; private set; }

    // ConfigureServices is where you register dependencies. This gets
    // called by the runtime before the ConfigureContainer method, below.
    public void ConfigureServices(IServiceCollection services)
    {

        var ApplicationAssmebly = typeof(ApplicationModule).Assembly;
        var mediatorBuilder = new ContainerBuilder();
        var mediatorConfig = new MediatRServiceConfiguration();

        services.AddAutofac();
        services.AddCors();
        services.AddControllersWithViews();
        services.AddMediatR(mediatorConfig.RegisterServicesFromAssembly(ApplicationAssmebly));
        services.AddAutoMapper(ApplicationAssmebly);
        services.AddOptions();
    }

    // ConfigureContainer is where you can register things directly
    // with Autofac. This runs after ConfigureServices so the things
    // here will override registrations made in ConfigureServices.
    // Don't build the container; that gets done for you. If you
    // need a reference to the container, you need to use the
    // "Without ConfigureContainer" mechanism shown later.
    public void ConfigureContainer(ContainerBuilder builder)
    {
        builder.RegisterModule<ApplicationModule>();
        builder.RegisterModule<InfrastructureModule>();
    }

    // Configure is where you add middleware. This is called after
    // ConfigureContainer. You can use IApplicationBuilder.ApplicationServices
    // here if you need to resolve things from the container.
    public void Configure(
      IApplicationBuilder app,
      ILoggerFactory loggerFactory)
    {
        app.UseHttpsRedirection();
        app.UseStaticFiles();
        app.UseRouting();
        app.UseCors(x => x.AllowAnyHeader().AllowAnyMethod().WithOrigins("https://localhost:44423"));
        app.UseEndpoints(e => e.MapControllers());
    }
}