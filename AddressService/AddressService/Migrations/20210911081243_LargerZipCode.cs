using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AddressService.Migrations
{
    public partial class LargerZipCode : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("1f3f6010-7656-4cf4-8fe1-e84aa7ec574a"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("2c138c56-302c-4455-ae7a-6eeee3c02f1e"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("5b1454d5-b5dc-4017-811b-82ec57537300"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("5de5f72f-bcda-4362-851f-2e46de0e95dc"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("abae50dc-93a2-4be0-9309-56749039f7f8"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("c9c54d85-46f7-48dc-8371-ccf5d392b9e8"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("e7858c5a-db1d-4b38-840e-530be6377785"));

            migrationBuilder.AlterColumn<string>(
                name: "ZipCode",
                table: "Cities",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10,
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[,]
                {
                    { new Guid("c3dea3b9-3715-4348-bd4d-8f991375dacd"), "381", "Serbia" },
                    { new Guid("f1068e87-1b0f-4c51-a58e-c7adddbd92b3"), "44", "United Kingdom" },
                    { new Guid("3c9b3912-774c-4c24-adeb-740fe735f217"), "49", "Germany" },
                    { new Guid("2d275174-c53b-45d6-9091-d39d3b6593a4"), "33", "Frace" },
                    { new Guid("cbbbd1b4-8fba-46a1-b3d4-f3c957be60b2"), "34", "Spain" },
                    { new Guid("891705dc-379a-4313-80eb-98a5d9d46dc2"), "39", "Italy" },
                    { new Guid("6e027439-0f99-4f8c-96f2-7720695ff6fc"), "387", "Bosnia and Herzegovina" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("2d275174-c53b-45d6-9091-d39d3b6593a4"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("3c9b3912-774c-4c24-adeb-740fe735f217"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("6e027439-0f99-4f8c-96f2-7720695ff6fc"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("891705dc-379a-4313-80eb-98a5d9d46dc2"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("c3dea3b9-3715-4348-bd4d-8f991375dacd"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("cbbbd1b4-8fba-46a1-b3d4-f3c957be60b2"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("f1068e87-1b0f-4c51-a58e-c7adddbd92b3"));

            migrationBuilder.AlterColumn<string>(
                name: "ZipCode",
                table: "Cities",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[,]
                {
                    { new Guid("5b1454d5-b5dc-4017-811b-82ec57537300"), "381", "Serbia" },
                    { new Guid("c9c54d85-46f7-48dc-8371-ccf5d392b9e8"), "44", "United Kingdom" },
                    { new Guid("2c138c56-302c-4455-ae7a-6eeee3c02f1e"), "49", "Germany" },
                    { new Guid("1f3f6010-7656-4cf4-8fe1-e84aa7ec574a"), "33", "Frace" },
                    { new Guid("e7858c5a-db1d-4b38-840e-530be6377785"), "34", "Spain" },
                    { new Guid("5de5f72f-bcda-4362-851f-2e46de0e95dc"), "39", "Italy" },
                    { new Guid("abae50dc-93a2-4be0-9309-56749039f7f8"), "387", "Bosnia and Herzegovina" }
                });
        }
    }
}
