using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibraryTask_dexef.Migrations
{
    /// <inheritdoc />
    public partial class editPassword : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ApplicationUser",
                keyColumn: "Id",
                keyValue: new Guid("69db714f-9576-45ba-b5b7-f00649be01de"),
                columns: new[] { "ConcurrencyStamp", "Password", "PasswordHash" },
                values: new object[] { "3e6ab7f4-f612-416e-9dd2-c63f8d3b5bbf", "P@ssw0rd", "AQAAAAIAAYagAAAAEOlVhgZ0SIjPIhr+5MEm6iX3iTgVeobRJ9RF12Cz9aJxvytgBXabTU94GSLLInfFYA==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ApplicationUser",
                keyColumn: "Id",
                keyValue: new Guid("69db714f-9576-45ba-b5b7-f00649be01de"),
                columns: new[] { "ConcurrencyStamp", "Password", "PasswordHash" },
                values: new object[] { "8a412b1a-f37e-4987-9083-e4528df136aa", "", "AQAAAAIAAYagAAAAEFdvu2mXVNeWZq8b1HSRHpErl0iD6w+qeLzmbBS6yXCiZAeioKuKPZuywy5xCX0RQA==" });
        }
    }
}
