using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AppleCore.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services
                .AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_1)

                // FluentValidation - ASP.NET Core integration https://fluentvalidation.net/
                .AddFluentValidation(fv =>
                {
                    fv.RunDefaultMvcValidationAfterFluentValidationExecutes = false;
                    fv.ImplicitlyValidateChildProperties = true;
                    fv.RegisterValidatorsFromAssemblyContaining<Startup>();
                });
            
            services
                .AddRouting(r => r.LowercaseUrls = true);

            // elmah.io https://docs.elmah.io/logging-to-elmah-io-from-aspnet-core/
            // This is now a managed solution, so costs to implement.
            // ASP.NET core doesn't use HttpHandlers or HttpModules so Elmah won't work. Microsoft has it's own and some people are working on porting ELMAH to core.
            
            // R4MVC https://github.com/T4MVC/R4MVC/wiki/Documentation
            // T4MVC (which helps avoid string literals and other conventions) has been superseded by R4MVC (R for Roslyn)
            // Unlike T4MVC, R4MVC isn't based on a T4 template, so triggering the generation code is slightly different, you need to run "Generate-R4MVC" at the Package Manager Console
            // Currently in pre-release.

            // CSRF/Antiforgery is provided out of the box as long as you use the Core Razore helper tags to generate your HTML form. 
            // https://docs.microsoft.com/en-us/aspnet/core/security/anti-request-forgery?view=aspnetcore-2.1
            // Look in the HTML for the hidden variable: __RequestVerificationToken
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            if ((env.IsProduction()) || (env.IsStaging()))
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            // Includes support for Razor Pages and controllers.
            app.UseMvc();
        }
    }
}
