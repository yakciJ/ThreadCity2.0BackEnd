using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ThreadCity2._0BackEnd.Migrations
{
    /// <inheritdoc />
    public partial class Update02 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "13d47389-ea8b-40b0-a63a-7ff6007d60a2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "706ff6d9-304c-4ec3-864d-041e6c2c9d2e");

            migrationBuilder.CreateTable(
                name: "postScores",
                columns: table => new
                {
                    PostScoreId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PostId = table.Column<int>(type: "int", nullable: false),
                    TimeScore = table.Column<double>(type: "float", nullable: false),
                    PopularityScore = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_postScores", x => x.PostScoreId);
                    table.ForeignKey(
                        name: "FK_postScores_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "PostId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1ab0d086-5734-4f94-b5c6-08e901c7381c", null, "Admin", "ADMIN" },
                    { "99aa450e-5221-4aa6-9fb3-b59945845ba6", null, "User", "USER" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_postScores_PostId",
                table: "postScores",
                column: "PostId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "postScores");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1ab0d086-5734-4f94-b5c6-08e901c7381c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "99aa450e-5221-4aa6-9fb3-b59945845ba6");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "13d47389-ea8b-40b0-a63a-7ff6007d60a2", null, "Admin", "ADMIN" },
                    { "706ff6d9-304c-4ec3-864d-041e6c2c9d2e", null, "User", "USER" }
                });
        }
    }
}
