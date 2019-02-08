using System;
using Microsoft.Extensions.Configuration;
using Xunit;

namespace Narochno.EnvFile.Sample
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
    }
}