using Carvajal.Prueba.Helper.StoreProcedure;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Carvajal.Prueba.MigrationSQLSERVER.Migrations
{
    public partial class CreacionBd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PersonTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Persons",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    PassWord = table.Column<string>(nullable: true),
                    Mail = table.Column<string>(nullable: true),
                    DocumentTypeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Persons_PersonTypes_DocumentTypeId",
                        column: x => x.DocumentTypeId,
                        principalTable: "PersonTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "PersonTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "CC" },
                    { 2, "RC" },
                    { 3, "TI" },
                    { 4, "CE" },
                    { 5, "PA" }
                });

            migrationBuilder.InsertData(
                table: "Persons",
                columns: new[] { "Id", "DocumentTypeId", "LastName", "Mail", "Name", "PassWord" },
                values: new object[,]
                {
                    { "47ceeb16-1b6b-4cad-98cb-3e3689f84356", 1, "Apellido Usuario 1", "usuario1@prueba.com.co", "Usuario1", "123456" },
                    { "f27980d9-9730-4486-91b3-af7334b71c8a", 1, "Apellido Usuario 2", "usuario2@prueba.com.co", "Usuario2", "123456" },
                    { "f36c5295-d4d5-4ea6-80a9-94b9aec97dd2", 2, "Apellido Usuario 3", "usuario3@prueba.com.co", "Usuario3", "123456" },
                    { "1b3f578f-cc7a-4d05-b480-57e420ac9add", 3, "Apellido Usuario 4", "usuario4@prueba.com.co", "Usuario4", "123456" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Persons_DocumentTypeId",
                table: "Persons",
                column: "DocumentTypeId");

            migrationBuilder.Sql($"{Definitions.QUERY_CREATE_SP_CREATEUSER}");
            migrationBuilder.Sql($"{Definitions.QUERY_CREATE_SP_UPDATEUSER}");
            migrationBuilder.Sql($"{Definitions.QUERY_CREATE_SP_DELETEUSER}");
            migrationBuilder.Sql($"{Definitions.QUERY_CREATE_SP_GETUSER}");
            
            migrationBuilder.Sql($"{Definitions.QUERY_CREATE_SP_GETDOCUMENTTYPE}");



        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Persons");

            migrationBuilder.DropTable(
                name: "PersonTypes");
        }
    }
}
