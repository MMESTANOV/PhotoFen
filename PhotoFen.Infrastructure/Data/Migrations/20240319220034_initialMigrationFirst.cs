using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PhotoFen.Data.Migrations
{
    public partial class initialMigrationFirst : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PhotoId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Category Identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false, comment: "Category name")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                },
                comment: "Photo Category");

            migrationBuilder.CreateTable(
                name: "Photographers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Photographer Identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false, comment: "Photographer name"),
                    PhotographerInfo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "Photographer info"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false, comment: "User Identifier")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Photographers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Photographers_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "Photographer");

            migrationBuilder.CreateTable(
                name: "Photos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Photo Identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "Photo tittle"),
                    Description = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false, comment: "Photo description"),
                    PhotoData = table.Column<byte[]>(type: "varbinary(max)", maxLength: 2000000, nullable: false, comment: "Photo data"),
                    LikesCount = table.Column<int>(type: "int", nullable: false, comment: "Count of likes on the photo"),
                    CategoryId = table.Column<int>(type: "int", nullable: false, comment: "Category identifier"),
                    TimeOfUpload = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Date of upload of the photo"),
                    PhotohrapherId = table.Column<int>(type: "int", nullable: false, comment: "Photohrapher identifier")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Photos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Photos_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Photos_Photographers_PhotohrapherId",
                        column: x => x.PhotohrapherId,
                        principalTable: "Photographers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "Photo");

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Comment Identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Content = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false, comment: "Comment content"),
                    UserID = table.Column<string>(type: "nvarchar(450)", nullable: false, comment: "User Identifier"),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Date of posted of the comment"),
                    PhotoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_AspNetUsers_UserID",
                        column: x => x.UserID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Comments_Photos_PhotoId",
                        column: x => x.PhotoId,
                        principalTable: "Photos",
                        principalColumn: "Id");
                },
                comment: "Photo Comment");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "PhotoId", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "6o5803ce-d744-4fc8-83d9-d6b3ac1f591k", 0, "81c67652-75af-4a2a-b833-27ce1e99eb8c", "guest2024@mail.com", false, false, null, "guest2024@mail.com", "guest2024@mail.com", "AQAAAAEAACcQAAAAEF3VFxEGN2wfRjdehOQ5UamL5rKYUYpNJOdqqRYHSwt6HiyicNL6pUJpCnTCK+upnQ==", null, false, null, "32fa3e0b-f1ba-4030-86d9-fd9ee0032fd3", false, "guest2024@mail.com" },
                    { "met12856-c198-4120-b3z3-b893d8396482", 0, "5f7ec3a5-01ad-4405-869f-d914a9a72408", "photographer1@mail.com", false, false, null, "photographer1@mail.com", "photographer1@mail.com", "AQAAAAEAACcQAAAAELpejBtoUqLzF74J9jU816+ztiwRVGGW+Hpoik6kCb7GPumKdoCMbZdSKIopHoPyww==", null, false, null, "07b97cff-15a7-427b-a54c-a67a76f2f674", false, "photographer1@mail.com" },
                    { "taa11559-c198-4129-b3f3-b893d8395083", 0, "f102c259-5348-46dd-b4b3-f50b706eaffb", "photographer2@mail.com", false, false, null, "photographer2@mail.com", "photographer2@mail.com", "AQAAAAEAACcQAAAAEDGdycVzlTYv4Q+Kp7q7x2j00dvMzMwCRu//qA+szbNEalCeIEMBYoDJJrNxjQAIvw==", null, false, null, "cfa5de42-0a26-425e-8c43-653515eea1dd", false, "photographer2@mail.com" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Landscapes" },
                    { 3, "Macro" },
                    { 4, "People" },
                    { 5, "Travel" },
                    { 6, "Street" },
                    { 7, "Sport" },
                    { 8, "Other" }
                });

            migrationBuilder.InsertData(
                table: "Photographers",
                columns: new[] { "Id", "Name", "PhotographerInfo", "UserId" },
                values: new object[] { 1, "Petrov", "I am Petar Petrov from Bulgaria and i shooting  landscapes.", "met12856-c198-4120-b3z3-b893d8396482" });

            migrationBuilder.InsertData(
                table: "Photographers",
                columns: new[] { "Id", "Name", "PhotographerInfo", "UserId" },
                values: new object[] { 2, "Macro Shooter", "I'm Stan from the Czech Republic. I love macro photography.", "taa11559-c198-4129-b3f3-b893d8395083" });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_PhotoId",
                table: "AspNetUsers",
                column: "PhotoId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_PhotoId",
                table: "Comments",
                column: "PhotoId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_UserID",
                table: "Comments",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Photographers_UserId",
                table: "Photographers",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Photos_CategoryId",
                table: "Photos",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Photos_PhotohrapherId",
                table: "Photos",
                column: "PhotohrapherId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Photos_PhotoId",
                table: "AspNetUsers",
                column: "PhotoId",
                principalTable: "Photos",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Photos_PhotoId",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Photos");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Photographers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_PhotoId",
                table: "AspNetUsers");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6o5803ce-d744-4fc8-83d9-d6b3ac1f591k");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "met12856-c198-4120-b3z3-b893d8396482");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "taa11559-c198-4129-b3f3-b893d8395083");

            migrationBuilder.DropColumn(
                name: "PhotoId",
                table: "AspNetUsers");
        }
    }
}
