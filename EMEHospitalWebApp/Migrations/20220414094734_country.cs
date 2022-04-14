using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EMEHospitalWebApp.Migrations
{
    public partial class country : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Country",
                schema: "HospitalWebApp",
                table: "Patients",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Country",
                schema: "HospitalWebApp",
                table: "Patients");
        }
    }
}
