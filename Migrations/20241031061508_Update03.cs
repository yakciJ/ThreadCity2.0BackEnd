using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ThreadCity2._0BackEnd.Migrations
{
    /// <inheritdoc />
    public partial class Update03 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_postScores_Posts_PostId",
                table: "postScores");

            migrationBuilder.DropPrimaryKey(
                name: "PK_postScores",
                table: "postScores");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1ab0d086-5734-4f94-b5c6-08e901c7381c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "99aa450e-5221-4aa6-9fb3-b59945845ba6");

            migrationBuilder.RenameTable(
                name: "postScores",
                newName: "PostScores");

            migrationBuilder.RenameIndex(
                name: "IX_postScores_PostId",
                table: "PostScores",
                newName: "IX_PostScores_PostId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PostScores",
                table: "PostScores",
                column: "PostScoreId");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "21abf296-cdd0-491d-9aa0-dccee35536e8", null, "Admin", "ADMIN" },
                    { "e0ad798f-6044-44d6-99ae-e0eec6fe1396", null, "User", "USER" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_PostScores_Posts_PostId",
                table: "PostScores",
                column: "PostId",
                principalTable: "Posts",
                principalColumn: "PostId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PostScores_Posts_PostId",
                table: "PostScores");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PostScores",
                table: "PostScores");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "21abf296-cdd0-491d-9aa0-dccee35536e8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e0ad798f-6044-44d6-99ae-e0eec6fe1396");

            migrationBuilder.RenameTable(
                name: "PostScores",
                newName: "postScores");

            migrationBuilder.RenameIndex(
                name: "IX_PostScores_PostId",
                table: "postScores",
                newName: "IX_postScores_PostId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_postScores",
                table: "postScores",
                column: "PostScoreId");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1ab0d086-5734-4f94-b5c6-08e901c7381c", null, "Admin", "ADMIN" },
                    { "99aa450e-5221-4aa6-9fb3-b59945845ba6", null, "User", "USER" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_postScores_Posts_PostId",
                table: "postScores",
                column: "PostId",
                principalTable: "Posts",
                principalColumn: "PostId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
