using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Carvajal.Prueba.Data.Interfaces;
using Carvajal.Prueba.Model.View;
using Dapper;

namespace Carvajal.Prueba.Data.Services
{
    public class DataServices<T> : IDataServices<T>
    {

        public Dictionary<string, string> Parameter { get; set; }
        public string SpName { get; set; }
        public string ConnectionString { get; set; }
        public DataServices(Dictionary<string, string> parameter, string spName, string connectionString)
        {
            this.Parameter = parameter;
            this.SpName = spName;
            this.ConnectionString = connectionString;
        }

        public string Execute()
        {
            DynamicParameters parameters = this.InicializeParameter(this.Parameter);
            using (var connection = new SqlConnection(this.ConnectionString))
            {
                connection.Open();
                int affectedRows = connection.Execute(this.SpName, parameters, commandType: CommandType.StoredProcedure);
                return affectedRows.ToString();
            }

        }

        public IEnumerable<T> Get()
        {
            using (IDbConnection db = new SqlConnection(this.ConnectionString))
            {
                var customer = db.Query<T>(this.SpName, this.Parameter);
                return customer;
            }
        }

        public IEnumerable<T> GetWithOutParameters()
        {
            using (IDbConnection db = new SqlConnection(this.ConnectionString))
            {
                var customer = db.Query<T>(this.SpName).ToList();
                return customer;
            }
        }

        public DynamicParameters InicializeParameter(Dictionary<string, string> parameters)
        {
            DynamicParameters parameter = new DynamicParameters();
            foreach (var item in parameters)
            {
                parameter.Add(item.Key, item.Value);

            }
            return parameter;
        }
    }
}