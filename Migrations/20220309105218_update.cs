using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GestionAbsence.Migrations
{
    public partial class update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Absences_Users_UserId",
                table: "Absences");

            migrationBuilder.DropForeignKey(
                name: "FK_Justificatits_Absences_AbsenceId",
                table: "Justificatits");

            migrationBuilder.DropForeignKey(
                name: "FK_Justificatits_Retards_RetardId",
                table: "Justificatits");

            migrationBuilder.DropTable(
                name: "Retards");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Justificatits",
                table: "Justificatits");

            migrationBuilder.DropIndex(
                name: "IX_Justificatits_RetardId",
                table: "Justificatits");

            migrationBuilder.DropColumn(
                name: "RetardId",
                table: "Justificatits");

            migrationBuilder.RenameTable(
                name: "Justificatits",
                newName: "Justificatifs");

            migrationBuilder.RenameIndex(
                name: "IX_Justificatits_AbsenceId",
                table: "Justificatifs",
                newName: "IX_Justificatifs_AbsenceId");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Absences",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Commentaire",
                table: "Absences",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Duree",
                table: "Absences",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsRetard",
                table: "Absences",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<int>(
                name: "AbsenceId",
                table: "Justificatifs",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Justificatifs",
                table: "Justificatifs",
                column: "Id");

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Libelle" },
                values: new object[] { 1, "Admin" });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Libelle" },
                values: new object[] { 2, "Formateur" });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Libelle" },
                values: new object[] { 3, "Secrétaire" });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Libelle" },
                values: new object[] { 4, "Apprenant" });

            migrationBuilder.AddForeignKey(
                name: "FK_Absences_Users_UserId",
                table: "Absences",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Justificatifs_Absences_AbsenceId",
                table: "Justificatifs",
                column: "AbsenceId",
                principalTable: "Absences",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Absences_Users_UserId",
                table: "Absences");

            migrationBuilder.DropForeignKey(
                name: "FK_Justificatifs_Absences_AbsenceId",
                table: "Justificatifs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Justificatifs",
                table: "Justificatifs");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DropColumn(
                name: "Commentaire",
                table: "Absences");

            migrationBuilder.DropColumn(
                name: "Duree",
                table: "Absences");

            migrationBuilder.DropColumn(
                name: "IsRetard",
                table: "Absences");

            migrationBuilder.RenameTable(
                name: "Justificatifs",
                newName: "Justificatits");

            migrationBuilder.RenameIndex(
                name: "IX_Justificatifs_AbsenceId",
                table: "Justificatits",
                newName: "IX_Justificatits_AbsenceId");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Absences",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<int>(
                name: "AbsenceId",
                table: "Justificatits",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddColumn<int>(
                name: "RetardId",
                table: "Justificatits",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Justificatits",
                table: "Justificatits",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Retards",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Date = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Duree = table.Column<int>(type: "INTEGER", nullable: false),
                    IsMatin = table.Column<bool>(type: "INTEGER", nullable: false),
                    UserId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Retards", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Retards_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Justificatits_RetardId",
                table: "Justificatits",
                column: "RetardId");

            migrationBuilder.CreateIndex(
                name: "IX_Retards_UserId",
                table: "Retards",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Absences_Users_UserId",
                table: "Absences",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Justificatits_Absences_AbsenceId",
                table: "Justificatits",
                column: "AbsenceId",
                principalTable: "Absences",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Justificatits_Retards_RetardId",
                table: "Justificatits",
                column: "RetardId",
                principalTable: "Retards",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
