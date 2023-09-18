namespace casa_app_backend.Configurations
{
    public static class EnvironmentVariableConfig
    {

        public static string ROTINA_DE_CASA_DB()
        {
            string? ROTINA_DE_CASA_DB = Environment.GetEnvironmentVariable("ROTINA_DE_CASA_DB");

            if (ROTINA_DE_CASA_DB is null)
            {
                throw new Exception();
            }

            return ROTINA_DE_CASA_DB;
        }
        public static string ROTINA_DE_CASA_NETWORK_CREDENTIAL()
        {
            string? ROTINA_DE_CASA_NETWORK_CREDENTIAL = Environment.GetEnvironmentVariable("ROTINA_DE_CASA_NETWORK_CREDENTIAL");

            if (ROTINA_DE_CASA_NETWORK_CREDENTIAL is null)
            {
                throw new Exception();
            }

            return ROTINA_DE_CASA_NETWORK_CREDENTIAL;
        }

        public static string GetNetworkCredential()
        {
            var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .AddEnvironmentVariables();

            IConfigurationRoot configuration = builder.Build();
            string? networkCredential = configuration["Variables:RotinaDeCasaNetworkCredential"];

            if (networkCredential is null)
            {
                throw new Exception();
            }

            return networkCredential;
        }

        public static string GetJwtSecretKey()
        {
              var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .AddEnvironmentVariables();

            IConfigurationRoot configuration = builder.Build();
            string? jwtSecretKey = configuration["Variables:JwtSecretKey"];

            if (jwtSecretKey is null)
            {
                throw new Exception();
            }

            return jwtSecretKey;
        }
    }
}