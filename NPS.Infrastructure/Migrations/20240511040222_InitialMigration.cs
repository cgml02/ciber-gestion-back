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
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    createdDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Profiles",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    description = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    createdDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profiles", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Questionnaires",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    question = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    companyId = table.Column<int>(type: "int", nullable: false),
                    createdDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questionnaires", x => x.id);
                    table.ForeignKey(
                        name: "FK_Questionnaires_Companies_companyId",
                        column: x => x.companyId,
                        principalTable: "Companies",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    firstName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    lastName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    email = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    password = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    profileId = table.Column<int>(type: "int", nullable: false),
                    createdDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.id);
                    table.ForeignKey(
                        name: "FK_Users_Profiles_profileId",
                        column: x => x.profileId,
                        principalTable: "Profiles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RulesQuestionnaire",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    scoreStart = table.Column<int>(type: "int", nullable: false),
                    scoreEnd = table.Column<int>(type: "int", nullable: false),
                    classification = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    questionnaireId = table.Column<int>(type: "int", nullable: false),
                    createdDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RulesQuestionnaire", x => x.id);
                    table.ForeignKey(
                        name: "FK_RulesQuestionnaire_Questionnaires_questionnaireId",
                        column: x => x.questionnaireId,
                        principalTable: "Questionnaires",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UsersQuestionnaires",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    score = table.Column<int>(type: "int", nullable: false),
                    userId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    questionnaireId = table.Column<int>(type: "int", nullable: false),
                    createdDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersQuestionnaires", x => x.id);
                    table.ForeignKey(
                        name: "FK_UsersQuestionnaires_Questionnaires_questionnaireId",
                        column: x => x.questionnaireId,
                        principalTable: "Questionnaires",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UsersQuestionnaires_Users_userId",
                        column: x => x.userId,
                        principalTable: "Users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "id", "createdDate", "name" },
                values: new object[] { 1, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cibergestión" });

            migrationBuilder.InsertData(
                table: "Profiles",
                columns: new[] { "id", "createdDate", "description", "name" },
                values: new object[] { 1, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Administrador del sitio", "Administrador" });

            migrationBuilder.InsertData(
                table: "Profiles",
                columns: new[] { "id", "createdDate", "description", "name" },
                values: new object[] { 2, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Votante en el cuestionario", "Votante" });

            migrationBuilder.InsertData(
                table: "Questionnaires",
                columns: new[] { "id", "companyId", "createdDate", "name", "question" },
                values: new object[] { 1, 1, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "NPS", "¿Cuán probable es que recomiende el producto o servicio a un familiar o amigo? Para ello se les pide calificar en una escala de 0 a 10, donde 0 es «Muy improbable» y 10 es «Definitivamente lo recomendaría»" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "id", "createdDate", "email", "firstName", "lastName", "password", "profileId" },
                values: new object[] { new Guid("9cd0a824-21f4-4a48-b06a-76439283d707"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "test@hotmail.com", "Votante", "Prueba", "3AseC+IKT6jv9tj2OauK6I+M3OvzJOK2JGGk5ajBvBlrNkXk", 2 });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "id", "createdDate", "email", "firstName", "lastName", "password", "profileId" },
                values: new object[] { new Guid("e62021e7-3e99-423b-a367-232a1483b11f"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "cgml02@hotmail.com", "Carlos", "Medina", "uH/y/Lr+GZjtUuJuhg1os6THungwxmTxYnLasuzhxq9obhaC", 1 });

            migrationBuilder.InsertData(
                table: "RulesQuestionnaire",
                columns: new[] { "id", "classification", "createdDate", "questionnaireId", "scoreEnd", "scoreStart" },
                values: new object[] { 1, "Detractores", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 6, 0 });

            migrationBuilder.InsertData(
                table: "RulesQuestionnaire",
                columns: new[] { "id", "classification", "createdDate", "questionnaireId", "scoreEnd", "scoreStart" },
                values: new object[] { 2, "Neutros", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 8, 7 });

            migrationBuilder.InsertData(
                table: "RulesQuestionnaire",
                columns: new[] { "id", "classification", "createdDate", "questionnaireId", "scoreEnd", "scoreStart" },
                values: new object[] { 3, "Promotores", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 10, 9 });

            migrationBuilder.CreateIndex(
                name: "IX_Questionnaires_companyId",
                table: "Questionnaires",
                column: "companyId");

            migrationBuilder.CreateIndex(
                name: "IX_RulesQuestionnaire_questionnaireId",
                table: "RulesQuestionnaire",
                column: "questionnaireId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_profileId",
                table: "Users",
                column: "profileId");

            migrationBuilder.CreateIndex(
                name: "IX_UsersQuestionnaires_questionnaireId",
                table: "UsersQuestionnaires",
                column: "questionnaireId");

            migrationBuilder.CreateIndex(
                name: "IX_UsersQuestionnaires_userId",
                table: "UsersQuestionnaires",
                column: "userId");
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