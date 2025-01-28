using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace My_Web_API.Migrations
{
    /// <inheritdoc />
    public partial class UpdateLocationModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "name",
                table: "Locations",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "Adress",
                table: "Locations",
                newName: "Address");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Locations",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Address",
                table: "Locations",
                newName: "Adress");
        }
    }
}
