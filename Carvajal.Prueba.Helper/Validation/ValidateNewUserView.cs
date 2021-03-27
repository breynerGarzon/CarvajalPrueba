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
            newData.Add("", "");
            newData.Add("Name", userData.Name);
            newData.Add("LastName", userData.Password);
            newData.Add("Mail", userData.Name);
            newData.Add("DocumentTypeId", userData.Name);
            return newData;
        }

        public static Dictionary<string, string> GetDataStructureUpdateUSer(UserView userData)
        {
            Dictionary<string, string> newData = new Dictionary<string, string>();
            newData.Add("", "");
            newData.Add("Name", userData.Name);
            newData.Add("LastName", userData.Password);
            newData.Add("Mail", userData.Name);
            newData.Add("DocumentTypeId", userData.Name);
            return newData;
        }

        public static Dictionary<string, string> GetDataStructureDeleteUSer(string userId)
        {
            Dictionary<string, string> newData = GetDataStructureBase(userId);
            return newData;
        }
        public static Dictionary<string, string> GetDataStructureBase(string userId)
        {
            Dictionary<string, string> newData = new Dictionary<string, string>();
            newData.Add("UserId", userId);
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