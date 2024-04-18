using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PhotoFen.Data.Migrations
{
    public partial class CorrectDBPhotoData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "PhotoData",
                table: "Photos",
                type: "nvarchar(max)",
                nullable: false,
                comment: "Photo data",
                oldClrType: typeof(byte[]),
                oldType: "varbinary(max)",
                oldMaxLength: 2000000,
                oldComment: "Photo data");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6o5803ce-d744-4fc8-83d9-d6b3ac1f591k",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e53aba8a-5e0e-4322-a8cf-c0441ae5cff2", "AQAAAAEAACcQAAAAEKfkenPStcAzAKzcWBD4hV0LVARx373++BCYJcvmUQVa4s3ACeeowu6Mo9YUOIGgsA==", "e4cc809b-bf8f-48ef-8266-ddb9398b1285" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "met12856-c198-4120-b3z3-b893d8396482",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "897d248c-a729-43bb-a039-ac4ea5a7f52f", "AQAAAAEAACcQAAAAEHgpSOAQ61goph7+3vakgw2ahqEn13yH3jP2FMOI7LGLnE1KDLpZRCdYfXxW1QXuzg==", "70a4913f-e573-4dab-8f3c-a4d3f21080a4" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "taa11559-c198-4129-b3f3-b893d8395083",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "92a37eda-5b7e-4b4f-b42e-bd943a508808", "AQAAAAEAACcQAAAAED4/yz5DP0Gp/LC9agDdrtVfhscbDNyzfaaDWKEdpGL5KEYuV7rv/kEwlMmS50P0tw==", "795812d5-8d51-45f5-8fd0-a16bc8ce6e5a" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte[]>(
                name: "PhotoData",
                table: "Photos",
                type: "varbinary(max)",
                maxLength: 2000000,
                nullable: false,
                comment: "Photo data",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldComment: "Photo data");

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
    }
}
