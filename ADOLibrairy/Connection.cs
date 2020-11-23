using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace ADOLibrairy
{
    public class Connection
    {
        internal string connectionString { get; set; }

        public Connection(string ConnectionString)
        {
            connectionString = ConnectionString;
        }

        private SqlConnection CreateConnection()
        {
            SqlConnection c = new SqlConnection();
            c.ConnectionString = connectionString;
            return c;
        }

        public SqlCommand CreateCommand(Command cmd, SqlConnection connection)
        {
            SqlCommand SqlCmd = connection.CreateCommand();
            SqlCmd.CommandText = cmd.Query;
            SqlCmd.CommandType = cmd.IsStoredProcedure ? CommandType.StoredProcedure : CommandType.Text;

            if (cmd.Parameters != null)
            {
                foreach (KeyValuePair<string, object> param in cmd.Parameters)
                {
                    SqlParameter parameter = SqlCmd.CreateParameter();
                    parameter.ParameterName = param.Key;
                    parameter.Value = param.Value;

                    SqlCmd.Parameters.Add(parameter);
                }
            }
            return SqlCmd;
        }

        public object ExecuteScalar(Command cmd)
        {
            using (SqlConnection c = CreateConnection())
            {
                using (SqlCommand Sqlcmd = CreateCommand(cmd, c))
                {
                    c.Open();
                    object t = Sqlcmd.ExecuteScalar();

                    return (t is DBNull) ? null : t;
                }
            }
        }

        public int ExecuteNonQuery(Command cmd)
        {
            using (SqlConnection c = CreateConnection())
            {
                using (SqlCommand Sqlcmd = CreateCommand(cmd, c))
                {
                    c.Open();
                    return Sqlcmd.ExecuteNonQuery();
                }
            }
        }

        public DataSet GetDataTable(Command cmd)
        {
            using (SqlConnection c = CreateConnection())
            {
                using (SqlCommand Sqlcmd = CreateCommand(cmd, c))
                {
                    SqlDataAdapter da = new SqlDataAdapter();
                    da.SelectCommand = Sqlcmd;
                    DataSet dt = new DataSet();
                    da.Fill(dt);
                    return dt;
                }
            }
        }

        public IEnumerable<T> ExecuteReader<T>(Command Command, Func<SqlDataReader, T> converter)
        {
            using (SqlConnection c = CreateConnection())
            {
                using (SqlCommand SqlCmd = CreateCommand(Command, c))
                {
                    c.Open();
                    using (SqlDataReader dr = SqlCmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            yield return converter(dr);
                        }
                    }
                }
            }
        }
    }
}
