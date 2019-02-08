# Narochno.EnvFile

Inspired by <https://github.com/motdotla/dotenv>

This will load `.env` files into `IConfiguration` (instead of Environment Variables like `dotenv`) to be used by .NET Core applications.

## Usage

Just like other configuration providers.  Recommended to load ENV VARs for your 12 factor apps after attempting to load from the local file.

```csharp
public class Program
{
    public static void Main(string[] args)
    {
        CreateWebHostBuilder(args).Build().Run();
    }

    public static IWebHostBuilder CreateWebHostBuilder(string[] args)
    {
        var configuration = new ConfigurationBuilder()
            // can overload to have other file names than .env
            .AddEnvFile()
            // overwrite env file vars
            .AddEnvironmentVariables()
            .Build();
        return new WebHostBuilder()
            .UseStartup<Startup>()
            .UseKestrel()
            .UseUrls(configuration.GetValue<string>("HOST"))
            .ConfigureLogging(lb => { lb.AddConsole(); })
            .UseConfiguration(configuration);
    }
}
```