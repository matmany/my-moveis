using Microsoft.Extensions.Configuration;

namespace MyMovieApi.Core.Helper
{
    public static class SettingsConfigurationHelper
    {
        public static string GetValue(string envIndex, IConfiguration configuration)
        {
            var envValue = Environment.GetEnvironmentVariable(envIndex);
            if (string.IsNullOrEmpty(envValue))
                envValue = configuration.GetValue<string>(envIndex);
                
            return envValue;
        } 
    }
}