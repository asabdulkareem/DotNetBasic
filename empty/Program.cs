// Create
//Step1: Creating an Instance of WebApplicationOptions Class
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.RazorPages;

WebApplicationOptions webApplicationOptions = new WebApplicationOptions
{
    WebRootPath = "MyWebRoot", //Setting the WebRootPath as MyWebRoot
    Args = args, //Setting the Command Line Arguments in Args
    EnvironmentName = "Production", //Changing to Production
};
var builder = WebApplication.CreateBuilder(webApplicationOptions);
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
//If the Environment is Development, Please Show the Unhandled Exception Details 
//if (app.Environment.IsDevelopment())
//{
//    //Create an Instance of DeveloperExceptionPageOptions to Customize
//    //UseDeveloperExceptionPage Middleware Component
//    DeveloperExceptionPageOptions developerExceptionPageOptions = new DeveloperExceptionPageOptions
//    {
//        SourceCodeLineCount = 5
//    };
//    //Passing DeveloperExceptionPageOptions Instance to UseDeveloperExceptionPage Middleware Component
//    app.UseDeveloperExceptionPage(developerExceptionPageOptions);
//}
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
//Configuring Middleware Component using Use and Run Extension Method
//First Middleware Component Registered using Use Extension Method
//app.Use(async (context, next) =>
//{
//    await context.Response.WriteAsync("Middleware1: Incoming Request\n");
//    //Calling the Next Middleware Component
//    await next();
//    await context.Response.WriteAsync("Middleware1: Outgoing Response\n");
//});
////Second Middleware Component Registered using Use Extension Method
//app.Use(async (context, next) =>
//{
//    await context.Response.WriteAsync("Middleware2: Incoming Request\n");
//    //Calling the Next Middleware Component
//    await next();
//    await context.Response.WriteAsync("Middleware2: Outgoing Response\n");
//});
////Third Middleware Component Registered using Run Extension Method
//app.Run(async (context) =>
//{
//    await context.Response.WriteAsync("Middleware3: Incoming Request handled and response generated\n");
//    //Terminal Middleware Component i.e. cannot call the Next Component
//});
//The UseDefaultFiles() middleware will search the wwwroot folder for the following files.
//index.htm
//index.html
//default.htm
//default.html 
/// Specify the MyCustomPage1.html as the default page
//First Create an Instance of DefaultFilesOptions
//DefaultFilesOptions defaultFilesOptions = new DefaultFilesOptions();
////Clear any DefaultFileNames if already there
//defaultFilesOptions.DefaultFileNames.Clear();
////Add the default HTML Page to the DefaultFilesOptions Instance
//defaultFilesOptions.DefaultFileNames.Add("CustomFiles.html");
//app.UseDefaultFiles(defaultFilesOptions);
// Use UseFileServer instead of UseDefaultFiles and UseStaticFiles
//FileServerOptions fileServerOptions = new FileServerOptions();
//fileServerOptions.DefaultFilesOptions.DefaultFileNames.Clear();
//fileServerOptions.DefaultFilesOptions.DefaultFileNames.Add("CustomFiles.html");
//app.UseFileServer(fileServerOptions);
// Enable directory browsing on the current path
//app.UseDirectoryBrowser();
app.UseStaticFiles();
//Adding Another Middleware Component to the Request Processing Pipeline
//app.Run(async (context) =>
//{
//    await context.Response.WriteAsync("Request Handled and Response Generated");
//});
app.MapGet("/", async context =>
{
    int Number1 = 10, Number2 = 0;
    int Result = Number1 / Number2; //This statement will throw Runtime Exception
    await context.Response.WriteAsync($"Result : {Result}");
});
//app.MapGet("/", () => $"EnvironmentName: {app.Environment.EnvironmentName} \n" +
//            $"ApplicationName: {app.Environment.ApplicationName} \n" +
//            $"WebRootPath: {app.Environment.WebRootPath} \n" +
//            $"ContentRootPath: {app.Environment.ContentRootPath}");
//This will Run the Application
app.Run();
//This will Start the Application
app.Run();
