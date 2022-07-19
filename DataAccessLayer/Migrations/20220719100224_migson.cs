using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class migson : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Contacts",
                columns: table => new
                {
                    ContactId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContactDTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ContactName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactEMail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactSubject = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactMessage = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.ContactId);
                });
         
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
           
            migrationBuilder.DropTable(
                name: "Contacts");

        }
    }
}
