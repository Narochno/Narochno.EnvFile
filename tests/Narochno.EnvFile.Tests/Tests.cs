using Microsoft.Extensions.Configuration;
using Xunit;

namespace Narochno.EnvFile.Tests
{
    public class Tests
    {
        [Fact]
        public void Basic()
        {
            var configuration = new ConfigurationBuilder().AddEnvFile().Build();
            var value = configuration.GetValue<string>("KEY");
            Assert.Equal("value", value);
        }

        [Fact]
        public void Manager()
        {
            var configuration = new ConfigurationManager().AddEnvFile().Build();
            var value = configuration.GetValue<string>("KEY");
            Assert.Equal("value", value);
        }
    }
}
