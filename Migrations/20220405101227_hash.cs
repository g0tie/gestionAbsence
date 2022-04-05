using Microsoft.EntityFrameworkCore.Migrations;

namespace GestionAbsence.Migrations
{
    public partial class hash : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "$2a$12$rivNP/v.ZjCk7DBjXRwnGul/qj9K0o1I/CcINlciExHzsmRXP44ky");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "Password",
                value: "$2a$12$pdwsU.9o2FBMldRSY5krFO9TFZkBzRrBcQzsRAa/VcqzEFxemjCti");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "Password",
                value: "$2a$12$7UUfJmWvej5chZJlLmo8rOQRanoec2eKWIWgqM.MnZy227Br0naiu");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                column: "Password",
                value: "$2a$12$FhSwLlHPXK9LlJB4U1wxTuLYYkjSSMKV01k0PIaz8gVqFt49/c4vC");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "Admin");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "Password",
                value: "Formateur");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "Password",
                value: "Secretaire");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                column: "Password",
                value: "Apprenant");
        }
    }
}
