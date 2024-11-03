using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace student_manager.Migrations
{
    /// <inheritdoc />
    public partial class AddressRemove : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Address",
                table: "Students",
                newName: "Email");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Email",
                table: "Students",
                newName: "Address");
        }
    }
}
