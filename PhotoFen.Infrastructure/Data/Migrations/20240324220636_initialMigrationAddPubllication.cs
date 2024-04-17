using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PhotoFen.Data.Migrations
{
    public partial class initialMigrationAddPubllication : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Publications",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Publication Identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "Publication tittle"),
                    Content = table.Column<string>(type: "nvarchar(max)", maxLength: 5000, nullable: false, comment: "Publication content"),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Date of posted of the publication")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Publications", x => x.Id);
                },
                comment: "Publication");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6o5803ce-d744-4fc8-83d9-d6b3ac1f591k",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c7a41a5f-4114-4e00-8afa-a2203a9042ad", "AQAAAAEAACcQAAAAEAETUGtFRCjwhULqB3etMF3hiVGaUORHwziY5y/EnvPc+ml6OhAM3LuME6utIWudKg==", "40040e8d-c183-4c94-a8f4-53d8e628764f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "met12856-c198-4120-b3z3-b893d8396482",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7393f5ed-687e-4377-a590-671a371e0eae", "AQAAAAEAACcQAAAAEBEz26O97FnEd86o2aDdOU/NX95qlUtSUsA/hPHiU2C6fjAUGXnrVGRdO4mmlMdpNA==", "2c9c1f1f-b03c-4026-af5b-a22563206b54" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "taa11559-c198-4129-b3f3-b893d8395083",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5f077d12-16d2-4b74-acbd-a748b517e752", "AQAAAAEAACcQAAAAECftc0z8xj2fiQdhn1m+ngfK+lpVmcbUPoZ4XV6cDKjyUjSxov01d4xSiR0+qDHv0A==", "8defc908-7582-406c-a797-f136acac74ee" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Publications");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6o5803ce-d744-4fc8-83d9-d6b3ac1f591k",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "81c67652-75af-4a2a-b833-27ce1e99eb8c", "AQAAAAEAACcQAAAAEF3VFxEGN2wfRjdehOQ5UamL5rKYUYpNJOdqqRYHSwt6HiyicNL6pUJpCnTCK+upnQ==", "32fa3e0b-f1ba-4030-86d9-fd9ee0032fd3" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "met12856-c198-4120-b3z3-b893d8396482",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5f7ec3a5-01ad-4405-869f-d914a9a72408", "AQAAAAEAACcQAAAAELpejBtoUqLzF74J9jU816+ztiwRVGGW+Hpoik6kCb7GPumKdoCMbZdSKIopHoPyww==", "07b97cff-15a7-427b-a54c-a67a76f2f674" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "taa11559-c198-4129-b3f3-b893d8395083",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f102c259-5348-46dd-b4b3-f50b706eaffb", "AQAAAAEAACcQAAAAEDGdycVzlTYv4Q+Kp7q7x2j00dvMzMwCRu//qA+szbNEalCeIEMBYoDJJrNxjQAIvw==", "cfa5de42-0a26-425e-8c43-653515eea1dd" });
        }
    }
}
