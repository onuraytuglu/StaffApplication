using Microsoft.EntityFrameworkCore.Migrations;

namespace PersonelProject.ToDo.DataAccess.Migrations
{
    public partial class UrgencyAddedColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UrgencyId",
                table: "Missions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Urgencies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Definition = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Urgencies", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Missions_UrgencyId",
                table: "Missions",
                column: "UrgencyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Missions_Urgencies_UrgencyId",
                table: "Missions",
                column: "UrgencyId",
                principalTable: "Urgencies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Missions_Urgencies_UrgencyId",
                table: "Missions");

            migrationBuilder.DropTable(
                name: "Urgencies");

            migrationBuilder.DropIndex(
                name: "IX_Missions_UrgencyId",
                table: "Missions");

            migrationBuilder.DropColumn(
                name: "UrgencyId",
                table: "Missions");
        }
    }
}
