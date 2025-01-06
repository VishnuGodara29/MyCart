using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyCarData.Migrations
{
    /// <inheritdoc />
    public partial class addUserType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserLogins_Users_UserInId",
                table: "UserLogins");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "UserInId",
                table: "UserLogins",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_UserLogins_UserInId",
                table: "UserLogins",
                newName: "IX_UserLogins_UserId");

            migrationBuilder.AddColumn<int>(
                name: "UserType",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_UserLogins_Users_UserId",
                table: "UserLogins",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserLogins_Users_UserId",
                table: "UserLogins");

            migrationBuilder.DropColumn(
                name: "UserType",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "UserLogins",
                newName: "UserInId");

            migrationBuilder.RenameIndex(
                name: "IX_UserLogins_UserId",
                table: "UserLogins",
                newName: "IX_UserLogins_UserInId");

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_UserLogins_Users_UserInId",
                table: "UserLogins",
                column: "UserInId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
