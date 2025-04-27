using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BTL_GK.Views
{
    internal class Connection
    {
        private static string strCon = @"Data Source=DESKTOP-82BTP3O\DUCLONG;Initial Catalog=QLBHTBDT;Integrated Security=True;";

        public static SqlConnection MoKetNoi()
        {
            SqlConnection sqlCon = new SqlConnection(strCon);
            if (sqlCon.State == System.Data.ConnectionState.Closed) sqlCon.Open();
            return sqlCon;
        }

        public static void DongKetNoi(SqlConnection sqlCon )
        {
            if(sqlCon.State==System.Data.ConnectionState.Open) sqlCon.Close();
            
        }



    }
}
