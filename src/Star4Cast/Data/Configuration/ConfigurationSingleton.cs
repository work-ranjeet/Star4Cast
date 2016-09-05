using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Star4Cast.Data.Configuration
{
    public sealed class ConfigurationSingleton
    {

        private static ConfigurationSingleton _instanceConfiguration = null;
        private static readonly object _locked = new object();
       

        private ConfigurationSingleton()
        {
        }

        public static ConfigurationSingleton Instance
        {
            get
            {
                lock (_locked)
                {
                    if (_instanceConfiguration == null)
                        _instanceConfiguration = new ConfigurationSingleton();

                    return _instanceConfiguration;
                }
            }
        }
      
        public IConfigurationRoot Configuration
        {
            get
            {
               
                return Startup.ConfigurationRoot;
            }
        }

        public string SQLConnectionString
        {
            get
            {
                return Configuration.GetConnectionString("MSSQLServer");
            }
        }

    }
}
