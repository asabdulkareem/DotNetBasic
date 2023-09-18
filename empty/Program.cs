// Create
var builder = WebApplication.CreateBuilder(args);
// Set up Web Server
// Host the Application
// Logging
// Configuration
// Dependency Injection Container
// Adds Framework Provided Services
// The WebApplicationBuilder exposes the following.
// IWebHostEnvironment: It provides information about an application’s web hosting environment. It will provide information on whether the application is hosted using In-Process or OutOfProcess Hosting Model. Whether it is using IIS Server or Kestrel Web Server, or both.
// IServiceCollection: A collection of services that can be used throughout an application. This is useful for adding user-provided or framework-provided services. It provides methods to register different types of services, such as Transient, Scoped, and Singleton services.
// ConfigurationManager: A collection of configuration providers that can be used throughout an application. This is useful for adding new configuration sources and providers.
// ILoggingBuilder: A collection of logging providers that can be used throughout an application. This is useful for adding new logging providers.

//Build (Configuring the Middleware Components)
var app = builder.Build();
//order of execution
//appsettings.json
// appsettings.{Environment}.json here we use appsettings.Development.json
// User secrets
// Environment Variables
ConfigurationManager configuration = builder.Configuration;
string? MyCustomKeyValue = configuration?.GetValue<string>("MyCustomKey");
string? MyCustomKeyValueDirect = configuration["MyCustomKey"];

// The Build method of the WebApplicationBuilder class creates a new instance of the WebApplication class. We then use the Web Application instance to set up the Middlewares and endpoints for our ASP.NET Core Application. The template has set one middleware component using the MapGet extension method as follows:
//app.MapGet("/", () => $"Hello World!\n{System.Diagnostics.Process.GetCurrentProcess().ProcessName}\n{MyCustomKeyValue}\n{MyCustomKeyValueDirect}");
//Run (Starts the Application) - The Run method of the WebApplication instance starts the application and listens to HTTP requests.
//Configuring New Inline Middleware Component using Run Extension Method
app.Use(async (context, next) =>
{
    await context.Response.WriteAsync("Getting Response from First Middleware");
    await next();
});
//Configuring New Middleware Component using Run Extension Method
app.Run(async (context) =>
{
    await context.Response.WriteAsync("Getting Response from Second Middleware");
});
app.Run();
