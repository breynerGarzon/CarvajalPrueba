// <auto-generated />
using Carvajal.Prueba.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Carvajal.Prueba.MigrationSQLSERVER.Migrations
{
    [DbContext(typeof(CarvajalContext))]
    partial class CarvajalContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Carvajal.Prueba.Data.Entity.DocumentType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("PersonTypes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "CC"
                        },
                        new
                        {
                            Id = 2,
                            Name = "RC"
                        },
                        new
                        {
                            Id = 3,
                            Name = "TI"
                        },
                        new
                        {
                            Id = 4,
                            Name = "CE"
                        },
                        new
                        {
                            Id = 5,
                            Name = "PA"
                        });
                });

            modelBuilder.Entity("Carvajal.Prueba.Data.Entity.User", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("DocumentTypeId")
                        .HasColumnType("int");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Mail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PassWord")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DocumentTypeId");

                    b.ToTable("Persons");

                    b.HasData(
                        new
                        {
                            Id = "47ceeb16-1b6b-4cad-98cb-3e3689f84356",
                            DocumentTypeId = 1,
                            LastName = "Apellido Usuario 1",
                            Mail = "usuario1@prueba.com.co",
                            Name = "Usuario1",
                            PassWord = "123456"
                        },
                        new
                        {
                            Id = "f27980d9-9730-4486-91b3-af7334b71c8a",
                            DocumentTypeId = 1,
                            LastName = "Apellido Usuario 2",
                            Mail = "usuario2@prueba.com.co",
                            Name = "Usuario2",
                            PassWord = "123456"
                        },
                        new
                        {
                            Id = "f36c5295-d4d5-4ea6-80a9-94b9aec97dd2",
                            DocumentTypeId = 2,
                            LastName = "Apellido Usuario 3",
                            Mail = "usuario3@prueba.com.co",
                            Name = "Usuario3",
                            PassWord = "123456"
                        },
                        new
                        {
                            Id = "1b3f578f-cc7a-4d05-b480-57e420ac9add",
                            DocumentTypeId = 3,
                            LastName = "Apellido Usuario 4",
                            Mail = "usuario4@prueba.com.co",
                            Name = "Usuario4",
                            PassWord = "123456"
                        });
                });

            modelBuilder.Entity("Carvajal.Prueba.Data.Entity.User", b =>
                {
                    b.HasOne("Carvajal.Prueba.Data.Entity.DocumentType", "DocumentType")
                        .WithMany()
                        .HasForeignKey("DocumentTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
