using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace FoodbWebAPI.Migrations
{
    public partial class InitialMigrations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Recipes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    Method = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recipes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ingredients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Amount = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    RecipeId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingredients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ingredients_Recipes_RecipeId",
                        column: x => x.RecipeId,
                        principalTable: "Recipes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ingredients_RecipeId",
                table: "Ingredients",
                column: "RecipeId");

            migrationBuilder.Sql("INSERT INTO \"Recipes\" (\"Name\", \"Method\") VALUES (\'Lasi vettä\', \'Kaada vesi lasiin. Juo.\');");
            migrationBuilder.Sql("INSERT INTO \"Recipes\" (\"Name\", \"Method\") VALUES (\'Makarooni ja ketsuppi\', \'Keitä makaroneja 8 min. Lisää ketsuppi. Sekoita.\');");
            
            migrationBuilder.Sql("INSERT INTO \"Ingredients\" (\"Amount\", \"Description\", \"RecipeId\") VALUES (\'250ml\', \'Vettä\', \'1\');");
            migrationBuilder.Sql("INSERT INTO \"Ingredients\" (\"Amount\", \"Description\", \"RecipeId\") VALUES (\'400 g\', \'Tummaa makaronia\', \'2\');");
            migrationBuilder.Sql("INSERT INTO \"Ingredients\" (\"Amount\", \"Description\", \"RecipeId\") VALUES (\'1 dl\', \'Ketsuppia\', \'2\');");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ingredients");

            migrationBuilder.DropTable(
                name: "Recipes");
        }
    }
}
