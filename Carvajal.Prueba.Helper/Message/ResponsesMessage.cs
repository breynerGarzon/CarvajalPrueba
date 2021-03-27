namespace Carvajal.Prueba.Helper.Message
{
    public static class ResponsesMessage
    {
        public static readonly string NewUserOk = "Usuario creado exitosamente";
        public static readonly string NewUserError = "Se genero un error al registrar el usuario, es probable que el número de documento o mail ya esten registrados";
        public static readonly string DeleteUserOk = "Usuario eliminado exitosamente";
        public static readonly string DeleteUserError = "Se genero un error al eliminar el usuario, es probable que el número de documento no este registrado";
        public static readonly string UpdateUserOk = "Usuario actualizado exitosamente";
        public static readonly string UpdateUserError = "Se genero un error al actualizar el usuario";
    }
}