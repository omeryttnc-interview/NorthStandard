using Microsoft.Extensions.Configuration;

namespace NorthStandard.Utilities
{
    public class ConfigReader
    {
        private static readonly IConfigurationRoot _configuration;

        static ConfigReader()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            _configuration = builder.Build();
        }

        // Generic method to get a section based on AppSettings
        public static AppSettings GetAppSettings()
        {
            return GetSection<AppSettings>();
        }

        // Generic method to get a section based on the class name
        public static T GetSection<T>() where T : new()
        {
            string sectionName = typeof(T).Name; // Use the class name as the section name
            var configSection = new T();
            _configuration.GetSection(sectionName).Bind(configSection);
            return configSection;
        }
    }
}
