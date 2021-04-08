using Microsoft.EntityFrameworkCore.Migrations;

namespace JuniorSlataTestTask.Migrations
{
    public partial class FixDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Jobseakers_Users_Managerid",
                table: "Jobseakers");

            migrationBuilder.DropForeignKey(
                name: "FK_Jobseakers_Users_Mentorid",
                table: "Jobseakers");

            migrationBuilder.DropIndex(
                name: "IX_Jobseakers_Managerid",
                table: "Jobseakers");

            migrationBuilder.DropIndex(
                name: "IX_Jobseakers_Mentorid",
                table: "Jobseakers");

            migrationBuilder.RenameColumn(
                name: "Mentorid",
                table: "Jobseakers",
                newName: "MentorId");

            migrationBuilder.RenameColumn(
                name: "Managerid",
                table: "Jobseakers",
                newName: "ManagerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MentorId",
                table: "Jobseakers",
                newName: "Mentorid");

            migrationBuilder.RenameColumn(
                name: "ManagerId",
                table: "Jobseakers",
                newName: "Managerid");

            migrationBuilder.CreateIndex(
                name: "IX_Jobseakers_Managerid",
                table: "Jobseakers",
                column: "Managerid");

            migrationBuilder.CreateIndex(
                name: "IX_Jobseakers_Mentorid",
                table: "Jobseakers",
                column: "Mentorid");

            migrationBuilder.AddForeignKey(
                name: "FK_Jobseakers_Users_Managerid",
                table: "Jobseakers",
                column: "Managerid",
                principalTable: "Users",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Jobseakers_Users_Mentorid",
                table: "Jobseakers",
                column: "Mentorid",
                principalTable: "Users",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
