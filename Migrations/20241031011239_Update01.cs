using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ThreadCity2._0BackEnd.Migrations
{
    /// <inheritdoc />
    public partial class Update01 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_LikePosts",
                table: "LikePosts");

            migrationBuilder.DropIndex(
                name: "IX_LikePosts_UserId",
                table: "LikePosts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LikeComments",
                table: "LikeComments");

            migrationBuilder.DropIndex(
                name: "IX_LikeComments_UserId",
                table: "LikeComments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Follows",
                table: "Follows");

            migrationBuilder.DropIndex(
                name: "IX_Follows_FollowerUserId",
                table: "Follows");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0a2eeab8-1b07-43ab-9a19-d03ce02e4617");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6931d6ea-5bcf-44f3-9913-50947a8161ea");

            migrationBuilder.DropColumn(
                name: "LikePostId",
                table: "LikePosts");

            migrationBuilder.DropColumn(
                name: "LikeCmtId",
                table: "LikeComments");

            migrationBuilder.DropColumn(
                name: "FollowId",
                table: "Follows");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "LikePosts",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "LikeComments",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FollowerUserId",
                table: "Follows",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FollowedUserId",
                table: "Follows",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_LikePosts",
                table: "LikePosts",
                columns: new[] { "UserId", "PostId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_LikeComments",
                table: "LikeComments",
                columns: new[] { "UserId", "CommentId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Follows",
                table: "Follows",
                columns: new[] { "FollowerUserId", "FollowedUserId" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "13d47389-ea8b-40b0-a63a-7ff6007d60a2", null, "Admin", "ADMIN" },
                    { "706ff6d9-304c-4ec3-864d-041e6c2c9d2e", null, "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_LikePosts",
                table: "LikePosts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LikeComments",
                table: "LikeComments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Follows",
                table: "Follows");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "13d47389-ea8b-40b0-a63a-7ff6007d60a2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "706ff6d9-304c-4ec3-864d-041e6c2c9d2e");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "LikePosts",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<int>(
                name: "LikePostId",
                table: "LikePosts",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "LikeComments",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<int>(
                name: "LikeCmtId",
                table: "LikeComments",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<string>(
                name: "FollowedUserId",
                table: "Follows",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "FollowerUserId",
                table: "Follows",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<int>(
                name: "FollowId",
                table: "Follows",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LikePosts",
                table: "LikePosts",
                column: "LikePostId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LikeComments",
                table: "LikeComments",
                column: "LikeCmtId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Follows",
                table: "Follows",
                column: "FollowId");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0a2eeab8-1b07-43ab-9a19-d03ce02e4617", null, "Admin", "ADMIN" },
                    { "6931d6ea-5bcf-44f3-9913-50947a8161ea", null, "User", "USER" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_LikePosts_UserId",
                table: "LikePosts",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_LikeComments_UserId",
                table: "LikeComments",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Follows_FollowerUserId",
                table: "Follows",
                column: "FollowerUserId");
        }
    }
}
