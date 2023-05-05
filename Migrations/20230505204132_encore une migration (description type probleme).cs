using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InterventionsBackend.Migrations
{
    /// <inheritdoc />
    public partial class encoreunemigrationdescriptiontypeprobleme : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "TypesProbleme",
                newName: "descriptionTypeProbleme");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "descriptionTypeProbleme",
                table: "TypesProbleme",
                newName: "Name");
        }
    }
}
