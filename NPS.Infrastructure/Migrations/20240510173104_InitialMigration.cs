using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NPS.Infrastructure.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Profiles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profiles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Questionnaires",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Question = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompanyId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questionnaires", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Questionnaires_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    ProfileId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Profiles_ProfileId",
                        column: x => x.ProfileId,
                        principalTable: "Profiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RulesQuestionnaire",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ScoreStart = table.Column<int>(type: "int", nullable: false),
                    ScoreEnd = table.Column<int>(type: "int", nullable: false),
                    Classification = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    QuestionnaireId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RulesQuestionnaire", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RulesQuestionnaire_Questionnaires_QuestionnaireId",
                        column: x => x.QuestionnaireId,
                        principalTable: "Questionnaires",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UsersQuestionnaires",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Score = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    QuestionnaireId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersQuestionnaires", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UsersQuestionnaires_Questionnaires_QuestionnaireId",
                        column: x => x.QuestionnaireId,
                        principalTable: "Questionnaires",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UsersQuestionnaires_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "Id", "CreatedDate", "Name" },
                values: new object[] { 1, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cibergestión" });

            migrationBuilder.InsertData(
                table: "Profiles",
                columns: new[] { "Id", "CreatedDate", "Description", "Name" },
                values: new object[] { 1, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Administrador del sitio", "Administrador" });

            migrationBuilder.InsertData(
                table: "Profiles",
                columns: new[] { "Id", "CreatedDate", "Description", "Name" },
                values: new object[] { 2, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Votante en el cuestionario", "Votante" });

            migrationBuilder.InsertData(
                table: "Questionnaires",
                columns: new[] { "Id", "CompanyId", "CreatedDate", "Name", "Question" },
                values: new object[] { 1, 1, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "NPS", "¿Cuán probable es que recomiende el producto o servicio a un familiar o amigo? Para ello se les pide calificar en una escala de 0 a 10, donde 0 es «Muy improbable» y 10 es «Definitivamente lo recomendaría»" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedDate", "Email", "FirstName", "LastName", "Password", "ProfileId" },
                values: new object[] { new Guid("086bc85a-3ad6-40ea-8354-c1124b09a60a"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "cgml02@hotmail.com", "Carlos", "Medina", "superadmin2024", 1 });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedDate", "Email", "FirstName", "LastName", "Password", "ProfileId" },
                values: new object[] { new Guid("434cfdf3-c7a3-4a59-8938-b52fe3eb29a9"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "test@hotmail.com", "Votante", "Prueba", "votante2024", 2 });

            migrationBuilder.InsertData(
                table: "RulesQuestionnaire",
                columns: new[] { "Id", "Classification", "CreatedDate", "QuestionnaireId", "ScoreEnd", "ScoreStart" },
                values: new object[] { 1, "Detractores", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 6, 0 });

            migrationBuilder.InsertData(
                table: "RulesQuestionnaire",
                columns: new[] { "Id", "Classification", "CreatedDate", "QuestionnaireId", "ScoreEnd", "ScoreStart" },
                values: new object[] { 2, "Neutros", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 8, 7 });

            migrationBuilder.InsertData(
                table: "RulesQuestionnaire",
                columns: new[] { "Id", "Classification", "CreatedDate", "QuestionnaireId", "ScoreEnd", "ScoreStart" },
                values: new object[] { 3, "Promotores", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 10, 9 });

            migrationBuilder.CreateIndex(
                name: "IX_Questionnaires_CompanyId",
                table: "Questionnaires",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_RulesQuestionnaire_QuestionnaireId",
                table: "RulesQuestionnaire",
                column: "QuestionnaireId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_ProfileId",
                table: "Users",
                column: "ProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_UsersQuestionnaires_QuestionnaireId",
                table: "UsersQuestionnaires",
                column: "QuestionnaireId");

            migrationBuilder.CreateIndex(
                name: "IX_UsersQuestionnaires_UserId",
                table: "UsersQuestionnaires",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RulesQuestionnaire");

            migrationBuilder.DropTable(
                name: "UsersQuestionnaires");

            migrationBuilder.DropTable(
                name: "Questionnaires");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Companies");

            migrationBuilder.DropTable(
                name: "Profiles");
        }
    }
}
