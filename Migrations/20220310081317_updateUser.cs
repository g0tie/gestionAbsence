using Microsoft.EntityFrameworkCore.Migrations;

namespace GestionAbsence.Migrations
{
    public partial class updateUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                column: "Libelle",
                value: "Secretaire");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Mail", "Nom", "Password", "Prenom", "RoleId" },
                values: new object[] { 1, "Admin@gmail.com", "Admin", "Admin", "Admin", 1 });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Mail", "Nom", "Password", "Prenom", "RoleId" },
                values: new object[] { 2, "Formateur@gmail.com", "Formateur", "Formateur", "Formateur", 2 });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Mail", "Nom", "Password", "Prenom", "RoleId" },
                values: new object[] { 3, "Secretaire@gmail.com", "Secretaire", "Secretaire", "Secretaire", 3 });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Mail", "Nom", "Password", "Prenom", "RoleId" },
                values: new object[] { 4, "Apprenant@gmail.com", "Apprenant", "Apprenant", "Apprenant", 4 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                column: "Libelle",
                value: "Secrétaire");
        }
    }
}
