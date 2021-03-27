using System.Collections.Generic;
using System.Linq;
using Carvajal.Prueba.Business.Interface;
using Carvajal.Prueba.Business.Services;
using Carvajal.Prueba.Helper.Message;
using Carvajal.Prueba.Model.View;
using Microsoft.Extensions.Options;
using Xunit;

namespace Carvajal.Prueba.Test.TestByCRUDUSER
{
    public class CrudUserTest
    {
        public IOptions<Settings> Options { get; set; }

        public void InicializeOptions()
        {
            var appSettings = new Settings() { ConnectionString = "Data Source=NOMBRESERVIDOR;Initial Catalog=Carvajal.Prueba;Integrated Security=False;User ID=USUARIOBD;Password=CONTRASEÑA_BD;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False" };
            Options = Microsoft.Extensions.Options.Options.Create(appSettings);
        }
        [Theory]
        [InlineData("123456", "Usuario 5", "Apellido 5", 1, "123456", "breyner@1234567", 1)]
        [InlineData("123457", "Usuario 5", "Apellido 5", 1, "123456", "breyner@12345678", 1)]
        [InlineData("123458", "Usuario 5", "Apellido 5", 1, "123456", "breyner@1234569", 1)]
        [InlineData("1234589", "Usuario 5", "Apellido 5", 1, "123456", "breyner@1234569", 2)]
        public void CreateUser(string documentNumber, string name, string lastName, int documentType, string password, string mail, int expected)
        {
            string value = expected == 1 ? ResponsesMessage.NewUserOk : ResponsesMessage.NewUserError;
            this.InicializeOptions();
            UserView newUser = new UserView()
            {
                DocumentNumber = documentNumber,
                Name = name,
                LastName = lastName,
                DocumentType = documentType,
                Password = password,
                Mail = mail
            };
            IUserBusinessServices services = new UserBusinessServices(Options);
            string response = services.Add(newUser);
            Assert.True(response.Equals(value));

        }


        [Theory]
        [InlineData("123456", 1)]
        [InlineData("123457", 1)]
        [InlineData("123458", 1)]
        [InlineData("Usuario 7", 2)]
        public void DeleteUser(string documentNumber, int expected)
        {
            string value = expected == 1 ? ResponsesMessage.DeleteUserOk : ResponsesMessage.DeleteUserError;
            this.InicializeOptions();
            IUserBusinessServices services = new UserBusinessServices(Options);
            string response = services.Delete(documentNumber);
            Assert.True(response.Equals(value));
        }

        [Theory]
        [InlineData("123456", "Usuario 66", "Apellido 666", 1, "123456", "breyner@1234567", 1)]
        [InlineData("123457", "Usuario 77", "Apellido 777", 1, "123456", "breyner@12345678", 1)]
        [InlineData("123458", "Usuario 88", "Apellido 888", 1, "123456", "breyner@1234569", 1)]
        [InlineData("1234589", "Usuario 99", "Apellido 999", 1, "123456", "breyner@1234569", 2)]
        public void UpdateUser(string documentNumber, string name, string lastName, int documentType, string password, string mail, int expected)
        {
            string value = expected == 1 ? ResponsesMessage.UpdateUserOk : ResponsesMessage.UpdateUserError;
            this.InicializeOptions();
            UserView newUser = new UserView()
            {
                DocumentNumber = documentNumber,
                Name = name,
                LastName = lastName,
                DocumentType = documentType,
                Password = password,
                Mail = mail
            };
            IUserBusinessServices services = new UserBusinessServices(Options);
            string response = services.Update(newUser);
            Assert.True(response.Equals(value));
        }

        [Fact]
        public void GetUsers()
        {
            this.InicializeOptions();
            IUserBusinessServices services = new UserBusinessServices(Options);
            IEnumerable<UserView> response = services.Get("");
            Assert.True(response.Count() > 0);
        }

        [Theory]
        [InlineData("123456", 1)]
        [InlineData("123457", 1)]
        [InlineData("100", 1)]
        public void GetUser(string userId, int expected)
        {
            this.InicializeOptions();
            IUserBusinessServices services = new UserBusinessServices(Options);
            IEnumerable<UserView> response = services.Get(userId);
            Assert.True(response.Count() == expected);
        }
    }
}