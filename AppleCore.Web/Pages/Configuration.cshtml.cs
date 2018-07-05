using AppleCore.Web.Configuration;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CuttingEdge.Conditions;
using Microsoft.Extensions.Configuration;

namespace AppleCore.Web.Pages
{
    public class ConfigurationModel : PageModel
    {
        private readonly IConfiguration _configuration;

        public string First { get; set; }
        public string Second { get; set; }
        public int NumberOfDoors { get; set; }

        public ConfigurationModel(
            IConfiguration configuration)
        {
            Condition.Requires(configuration, "configuration").IsNotNull();

            _configuration = configuration;
        }

        public void OnGet()
        {
            First = _configuration["AppSettings:First"];

            var appSettings = _configuration.GetSection("AppSettings").Get<AppSettings>();

            Second = appSettings.Second;
            NumberOfDoors = appSettings.Car.NumberOfDoors;
        }
    }
}
