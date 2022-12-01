using Microsoft.EntityFrameworkCore.Migrations;

namespace SODesk.Server.Migrations.Sqlite
{
    public partial class Temppassword : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TempPassword",
                table: "SODeskUsers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TempPassword",
                table: "SODeskUsers");
        }
    }
}
