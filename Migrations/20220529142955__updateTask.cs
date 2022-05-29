using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlinePanelForProjectsControl.Migrations
{
    public partial class _updateTask : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProjectTasks",
                columns: table => new
                {
                    TaskID = table.Column<Guid>(nullable: false),
                    ProjectId = table.Column<Guid>(nullable: false),
                    TaskName = table.Column<string>(nullable: true),
                    TaskDescription = table.Column<string>(nullable: true),
                    DateOfStart = table.Column<DateTime>(nullable: false),
                    DateOfEnd = table.Column<DateTime>(nullable: false),
                    isFinished = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectTasks", x => x.TaskID);
                    table.ForeignKey(
                        name: "FK_ProjectTasks_ProjectItems_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "ProjectItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_ProjectTasks_ProjectId",
                table: "ProjectTasks",
                column: "ProjectId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProjectTasks");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8af10569-b018-4fe7-a380-7d6a14c70b74",
                column: "ConcurrencyStamp",
                value: "41b55c9c-167a-4957-896f-12e112cd04cc");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f917fd6d-a7f9-4212-bbe7-c193cf061ef0",
                column: "ConcurrencyStamp",
                value: "53f7be92-41eb-47f6-af8c-cdbec1ba4978");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3b62472e-4f66-49fa-a20f-e7685b9565d8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "cd0270b9-0b82-4025-a0ae-d86d4e7a89f2", "AQAAAAEAACcQAAAAEMBNUB8Vi5m0YwIw08iYDbPdUK667fyKFw3vK9zyT4fkp7PENFHxNmUUM9r1Y5au7A==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "451219dc-97d0-4f3a-90d3-a6b3a0d36c6b",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "3a79c859-784b-4e3f-8d8a-02bad775d1d0", "AQAAAAEAACcQAAAAEOFN4lhY8z3sR+I67OtwYU2zosR0YGVZq1zjyR8OWUmyAcC7DEwHESlk5yqrzFDsaA==" });

            migrationBuilder.UpdateData(
                table: "TextFields",
                keyColumn: "Id",
                keyValue: new Guid("4aa76a4c-c59d-409a-84c1-06e6487a137a"),
                column: "DateAdded",
                value: new DateTime(2022, 5, 28, 12, 19, 35, 672, DateTimeKind.Utc).AddTicks(4016));

            migrationBuilder.UpdateData(
                table: "TextFields",
                keyColumn: "Id",
                keyValue: new Guid("63dc8fa6-07ae-4391-8916-e057f71239ce"),
                column: "DateAdded",
                value: new DateTime(2022, 5, 28, 12, 19, 35, 672, DateTimeKind.Utc).AddTicks(3105));

            migrationBuilder.UpdateData(
                table: "TextFields",
                keyColumn: "Id",
                keyValue: new Guid("ccc0d57c-b438-499c-964b-1a542a908894"),
                column: "DateAdded",
                value: new DateTime(2022, 5, 28, 12, 19, 35, 672, DateTimeKind.Utc).AddTicks(3978));
        }
    }
}
