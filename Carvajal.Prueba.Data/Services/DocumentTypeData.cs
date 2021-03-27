using System.Collections.Generic;
using Carvajal.Prueba.Model.View;

namespace Carvajal.Prueba.Data.Services
{
    public class DocumentTypeData : DataServices<DocumentView>
    {
        public DocumentTypeData(Dictionary<string, string> parameter, string spName, string connectionString) : base(parameter, spName, connectionString)
        {

        }
    }
}