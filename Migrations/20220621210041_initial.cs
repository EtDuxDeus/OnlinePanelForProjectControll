using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlinePanelForProjectsControl.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Meetings",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    Url = table.Column<string>(nullable: true),
                    DateOfMeet = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Meetings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProjectItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    TitleImagePath = table.Column<string>(nullable: true),
                    MetaTitle = table.Column<string>(nullable: true),
                    MetaDescription = table.Column<string>(nullable: true),
                    MetaKeywords = table.Column<string>(nullable: true),
                    DateAdded = table.Column<DateTime>(nullable: false),
                    Title = table.Column<string>(nullable: false),
                    Subtitle = table.Column<string>(nullable: true),
                    Text = table.Column<string>(nullable: true),
                    DateOfStart = table.Column<DateTime>(nullable: false),
                    PlannedDateOfEnd = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectItems", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TextFields",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Subtitle = table.Column<string>(nullable: true),
                    TitleImagePath = table.Column<string>(nullable: true),
                    MetaTitle = table.Column<string>(nullable: true),
                    MetaDescription = table.Column<string>(nullable: true),
                    MetaKeywords = table.Column<string>(nullable: true),
                    DateAdded = table.Column<DateTime>(nullable: false),
                    CodeWord = table.Column<string>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    Text = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TextFields", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    MeetingId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_Meetings_MeetingId",
                        column: x => x.MeetingId,
                        principalTable: "Meetings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MeetingDevs",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    MeetingId = table.Column<Guid>(nullable: false),
                    DevId = table.Column<string>(nullable: true),
                    DeveloperId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MeetingDevs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MeetingDevs_AspNetUsers_DeveloperId",
                        column: x => x.DeveloperId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MeetingDevs_Meetings_MeetingId",
                        column: x => x.MeetingId,
                        principalTable: "Meetings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProjectDevs",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ProjectId = table.Column<Guid>(nullable: false),
                    DevId = table.Column<string>(nullable: true),
                    DeveloperItemId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectDevs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProjectDevs_AspNetUsers_DeveloperItemId",
                        column: x => x.DeveloperItemId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProjectDevs_ProjectItems_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "ProjectItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProjectTasks",
                columns: table => new
                {
                    TaskID = table.Column<Guid>(nullable: false),
                    ProjectId = table.Column<Guid>(nullable: false),
                    TaskName = table.Column<string>(nullable: true),
                    TaskDescription = table.Column<string>(nullable: true),
                    DeveloperId = table.Column<string>(nullable: true),
                    EstimatedTime = table.Column<int>(nullable: false),
                    SpendedTime = table.Column<int>(nullable: false),
                    isFinished = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectTasks", x => x.TaskID);
                    table.ForeignKey(
                        name: "FK_ProjectTasks_AspNetUsers_DeveloperId",
                        column: x => x.DeveloperId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProjectTasks_ProjectItems_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "ProjectItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "8af10569-b018-4fe7-a380-7d6a14c70b74", "c7daaae1-0a0d-4b25-a6dc-8980efb2771c", "admin", "ADMIN" },
                    { "f917fd6d-a7f9-4212-bbe7-c193cf061ef0", "e00febf0-0de6-4b0c-b2fa-77f84d0e93f2", "user", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "MeetingId", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "3b62472e-4f66-49fa-a20f-e7685b9565d8", 0, "c3b35d56-1f26-4063-a542-9be4e52dd846", "minerukraien@gmail.com", true, false, null, null, "minerukraine@GMAIl.COM", "ADMIN", "AQAAAAEAACcQAAAAENzPI6JKWgqmRHov4gVRhu3+yhGpD386UV28f/rC2OU7vZB0QBu3Nc26xirNYHmY5A==", null, false, "", false, "admin" },
                    { "451219dc-97d0-4f3a-90d3-a6b3a0d36c6b", 0, "e18c4403-aedd-4c4c-b59f-5aad5789e1d1", "user@email.com", true, false, null, null, "USER@EMAIL.COM", "USER", "AQAAAAEAACcQAAAAEAl09q1smBt/eAKEPUp4RaEj4aGq9u83maEs1xSa9D0GqysYMpnNtn4j72FNIfzLsg==", null, false, "", false, "user" },
                    { "90b3e19e-0c62-4a3a-a714-7aabbbf8bab7", 0, "68bc7ccc-e27b-45be-8efe-d77f0ee6121e", "my@email.com", true, false, null, null, "MY@EMAIl.COM", "SNAILKICK", "AQAAAAEAACcQAAAAEK/Juuqc3WdcQ7eoBCSvtX/nhAhxEIICYQFDEjwGwFokjEQhmQ6+kMUy2ya7TpH8Pg==", null, false, "", false, "SnailKick" },
                    { "0722f26e-3067-4740-b8ec-98ef8e379bf7", 0, "eb5f71d0-af2e-4e89-8e6b-06b6395bfdd1", "dev@email.com", true, false, null, null, "DEV@EMAIl.COM", "DEVELOPER", "AQAAAAEAACcQAAAAEJ8DTFmegigANxfM0NSJpqZDPzeCCVy7EvAszEwth2KPY4ZU7OeKTjcsSkBSgmIC0g==", null, false, "", false, "Developer" }
                });

            migrationBuilder.InsertData(
                table: "TextFields",
                columns: new[] { "Id", "CodeWord", "DateAdded", "MetaDescription", "MetaKeywords", "MetaTitle", "Subtitle", "Text", "Title", "TitleImagePath" },
                values: new object[,]
                {
                    { new Guid("63dc8fa6-07ae-4391-8916-e057f71239ce"), "PageIndex", new DateTime(2022, 6, 21, 21, 0, 41, 431, DateTimeKind.Utc).AddTicks(5741), null, null, null, null, "Содержание заполняется администратором", "Главная", null },
                    { new Guid("4aa76a4c-c59d-409a-84c1-06e6487a137a"), "PageContacts", new DateTime(2022, 6, 21, 21, 0, 41, 431, DateTimeKind.Utc).AddTicks(6595), null, null, null, null, "Содержание заполняется администратором", "Контакты", null }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[,]
                {
                    { "3b62472e-4f66-49fa-a20f-e7685b9565d8", "8af10569-b018-4fe7-a380-7d6a14c70b74" },
                    { "451219dc-97d0-4f3a-90d3-a6b3a0d36c6b", "f917fd6d-a7f9-4212-bbe7-c193cf061ef0" },
                    { "90b3e19e-0c62-4a3a-a714-7aabbbf8bab7", "8af10569-b018-4fe7-a380-7d6a14c70b74" },
                    { "0722f26e-3067-4740-b8ec-98ef8e379bf7", "f917fd6d-a7f9-4212-bbe7-c193cf061ef0" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_MeetingId",
                table: "AspNetUsers",
                column: "MeetingId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_MeetingDevs_DeveloperId",
                table: "MeetingDevs",
                column: "DeveloperId");

            migrationBuilder.CreateIndex(
                name: "IX_MeetingDevs_MeetingId",
                table: "MeetingDevs",
                column: "MeetingId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectDevs_DeveloperItemId",
                table: "ProjectDevs",
                column: "DeveloperItemId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectDevs_ProjectId",
                table: "ProjectDevs",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectTasks_DeveloperId",
                table: "ProjectTasks",
                column: "DeveloperId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectTasks_ProjectId",
                table: "ProjectTasks",
                column: "ProjectId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "MeetingDevs");

            migrationBuilder.DropTable(
                name: "ProjectDevs");

            migrationBuilder.DropTable(
                name: "ProjectTasks");

            migrationBuilder.DropTable(
                name: "TextFields");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "ProjectItems");

            migrationBuilder.DropTable(
                name: "Meetings");
        }
    }
}
