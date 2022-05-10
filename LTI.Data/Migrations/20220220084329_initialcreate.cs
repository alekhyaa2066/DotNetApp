using Microsoft.EntityFrameworkCore.Migrations;

namespace LTI.Data.Migrations
{
    public partial class initialcreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AT_Employees",
                columns: table => new
                {
                    EId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EName = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    DU = table.Column<int>(type: "int", nullable: false),
                    Experience = table.Column<int>(type: "int", nullable: false),
                    MobileNo = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Skills = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AT_Employees", x => x.EId);
                });

            migrationBuilder.CreateTable(
                name: "AT_Projects",
                columns: table => new
                {
                    PId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PName = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    PManager = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    Skill1 = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    Skill2 = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    Skill3 = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AT_Projects", x => x.PId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AT_Employees");

            migrationBuilder.DropTable(
                name: "AT_Projects");
        }
    }
}
