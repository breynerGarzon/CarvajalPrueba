using System;
using System.Collections.Generic;
using Carvajal.Prueba.Helper.StoreProcedure;
using Carvajal.Prueba.Model.View;

namespace Carvajal.Prueba.Helper.Validation
{
    public static class ValidateNewUserView
    {
        public static Dictionary<string, string> GetDataStructureNewUSer(UserView userData)
        {
            Dictionary<string, string> newData = new Dictionary<string, string>();
            newData.Add("DocumentNumber", userData.DocumentNumber);
            newData.Add("Names", userData.Name);
            newData.Add("LastNames", userData.LastName);
            newData.Add("Password", userData.Password);
            newData.Add("Mail", userData.Mail);
            newData.Add("DocumentType", userData.DocumentType.ToString());
            return newData;
        }

        public static Dictionary<string, string> GetDataStructureUpdateUSer(UserView userData)
        {
            Dictionary<string, string> newData = new Dictionary<string, string>();
            newData.Add("DocumentNumber", userData.DocumentNumber);
            newData.Add("Names", userData.Name);
            newData.Add("LastNames", userData.LastName);
            newData.Add("Password", userData.Password);
            newData.Add("Mail", userData.Mail);
            newData.Add("DocumentType", userData.DocumentType.ToString());
            return newData;
        }

        public static Dictionary<string, string> GetDataStructureDeleteUSer(string userId)
        {
            Dictionary<string, string> newData = new Dictionary<string, string>();
            newData.Add("DocumentNumber", userId);
            return newData;
        }
        public static Dictionary<string, string> GetDataStructureBase(string userId)
        {
            Dictionary<string, string> newData = new Dictionary<string, string>();
            newData.Add("DocumentNumber", userId);
            return newData;
        }

        public static Dictionary<string, string> GetDataStructureLogIn(LoginView dataLog)
        {
            Dictionary<string, string> newData = new Dictionary<string, string>();
            newData.Add("userName", dataLog.Email);
            newData.Add("PassWord", dataLog.Password);
            return newData;
        }



        public static string ValidateQueryUser(string parameter)
        {
            if (!string.IsNullOrEmpty(parameter))
            {
                return StoreProcedureName.GETUSER;
            }
            return StoreProcedureName.GETUSERS;
        }
    }
}