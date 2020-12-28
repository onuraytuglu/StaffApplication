using Microsoft.EntityFrameworkCore.Migrations;

namespace PersonelProject.ToDo.DataAccess.Migrations
{
    public partial class AppUserWtihRelationShipMission : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Calismalar",
                table: "Calismalar");

            migrationBuilder.RenameTable(
                name: "Calismalar",
                newName: "Missions");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SurName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AppUserId",
                table: "Missions",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Missions",
                table: "Missions",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Missions_AppUserId",
                table: "Missions",
                column: "AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Missions_AspNetUsers_AppUserId",
                table: "Missions",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Missions_AspNetUsers_AppUserId",
                table: "Missions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Missions",
                table: "Missions");

            migrationBuilder.DropIndex(
                name: "IX_Missions_AppUserId",
                table: "Missions");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "SurName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "Missions");

            migrationBuilder.RenameTable(
                name: "Missions",
                newName: "Calismalar");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Calismalar",
                table: "Calismalar",
                column: "Id");
        }
    }
}
