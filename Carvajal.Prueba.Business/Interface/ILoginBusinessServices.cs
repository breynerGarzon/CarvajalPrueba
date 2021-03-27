using Carvajal.Prueba.Model.View;

namespace Carvajal.Prueba.Business.Interface
{
    public interface ILoginBusinessServices
    {
        LoginReponseView LogIn(LoginView dataLog);
    }
}