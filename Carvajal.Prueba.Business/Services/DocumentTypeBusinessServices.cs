using System.Collections.Generic;
using Carvajal.Prueba.Business.Interface;
using Carvajal.Prueba.Data.Services;
using Carvajal.Prueba.Helper.StoreProcedure;
using Carvajal.Prueba.Model.View;
using Microsoft.Extensions.Options;

namespace Carvajal.Prueba.Business.Services
{
    public class DocumentTypeBusinessServices : IDocumentTypeBusinessServices
    {
        private readonly Settings _appSettingsOptions;
        public DocumentTypeBusinessServices(IOptions<Settings> appSettingsOptions)
        {
            this._appSettingsOptions = appSettingsOptions.Value;
        }

        public string Add(DocumentView dataNew)
        {
            throw new System.NotImplementedException();
        }

        public string Delete(string dataId)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<DocumentView> Get(string dataId)
        {
            try
            {
                DocumentTypeData documents = new DocumentTypeData(new Dictionary<string, string>(), StoreProcedureName.GETDOCUMENTSTYPE, this._appSettingsOptions.ConnectionString);
                IEnumerable<DocumentView> response = documents.Get();
                return response;
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        public string Update(DocumentView dataUpdate)
        {
            throw new System.NotImplementedException();
        }
    }
}