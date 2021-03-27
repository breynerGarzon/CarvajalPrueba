using System.Collections.Generic;
using Carvajal.Prueba.Model.View;

namespace Carvajal.Prueba.Data.Services
{
    public class LoginData: DataServices<LoginView>
    {
        public LoginData(Dictionary<string, string> parameter, string spName, string connectionString) : base(parameter, spName, connectionString)
        {

        }
        
    }
}