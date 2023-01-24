using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class createdb2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_RecSection_RecentSecId",
                table: "Posts");

            migrationBuilder.DropTable(
                name: "RecSection");

            migrationBuilder.DropIndex(
                name: "IX_Posts_RecentSecId",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "RecentSecId",
                table: "Posts");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RecentSecId",
                table: "Posts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "RecSection",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecSection", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Posts_RecentSecId",
                table: "Posts",
                column: "RecentSecId");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_RecSection_RecentSecId",
                table: "Posts",
                column: "RecentSecId",
                principalTable: "RecSection",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
