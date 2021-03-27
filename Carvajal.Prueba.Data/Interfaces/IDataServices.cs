using System.Collections.Generic;
using Dapper;

namespace Carvajal.Prueba.Data.Interfaces
{
    public interface IDataServices<T>
    {
        string Execute();
        IEnumerable<T> Get();
        IEnumerable<T> GetWithOutParameters();
        DynamicParameters InicializeParameter(Dictionary<string, string> parameter);
    }
}