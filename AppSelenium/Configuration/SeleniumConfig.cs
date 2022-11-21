using Microsoft.Extensions.Configuration;

namespace AppSelenium.Configuration
{
    public class SeleniumConfig
    {
        private readonly IConfiguration _config;
        public SeleniumConfig()
        {
            _config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
        }

        public string WebDriver => _config["WebDriver"];
        public string Url => _config["Url"];
        public bool Headless => bool.Parse(_config["Headless"]);
    }
}
