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
            using (IDbConnection db = new SqlConnection(this.ConnectionString))
            {
                var customer = db.Query<UserView>(this.SpName, this.Parameter).ToString();
                return customer;
            }
        }

        public IEnumerable<T> Get()
        {
            List<T> users = new List<T>();
            using (IDbConnection db = new SqlConnection(this.ConnectionString))
            {
                var customer = db.Query<T>(this.SpName, this.Parameter).ToList();
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