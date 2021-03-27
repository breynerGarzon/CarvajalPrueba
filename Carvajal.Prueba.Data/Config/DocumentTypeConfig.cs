using System.Collections.Generic;
using Carvajal.Prueba.Data.Entity;
using Microsoft.EntityFrameworkCore;

namespace Carvajal.Prueba.Data.Config
{
    public class DocumentTypeConfig : IEntityTypeConfiguration<DocumentType>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<DocumentType> builder)
        {
            List<DocumentType> documentsTypes = new List<DocumentType>();
            documentsTypes.Add(new DocumentType() { Id = 1, Name = "CC"});
            documentsTypes.Add(new DocumentType() { Id = 2, Name = "RC"});
            documentsTypes.Add(new DocumentType() { Id = 3, Name = "TI"});
            documentsTypes.Add(new DocumentType() { Id = 4, Name = "CE"});
            documentsTypes.Add(new DocumentType() { Id = 5, Name = "PA"});
            builder.HasData(documentsTypes.ToArray());
            builder.Property(item => item.Id).ValueGeneratedOnAdd();
        }
    }
}