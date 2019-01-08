using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DAL
{
    public class DBUtils
    {
        public SqlConnection connection;

        public DBUtils()
        {
            //string strConnection = ConfigurationManager.ConnectionStrings["strConnection"].ToString();
            string strConnection = "Server=JMT;Database=BookShareProject;User Id=sa;Password=sa";
            connection = new SqlConnection(strConnection);
        }
    }
}
