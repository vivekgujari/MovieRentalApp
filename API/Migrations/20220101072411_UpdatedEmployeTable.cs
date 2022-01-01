using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class UpdatedEmployeTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte>(
                name: "TitleId",
                table: "Employee",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<int>(
                name: "TitleId1",
                table: "Employee",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Employee_TitleId1",
                table: "Employee",
                column: "TitleId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_Title_TitleId1",
                table: "Employee",
                column: "TitleId1",
                principalTable: "Title",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employee_Title_TitleId1",
                table: "Employee");

            migrationBuilder.DropIndex(
                name: "IX_Employee_TitleId1",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "TitleId",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "TitleId1",
                table: "Employee");
        }
    }
}
