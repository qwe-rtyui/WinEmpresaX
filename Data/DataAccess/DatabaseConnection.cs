using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using System.IO;

namespace WinFormsKyotoDesk.Data.DataAccess
{
    internal class DatabaseConnection
    {
        private static string _connectionString = "Host=localhost;Port=5432;Username=;Password=;Database=KyotoDesk";
        public static string GetConnectionString()
        {
            
            return _connectionString;
        }
    }
}
