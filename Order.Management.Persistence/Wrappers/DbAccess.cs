using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrderManagement.Persistence.Wrappers.Interfaces;

namespace OrderManagement.Persistence.Wrappers
{
    public class DbAccess : IDbAccess
    {
        private readonly string _connectionString;

        public DbAccess(string connectionString)
        {
            _connectionString = connectionString;
        }
    }
}
