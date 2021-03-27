namespace Carvajal.Prueba.Data.Entity
{
    public class User
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string PassWord { get; set; }
        public string Mail { get; set; }
        public int DocumentTypeId { get; set; }
        public DocumentType DocumentType { get; set; }
    }
}