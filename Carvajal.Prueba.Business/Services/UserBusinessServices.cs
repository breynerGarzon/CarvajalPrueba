using System.Collections.Generic;
using Carvajal.Prueba.Business.Interface;
using Carvajal.Prueba.Data.Services;
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
            }
            catch (System.Exception)
            {

                throw;
            }
            // newUSer.Execute();
            throw new System.NotImplementedException();
        }

        public string Delete(string userId)
        {
            try
            {
                Dictionary<string, string> dataUser = ValidateNewUserView.GetDataStructureDeleteUSer(userId);
                UserData newUSer = new UserData(dataUser, StoreProcedureName.DELETEUSER, this._appSettingsOptions.ConnectionString);
                string response = newUSer.Execute();
            }
            catch (System.Exception)
            {

                throw;
            }
            throw new System.NotImplementedException();
        }

        public IEnumerable<UserView> Get(string userId)
        {
            try
            {
                Dictionary<string, string> dataUser = ValidateNewUserView.GetDataStructureBase(userId);
                string query = ValidateNewUserView.ValidateQueryUser(userId);
                UserData newUSer = new UserData(dataUser, query, this._appSettingsOptions.ConnectionString);
                IEnumerable<UserView> response = newUSer.Get();
                return response;
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        public string Update(UserView newUser)
        {
            try
            {
                Dictionary<string, string> dataUser = ValidateNewUserView.GetDataStructureUpdateUSer(newUser);
                UserData updateUSer = new UserData(dataUser, StoreProcedureName.UPDATEUSER, this._appSettingsOptions.ConnectionString);
                string response = updateUSer.Execute();
                return response;
            }
            catch (System.Exception)
            {

                throw;
            }
        }
    }
}