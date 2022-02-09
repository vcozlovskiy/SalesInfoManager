using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace SailsInfoManager.SalesInfoManager
{
    public class Settings
    {
        public string connectionString { get; protected set; }
        public string targetPath { get; protected set; }
        public string soursePath { get; protected set; }
        public Settings()
        {
            connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            targetPath = ConfigurationManager.AppSettings["TargetPath"];
            soursePath = ConfigurationManager.AppSettings["SourcePath"];
        }
    }
}
