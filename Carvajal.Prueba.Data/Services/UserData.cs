using System.Collections.Generic;
using Carvajal.Prueba.Model.View;

namespace Carvajal.Prueba.Data.Services
{
    public class UserData : DataServices<UserView>
    {
        public UserData(Dictionary<string, string> parameter, string spName, string connectionString) : base(parameter, spName, connectionString)
        {

        }
    }
}