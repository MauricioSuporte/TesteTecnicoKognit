using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UserWalletAPI.Migrations
{
    /// <inheritdoc />
    public partial class RenameCpfColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CPF",
                table: "Users",
                newName: "Cpf");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Cpf",
                table: "Users",
                newName: "CPF");
        }
    }
}
