using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Configuration;

using Npgsql;

namespace RIC.DB
{
    public class Connection
    {
        private int DBtimeOut = 300;
        public String connectionString = string.Empty;

        public Connection()
        {
            connectionString = GetConnString();

        }


        public static string GetConnString()
        {



            var uriString = "postgres://uvuujwyb:QzFyaIL_XQwNItThtkUlRSPc_GkDQ20M@isilo.db.elephantsql.com:5432/uvuujwyb";

            var uri = new Uri(uriString);
            var db = uri.AbsolutePath.Trim('/');
            var user = uri.UserInfo.Split(':')[0];
            var passwd = uri.UserInfo.Split(':')[1];
            var port = uri.Port > 0 ? uri.Port : 5432;
            var connStr = string.Format("Server={0};Port={4};Database={1};User Id={2};Password={3};",
                uri.Host, db, user, passwd, port);
            return connStr;
        }




        public DataTable LoadDatos(string query)
        {
            DataTable dt = new DataTable();

            try
            {
                using (var conn = new NpgsqlConnection(connectionString))
                {
     
                        //SqlCommand cmd = new SqlCommand(query, conn);
                        NpgsqlCommand cmd = new NpgsqlCommand();
                        cmd.CommandTimeout = DBtimeOut;
                        cmd.CommandType = CommandType.Text;
                        cmd.Connection = conn;
                        cmd.CommandText = query;

                        NpgsqlDataAdapter adap = new NpgsqlDataAdapter(cmd);
                        //cmd.Parameters.AddRange(param);
                        adap.Fill(dt);
                        cmd.Parameters.Clear();
 
                }
            }
            catch (Exception ex)
            {
                
                throw ex;

            }
            return dt;
        }


        public int InsertQuery(string query, NpgsqlParameter[] param)
        {
            int result = 0;
            NpgsqlConnection pgconnection = new NpgsqlConnection();
            NpgsqlCommand command = new NpgsqlCommand();

            try
            {
                pgconnection.ConnectionString = connectionString;

                if (pgconnection.State == ConnectionState.Closed)
                {
                    pgconnection.Open();
                }

                command.CommandTimeout = DBtimeOut;
                command.CommandType = CommandType.Text;
                command.Connection = pgconnection;
                command.Parameters.Clear();
                if (param != null)
                    command.Parameters.AddRange(param);
                
                
                    command.CommandText = query;
                    result = command.ExecuteNonQuery();
                

            }
            catch (Exception ex)
            {
                result = 0;
                throw ex;
            }
            finally
            {
                pgconnection.Close();
            }

            return result;
        }




    }
}
