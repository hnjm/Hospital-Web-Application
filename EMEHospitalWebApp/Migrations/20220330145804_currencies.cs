using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EMEHospitalWebApp.Migrations
{
    public partial class currencies : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Code",
                schema: "HospitalWebApp",
                table: "Currencies",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                schema: "HospitalWebApp",
                table: "Currencies",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Code",
                schema: "HospitalWebApp",
                table: "Currencies");

            migrationBuilder.DropColumn(
                name: "Description",
                schema: "HospitalWebApp",
                table: "Currencies");
        }
    }
}
