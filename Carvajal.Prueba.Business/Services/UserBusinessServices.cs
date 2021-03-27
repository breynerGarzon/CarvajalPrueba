using System.Collections.Generic;
using Carvajal.Prueba.Business.Interface;
using Carvajal.Prueba.Data.Services;
using Carvajal.Prueba.Helper.Message;
using Carvajal.Prueba.Helper.StoreProcedure;
using Carvajal.Prueba.Helper.Validation;
using Carvajal.Prueba.Model.View;
using Microsoft.Extensions.Options;

namespace Carvajal.Prueba.Business.Services
{
    public class UserBusinessServices : IUserBusinessServices
    {
        private readonly Settings _appSettingsOptions;
        public UserBusinessServices(IOptions<Settings> appSettingsOptions)
        {
            this._appSettingsOptions = appSettingsOptions.Value;

        }
        public string Add(UserView newUser)
        {
            try
            {
                Dictionary<string, string> dataUser = ValidateNewUserView.GetDataStructureNewUSer(newUser);
                UserData newUSer = new UserData(dataUser, StoreProcedureName.ADDUSER, this._appSettingsOptions.ConnectionString);
                string response = newUSer.Execute();
                if (response.Equals("1"))
                {
                    return ResponsesMessage.NewUserOk;
                }
                else
                {
                    return ResponsesMessage.NewUserError;
                }
            }
            catch (System.Exception ex)
            {
                throw new System.Exception("Se genero un error al agregar el usuario, por favor valide la cadena de conexión o intente nuevamente");
            }
        }

        public string Delete(string userId)
        {
            try
            {
                Dictionary<string, string> dataUser = ValidateNewUserView.GetDataStructureDeleteUSer(userId);
                UserData newUSer = new UserData(dataUser, StoreProcedureName.DELETEUSER, this._appSettingsOptions.ConnectionString);
                string response = newUSer.Execute();
                if (response.Equals("1"))
                {
                    return ResponsesMessage.DeleteUserOk;
                }
                else
                {
                    return ResponsesMessage.DeleteUserError;
                }
            }
            catch (System.Exception ex)
            {
                throw new System.Exception("Se genero un error al eliminar el usuario, por favor valide la cadena de conexión o intente nuevamente");
            }
        }

        public IEnumerable<UserView> Get(string userId)
        {
            try
            {
                Dictionary<string, string> dataUser = ValidateNewUserView.GetDataStructureBase(userId);
                string query = ValidateNewUserView.ValidateQueryUser(userId);
                UserData newUSer = new UserData(dataUser, query, this._appSettingsOptions.ConnectionString);
                IEnumerable<UserView> response = string.IsNullOrEmpty(userId) ? newUSer.GetWithOutParameters() : newUSer.Get();
                return response;
            }
            catch (System.Exception ex)
            {
                throw new System.Exception("Se genero un error al consultar los usuarios, por favor valide la cadena de conexión o intente nuevamente");
            }
        }

        public string Update(UserView newUser)
        {
            try
            {
                Dictionary<string, string> dataUser = ValidateNewUserView.GetDataStructureUpdateUSer(newUser);
                UserData updateUSer = new UserData(dataUser, StoreProcedureName.UPDATEUSER, this._appSettingsOptions.ConnectionString);
                string response = updateUSer.Execute();
                if (response.Equals("1"))
                {
                    return ResponsesMessage.UpdateUserOk;
                }
                else
                {
                    return ResponsesMessage.UpdateUserError;
                }
            }
            catch (System.Exception ex)
            {
                throw new System.Exception("Se genero un error al actualizar el usuario, por favor valide la cadena de conexión o intente nuevamente");
            }
        }
    }
}