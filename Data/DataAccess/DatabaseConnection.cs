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
        public static string GetConnectionString()
        {
            return "Host=localhost;Port=5432;Username=postgres;Password=Qwertyui;Database=KyotoDesk";
        }
    }
}
