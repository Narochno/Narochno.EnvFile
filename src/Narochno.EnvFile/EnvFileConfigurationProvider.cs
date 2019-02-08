using System;
using System.IO;
using Microsoft.Extensions.Configuration;

namespace Narochno.EnvFile
{
    public class EnvFileConfigurationProvider : ConfigurationProvider
    {
        private readonly string _path;

        public EnvFileConfigurationProvider(string path)
        {
            _path = path;
        }

        public override void Load()
        {
            Data.Clear();
           
            if (!File.Exists(_path))
            {
                throw new FileNotFoundException(_path);
            }

            using (var reader = File.OpenText(_path))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    var values = line.Split("=", StringSplitOptions.RemoveEmptyEntries);
                    if (values.Length != 2)
                    {
                        continue;
                    }
                    Data.Add(values[0], values[1]);
                }
            }
        }
    }
}