using System.IO;
using Microsoft.Extensions.Configuration;

namespace Narochno.EnvFile
{
    public static class EnvConfigurationExtensions
    {
        public static IConfigurationBuilder AddEnvFile(
            this IConfigurationBuilder builder,
            string file = ".env"
        )
        {
            if (!Path.IsPathRooted(file))
            {
                file = Path.Combine(Directory.GetCurrentDirectory(), file);
            }

            if (File.Exists(file))
            {
                builder.Add(new EnvFileConfigurationSource(file));
            }

            return builder;
        }

        public static IConfigurationManager AddEnvFile(
            this IConfigurationManager manager,
            string file = ".env"
        )
        {
            if (!Path.IsPathRooted(file))
            {
                file = Path.Combine(Directory.GetCurrentDirectory(), file);
            }

            if (File.Exists(file))
            {
                manager.Add(new EnvFileConfigurationSource(file));
            }

            return manager;
        }
    }
}
