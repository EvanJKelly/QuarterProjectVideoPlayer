using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using QuatorProjectVIdeoPlayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuatorProjectVIdeoPlayer
{
    /// <summary>
    /// Gets connection to database
    /// </summary>
    public class DBHelper
    {
       
            public static SqlConnection GetConnection()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"Data Source = (localdb)\MSSQLLocalDB; Initial Catalog = VideoPlayerDB; Integrated Security = True; Connect Timeout = 30; Encrypt = False; TrustServerCertificate = False; ApplicationIntent = ReadWrite; MultiSubnetFailover = False";
            return con;
        }
    }
}
