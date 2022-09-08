using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    public partial class Position_addFKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Users_PositionRefId",
                table: "Users",
                column: "PositionRefId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Positions_PositionRefId",
                table: "Users",
                column: "PositionRefId",
                principalTable: "Positions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Positions_PositionRefId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_PositionRefId",
                table: "Users");
        }
    }
}
