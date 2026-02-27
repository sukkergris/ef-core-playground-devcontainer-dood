using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Agency.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Agency");

            migrationBuilder.CreateTable(
                name: "Agencies",
                schema: "Agency",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agencies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Agents",
                schema: "Agency",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CallId = table.Column<string>(type: "text", nullable: false),
                    SecretId = table.Column<string>(type: "text", nullable: false),
                    AgencyId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Agents_Agencies_AgencyId",
                        column: x => x.AgencyId,
                        principalSchema: "Agency",
                        principalTable: "Agencies",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Agents_AgencyId",
                schema: "Agency",
                table: "Agents",
                column: "AgencyId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Agents",
                schema: "Agency");

            migrationBuilder.DropTable(
                name: "Agencies",
                schema: "Agency");
        }
    }
}
