using System;
using System.Collections.Generic;
using Carvajal.Prueba.Data.Entity;
using Microsoft.EntityFrameworkCore;

namespace Carvajal.Prueba.Data.Config
{
    public class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<User> builder)
        {
            List<User> persons = new List<User>();
            persons.Add(new User() { Id = this.GetId(), Name = "Usuario1", LastName = "Apellido Usuario 1", PassWord = "123456", Mail = "usuario1@prueba.com.co", DocumentTypeId = 1 });
            persons.Add(new User() { Id = this.GetId(), Name = "Usuario2", LastName = "Apellido Usuario 2", PassWord = "123456", Mail = "usuario2@prueba.com.co", DocumentTypeId = 1 });
            persons.Add(new User() { Id = this.GetId(), Name = "Usuario3", LastName = "Apellido Usuario 3", PassWord = "123456", Mail = "usuario3@prueba.com.co", DocumentTypeId = 2 });
            persons.Add(new User() { Id = this.GetId(), Name = "Usuario4", LastName = "Apellido Usuario 4", PassWord = "123456", Mail = "usuario4@prueba.com.co", DocumentTypeId = 3 });
            builder.HasData(persons.ToArray());
            builder.Property(item => item.Id).ValueGeneratedOnAdd();
        }

        private string GetId()
        {
            return new Guid().ToString();
        }
    }
}