using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace PFE1.Migrations
{
    public partial class PFE : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "1", null });

            migrationBuilder.RenameColumn(
                name: "Username",
                table: "Personnel",
                newName: "Prenom");

            migrationBuilder.RenameColumn(
                name: "Password",
                table: "Personnel",
                newName: "Nom");

            migrationBuilder.RenameColumn(
                name: "idperso",
                table: "Personnel",
                newName: "Id");

            migrationBuilder.AddColumn<string>(
                name: "Adresse",
                table: "Personnel",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CIN",
                table: "Personnel",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Personnel",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Auth",
                columns: table => new
                {
                    iduser = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Username = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    Role = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Auth", x => x.iduser);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Auth");

            migrationBuilder.DropColumn(
                name: "Adresse",
                table: "Personnel");

            migrationBuilder.DropColumn(
                name: "CIN",
                table: "Personnel");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Personnel");

            migrationBuilder.RenameColumn(
                name: "Prenom",
                table: "Personnel",
                newName: "Username");

            migrationBuilder.RenameColumn(
                name: "Nom",
                table: "Personnel",
                newName: "Password");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Personnel",
                newName: "idperso");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "1", null, "Personnel", "Personnel" });
        }
    }
}
