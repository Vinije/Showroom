using Microsoft.EntityFrameworkCore.Migrations;

namespace Showroom.Api.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProjectType = table.Column<int>(type: "int", nullable: false),
                    OwnerId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProjectPath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProjectThumbnail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Rating = table.Column<double>(type: "float", nullable: false),
                    Views = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "Description", "Name", "OwnerId", "ProjectPath", "ProjectThumbnail", "ProjectType", "Rating", "Views" },
                values: new object[] { 1, "This is just a test, this should influence 90% of people.", "Test 1", "200", "Projects/TestProject1", "images/Untitled1.png", 0, 0.0, 0 });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "Description", "Name", "OwnerId", "ProjectPath", "ProjectThumbnail", "ProjectType", "Rating", "Views" },
                values: new object[] { 2, "This is description of test project number 2. This is also awesome project.", "Test 2", "250", "Projects/TestProject2", "images/Untitled2.png", 1, 0.0, 0 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Projects");
        }
    }
}
