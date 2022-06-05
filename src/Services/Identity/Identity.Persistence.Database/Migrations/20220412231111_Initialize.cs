using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Identity.Persistence.Database.Migrations
{
    public partial class Initialize : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Identity");

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                schema: "Identity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                schema: "Identity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreCompleto = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                schema: "Identity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "Identity",
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                schema: "Identity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalSchema: "Identity",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                schema: "Identity",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalSchema: "Identity",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                schema: "Identity",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "Identity",
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalSchema: "Identity",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                schema: "Identity",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalSchema: "Identity",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { 1, "14cc76af-92a8-409d-b45d-d93dbe7ebce8", "Admin", "ADMIN" },
                    { 2, "cc1a07a1-0f60-43c2-95cf-d1c461a31418", "Paciente", "PACIENTE" }
                });

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NombreCompleto", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { 1, 0, "5ccaede5-9c0b-48f1-aafb-230483e69695", null, false, false, null, "Nombres 1 Apellidos 1", null, "ADMIN1", "AQAAAAEAACcQAAAAEFbmuCg6u6G6QSieT2mD0vQzzeel3i7N+s42C5cL18j/Q8hEw2GUE8w/MXSKwbJ5fg==", null, false, "eb08a634-e4d9-4d0e-aaad-0cdc23a7dd12", false, "admin1" },
                    { 2, 0, "07646027-dc8c-4170-a85a-95a872752cb6", null, false, false, null, "Nombres 2 Apellidos 2", null, "ADMIN2", "AQAAAAEAACcQAAAAEIQCoj1FtcI3V97BNcIeRJQOJIwR4oe8uCWHVF6nDvAiPmR1JSJZmms8X+xUnGxs0Q==", null, false, "5f14a334-ea51-4d1d-bc5c-c5ef1d832a13", false, "admin2" },
                    { 3, 0, "0d2e4fb4-99cb-4394-8481-36c6e7433188", null, false, false, null, "Nombres 3 Apellidos 3", null, "ADMIN3", "AQAAAAEAACcQAAAAEN+cxFGJI5Z62VnEzaI+KUsV+OCz2VlBSFrdf1iButyEv4/BQuuxqB2+LdpPXrvQsw==", null, false, "a0ebc577-e4a9-4853-8a96-0a518ef9b6be", false, "admin3" },
                    { 4, 0, "714d89b2-7ccf-4dc9-8fac-835394819c02", null, false, false, null, "Nombres 4 Apellidos 4", null, "ADMIN4", "AQAAAAEAACcQAAAAELwpqa0dMzg2hsoLgi7swPbOIc0GCYcbUxHwVMsxMBVAFkHo4QLwFaxaHwycEeNAOw==", null, false, "20bc3214-e54c-4755-87cb-9de1fefdc82f", false, "admin4" },
                    { 5, 0, "b14fdbfb-ea43-45d2-96f3-bee9f2c84089", null, false, false, null, "Nombres 5 Apellidos 5", null, "ADMIN5", "AQAAAAEAACcQAAAAEJu6ACJSFdUkKlSYqHCLuHvj0F+2GGKvnk9nqG7a+TvOqafUDJCcp6/sYXCxiSIsvg==", null, false, "9e9de612-9e33-41dd-a875-c7ea6c811927", false, "admin5" },
                    { 6, 0, "9a157b2f-2981-41ee-b051-b12a39764ee4", null, false, false, null, "Nombres 6 Apellidos 6", null, "ADMIN6", "AQAAAAEAACcQAAAAEBXfVZmJEg3mNF2wWQJFwhYFeQec6ouWV8fKLLj0xoVjcmmBou22GRBYwguRW6GRNA==", null, false, "03d96a7a-31b8-4da9-a110-059e90e01f6d", false, "admin6" },
                    { 7, 0, "75ede969-38d9-4967-a11f-0762081ddfe1", null, false, false, null, "Nombres 7 Apellidos 7", null, "ADMIN7", "AQAAAAEAACcQAAAAEP7Hn7boBtUkCKG8VDNfc2Go21gwIP/0YRPkzSJsdCRCwHutCZsOQIwd5LYbaQd9QQ==", null, false, "b2d426f1-9840-467a-bba1-51ce3a10ec3f", false, "admin7" },
                    { 8, 0, "8489e6d7-83a6-4474-91a8-c350c1b4a6c1", null, false, false, null, "Nombres 8 Apellidos 8", null, "ADMIN8", "AQAAAAEAACcQAAAAEGfCs3GHbrq/hffZkfzXlhyxKAvGhqpBVi6Vbb7FJ4CxXqiwqZBoAqdcLLQ0RVyafw==", null, false, "5875d3ec-b55b-4416-8b50-54218e628d38", false, "admin8" },
                    { 9, 0, "25950234-19b5-47d0-8ca3-376dc4ba1af3", null, false, false, null, "Nombres 9 Apellidos 9", null, "ADMIN9", "AQAAAAEAACcQAAAAEJiJpzKfFUfnls2WvNA87gVP/XwTSdEl+ISqLhUFINEsxO0wzghUJdLpvAJCkDEKNQ==", null, false, "7700b540-89e9-4842-abbc-57bcbb3ba3fa", false, "admin9" },
                    { 10, 0, "9e615bc4-6b5e-4e03-83d6-6239007cd4f6", null, false, false, null, "Nombres 10 Apellidos 10", null, "ADMIN10", "AQAAAAEAACcQAAAAEIxcH9sZQVJNJ8ioeqogVx6TGmez7dDqY6QFWOn6oRagULvb6UNi649TUH3n+a253A==", null, false, "7bdd0025-8bb7-4134-bc05-14bbe5364531", false, "admin10" },
                    { 11, 0, "c5ccd026-e526-44b3-83e8-57c7891055e4", null, false, false, null, "Nombres 1 Apellidos 1", null, "PACIENTE1", "AQAAAAEAACcQAAAAECYMzK5Lb+WD4x00KOC0So+s51rCumLgoh8y4VCJorUp4lWa3za/n6KKtz7IgZNvRA==", null, false, "1f30b90f-dca5-4e91-a634-d8ff3b3e3679", false, "paciente1" },
                    { 12, 0, "a8343008-051a-4262-b06d-8a5c567dbfd2", null, false, false, null, "Nombres 2 Apellidos 2", null, "PACIENTE2", "AQAAAAEAACcQAAAAEMilBZepCUwH4OeOhmINZh9XNG0Kw9az6MM53uronjRy88gae9Xflr9uzhWRMKOQNQ==", null, false, "043d2599-4ba3-4ba4-952a-17d38e9074f0", false, "paciente2" },
                    { 13, 0, "02cda644-f818-4033-81f1-980a1be7e7a1", null, false, false, null, "Nombres 3 Apellidos 3", null, "PACIENTE3", "AQAAAAEAACcQAAAAEA2kTYUCNbVamgcPm9auwCNAVFcwS9h37aNLLmQyosW5YB1W0l1jRw6y3LBrH5f/MQ==", null, false, "82821194-6c5a-4c0c-ab8a-9d65519b5aa1", false, "paciente3" },
                    { 14, 0, "318ba7e4-4d55-493d-9e60-9d2f90d51b3a", null, false, false, null, "Nombres 4 Apellidos 4", null, "PACIENTE4", "AQAAAAEAACcQAAAAEB0on7fJBCbwmuo2055BLRva3bKDB9fXp+PwqoLVo+rF4iDXT4SzTWN8H0kxHNn6kA==", null, false, "eb1b84d6-25cc-4e47-a466-7e4981ff3eb0", false, "paciente4" },
                    { 15, 0, "01ad3e3c-f358-4662-a626-077754d9f7cc", null, false, false, null, "Nombres 5 Apellidos 5", null, "PACIENTE5", "AQAAAAEAACcQAAAAEOc3Wg5eYPCarLLyBhHlwftOb56cglNcuiITHrDiIOykxGkqGn6nzEOWJiAKMk0DZQ==", null, false, "01f109fc-53c7-434f-945e-fbf1f12b42c6", false, "paciente5" },
                    { 16, 0, "c43ce31b-34ed-4353-b544-ae085bc8979f", null, false, false, null, "Nombres 6 Apellidos 6", null, "PACIENTE6", "AQAAAAEAACcQAAAAEO1Zy5coIzv2A9+IOiiqVCr5i1jeXYKx7cIuDSEjlfVJuYpkU9eQmshsTJnbh+HgtQ==", null, false, "fd010372-cc71-4380-ab56-6789b6dfd8a4", false, "paciente6" },
                    { 17, 0, "3ecb4c81-774e-499c-9de2-7f5791edd004", null, false, false, null, "Nombres 7 Apellidos 7", null, "PACIENTE7", "AQAAAAEAACcQAAAAEGOTLPpAoVidgwbniyE3F6T3e4uwYZS9qzgRR1kznrLGVqRTYbVBBlPb3VUnVVnpxg==", null, false, "795f2f91-1ecf-4a16-983c-46da428aa308", false, "paciente7" },
                    { 18, 0, "2bdd46a4-250c-4148-bd2d-61a9731c692a", null, false, false, null, "Nombres 8 Apellidos 8", null, "PACIENTE8", "AQAAAAEAACcQAAAAEJ7MmI7GgVw6ym1Y4o/0KpH+Zcz6+u5QLtf+W20Oj7cgoSjctqHIIT0hK+aXSd8JYg==", null, false, "a46fe84a-06cf-4291-912f-e35109c99915", false, "paciente8" },
                    { 19, 0, "4646e067-9e94-46bc-afff-be08d46589cf", null, false, false, null, "Nombres 9 Apellidos 9", null, "PACIENTE9", "AQAAAAEAACcQAAAAEAq+xlGbHzSmY/E3meqvYf1DsmUiB5Ekn2C1dO5KVypeGd/vgjYQiIS06snlHkRqCA==", null, false, "b249b559-2809-43d5-8d76-1f9c9203b0fe", false, "paciente9" },
                    { 20, 0, "41cfd580-487d-47bc-b732-46baf5ea66b0", null, false, false, null, "Nombres 10 Apellidos 10", null, "PACIENTE10", "AQAAAAEAACcQAAAAEI2FijsbNpYv9pyvSSRIGtEcxV8I/qym4bXkMsWWzYIao2zn0FwItW9nHsmyYbsXLA==", null, false, "e251b614-202c-4932-9b87-0331b9005d6f", false, "paciente10" },
                    { 21, 0, "26e569c6-821e-40f9-bd39-acabda4a4ab7", null, false, false, null, "Nombres 11 Apellidos 11", null, "PACIENTE11", "AQAAAAEAACcQAAAAEH0UjWdB9gcI4ncz9b1wKhgvSXYCGQBsmP/0F8ZxkUQUnq8ds/fVXMK89cto8mc0eA==", null, false, "754d6394-c9a9-4f1e-b54c-15afa9adaee9", false, "paciente11" },
                    { 22, 0, "6e161533-e5a1-4cf7-b50d-b3d198c6ec58", null, false, false, null, "Nombres 12 Apellidos 12", null, "PACIENTE12", "AQAAAAEAACcQAAAAEO8bAfzO/DUUXOvIH7sn/+wbpL2Tiv5xX4/53NxGrKWm/V/QMj/0Gae5oHqlMqR+Zw==", null, false, "57203b92-454d-4fe7-8e23-1cb3a4f1e9fc", false, "paciente12" },
                    { 23, 0, "84b4a01c-6cb2-4e7f-8bb6-6638804ad90b", null, false, false, null, "Nombres 13 Apellidos 13", null, "PACIENTE13", "AQAAAAEAACcQAAAAEG4h4mxr2mBEhxK/mGHRYnpwt4ZepR6lckndLfT63bMU6I1jMJ6LPbZrqomRXmMP4g==", null, false, "3bb60eb4-3777-4fae-90bd-334fd9d8861f", false, "paciente13" },
                    { 24, 0, "1c026fda-37f9-4d9b-a069-0f462f608bd9", null, false, false, null, "Nombres 14 Apellidos 14", null, "PACIENTE14", "AQAAAAEAACcQAAAAEFVIkxbSHlaCrJcAuFCfsHzck/DpItK/N9n1zapdLKCq5D26r754ZFbZkgfJyVba5w==", null, false, "ddd4f7e4-fe38-4f62-a39a-427c14278730", false, "paciente14" },
                    { 25, 0, "7e92d06c-ea47-4d57-bd31-3c5a2beebe30", null, false, false, null, "Nombres 15 Apellidos 15", null, "PACIENTE15", "AQAAAAEAACcQAAAAEEg5lu9qdmlcmCvvYUGrODI9ZOQJAHlB1LrKdYPnLYDbicZPVBvC/swQ1aZMdDQTug==", null, false, "747d60ab-f93a-45d6-8d79-80370327adca", false, "paciente15" },
                    { 26, 0, "98fc7ae8-1929-473a-b9fb-d6a1f5a4eff4", null, false, false, null, "Nombres 16 Apellidos 16", null, "PACIENTE16", "AQAAAAEAACcQAAAAENakCvQrDUqv5tPU3WQqYU6HMLT7eHjFnZvc0IbS1o1eDX/zSNlznpbKS/wobF8Avg==", null, false, "a7b8c21b-8bf4-458c-ab41-1d81850ea8b9", false, "paciente16" },
                    { 27, 0, "329d2f74-8cdb-4ab3-aa97-1dd5142a1ccd", null, false, false, null, "Nombres 17 Apellidos 17", null, "PACIENTE17", "AQAAAAEAACcQAAAAEIPwq/rEigvnE3hS4uyO0L/qozQfCk5e3AoCmwA7Dt+L0PCz7n9VXdnrpi5oFzvc7g==", null, false, "335e6dad-d5e9-40fc-a148-1ec54fa80f27", false, "paciente17" },
                    { 28, 0, "357583fc-61b1-49fc-983e-a6a6d2236770", null, false, false, null, "Nombres 18 Apellidos 18", null, "PACIENTE18", "AQAAAAEAACcQAAAAEGnWOJhx9q6czi65MhO0V2yd45h77qSR/MhLIE54ED0LTbqTksoX4btEJVrfjmesfA==", null, false, "6e1c0aa8-5994-40ff-83c5-215b2781cb7c", false, "paciente18" },
                    { 29, 0, "c4c71690-8ee5-4b1b-9129-ee4dfd451b84", null, false, false, null, "Nombres 19 Apellidos 19", null, "PACIENTE19", "AQAAAAEAACcQAAAAEPjk/ZHyidlTROK4uR4c17b8OfqDdpzHufNAnbJk+qPSFXZG+tg09cqOWDOteTaeHQ==", null, false, "fef10f4f-32df-4aa9-8a48-cc46cfb5eefc", false, "paciente19" },
                    { 30, 0, "6bfff6b8-f1b4-495d-9ea0-dab78e89fa1a", null, false, false, null, "Nombres 20 Apellidos 20", null, "PACIENTE20", "AQAAAAEAACcQAAAAEK5UR/yoHEb3hckBjzoAOnbKODC7/qjg2+fVSCSaGxdr+O+VZ2LQse2hCadY0tgKUw==", null, false, "c984f014-a8cc-49a1-8f51-2429cdc9b108", false, "paciente20" },
                    { 31, 0, "25bb461d-2408-4fa8-9b37-1f4a30cb25a1", null, false, false, null, "Nombres 21 Apellidos 21", null, "PACIENTE21", "AQAAAAEAACcQAAAAEAJHujknUqmXvNsYSDBAf2GRbDbqmlvp3CgJv6D2NfCoFUvcNM2mT2b9MTbVe+DHGg==", null, false, "43b91946-1c10-4612-a52e-6f67efd79f16", false, "paciente21" },
                    { 32, 0, "0dd2416b-e93a-4bdc-83a8-4611e60ac69f", null, false, false, null, "Nombres 22 Apellidos 22", null, "PACIENTE22", "AQAAAAEAACcQAAAAEM9fIpm1OjJCrvGuQ3zBn2c3MKkttX/Zdy5S+L1x1Acgb4ZJ60GJCEGUeK9lnKDD9w==", null, false, "9375050a-6af4-47fb-ac60-a8d8cd810e32", false, "paciente22" },
                    { 33, 0, "f3a90d55-c564-4215-aa31-5c0e8cfe76d4", null, false, false, null, "Nombres 23 Apellidos 23", null, "PACIENTE23", "AQAAAAEAACcQAAAAELetDBoHHryHp/e3b+j3IWxFjXBtktloilsIZccPc2yVp7CotnV4xkFV3q9RKQEE7w==", null, false, "3f830fa3-f9cf-43cc-917f-7919f70d1caf", false, "paciente23" },
                    { 34, 0, "6d83b889-349e-48fe-b34a-fd110ce741ab", null, false, false, null, "Nombres 24 Apellidos 24", null, "PACIENTE24", "AQAAAAEAACcQAAAAEIPnjpPCT5OOrB6syBn6h3CJaqhAqPOt+1WUAZMMlllNGCtnDFbd6lYSReL6yr/d6Q==", null, false, "ba3289bc-610d-4bd8-8099-b7bdff5b6bbd", false, "paciente24" },
                    { 35, 0, "8809f14b-1b83-459f-b590-6aeb35557d3d", null, false, false, null, "Nombres 25 Apellidos 25", null, "PACIENTE25", "AQAAAAEAACcQAAAAENV0OHF8r12u+06iCCKZ6TsBYxNJBJ72A/RkMOUkKT3Omn+qqlJNnTL9cACiZMZB5g==", null, false, "c80cc65b-e66e-4e66-a528-3859ca8f0bdf", false, "paciente25" },
                    { 36, 0, "6e6e1c2b-7a67-474f-a487-d4a47e39b90f", null, false, false, null, "Nombres 26 Apellidos 26", null, "PACIENTE26", "AQAAAAEAACcQAAAAEGtGV7NgcFh5bvPZS/2g/amB9s8fWqVmJLzYN9p15X9ShbUAvgYglfxjzqhP8hM2gA==", null, false, "2544b56b-18e3-4970-a188-cdf15a79da05", false, "paciente26" },
                    { 37, 0, "ebea8304-ebf8-413a-88bb-2770ebf14d9e", null, false, false, null, "Nombres 27 Apellidos 27", null, "PACIENTE27", "AQAAAAEAACcQAAAAEPRlbUdOhAyve2Z0BKnFg2IUZMjWm5MRCklgaMiQE4okeBaBgbyBCyD6RchDCeyokQ==", null, false, "216019ad-525d-4294-896b-8d4ea9789e6e", false, "paciente27" },
                    { 38, 0, "a9b94d0f-80b6-42f1-a603-6f76e2f04605", null, false, false, null, "Nombres 28 Apellidos 28", null, "PACIENTE28", "AQAAAAEAACcQAAAAEFBKeyNclR4FUrt9miWf/D5XyqH6mLqvC320KOQDGeCCW4109aoJr+shd9+bxelUhw==", null, false, "597ca21b-57fd-43eb-8b01-d196814bc22c", false, "paciente28" },
                    { 39, 0, "ef27e67b-b5ca-46e3-9969-2dd95cc3bd38", null, false, false, null, "Nombres 29 Apellidos 29", null, "PACIENTE29", "AQAAAAEAACcQAAAAEMXfd7gyZC+XMBwAwWAlm9t6wG/BpiALLE5xlj07sKcLgFopnn62TfJBJdtYUVRPjQ==", null, false, "67eae156-7558-49a5-9e86-ff7c578afd7b", false, "paciente29" },
                    { 40, 0, "e1806aef-ea44-4285-986e-13d49dff122f", null, false, false, null, "Nombres 30 Apellidos 30", null, "PACIENTE30", "AQAAAAEAACcQAAAAEHFELoPBmO3V6hQ9rAMZkXlTuR8VCwLvuLNWykpbpQEvl9h7r3Y8Ibw/zey7HyT2cw==", null, false, "4f53bc17-a557-48f6-a8bf-787765579d4f", false, "paciente30" }
                });

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NombreCompleto", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { 41, 0, "e95929cf-3627-45f9-95d4-7ad343a57332", null, false, false, null, "Nombres 31 Apellidos 31", null, "PACIENTE31", "AQAAAAEAACcQAAAAEM5ONyeDwIrhf2E0LpGbtC44NgcUfFFL52OoNdverWTX/hKAn0jUGkdXwHMPw3DDVw==", null, false, "82e263d0-56bc-4667-9b0d-d0a2db8c30c3", false, "paciente31" },
                    { 42, 0, "8c11618a-c4ef-4730-8a70-81ccabac3aa0", null, false, false, null, "Nombres 32 Apellidos 32", null, "PACIENTE32", "AQAAAAEAACcQAAAAEC4dP04srdFkMYiH1ie0wizlvFKxon4YgERUtGI9HMsrfbkhN3IzeHqlYt47WxLEQQ==", null, false, "3fdbb149-ed1a-4205-8396-5a9629567647", false, "paciente32" },
                    { 43, 0, "04c8ed5d-5255-4586-ab14-6dcd9481884e", null, false, false, null, "Nombres 33 Apellidos 33", null, "PACIENTE33", "AQAAAAEAACcQAAAAEHRXPUxBqxGHnrVuSb0Y9wzCqTvKnqViH6g/R6hQdIaxHzYhDLV+JsDC6BI/KcZoMA==", null, false, "39cf8eef-8e7d-41fa-bbf0-7a0f0f49d803", false, "paciente33" },
                    { 44, 0, "27970974-63c8-4f0d-ad42-2ce18c755b56", null, false, false, null, "Nombres 34 Apellidos 34", null, "PACIENTE34", "AQAAAAEAACcQAAAAEDVsC5JR5S8EwwTtApT3vWR582nQmVuOZepO8Nk1/WHxRMqNF3z/oUj41VTGvBC6yA==", null, false, "2fbdb6a2-60bc-454f-bd5b-349ff9ac779b", false, "paciente34" },
                    { 45, 0, "045320a8-c990-441a-a79a-4db34e7eb216", null, false, false, null, "Nombres 35 Apellidos 35", null, "PACIENTE35", "AQAAAAEAACcQAAAAEAYWfsHw8QwIijljxt4xVDwAFv8FshePhMwe895VjF7vObJuW7XaDDolI26PZ5ffIA==", null, false, "127ef3f6-27dc-41d8-8011-ed995fa408a1", false, "paciente35" },
                    { 46, 0, "b6b4fb21-2ceb-4dc9-be96-9057432ccb68", null, false, false, null, "Nombres 36 Apellidos 36", null, "PACIENTE36", "AQAAAAEAACcQAAAAEDf/8bKmGqZoezYbhxyFk0wqSm2ppyqgJVeoq6Zt4VuBSwqw8kV5c1/SuV/7D7KoDA==", null, false, "9a2c35a8-e608-40e4-9271-0d45f9f83c95", false, "paciente36" },
                    { 47, 0, "1b72b778-09d6-483e-8327-63a100f6b78e", null, false, false, null, "Nombres 37 Apellidos 37", null, "PACIENTE37", "AQAAAAEAACcQAAAAEENwIxVHx5EGRlBnNNSiALs6foy93x6aidM4iPggi/faSVb4nJry0pj9cYG2DH3C8w==", null, false, "31e2cb94-ecc7-4d91-a7b0-b3e901cfa292", false, "paciente37" },
                    { 48, 0, "a75f5254-9b47-47f5-9c24-23fdbd57bbb3", null, false, false, null, "Nombres 38 Apellidos 38", null, "PACIENTE38", "AQAAAAEAACcQAAAAEK+XCIq2r+/CLVpGbE1/Bo3Ns5XvlTIu5LVltOOXgIb0cNXPVd2nHzyckKDhXqCtVA==", null, false, "1e96bfb9-81ef-49ad-ba1e-d487b7560169", false, "paciente38" },
                    { 49, 0, "cca9173a-0e8d-4f89-913a-eb16c381c8c9", null, false, false, null, "Nombres 39 Apellidos 39", null, "PACIENTE39", "AQAAAAEAACcQAAAAEIVGFi/8pLQALtkvScc9B1/hl2aihzJ+kl+ltnlCGl07o4LhWVypQPtwbt/UWLNCGQ==", null, false, "984f6228-c0d9-4fed-b39b-65e889b8e62e", false, "paciente39" },
                    { 50, 0, "436c9304-5dba-4372-9006-0e221b505467", null, false, false, null, "Nombres 40 Apellidos 40", null, "PACIENTE40", "AQAAAAEAACcQAAAAEFQZdxo60MWz8gihhrwskkHNff5LokvLx2cCreSHIsRBIKkT62wKps2Urt3N2HIzOw==", null, false, "383eb44f-5ef5-48fe-b9c0-14fa81409635", false, "paciente40" },
                    { 51, 0, "c0a6becd-5e4f-400b-baa7-99a58a275a46", null, false, false, null, "Nombres 41 Apellidos 41", null, "PACIENTE41", "AQAAAAEAACcQAAAAEHFtPtoGsOh1DywonjvoDF4+375yfWcV0oRg3XHBvbd73VV0Kr40t2nzZEV2xApIOw==", null, false, "0551b04f-9f4a-4016-ae03-ace5af961e02", false, "paciente41" },
                    { 52, 0, "86dc5ff9-84a7-47d8-92e0-7853e7dd65ea", null, false, false, null, "Nombres 42 Apellidos 42", null, "PACIENTE42", "AQAAAAEAACcQAAAAEEn8HRHG9Szuc/DJOVa4twrBnpsMpHftDuVoaKhDTPUt9mHU5eq52oxLIL0nldPSzg==", null, false, "0eac3a9b-826e-4d0c-a5e6-c9ffee27c7ad", false, "paciente42" },
                    { 53, 0, "6ef83fd0-ceb4-427a-bd9f-7b9946e79811", null, false, false, null, "Nombres 43 Apellidos 43", null, "PACIENTE43", "AQAAAAEAACcQAAAAEOl+5+3X3JXoRDoeiPU4Xp2XIKZtt4FoRGdUbyjzAQyczb9A13ZnMbD+hLHOJxFjrw==", null, false, "0fa407ae-73f5-49a1-af3d-b628cc27640a", false, "paciente43" },
                    { 54, 0, "432521f0-7799-461d-a882-dac0508fd416", null, false, false, null, "Nombres 44 Apellidos 44", null, "PACIENTE44", "AQAAAAEAACcQAAAAEDPeLF+zvRuIZiSNw9+s8sN8o42+A7p0fLQHsf70cOYRbfpRhYRAlmAkHouTApbhEA==", null, false, "a3fcbaf7-024a-4b70-ae8d-fe51550872ed", false, "paciente44" },
                    { 55, 0, "5244d529-054e-4aa9-94cf-ae7ee8e14dcc", null, false, false, null, "Nombres 45 Apellidos 45", null, "PACIENTE45", "AQAAAAEAACcQAAAAENbE9aUd5e2MphaIoWrLOVW+33FqdtFl0MuAcPnXg7pShdazigv/hvBpvcFrRZ2Axw==", null, false, "3dc51b12-81d0-4d27-9e42-d4cda537cb8c", false, "paciente45" },
                    { 56, 0, "0814fa94-abb4-4013-84ec-5309887e0235", null, false, false, null, "Nombres 46 Apellidos 46", null, "PACIENTE46", "AQAAAAEAACcQAAAAELBOvqpMW9BoHxEd+lmF0WGO7ibixq1LUtCOe31MIN2CaBNPaLx2kvfrvtcriXeKCA==", null, false, "248babbe-4418-4aec-97fb-1180aad0780f", false, "paciente46" },
                    { 57, 0, "d46e4e57-7a0f-4785-a300-78aa74636899", null, false, false, null, "Nombres 47 Apellidos 47", null, "PACIENTE47", "AQAAAAEAACcQAAAAEOfp47/aOQpo77h4fLIGtCw86Oy88y2j5OQY7sRC/2sERHLkBeAg4fnfedlgdJcrNQ==", null, false, "770e60e3-0380-45e0-9e92-6ec1d59e6b97", false, "paciente47" },
                    { 58, 0, "53fdd4f4-a4c8-4134-81ac-facc1621ce0b", null, false, false, null, "Nombres 48 Apellidos 48", null, "PACIENTE48", "AQAAAAEAACcQAAAAECYx3aNnswvTJmcpQ2Uo9nTZCP+Ga73gg4QBAM6z0p15vC2ObPhWrci7lwzqDi3mKw==", null, false, "a3a856c3-58c9-4a4f-beef-c84454c7b4bd", false, "paciente48" },
                    { 59, 0, "151418ff-5180-4054-8529-ef59bc7c0f7a", null, false, false, null, "Nombres 49 Apellidos 49", null, "PACIENTE49", "AQAAAAEAACcQAAAAEDqyNnl2W1govA2j+GDe5liXLkrY1AHYVwdcTlrM0VDd9TmhP2qX24VB7TNaco4FMA==", null, false, "5e18189e-9b85-4da4-9f7a-5c81694fca37", false, "paciente49" },
                    { 60, 0, "4d2829b9-4803-4443-a309-c5cb2ecd51ff", null, false, false, null, "Nombres 50 Apellidos 50", null, "PACIENTE50", "AQAAAAEAACcQAAAAED6j7sYmpGoNkTMaLzSVoUOlTYQe8ci5H/Axg5vu2CIbsS37cLe9/D0FKV6M59cIag==", null, false, "e791aa17-929b-451b-9808-4e06879dc2a7", false, "paciente50" },
                    { 61, 0, "1e134b0e-5a31-4561-aff0-08bc5168ed0f", null, false, false, null, "Nombres 51 Apellidos 51", null, "PACIENTE51", "AQAAAAEAACcQAAAAEOtlEekXvICjFefd7x3sv9ioHJLcVeuddErWvs6QlOiL2RobtoMkdq+swp/2Qy9lFg==", null, false, "5232cc23-8ac3-45fd-ab89-46538c72af69", false, "paciente51" },
                    { 62, 0, "65f62db8-f530-429a-9c53-5d16ef90899f", null, false, false, null, "Nombres 52 Apellidos 52", null, "PACIENTE52", "AQAAAAEAACcQAAAAEK5+Rb84cCiuL8znaj2ef262EIB7ayz5UPKd0MTvh5z49sshIQYbEIIJ4rTCncQnVA==", null, false, "6f77e0e7-e630-43a6-8431-dd27bd40cd1e", false, "paciente52" },
                    { 63, 0, "082c67c0-a3f1-4c85-9093-e1d1f5ceecc0", null, false, false, null, "Nombres 53 Apellidos 53", null, "PACIENTE53", "AQAAAAEAACcQAAAAEJTBCIbaGKJH3SVlWFSSpggHj3KbvkKJwHd9vvqkde6Zsil9BlnJEcqlNt2wvN7F5w==", null, false, "69b872d7-04b9-4fa3-be06-96cf8ee54b9e", false, "paciente53" },
                    { 64, 0, "c609d40c-ccce-4589-a571-a01c4460a674", null, false, false, null, "Nombres 54 Apellidos 54", null, "PACIENTE54", "AQAAAAEAACcQAAAAEKiBd2eBXEWZNarRQ5ePi+ugCy6G9+o+vebexONv0U1DdZ17nFtIw4w5WAERRcA+6A==", null, false, "333d88d1-fa0a-46ad-8a59-216f0393bddd", false, "paciente54" },
                    { 65, 0, "b99eed65-6503-4c82-b531-97618328ae50", null, false, false, null, "Nombres 55 Apellidos 55", null, "PACIENTE55", "AQAAAAEAACcQAAAAEFbs4HqlVQvYgfpPdt1gzP2lZdf+3XhSn9pxaPqo+wK76owc1LjbNc9Ypo0DdNugGg==", null, false, "d0ca9151-de33-48ab-bc44-ac7e7534d7d2", false, "paciente55" },
                    { 66, 0, "b8982585-82b0-4324-9ebd-2ae9b519e126", null, false, false, null, "Nombres 56 Apellidos 56", null, "PACIENTE56", "AQAAAAEAACcQAAAAEFvDw03kqezd5lWI3RiUzpAPOOUqs/44LgF6f1i83c76bMRYJj8wlpg1esen6wOjsQ==", null, false, "1092aa2d-ac6a-4d66-abae-12b368052b5c", false, "paciente56" },
                    { 67, 0, "3276b7f7-9ed2-4fa1-bb07-ef7023f1b139", null, false, false, null, "Nombres 57 Apellidos 57", null, "PACIENTE57", "AQAAAAEAACcQAAAAEMPgKvGROKVXgwkuW0VUvzy0AzovoY3YAEXQUo3OOkSHHVBmolWM4ltnHmM5ipH3Lw==", null, false, "cb00f673-d1d1-4116-b465-bc47ea99a7e9", false, "paciente57" },
                    { 68, 0, "fc7853e6-3f4a-45bb-8ba8-615f96c8d127", null, false, false, null, "Nombres 58 Apellidos 58", null, "PACIENTE58", "AQAAAAEAACcQAAAAEEDKvqGUeDw52tTL5TRPjmVI9tR9Lx9Iuu5KxElahkzmwNhGueRUIUL9TngoXB1IOA==", null, false, "38d0397a-5965-44bd-b76c-7b52a00dc5db", false, "paciente58" },
                    { 69, 0, "7746bf6a-acf7-499b-876a-3bf92f425022", null, false, false, null, "Nombres 59 Apellidos 59", null, "PACIENTE59", "AQAAAAEAACcQAAAAEByKeQ2YVPdyJH2OPJyc+KAKSrf7/BHBCy3XxWcrYmyIYN4RtU9A/YjP0yNFlf8keA==", null, false, "7ca76447-b811-48e7-9085-316a9228f78b", false, "paciente59" },
                    { 70, 0, "a7e05543-5fb5-4d11-9c20-99589d468f6c", null, false, false, null, "Nombres 60 Apellidos 60", null, "PACIENTE60", "AQAAAAEAACcQAAAAEA5tJqiuCsUscFAmQvEuURMNurnq4xmity/QQQi2ugBeMgwhMbfEuX/0YTwzX3TC+A==", null, false, "0a146ace-23dd-4671-9a84-5aa4d71e9b82", false, "paciente60" },
                    { 71, 0, "a1700f99-a112-4d52-b370-72db0c8a90b1", null, false, false, null, "Nombres 61 Apellidos 61", null, "PACIENTE61", "AQAAAAEAACcQAAAAEAWOvPJ5pYdg4qX9zFnxdlkCeqYk70OlueZcjbpTFPH+dl9CHBpT3VeQS81vko1m/g==", null, false, "e4a35904-4067-4f66-976c-39de9271289b", false, "paciente61" },
                    { 72, 0, "c9b21937-495d-4efa-ad4b-427c6c2ed828", null, false, false, null, "Nombres 62 Apellidos 62", null, "PACIENTE62", "AQAAAAEAACcQAAAAEJKmpLmqy6+/HUP8XsX1TvKQzaFSXeyQlQ30z+M/DL1zNdjodbBWdL7gYJ+N3zCPQw==", null, false, "393682d8-70c8-4351-ab1b-0d7dc88261c4", false, "paciente62" },
                    { 73, 0, "98c3f8ac-177a-4215-9df1-886ddaab29eb", null, false, false, null, "Nombres 63 Apellidos 63", null, "PACIENTE63", "AQAAAAEAACcQAAAAEAvja0MCXPl6mfniOCgk1dRGNDXnxXuxHBKAIDZj60cYs0GrWXitD7Vu/mfAkV2m6Q==", null, false, "05bc24f3-6852-4761-8ed7-4b2ed2830dc6", false, "paciente63" },
                    { 74, 0, "69f99ab6-2b3f-47d8-b6a6-2dbc29e1ae9b", null, false, false, null, "Nombres 64 Apellidos 64", null, "PACIENTE64", "AQAAAAEAACcQAAAAEK/CeJsmW1iAwYC43A1mkRlGV8CrXppDR2MB9YafZBkfZ+ira03W5tS5zsyA/O3OBQ==", null, false, "38a4fce2-27e4-4c8f-ba3f-5708655df7e0", false, "paciente64" },
                    { 75, 0, "5de49715-6017-4625-90c9-38e9b2718925", null, false, false, null, "Nombres 65 Apellidos 65", null, "PACIENTE65", "AQAAAAEAACcQAAAAEOmGer5pVcxKf72EOslJRUt41cLQtlXwCuD1NqWcFY8pBbeLyoiqWvaQkxSTWztiQw==", null, false, "cb24e961-4b7b-43f0-aede-60f55b1a829a", false, "paciente65" },
                    { 76, 0, "6ffcf62c-edab-4a1b-8046-e0986fe23a44", null, false, false, null, "Nombres 66 Apellidos 66", null, "PACIENTE66", "AQAAAAEAACcQAAAAEElpPeVxQF61N28IQ/vtUiM08I+SMjA+6etFFLZXwu6I/fLz9g/hILyadGrVhEpWkg==", null, false, "f7164885-47a0-4d02-84c2-3fee847b0472", false, "paciente66" },
                    { 77, 0, "d5bda3dc-de9c-4b82-ac21-65b1ed2ffd27", null, false, false, null, "Nombres 67 Apellidos 67", null, "PACIENTE67", "AQAAAAEAACcQAAAAEAM2EEqA5beihlNhh/e2gnmUdq9B5EVuYchC/EFf5amdgwe7pL/+Nvi0TvuffVHImQ==", null, false, "f3de405c-f4e0-4638-80dc-0202f65f9dbb", false, "paciente67" },
                    { 78, 0, "e91de7e5-c60e-41e4-a311-0c7685def1aa", null, false, false, null, "Nombres 68 Apellidos 68", null, "PACIENTE68", "AQAAAAEAACcQAAAAEMwqmxhBJgczA4hdD0yaHewRnxRMLN3C3E5iBVq65RTCffgfrJzMndrsduDFiNK77Q==", null, false, "2dc7f618-b37e-4081-9d31-10599aad1f58", false, "paciente68" },
                    { 79, 0, "0171cdaf-a016-4776-8e4e-5eb1c0c4f3e6", null, false, false, null, "Nombres 69 Apellidos 69", null, "PACIENTE69", "AQAAAAEAACcQAAAAEGk+utoCuIBcDc0Xr89p4WgArQ0Tapgkf8xvbICsgSpz7nsOztCkAQv0+5XQkpZwoA==", null, false, "51680d90-0ed9-45f8-9eeb-42d77a03a1dc", false, "paciente69" },
                    { 80, 0, "2e1356af-e92c-4a81-bbcb-4810ade39d55", null, false, false, null, "Nombres 70 Apellidos 70", null, "PACIENTE70", "AQAAAAEAACcQAAAAEDCfniBkgamwUrtL8VHMvSIfQHjCYG4Jjs+SFso3OENNP4SDwlj1GtPcVbqlOBbv9w==", null, false, "9681bb38-ebc4-4fa5-abb9-2e0af3283c51", false, "paciente70" },
                    { 81, 0, "4ec54920-5aee-4b23-80e3-74460e6ea38c", null, false, false, null, "Nombres 71 Apellidos 71", null, "PACIENTE71", "AQAAAAEAACcQAAAAEMISVIaqn1ZF7aZtactlv/pOSPNNO8/NgL0qL3iPhSHIR5ARO6Y9ZmjmiHF+YNL9Vw==", null, false, "5a094042-ad2b-4503-bd97-45006f04d3e8", false, "paciente71" },
                    { 82, 0, "e61235c7-f842-4df9-89df-43c030d08168", null, false, false, null, "Nombres 72 Apellidos 72", null, "PACIENTE72", "AQAAAAEAACcQAAAAEAo1D656pnq79VervDD4yCcvQ3AeUG43tzzN+rG6RzYd7+QhGsE/+ncgypKZxEdiXg==", null, false, "866b8bf8-69c3-4381-821c-5a707bf6b84d", false, "paciente72" }
                });

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NombreCompleto", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { 83, 0, "feac76a6-66af-4347-9772-a4151059fc6a", null, false, false, null, "Nombres 73 Apellidos 73", null, "PACIENTE73", "AQAAAAEAACcQAAAAEMNjwxpdrWN46tcO1YeeK+fRh0oDYaDPKwh7TMrn4Hs5g5H78Dsv47yShG+YvtOLKg==", null, false, "83d60b26-7834-40b7-b548-c711d62ddb8a", false, "paciente73" },
                    { 84, 0, "0f1c5d87-2528-4439-a90a-7b938bceed8a", null, false, false, null, "Nombres 74 Apellidos 74", null, "PACIENTE74", "AQAAAAEAACcQAAAAEISf9h6HmoeLsXyqvjKIMT4mjbdTg6CMbbB7C6/wGTzqGuERJz8UJs3QcbKXCotV9w==", null, false, "2d54873e-42ae-44d3-b447-1d95a414cb99", false, "paciente74" },
                    { 85, 0, "ba7841dc-c8ec-475c-8aca-31f763ea2a17", null, false, false, null, "Nombres 75 Apellidos 75", null, "PACIENTE75", "AQAAAAEAACcQAAAAEMA9xHsKGh6XgHtrVEhRlgOBRwBcdiyAbn+iZL6ftBNVPEcr+GUqeoj5GZ46Ey3P8g==", null, false, "763112ac-dd74-41ff-ad13-5b923f7209d6", false, "paciente75" },
                    { 86, 0, "4b35bf53-94c8-4a92-8ac7-05a0f3c0aa06", null, false, false, null, "Nombres 76 Apellidos 76", null, "PACIENTE76", "AQAAAAEAACcQAAAAEBCr6Q6OeWekKl0M6CzYoZrVbCc4CIPRrkMzukEuuRSDtQA6GnkzVFFuxOUyx89abA==", null, false, "0f62e4d4-7558-4ff3-a165-63549f58a8d6", false, "paciente76" },
                    { 87, 0, "f0fa8608-6f08-4247-9b29-244c9e0a4d55", null, false, false, null, "Nombres 77 Apellidos 77", null, "PACIENTE77", "AQAAAAEAACcQAAAAEFq9fTClJdfoS9YXOlbciCl7yAMaMcu/7rT6QpSoLnUCJsknqR/ddZZ4nXskPJN9wg==", null, false, "582e143c-376f-4498-8bb6-24ce91e92288", false, "paciente77" },
                    { 88, 0, "fa3c7915-f027-4965-8f42-869e388a8412", null, false, false, null, "Nombres 78 Apellidos 78", null, "PACIENTE78", "AQAAAAEAACcQAAAAEEhb/OqNbQ7XrbOXG+elk7+iAIRpE+2unUgv5nsgEuWP7MF/P2SPqNVXoxwvi93HFQ==", null, false, "6e686eb1-dd48-4559-b65d-c52c85bbda0d", false, "paciente78" },
                    { 89, 0, "a1b01f3a-ca89-4e36-bbf4-cf2e1b1482ce", null, false, false, null, "Nombres 79 Apellidos 79", null, "PACIENTE79", "AQAAAAEAACcQAAAAEKzN4NdCl1LsDih2m1HZn+kg5SaTEeQBCWb50i2zAc7kLoJ3SX6a2Lbg8IjKm3lbcg==", null, false, "4441ba94-b617-4dcc-b129-728ff1d0a858", false, "paciente79" },
                    { 90, 0, "aa9bd450-96a7-4c4a-9bd8-8bef125f0b41", null, false, false, null, "Nombres 80 Apellidos 80", null, "PACIENTE80", "AQAAAAEAACcQAAAAEOti7o0YnQl8IskQWat2d3hIzYxJtbiY7/RAGxjyqUc02qU0IViiW9Sx+AG30P2LCw==", null, false, "0cac3003-1f50-45e8-8bf3-b401bdaf97a5", false, "paciente80" },
                    { 91, 0, "e66e318d-8335-41cf-9343-1ddb15009f85", null, false, false, null, "Nombres 81 Apellidos 81", null, "PACIENTE81", "AQAAAAEAACcQAAAAEM/M/1rHu1JBIdbXvH07KJzv0gUFGP+/tiuDCjW8PJwsjJ/zM67At72sr2t1vx3R7Q==", null, false, "91343995-b5dd-4459-a16b-21b5cd07ea77", false, "paciente81" },
                    { 92, 0, "37cc46fd-846a-47f6-8f2b-f9b7280c7901", null, false, false, null, "Nombres 82 Apellidos 82", null, "PACIENTE82", "AQAAAAEAACcQAAAAENV8oOXZ/kMZi9NiU5CXi0O3exxQvvK0lnyWyZSXjbSvUa3AiiT17zOrDiSbnQqkxA==", null, false, "345872f3-1f77-43db-b39c-a38ecdd15938", false, "paciente82" },
                    { 93, 0, "0482771f-d621-4356-abea-709c2c195933", null, false, false, null, "Nombres 83 Apellidos 83", null, "PACIENTE83", "AQAAAAEAACcQAAAAEGhQmMd2NoswVHnfURQ7Q/gjdN7RhRNxDDsCgDWY1T5VYYtD56YkkCQO0JNX/rSIJw==", null, false, "52046b81-9b85-49e4-9826-0b1e12ebc0cb", false, "paciente83" },
                    { 94, 0, "63262a3a-0a09-42e5-8205-d080545a3f45", null, false, false, null, "Nombres 84 Apellidos 84", null, "PACIENTE84", "AQAAAAEAACcQAAAAEGBvhW1RI+7R1c7N3hM871Ry34f0IevkOlYB7bxQ9upv9dIE1ibbhNIJy/nzxUKwHQ==", null, false, "c6a873e7-26e4-4d35-9612-9355efea880b", false, "paciente84" },
                    { 95, 0, "634815c7-f09c-4609-b5ea-0ed23da75302", null, false, false, null, "Nombres 85 Apellidos 85", null, "PACIENTE85", "AQAAAAEAACcQAAAAECXl3ZixF4TjvojNM6brfX5fcpNDwiSjOrxXVTVsHcXL92/tIKGI/c8i2Hz98RUCgw==", null, false, "695ea145-277b-479e-9fed-ef7dd212d99c", false, "paciente85" },
                    { 96, 0, "a507803d-1f98-482c-b752-bf95dfd4335c", null, false, false, null, "Nombres 86 Apellidos 86", null, "PACIENTE86", "AQAAAAEAACcQAAAAEJkFScjh9z2QYDKggHJ94qot8m+DoN051mXVtP7+F/CK7R6aXWQQWjiMKzNaqWlGmQ==", null, false, "057df67f-d2c5-4581-a2ea-25950d8556af", false, "paciente86" },
                    { 97, 0, "a32f6221-0d68-4c60-a947-71cf7d39b8c5", null, false, false, null, "Nombres 87 Apellidos 87", null, "PACIENTE87", "AQAAAAEAACcQAAAAEKDEbYP8ysdQMJdKR/u2BigTOgAgR8bQ0UFnT4GF/h7s/JGV6QbwPDCd6udlTBAjXA==", null, false, "a78b0f45-f169-4ef1-b577-12519d24dabe", false, "paciente87" },
                    { 98, 0, "ad826989-7e8a-425c-ac3e-b685837b26cf", null, false, false, null, "Nombres 88 Apellidos 88", null, "PACIENTE88", "AQAAAAEAACcQAAAAEKs0AetReecpM2CNp4VtSvmFCrXZ1B3qArJpU7VQQQoW2uWdRgUJIz7zrHXy2SvD0A==", null, false, "d8510590-3673-47a9-b5b1-370052a4a8fb", false, "paciente88" },
                    { 99, 0, "5622968f-4a64-45cd-bafc-d94d7223849c", null, false, false, null, "Nombres 89 Apellidos 89", null, "PACIENTE89", "AQAAAAEAACcQAAAAEBm0ll1qt8zCrmRcBsprrNpGsZsAU5BnmQH9ShzJXqSr0hy/2Ot8NbQNB4GxGmlaJw==", null, false, "65224fb3-4904-49b3-84a3-476b3792fdf8", false, "paciente89" },
                    { 100, 0, "189afc0e-65a9-4a0c-9446-313263b83009", null, false, false, null, "Nombres 90 Apellidos 90", null, "PACIENTE90", "AQAAAAEAACcQAAAAEA+QHiJ13/TSW7R8BB6gVi3vx/fqyoxvEL05FFFy34FoKAu41koGDddLe33MiWiCJg==", null, false, "fa883aee-78fc-45a6-b2a1-c3734821c3d9", false, "paciente90" },
                    { 101, 0, "23261bd3-caa6-46ea-a90b-5866cdfc64a4", null, false, false, null, "Nombres 91 Apellidos 91", null, "PACIENTE91", "AQAAAAEAACcQAAAAEJhvQcZu9DdNUv6RSoAcpeUFzwqKB6o7jBPEG3bULmGfxquKOSKhs8F0WLTMm+MN0A==", null, false, "9afcf145-f3d9-4787-8516-15184f68dbc4", false, "paciente91" },
                    { 102, 0, "c2367b05-d1aa-41a2-87a8-242b02f1c0bb", null, false, false, null, "Nombres 92 Apellidos 92", null, "PACIENTE92", "AQAAAAEAACcQAAAAEMxm+gghU6IdsLxGWGPZRa2DMadVDLa5a1VoisM67h1YVcnleSSLesj19pOWitSgpA==", null, false, "eb92399b-7153-4379-a5e8-9dec7fa34f6a", false, "paciente92" },
                    { 103, 0, "b1170482-e024-4805-b3ce-c71b3b44a0f2", null, false, false, null, "Nombres 93 Apellidos 93", null, "PACIENTE93", "AQAAAAEAACcQAAAAEGVkexjAOQYGE5poMvzH3aQj3hdhIzaHYtbGxvuoHKh2mtbeuIouOIj/Sffr0n6S1g==", null, false, "4ab423a0-d308-48b2-ba71-43d22705c8b5", false, "paciente93" },
                    { 104, 0, "9f543d15-0170-49ee-803b-fdb6788b34e5", null, false, false, null, "Nombres 94 Apellidos 94", null, "PACIENTE94", "AQAAAAEAACcQAAAAEMdVOkWyusm26OxrkQvbdW6yAuE9ajAEekMIr5w4dHgUyUh5VhPhdAhUv3Xj6+f0fg==", null, false, "51df2fc5-87d3-4789-b1d7-58d7f0aeb06a", false, "paciente94" },
                    { 105, 0, "9c361288-69c2-45b6-aa40-b3004e63e547", null, false, false, null, "Nombres 95 Apellidos 95", null, "PACIENTE95", "AQAAAAEAACcQAAAAELb6gf3FDbnySU31P1W7mQmKC/HXug3ejlGt+IIZa8Ym+S17qaIaF8W9baWIM3hlpA==", null, false, "fbca7890-1793-4229-97da-c379e2c5af9a", false, "paciente95" },
                    { 106, 0, "c2b6b159-23d6-4237-af8b-fed8b0ee36ec", null, false, false, null, "Nombres 96 Apellidos 96", null, "PACIENTE96", "AQAAAAEAACcQAAAAEHb8O4uLfYsylrnv01VQYuUMxqO9nTf+KdUBwP/40+xyXcbY8zCSPJUewiYc9O8uTg==", null, false, "041e978a-b7ef-40e3-be0b-31aab583e99c", false, "paciente96" },
                    { 107, 0, "5a9170ec-9594-4027-a804-69f6af96b578", null, false, false, null, "Nombres 97 Apellidos 97", null, "PACIENTE97", "AQAAAAEAACcQAAAAEJUGgkjKeoU87ssJmbTGJanBqLCTlFKbTx6YOCZ2nMIXAdxju5f07xYMdn7Cq4enIg==", null, false, "5618bef6-8d42-47db-ac64-9e2f0ab31673", false, "paciente97" },
                    { 108, 0, "c165554f-b423-4f4b-919b-28c0ee606ffa", null, false, false, null, "Nombres 98 Apellidos 98", null, "PACIENTE98", "AQAAAAEAACcQAAAAEFzpJC2F9LIjNsaaJjdJfyV9Qv+OP+n1Z+cYtkyDPE1TMYrdZKcw857WLd0kITK9CQ==", null, false, "ae3d3f7a-8623-4361-87f2-d5fcef77d5ce", false, "paciente98" },
                    { 109, 0, "44504141-d0fa-44d9-a637-a9df3841935e", null, false, false, null, "Nombres 99 Apellidos 99", null, "PACIENTE99", "AQAAAAEAACcQAAAAEAhOvkZV/tA/GSepGFOZKNtolDhsmh2OhC8gC6A8Am0CTOdazpuLbIiGo4/JJOE9Aw==", null, false, "e8190010-34c8-485b-ba50-79ca02df2eb1", false, "paciente99" },
                    { 110, 0, "2d624449-9fa1-4437-9aa8-e32c9c3200ff", null, false, false, null, "Nombres 100 Apellidos 100", null, "PACIENTE100", "AQAAAAEAACcQAAAAEFTa3H93/5wFXNsYBCto7AqlxiwkzkRFTXCl7ImdsKtd2Pa22n3TNCR4+ANSTTgeVA==", null, false, "6ef731d9-b3c6-47f7-8f73-6e79f82aed1b", false, "paciente100" }
                });

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId", "Discriminator" },
                values: new object[,]
                {
                    { 1, 1, "RolUsuario" },
                    { 1, 2, "RolUsuario" },
                    { 1, 3, "RolUsuario" },
                    { 1, 4, "RolUsuario" },
                    { 1, 5, "RolUsuario" },
                    { 1, 6, "RolUsuario" },
                    { 1, 7, "RolUsuario" },
                    { 1, 8, "RolUsuario" },
                    { 1, 9, "RolUsuario" },
                    { 1, 10, "RolUsuario" },
                    { 2, 11, "RolUsuario" },
                    { 2, 12, "RolUsuario" },
                    { 2, 13, "RolUsuario" },
                    { 2, 14, "RolUsuario" },
                    { 2, 15, "RolUsuario" },
                    { 2, 16, "RolUsuario" },
                    { 2, 17, "RolUsuario" },
                    { 2, 18, "RolUsuario" },
                    { 2, 19, "RolUsuario" },
                    { 2, 20, "RolUsuario" },
                    { 2, 21, "RolUsuario" },
                    { 2, 22, "RolUsuario" },
                    { 2, 23, "RolUsuario" },
                    { 2, 24, "RolUsuario" },
                    { 2, 25, "RolUsuario" },
                    { 2, 26, "RolUsuario" },
                    { 2, 27, "RolUsuario" },
                    { 2, 28, "RolUsuario" },
                    { 2, 29, "RolUsuario" },
                    { 2, 30, "RolUsuario" },
                    { 2, 31, "RolUsuario" },
                    { 2, 32, "RolUsuario" },
                    { 2, 33, "RolUsuario" },
                    { 2, 34, "RolUsuario" },
                    { 2, 35, "RolUsuario" },
                    { 2, 36, "RolUsuario" },
                    { 2, 37, "RolUsuario" },
                    { 2, 38, "RolUsuario" },
                    { 2, 39, "RolUsuario" },
                    { 2, 40, "RolUsuario" },
                    { 2, 41, "RolUsuario" },
                    { 2, 42, "RolUsuario" }
                });

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId", "Discriminator" },
                values: new object[,]
                {
                    { 2, 43, "RolUsuario" },
                    { 2, 44, "RolUsuario" },
                    { 2, 45, "RolUsuario" },
                    { 2, 46, "RolUsuario" },
                    { 2, 47, "RolUsuario" },
                    { 2, 48, "RolUsuario" },
                    { 2, 49, "RolUsuario" },
                    { 2, 50, "RolUsuario" },
                    { 2, 51, "RolUsuario" },
                    { 2, 52, "RolUsuario" },
                    { 2, 53, "RolUsuario" },
                    { 2, 54, "RolUsuario" },
                    { 2, 55, "RolUsuario" },
                    { 2, 56, "RolUsuario" },
                    { 2, 57, "RolUsuario" },
                    { 2, 58, "RolUsuario" },
                    { 2, 59, "RolUsuario" },
                    { 2, 60, "RolUsuario" },
                    { 2, 61, "RolUsuario" },
                    { 2, 62, "RolUsuario" },
                    { 2, 63, "RolUsuario" },
                    { 2, 64, "RolUsuario" },
                    { 2, 65, "RolUsuario" },
                    { 2, 66, "RolUsuario" },
                    { 2, 67, "RolUsuario" },
                    { 2, 68, "RolUsuario" },
                    { 2, 69, "RolUsuario" },
                    { 2, 70, "RolUsuario" },
                    { 2, 71, "RolUsuario" },
                    { 2, 72, "RolUsuario" },
                    { 2, 73, "RolUsuario" },
                    { 2, 74, "RolUsuario" },
                    { 2, 75, "RolUsuario" },
                    { 2, 76, "RolUsuario" },
                    { 2, 77, "RolUsuario" },
                    { 2, 78, "RolUsuario" },
                    { 2, 79, "RolUsuario" },
                    { 2, 80, "RolUsuario" },
                    { 2, 81, "RolUsuario" },
                    { 2, 82, "RolUsuario" },
                    { 2, 83, "RolUsuario" },
                    { 2, 84, "RolUsuario" }
                });

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId", "Discriminator" },
                values: new object[,]
                {
                    { 2, 85, "RolUsuario" },
                    { 2, 86, "RolUsuario" },
                    { 2, 87, "RolUsuario" },
                    { 2, 88, "RolUsuario" },
                    { 2, 89, "RolUsuario" },
                    { 2, 90, "RolUsuario" },
                    { 2, 91, "RolUsuario" },
                    { 2, 92, "RolUsuario" },
                    { 2, 93, "RolUsuario" },
                    { 2, 94, "RolUsuario" },
                    { 2, 95, "RolUsuario" },
                    { 2, 96, "RolUsuario" },
                    { 2, 97, "RolUsuario" },
                    { 2, 98, "RolUsuario" },
                    { 2, 99, "RolUsuario" },
                    { 2, 100, "RolUsuario" },
                    { 2, 101, "RolUsuario" },
                    { 2, 102, "RolUsuario" },
                    { 2, 103, "RolUsuario" },
                    { 2, 104, "RolUsuario" },
                    { 2, 105, "RolUsuario" },
                    { 2, 106, "RolUsuario" },
                    { 2, 107, "RolUsuario" },
                    { 2, 108, "RolUsuario" },
                    { 2, 109, "RolUsuario" },
                    { 2, 110, "RolUsuario" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                schema: "Identity",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                schema: "Identity",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                schema: "Identity",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                schema: "Identity",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                schema: "Identity",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                schema: "Identity",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                schema: "Identity",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "AspNetRoles",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "AspNetUsers",
                schema: "Identity");
        }
    }
}
