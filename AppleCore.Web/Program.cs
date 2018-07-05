using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace AppleCore.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
            
            WebHost.CreateDefaultBuilder(args)
                .UseKestrel(c => c.AddServerHeader = false)
                .UseStartup<Startup>()
                .Build();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)

                // Remove the web server's response "Server" header.
                .UseKestrel(c => c.AddServerHeader = false) 

                // To remove the "X-Powered-By" header,  at the time of writing (28 Jun 2018), you have to add a web.config entry. https://stackoverflow.com/a/39175938/335545

                .UseStartup<Startup>();
    }
}
