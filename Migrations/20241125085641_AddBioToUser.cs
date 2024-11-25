using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ThreadCity2._0BackEnd.Migrations
{
    /// <inheritdoc />
    public partial class AddBioToUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_AspNetUsers_UserId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Follows_AspNetUsers_FollowedUserId",
                table: "Follows");

            migrationBuilder.DropForeignKey(
                name: "FK_Follows_AspNetUsers_FollowerUserId",
                table: "Follows");

            migrationBuilder.DropForeignKey(
                name: "FK_LikeComments_AspNetUsers_UserId",
                table: "LikeComments");

            migrationBuilder.DropForeignKey(
                name: "FK_LikePosts_AspNetUsers_UserId",
                table: "LikePosts");

            migrationBuilder.DropForeignKey(
                name: "FK_SeenPosts_AspNetUsers_UserId",
                table: "SeenPosts");

            migrationBuilder.DropForeignKey(
                name: "FK_Shares_AspNetUsers_UserId",
                table: "Shares");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4760e7fd-dfd5-4d15-a59b-6af8dd367d0c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e0a84b98-99fc-486f-8bc9-225af5edf59a");

            migrationBuilder.AddColumn<string>(
                name: "Bio",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "d02bda9a-d68d-427c-a656-d776ad101b9d", null, "Admin", "ADMIN" },
                    { "d23d6a0d-8ffe-46aa-848c-679ae439313f", null, "User", "USER" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_AspNetUsers_UserId",
                table: "Comments",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Follows_AspNetUsers_FollowedUserId",
                table: "Follows",
                column: "FollowedUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Follows_AspNetUsers_FollowerUserId",
                table: "Follows",
                column: "FollowerUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LikeComments_AspNetUsers_UserId",
                table: "LikeComments",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LikePosts_AspNetUsers_UserId",
                table: "LikePosts",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SeenPosts_AspNetUsers_UserId",
                table: "SeenPosts",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Shares_AspNetUsers_UserId",
                table: "Shares",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_AspNetUsers_UserId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Follows_AspNetUsers_FollowedUserId",
                table: "Follows");

            migrationBuilder.DropForeignKey(
                name: "FK_Follows_AspNetUsers_FollowerUserId",
                table: "Follows");

            migrationBuilder.DropForeignKey(
                name: "FK_LikeComments_AspNetUsers_UserId",
                table: "LikeComments");

            migrationBuilder.DropForeignKey(
                name: "FK_LikePosts_AspNetUsers_UserId",
                table: "LikePosts");

            migrationBuilder.DropForeignKey(
                name: "FK_SeenPosts_AspNetUsers_UserId",
                table: "SeenPosts");

            migrationBuilder.DropForeignKey(
                name: "FK_Shares_AspNetUsers_UserId",
                table: "Shares");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d02bda9a-d68d-427c-a656-d776ad101b9d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d23d6a0d-8ffe-46aa-848c-679ae439313f");

            migrationBuilder.DropColumn(
                name: "Bio",
                table: "AspNetUsers");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "4760e7fd-dfd5-4d15-a59b-6af8dd367d0c", null, "Admin", "ADMIN" },
                    { "e0a84b98-99fc-486f-8bc9-225af5edf59a", null, "User", "USER" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_AspNetUsers_UserId",
                table: "Comments",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Follows_AspNetUsers_FollowedUserId",
                table: "Follows",
                column: "FollowedUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Follows_AspNetUsers_FollowerUserId",
                table: "Follows",
                column: "FollowerUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LikeComments_AspNetUsers_UserId",
                table: "LikeComments",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LikePosts_AspNetUsers_UserId",
                table: "LikePosts",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SeenPosts_AspNetUsers_UserId",
                table: "SeenPosts",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Shares_AspNetUsers_UserId",
                table: "Shares",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
