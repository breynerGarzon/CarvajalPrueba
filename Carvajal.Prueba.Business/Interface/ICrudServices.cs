using System.Collections.Generic;

namespace Carvajal.Prueba.Business.Interface
{
    public interface ICrudServices<T>
    {
        string Add(T dataNew);
        string Update(T dataUpdate);
        string Delete(string dataId);
        IEnumerable<T> Get(string dataId);
    }
}