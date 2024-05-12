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

        [Fact]
        public void PG_Test()
        {
            var configuration = new ConfigurationManager().AddEnvFile("test.env").Build();
            var value = configuration.GetValue<string>("HOST");
            Assert.Equal("test=me;val=me", value);
        }
    }
}
