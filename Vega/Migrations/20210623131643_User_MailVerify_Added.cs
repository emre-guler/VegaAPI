using Microsoft.EntityFrameworkCore.Migrations;

namespace Vega.Migrations
{
    public partial class User_MailVerify_Added : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "MailVerify",
                table: "Users",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MailVerify",
                table: "Users");
        }
    }
}
