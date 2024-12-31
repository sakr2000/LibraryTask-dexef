using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibraryTask_dexef.Migrations
{
    /// <inheritdoc />
    public partial class first : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ApplicationUser",
                keyColumn: "Id",
                keyValue: new Guid("69db714f-9576-45ba-b5b7-f00649be01de"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "eac11492-55f2-428f-9f9b-4563fbca76c8", "AQAAAAIAAYagAAAAEO1P+RrKrxHbgdObLRGPO1qknm9w3Vzyui0QgtMojfYaLYgDQyTuD38c06Ab1hWDpA==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ApplicationUser",
                keyColumn: "Id",
                keyValue: new Guid("69db714f-9576-45ba-b5b7-f00649be01de"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "2c649f12-ae2e-412b-9b33-28fde692d46c", "AQAAAAIAAYagAAAAEEguBF5GcRGsKUHoPuRogPhYCYprkIQ3aptJQYWUqi8UIQxPAtG9OITGHMGCNHHtUQ==" });
        }
    }
}
