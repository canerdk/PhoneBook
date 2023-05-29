using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PhoneBook.Infrastructure.Migrations
{
    public partial class _29052023 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Persons",
                columns: new[] { "Id", "Company", "FirsName", "LastName" },
                values: new object[,]
                {
                    { new Guid("037f21f4-ee55-47e0-9696-ab540fd71b90"), "Company3", "Mehmet", "Demirkaya" },
                    { new Guid("89049e21-eb04-40b2-9add-04dc29fa7d30"), "Company1", "Caner", "Demirkaya" },
                    { new Guid("a2cbcfaa-e306-48bc-b1eb-0c8397b679cf"), "Company2", "Ahmet", "Demirkaya" }
                });

            migrationBuilder.InsertData(
                table: "PersonContacts",
                columns: new[] { "Id", "Content", "PersonId", "Title", "Type" },
                values: new object[,]
                {
                    { new Guid("03371521-d91b-42dd-870d-c08ed467898d"), "Ankara", new Guid("a2cbcfaa-e306-48bc-b1eb-0c8397b679cf"), "Location", 3 },
                    { new Guid("117781bc-9a13-43c6-af34-047e4e93345a"), "5554443322", new Guid("89049e21-eb04-40b2-9add-04dc29fa7d30"), "Phone", 1 },
                    { new Guid("38a118f7-b516-47a4-9447-a3ef0732cb4c"), "Ankara", new Guid("89049e21-eb04-40b2-9add-04dc29fa7d30"), "Location", 3 },
                    { new Guid("75441eed-49bc-407b-9318-d3f6b247e7a6"), "9998887744", new Guid("a2cbcfaa-e306-48bc-b1eb-0c8397b679cf"), "Phone", 1 },
                    { new Guid("932df542-135e-4363-b043-c61d72dd2460"), "3334441112", new Guid("89049e21-eb04-40b2-9add-04dc29fa7d30"), "Phone", 1 },
                    { new Guid("caf0dfd2-9436-4115-ab27-6b6c72df852f"), "9998887744", new Guid("037f21f4-ee55-47e0-9696-ab540fd71b90"), "Phone", 1 },
                    { new Guid("ce22210a-1e2a-450d-9242-fbe5a4833b07"), "İstanbul", new Guid("037f21f4-ee55-47e0-9696-ab540fd71b90"), "Location", 3 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "PersonContacts",
                keyColumn: "Id",
                keyValue: new Guid("03371521-d91b-42dd-870d-c08ed467898d"));

            migrationBuilder.DeleteData(
                table: "PersonContacts",
                keyColumn: "Id",
                keyValue: new Guid("117781bc-9a13-43c6-af34-047e4e93345a"));

            migrationBuilder.DeleteData(
                table: "PersonContacts",
                keyColumn: "Id",
                keyValue: new Guid("38a118f7-b516-47a4-9447-a3ef0732cb4c"));

            migrationBuilder.DeleteData(
                table: "PersonContacts",
                keyColumn: "Id",
                keyValue: new Guid("75441eed-49bc-407b-9318-d3f6b247e7a6"));

            migrationBuilder.DeleteData(
                table: "PersonContacts",
                keyColumn: "Id",
                keyValue: new Guid("932df542-135e-4363-b043-c61d72dd2460"));

            migrationBuilder.DeleteData(
                table: "PersonContacts",
                keyColumn: "Id",
                keyValue: new Guid("caf0dfd2-9436-4115-ab27-6b6c72df852f"));

            migrationBuilder.DeleteData(
                table: "PersonContacts",
                keyColumn: "Id",
                keyValue: new Guid("ce22210a-1e2a-450d-9242-fbe5a4833b07"));

            migrationBuilder.DeleteData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: new Guid("037f21f4-ee55-47e0-9696-ab540fd71b90"));

            migrationBuilder.DeleteData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: new Guid("89049e21-eb04-40b2-9add-04dc29fa7d30"));

            migrationBuilder.DeleteData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: new Guid("a2cbcfaa-e306-48bc-b1eb-0c8397b679cf"));
        }
    }
}
