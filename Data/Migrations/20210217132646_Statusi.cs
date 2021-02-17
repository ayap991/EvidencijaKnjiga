using Microsoft.EntityFrameworkCore.Migrations;

namespace EvidencijaKnjiga.Data.Migrations
{
    public partial class Statusi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "StatusID",
                table: "Knjiga",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StatusID1",
                table: "Knjiga",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Status",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Opis = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Status", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Knjiga_StatusID1",
                table: "Knjiga",
                column: "StatusID1");

            migrationBuilder.AddForeignKey(
                name: "FK_Knjiga_Status_StatusID1",
                table: "Knjiga",
                column: "StatusID1",
                principalTable: "Status",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Knjiga_Status_StatusID1",
                table: "Knjiga");

            migrationBuilder.DropTable(
                name: "Status");

            migrationBuilder.DropIndex(
                name: "IX_Knjiga_StatusID1",
                table: "Knjiga");

            migrationBuilder.DropColumn(
                name: "StatusID",
                table: "Knjiga");

            migrationBuilder.DropColumn(
                name: "StatusID1",
                table: "Knjiga");
        }
    }
}
