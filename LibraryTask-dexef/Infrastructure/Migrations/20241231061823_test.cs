using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibraryTask_dexef.Migrations
{
    /// <inheritdoc />
    public partial class test : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ApplicationUser",
                keyColumn: "Id",
                keyValue: new Guid("69db714f-9576-45ba-b5b7-f00649be01de"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "8a412b1a-f37e-4987-9083-e4528df136aa", "AQAAAAIAAYagAAAAEFdvu2mXVNeWZq8b1HSRHpErl0iD6w+qeLzmbBS6yXCiZAeioKuKPZuywy5xCX0RQA==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ApplicationUser",
                keyColumn: "Id",
                keyValue: new Guid("69db714f-9576-45ba-b5b7-f00649be01de"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "eac11492-55f2-428f-9f9b-4563fbca76c8", "AQAAAAIAAYagAAAAEO1P+RrKrxHbgdObLRGPO1qknm9w3Vzyui0QgtMojfYaLYgDQyTuD38c06Ab1hWDpA==" });
        }
    }
}
