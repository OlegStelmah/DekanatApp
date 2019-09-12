using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DekanatApp.Helpers
{
    public static class DatabaseHelper
    {
        public static List<T> ExecuteStoredProcedure<T>(this DbContext context, string name, List<SqlParameter> parameters)
        {
            try
            {
                var cmd = context.Database.GetDbConnection().CreateCommand();

                cmd.CommandText = $"fedirpetrenko.[{name}]";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 60;
                cmd.Parameters.AddRange(parameters.ToArray());
                if (cmd.Connection.State != ConnectionState.Open)
                {
                    cmd.Connection.Open();
                }

                var result = new List<T>();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var obj = (T)Activator.CreateInstance(typeof(T));
                    var properties = obj.GetType().GetProperties();
                    foreach (var propertyInfo in properties)
                    {
                        propertyInfo.SetValue(obj, reader[propertyInfo.Name]);
                    }
                    result.Add(obj);
                }
                return result;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                throw;
            }
        }

        public static async Task<List<T>> ExecuteStoredProcedureAsync<T>(this DbContext context, string name, List<SqlParameter> parameters)
        {
            var cmd = context.Database.GetDbConnection().CreateCommand();
            try
            {
                cmd.CommandText = $"fedirpetrenko.[{name}]";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 60;
                cmd.Parameters.AddRange(parameters.ToArray());
                if (cmd.Connection.State != ConnectionState.Open)
                {
                    await cmd.Connection.OpenAsync();
                }

                var result = new List<T>();
                var reader = await cmd.ExecuteReaderAsync();
                while (await reader.ReadAsync())
                {
                    var obj = (T)Activator.CreateInstance(typeof(T));
                    var properties = obj.GetType().GetProperties();
                    foreach (var propertyInfo in properties)
                    {
                        if (reader[propertyInfo.Name] is DBNull)
                            propertyInfo.SetValue(obj, GetDefaultValue(propertyInfo.PropertyType));
                        else
                            propertyInfo.SetValue(obj, reader[propertyInfo.Name]);
                    }
                    result.Add(obj);
                }
                return result;
            }
            finally
            {
                cmd.Connection.Close();
            }
        }

        public static async Task<List<T>> ExecuteStoredProcedureAsync<T>(this DbContext context, string name, SqlParameter parameter)
        {
            return await ExecuteStoredProcedureAsync<T>(context, name, new List<SqlParameter>() { parameter });
        }

        public static async Task<T> ExecuteScalarFunction<T>(this DbContext context, string name, SqlParameter parameter)
        {
            var cmd = context.Database.GetDbConnection().CreateCommand();
            try
            {
                cmd.CommandText = $"SELECT fedirpetrenko.[{name}] ( {parameter.ParameterName})";
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add(parameter);

                if (cmd.Connection.State != ConnectionState.Open)
                {
                    await cmd.Connection.OpenAsync();
                }

                var dbResult = await cmd.ExecuteScalarAsync();
                var result = (T)dbResult;
                return result;
            }
            finally
            {
                cmd.Connection.Close();
            } 
        }

        private static object GetDefaultValue(Type t)
        {
            if (t.IsValueType)
                return Activator.CreateInstance(t);

            return null;
        }
    }
}
