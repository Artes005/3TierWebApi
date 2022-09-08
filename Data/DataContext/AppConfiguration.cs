using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
using Microsoft.Extensions.Configuration;


namespace Data.DataContext
{
    public class AppConfiguration
    {
        public string SqlConnectionString { get; set; }

        public AppConfiguration()
        {
            var configBuilder = new ConfigurationBuilder();
            string path = Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json");
            configBuilder.AddJsonFile(path, false);

            var root = configBuilder.Build();

            SqlConnectionString = root.GetSection("ConnectionString:DefaultConnection").Value;
        }


    }
}
