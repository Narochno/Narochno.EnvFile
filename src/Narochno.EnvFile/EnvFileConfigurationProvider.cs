using System;
using System.IO;
using System.Linq;
using Microsoft.Extensions.Configuration;

namespace Narochno.EnvFile
{
    public class EnvFileConfigurationProvider(string path) : ConfigurationProvider
    {
        public override void Load()
        {
            Data.Clear();

            if (!File.Exists(path))
            {
                throw new FileNotFoundException(path);
            }

            using var reader = File.OpenText(path);
            string? line;
            while ((line = reader.ReadLine()) != null)
            {
                var values = line.Split("=", StringSplitOptions.RemoveEmptyEntries);
                if (values.Length < 2)
                {
                    continue;
                }
                Data.Add(values[0], string.Join('=', values.Skip(1)));
            }
        }
    }
}
