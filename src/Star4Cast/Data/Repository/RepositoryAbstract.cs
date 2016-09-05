using Microsoft.Extensions.Configuration;
using Star4Cast.Data.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Star4Cast.Data.Repository
{
    public class RepositoryAbstract
    {
        
        public SqlConnection SQLConnection
        {
            get
            {
                return new SqlConnection(ConfigurationSingleton.Instance.SQLConnectionString);
            }
        }
    }
}
