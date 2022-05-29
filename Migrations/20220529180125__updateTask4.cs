using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlinePanelForProjectsControl.Migrations
{
    public partial class _updateTask4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProjectTasks_ProjectItems_ProjectId",
                table: "ProjectTasks");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8af10569-b018-4fe7-a380-7d6a14c70b74",
                column: "ConcurrencyStamp",
                value: "212acb4b-3a5c-417b-8e6d-6a83a29e9498");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f917fd6d-a7f9-4212-bbe7-c193cf061ef0",
                column: "ConcurrencyStamp",
                value: "c466faff-84f4-4bf1-8bf7-69a35d835ea1");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3b62472e-4f66-49fa-a20f-e7685b9565d8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "452e4f56-a6ae-4ae2-84fd-0f7c685578f2", "AQAAAAEAACcQAAAAEHmsUmJyDy8tMpb1fRugilcvbF4sMdnoQ2tAckEh4FuK5Z6zqzvRECCmz88VWxUUJA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "451219dc-97d0-4f3a-90d3-a6b3a0d36c6b",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "6617c9d8-c9b8-46e7-be2e-38744b8948c3", "AQAAAAEAACcQAAAAEG2sgHVXbXORbtn0nsNfyQl6BlJpB4+xPWGuKOyHqy0c7/QagGjN1eLnCoifLK+cpA==" });

            migrationBuilder.UpdateData(
                table: "TextFields",
                keyColumn: "Id",
                keyValue: new Guid("4aa76a4c-c59d-409a-84c1-06e6487a137a"),
                column: "DateAdded",
                value: new DateTime(2022, 5, 29, 18, 1, 25, 650, DateTimeKind.Utc).AddTicks(1329));

            migrationBuilder.UpdateData(
                table: "TextFields",
                keyColumn: "Id",
                keyValue: new Guid("63dc8fa6-07ae-4391-8916-e057f71239ce"),
                column: "DateAdded",
                value: new DateTime(2022, 5, 29, 18, 1, 25, 650, DateTimeKind.Utc).AddTicks(456));

            migrationBuilder.UpdateData(
                table: "TextFields",
                keyColumn: "Id",
                keyValue: new Guid("ccc0d57c-b438-499c-964b-1a542a908894"),
                column: "DateAdded",
                value: new DateTime(2022, 5, 29, 18, 1, 25, 650, DateTimeKind.Utc).AddTicks(1292));

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectTasks_ProjectItems_ProjectId",
                table: "ProjectTasks",
                column: "ProjectId",
                principalTable: "ProjectItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProjectTasks_ProjectItems_ProjectId",
                table: "ProjectTasks");

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

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectTasks_ProjectItems_ProjectId",
                table: "ProjectTasks",
                column: "ProjectId",
                principalTable: "ProjectItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
