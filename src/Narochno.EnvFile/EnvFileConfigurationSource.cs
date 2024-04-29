using Microsoft.Extensions.Configuration;

namespace Narochno.EnvFile
{
    public class EnvFileConfigurationSource(string path) : IConfigurationSource
    {
        public IConfigurationProvider Build(IConfigurationBuilder builder) =>
            new EnvFileConfigurationProvider(path);
    }
}
