using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace yummer_backend.Migrations
{
    /// <inheritdoc />
    public partial class RemoveItemImage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "Items");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Items",
                type: "character varying(255)",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Items",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(255)",
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "Image",
                table: "Items",
                type: "bytea",
                nullable: true);
        }
    }
}
