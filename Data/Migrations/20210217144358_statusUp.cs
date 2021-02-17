using Microsoft.EntityFrameworkCore.Migrations;

namespace EvidencijaKnjiga.Data.Migrations
{
    public partial class statusUp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Knjiga_Status_StatusID",
                table: "Knjiga");

            migrationBuilder.DropIndex(
                name: "IX_Knjiga_StatusID",
                table: "Knjiga");

            migrationBuilder.AlterColumn<string>(
                name: "StatusID",
                table: "Knjiga",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StatusID1",
                table: "Knjiga",
                nullable: true);

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

            migrationBuilder.DropIndex(
                name: "IX_Knjiga_StatusID1",
                table: "Knjiga");

            migrationBuilder.DropColumn(
                name: "StatusID1",
                table: "Knjiga");

            migrationBuilder.AlterColumn<int>(
                name: "StatusID",
                table: "Knjiga",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Knjiga_StatusID",
                table: "Knjiga",
                column: "StatusID");

            migrationBuilder.AddForeignKey(
                name: "FK_Knjiga_Status_StatusID",
                table: "Knjiga",
                column: "StatusID",
                principalTable: "Status",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
