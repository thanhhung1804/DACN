using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopApp.Database
{
    public interface IDatabase
    {
        void Connect();
        void Disconnect();
        bool IsConnected();
        DataTable ExecuteQuery(string query);
    }
}
