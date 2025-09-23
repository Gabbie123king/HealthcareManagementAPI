using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HealthcareManagementAPI.Migrations
{
    /// <inheritdoc />
    public partial class FixPatientColumns : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FirsName",
                table: "Patients",
                newName: "LastName");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Patients",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Patients");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "Patients",
                newName: "FirsName");
        }
    }
}
