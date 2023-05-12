using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopApp.Database
{
    public class SqlServerDatabase : Database
    {
        public SqlServerDatabase(string connectionString) : base(connectionString)
        {
        }
    }
}
