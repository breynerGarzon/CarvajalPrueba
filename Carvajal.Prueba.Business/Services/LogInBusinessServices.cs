using System.Collections.Generic;
using Carvajal.Prueba.Business.Interface;
using Carvajal.Prueba.Data.Services;
using Carvajal.Prueba.Helper.StoreProcedure;
using Carvajal.Prueba.Helper.Validation;
using Carvajal.Prueba.Model.View;
using Microsoft.Extensions.Options;

namespace Carvajal.Prueba.Business.Services
{
    public class LogInBusinessServices : ILoginBusinessServices
    {
        private readonly Settings _appSettingsOptions;
        public LogInBusinessServices(IOptions<Settings> appSettingsOptions)
        {
            this._appSettingsOptions = appSettingsOptions.Value;

        }
        public LoginReponseView LogIn(LoginView dataLog)
        {
            try
            {
                Dictionary<string, string> dataUser = ValidateNewUserView.GetDataStructureLogIn(dataLog);
                LoginData newUSer = new LoginData(dataUser, StoreProcedureName.LOGIN, this._appSettingsOptions.ConnectionString);
                int response = int.Parse(newUSer.Execute());
                if (response > 0)
                {
                    return new LoginReponseView() { Status = true };
                }
                return new LoginReponseView() { Status = false, Description = "Las credenciales suministradas son inválidas." };
            }
            catch (System.Exception)
            {

                throw;
            }
        }
    }
}