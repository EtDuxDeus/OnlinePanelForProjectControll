using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlinePanelForProjectsControl.Migrations
{
    public partial class _updateTask2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8af10569-b018-4fe7-a380-7d6a14c70b74",
                column: "ConcurrencyStamp",
                value: "1b8d5e12-ca26-4d0c-9261-173cdfa5ef32");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f917fd6d-a7f9-4212-bbe7-c193cf061ef0",
                column: "ConcurrencyStamp",
                value: "b7c7797c-c271-4f04-a7db-ed551d5f6572");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3b62472e-4f66-49fa-a20f-e7685b9565d8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "ee5b8463-a1d6-4dab-ab1d-d7cc7c97cec2", "AQAAAAEAACcQAAAAEJhMwR4w7yYXctRzB/edvYy3hL1Td8yfi6H63BzrGOdZBknbTnpFXuMi3I4aqDZrBw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "451219dc-97d0-4f3a-90d3-a6b3a0d36c6b",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "c663d665-c6fd-40b0-8450-02bf46d3cc23", "AQAAAAEAACcQAAAAELJUrEJx+negBbIAOyy2bQpHirKPr7ogYYQFEWlogv0BNuPIDoc+b0XcvpEYxLRPmQ==" });

            migrationBuilder.InsertData(
                table: "ProjectTasks",
                columns: new[] { "TaskID", "DateOfEnd", "DateOfStart", "ProjectId", "TaskDescription", "TaskName", "isFinished" },
                values: new object[] { new Guid("a37182eb-dabb-43e0-8952-c662fa5e634e"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("713dcd88-126d-4671-1ed1-08da40a5c328"), "Опис таску", "Тест Тасков", false });

            migrationBuilder.UpdateData(
                table: "TextFields",
                keyColumn: "Id",
                keyValue: new Guid("4aa76a4c-c59d-409a-84c1-06e6487a137a"),
                column: "DateAdded",
                value: new DateTime(2022, 5, 29, 14, 48, 10, 828, DateTimeKind.Utc).AddTicks(9219));

            migrationBuilder.UpdateData(
                table: "TextFields",
                keyColumn: "Id",
                keyValue: new Guid("63dc8fa6-07ae-4391-8916-e057f71239ce"),
                column: "DateAdded",
                value: new DateTime(2022, 5, 29, 14, 48, 10, 828, DateTimeKind.Utc).AddTicks(8075));

            migrationBuilder.UpdateData(
                table: "TextFields",
                keyColumn: "Id",
                keyValue: new Guid("ccc0d57c-b438-499c-964b-1a542a908894"),
                column: "DateAdded",
                value: new DateTime(2022, 5, 29, 14, 48, 10, 828, DateTimeKind.Utc).AddTicks(9143));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ProjectTasks",
                keyColumn: "TaskID",
                keyValue: new Guid("a37182eb-dabb-43e0-8952-c662fa5e634e"));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8af10569-b018-4fe7-a380-7d6a14c70b74",
                column: "ConcurrencyStamp",
                value: "a39247d0-ce27-404f-be6d-ed36737cfad1");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f917fd6d-a7f9-4212-bbe7-c193cf061ef0",
                column: "ConcurrencyStamp",
                value: "9a133ea6-3e51-4be9-9d22-99eebf28bffd");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3b62472e-4f66-49fa-a20f-e7685b9565d8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "49696c00-9323-426c-b7f0-265cdfa80033", "AQAAAAEAACcQAAAAEOvX7p3zYKqJQfyPVIaUchOkShYHBPLSAB1xw4hDB7W7c2yAQbNjCdVlFPhzcSLo1g==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "451219dc-97d0-4f3a-90d3-a6b3a0d36c6b",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "4e1a91f0-a685-4e8b-b426-75dbd2468d5d", "AQAAAAEAACcQAAAAEO0+7jhZfrqveOBiVAKTTHp17ObwRJrJGiXXWXsomm/Bpb4qh8zpefWOzRy9bqDWEQ==" });

            migrationBuilder.UpdateData(
                table: "TextFields",
                keyColumn: "Id",
                keyValue: new Guid("4aa76a4c-c59d-409a-84c1-06e6487a137a"),
                column: "DateAdded",
                value: new DateTime(2022, 5, 29, 14, 29, 54, 792, DateTimeKind.Utc).AddTicks(2096));

            migrationBuilder.UpdateData(
                table: "TextFields",
                keyColumn: "Id",
                keyValue: new Guid("63dc8fa6-07ae-4391-8916-e057f71239ce"),
                column: "DateAdded",
                value: new DateTime(2022, 5, 29, 14, 29, 54, 792, DateTimeKind.Utc).AddTicks(1034));

            migrationBuilder.UpdateData(
                table: "TextFields",
                keyColumn: "Id",
                keyValue: new Guid("ccc0d57c-b438-499c-964b-1a542a908894"),
                column: "DateAdded",
                value: new DateTime(2022, 5, 29, 14, 29, 54, 792, DateTimeKind.Utc).AddTicks(2058));
        }
    }
}
