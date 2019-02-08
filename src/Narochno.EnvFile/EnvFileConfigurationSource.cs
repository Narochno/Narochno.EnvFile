using Microsoft.Extensions.Configuration;

namespace Narochno.EnvFile
{
    public class EnvFileConfigurationSource : IConfigurationSource
    {
        private readonly string _path;

        public EnvFileConfigurationSource(string path)
        {
            _path = path;
        }

        public IConfigurationProvider Build(IConfigurationBuilder builder)
        {
            return new EnvFileConfigurationProvider(_path);    
        }
    }
}