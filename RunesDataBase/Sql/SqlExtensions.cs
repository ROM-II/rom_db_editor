using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace RunesDataBase.Sql
{
    internal static class SqlExtensions
    {
        public static void RunCommand(this SqlConnection con, SqlCommand command)
        {
            if (con.State != ConnectionState.Open)
            {
                con.Open();
            }
            command.Connection = con;
            command.ExecuteNonQuery();
        }
        public static void RunCommand(this SqlConnection con, Func<SqlCommand> builder)
        {
            using (var command = builder())
                con.RunCommand(command);
        }
        public static void RunCommand(this SqlConnection con, string command)
        {
            con.RunCommand(() => new SqlCommand(command));
        }
        public static void RunCommand(this SqlConnection con, string command, IDictionary<string, object> parameters)
        {
            con.RunCommand(() =>
            {
                var cmd = new SqlCommand(command);
                foreach (var parameter in parameters)
                {
                    cmd.Parameters.AddWithValue(parameter.Key, parameter.Value);
                }
                return cmd;
            });
        }
    }
}
