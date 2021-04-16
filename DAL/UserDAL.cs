using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace DAL
{
    public class UserDAL
    {
        private readonly IConfiguration _configuration;
        private readonly string _strConn;
        private const string __DEFAULT_CONN = "EzTrade";
        private readonly SqlConnection _sqlConnection;

        public UserDAL(IConfiguration configuration)
        {
            configuration = _configuration;
            _strConn = configuration.GetConnectionString(__DEFAULT_CONN);
            _sqlConnection = new SqlConnection(_strConn);
        }
    }
}
