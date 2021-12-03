using System;
using Microsoft.EntityFrameworkCore.Migrations;

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
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
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
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
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
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
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
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
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
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
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
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
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
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
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
                    { "2301D884-221A-4E7D-B509-0113DCC043E1", "a7890d78-7e51-462a-a2ea-9c731415440c", "Admin", "ADMIN" },
                    { "7D9B7113-A8F8-4035-99A7-A20DD400F6A3", "4982efb5-9587-4e46-b6d2-da403b021e2c", "Paciente", "PACIENTE" }
                });

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NombreCompleto", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "fc45b81d-a6f4-4564-a148-65340a2ebfc4", 0, "e260306e-3388-4ecb-ab0d-3672c51026c5", null, false, false, null, "Nombres 80 Apellidos 80", null, "PACIENTE70", "AQAAAAEAACcQAAAAEKfbvfutt0jUWs3g8eyiysULzyApYLNA74RyPOHtMLgMzNwsaIZHphtzDadOZcHzzA==", null, false, "ce3be4dd-bab0-4a17-b9de-cd8ccb1c2425", false, "paciente70" },
                    { "44a08975-0c9d-445a-bb56-7e7a73713c56", 0, "545e6ca8-d635-4230-845a-dca2116dfab3", null, false, false, null, "Nombres 79 Apellidos 79", null, "PACIENTE69", "AQAAAAEAACcQAAAAEOMOtgBgJxaVeA+YeEnSsD+KAAHcTksyyCzA8jeCx4qZsCL7cI++/J9BqGMlEqbVbg==", null, false, "fb2a00ef-6cc4-47a8-aee3-06ad3d10cb7d", false, "paciente69" },
                    { "d687feaf-58ed-450d-a90f-d758ab94c490", 0, "1bff7071-0cc2-4004-854a-ed13d3211140", null, false, false, null, "Nombres 78 Apellidos 78", null, "PACIENTE68", "AQAAAAEAACcQAAAAEHFH2pKDz9G5iDLGs3oQmVfdOBJ5++ZSGJYay4Fjqz7ChPNB96u1zYhtXzxaIwZYWQ==", null, false, "3e7ead2c-74ce-45b6-b57d-97e6d80cef35", false, "paciente68" },
                    { "cddbded3-b071-4cda-a0e3-e5c07eacf050", 0, "a72dba15-0e3c-48a2-9702-c907324a1238", null, false, false, null, "Nombres 77 Apellidos 77", null, "PACIENTE67", "AQAAAAEAACcQAAAAEKe5QWdiwdEmVOdZ+PA5L7bUaBd/RL6LrtNqjag8MwCtzIoLLISZXjig3HqVsxbBjg==", null, false, "f1f9859a-7e46-44c5-b424-815f6bfb2cd1", false, "paciente67" },
                    { "135c4e31-4642-457a-aac6-6fd0a4c84002", 0, "7befe81e-3ab2-45fe-aa53-57c17bdd7852", null, false, false, null, "Nombres 76 Apellidos 76", null, "PACIENTE66", "AQAAAAEAACcQAAAAEHAaNlfh+LytCB4PRHb/5CGhEmFfcAv5DP1zLnzCC97tJ8M0hp3s3FBPnkp6qWakVw==", null, false, "7c8bd98b-fc4b-40d4-a75b-0313816e12f1", false, "paciente66" },
                    { "06bb0d90-f8f4-4859-9946-f462cce1debd", 0, "bfcc335d-03c8-4697-b883-5a5dc6983783", null, false, false, null, "Nombres 75 Apellidos 75", null, "PACIENTE65", "AQAAAAEAACcQAAAAEHHe8i36xzdkpCK2EfTg7jxKFrnHEtCUH2Q4+mqnOCaFfj02d1/OJ69ZcnvKeh/cOw==", null, false, "55104c96-b49f-497c-b89b-4c580c59b8df", false, "paciente65" },
                    { "39967775-50d3-42ac-ab1b-af73976332d4", 0, "6dc88ca5-05b6-4d93-b582-57257b8bdb51", null, false, false, null, "Nombres 74 Apellidos 74", null, "PACIENTE64", "AQAAAAEAACcQAAAAEP3/7MjsjqzqUsH7gtx8Ic//N+IsdZpatRGEKkzVrTPvO0GkcghGYwXbKyI0CundGA==", null, false, "f41df6c9-06d4-4e4e-8371-42b8f5ae1295", false, "paciente64" },
                    { "e5705e91-f019-402e-beec-58211c586fa0", 0, "2b819adc-f17b-4ae6-9590-92311d89e90f", null, false, false, null, "Nombres 73 Apellidos 73", null, "PACIENTE63", "AQAAAAEAACcQAAAAEEwOaKtWrYH/MRtIDtUZzRbRtjnlVJ6wsvNFgFyU8kIsqrKwzNXAnlQdDCNM3ASKWQ==", null, false, "c9f3814d-d8e6-448d-a85c-3d16f9d4e547", false, "paciente63" },
                    { "9496c3cb-9bdb-4aee-8122-26389a2142f6", 0, "03b1ce50-7241-4007-bfe5-b8fa8952bcb1", null, false, false, null, "Nombres 72 Apellidos 72", null, "PACIENTE62", "AQAAAAEAACcQAAAAEAW5jOpkBsH3puTurcnCQPTVKaqGHmEu1SjWmliut5ABTPQcHH7DpqaijsFACRpF/w==", null, false, "202f79ca-dca4-442c-8801-3c0dc4eb3181", false, "paciente62" },
                    { "9fe2c51b-cd80-4693-863a-62dc2e8b2e84", 0, "a63643f9-aa65-4385-8da6-df5f49de966f", null, false, false, null, "Nombres 71 Apellidos 71", null, "PACIENTE61", "AQAAAAEAACcQAAAAEP+0e9CzBKTu5T9bgvCkGENfQK2BAs8iQRr/7Pk0/Z1akpkHuduuYD0hQpysn8RT2Q==", null, false, "20bdc020-37ff-43df-9a20-92cac3506cbb", false, "paciente61" },
                    { "58a7c671-5463-4612-9ca5-5b9f1d531ee0", 0, "5e7040d7-583b-4808-8b94-c09124a368d4", null, false, false, null, "Nombres 70 Apellidos 70", null, "PACIENTE60", "AQAAAAEAACcQAAAAECdQQSEDkHVLmDHVd5+1ucRE+RnEjLRIEbotaRbAmjEqAGdOwAigfFhLEjKSTgek6g==", null, false, "04245c2d-f081-474f-9003-7d48d5b43d76", false, "paciente60" },
                    { "b3480801-2136-4452-90aa-32158e249661", 0, "05cd8248-3831-487c-bcf9-1b197f751a32", null, false, false, null, "Nombres 69 Apellidos 69", null, "PACIENTE59", "AQAAAAEAACcQAAAAEIT1/xUTBjpjjsyBmByM8kN0jwPJcjN8eCQjFbngtfzB5alOhOdkyC0JgttGJgYfMg==", null, false, "a43e6a2d-05ce-437a-ab97-debb5e1f4dc1", false, "paciente59" },
                    { "e8b98ef5-f136-44ba-bdbd-224127df9995", 0, "a39320e6-49da-4ae4-958e-e67b9bd642f1", null, false, false, null, "Nombres 68 Apellidos 68", null, "PACIENTE58", "AQAAAAEAACcQAAAAEOH3rGvNc9q/Z0ZCxYO5LGepCklu51odjLj58DHxgENTntEDviPyLYDZ3q2Sb4Vjrw==", null, false, "b053ebca-c418-4d6a-8749-315dd1e0f66a", false, "paciente58" },
                    { "8e1387d7-f4db-4b83-acde-d2d9765d2233", 0, "33d95db1-0198-4989-bfc8-b6ab8a8ee45f", null, false, false, null, "Nombres 67 Apellidos 67", null, "PACIENTE57", "AQAAAAEAACcQAAAAENObrXNJwepIBM1y4EtIg2+crR86lB/FoxdQR/hsow4yq5hgHZX4MCMsYGGIiSJWyg==", null, false, "cb796f54-8b42-454c-8be0-bfe9d7c976ff", false, "paciente57" },
                    { "0964ca1b-95c7-4da2-ae3b-786c4f485139", 0, "95c1a979-3579-4fe9-a38f-4b30307b849b", null, false, false, null, "Nombres 66 Apellidos 66", null, "PACIENTE56", "AQAAAAEAACcQAAAAECq8JbQ/q4fStMQp8d7srzUW5MYlP8GtMWqv6KlllBj0c4lLcgrCZ7PZFBn+kJnNiA==", null, false, "172e09bc-7abb-414a-bf9b-6e77d9c9f0a3", false, "paciente56" },
                    { "29417803-fc0f-4674-8368-ec8d58202145", 0, "0990cc16-85f2-4260-8afc-cf2506e7fe98", null, false, false, null, "Nombres 65 Apellidos 65", null, "PACIENTE55", "AQAAAAEAACcQAAAAEFnsRiqLV2Pa1ItgqIMGwX/r2a8LlylMVHaIjPGnqmbBWIeVVs0vA6QJWmzlTLtPTg==", null, false, "98a62b91-88f7-45a5-88c6-ee68d6371d0f", false, "paciente55" },
                    { "c98ce1bc-d9f7-4d42-ba50-003a1834add9", 0, "dbd52f4b-4c98-437d-9811-267e490685e2", null, false, false, null, "Nombres 64 Apellidos 64", null, "PACIENTE54", "AQAAAAEAACcQAAAAECvEOBX2AIpNaRDrFj2jP1a4PcB5jDcCMCawD5i0K0olwjbKFELmwt6MzrgARXD+5Q==", null, false, "d972e03d-bdc4-42ca-921c-4c70bfbacb99", false, "paciente54" },
                    { "1c17547d-63cc-4993-8595-60307f54b60d", 0, "793e1cad-9980-4fd3-bc15-0141db497394", null, false, false, null, "Nombres 63 Apellidos 63", null, "PACIENTE53", "AQAAAAEAACcQAAAAELuknJuWIiaDDxnzU274FsWjRnAJNQfC7QeHstiOCFpkjbMpwzZ2YzLQiGfhLawB0g==", null, false, "1a98128d-5c95-4dd6-88ee-31a7a4f6196d", false, "paciente53" },
                    { "6c4aec57-9672-4284-93b0-261bca0dae04", 0, "f9edb632-5e8e-430e-aade-401ad48529fd", null, false, false, null, "Nombres 62 Apellidos 62", null, "PACIENTE52", "AQAAAAEAACcQAAAAEG4gzivPqHRfQEG344NmVSgGBSW1aMTJodl7JdtMr0pfomoXvBcrx2DNI4lzSMHHiA==", null, false, "a060faad-6f92-4073-ab72-6c76bad52874", false, "paciente52" },
                    { "6ac1add2-25f7-473f-b1f6-9d04db1a939e", 0, "16ef5d96-f475-4022-b177-021aabaff8eb", null, false, false, null, "Nombres 61 Apellidos 61", null, "PACIENTE51", "AQAAAAEAACcQAAAAENfMvOVoahgWuRi3dgVkaJQww2y42rprPnZv7JsD8yjJBJKk92G1xsQQNGel42AE8A==", null, false, "e3997951-618e-411b-b042-466c62b22e22", false, "paciente51" },
                    { "9bca5ab3-9665-486b-8aee-e0411413a000", 0, "b10da516-1b57-4145-9a20-046383bb39d4", null, false, false, null, "Nombres 60 Apellidos 60", null, "PACIENTE50", "AQAAAAEAACcQAAAAEHc7SnHGaItTUq4Gx0NwqLXUoZZ0M6TXAQ0D/mol+7SUW2Lz1U/e1Xv226yCwjscUQ==", null, false, "ca7e3864-ed63-4e7d-9e76-e58596a2c153", false, "paciente50" },
                    { "5259e159-a707-4bdb-af32-b2d3888e120a", 0, "e45947aa-2fef-4131-aab2-7a8df677e728", null, false, false, null, "Nombres 59 Apellidos 59", null, "PACIENTE49", "AQAAAAEAACcQAAAAEMxWF2u2z+jIxa5zFmVvst1s9U4WWWLqE/cXDyOMseAIsONY/GMCnN+g4qz/3wjpKg==", null, false, "3895438b-10be-453b-984f-ffc05449d9d9", false, "paciente49" },
                    { "f6748d90-0bc6-4706-b813-d14023d1c3de", 0, "77bfd5f6-cec8-455c-bfb5-d9b121a14329", null, false, false, null, "Nombres 58 Apellidos 58", null, "PACIENTE48", "AQAAAAEAACcQAAAAEBj5y5N8naFeA5/B/pnizPs3O0QSaPH7SpSMniLhcfYokrdbpdNfQl0JtWzQMIxCsA==", null, false, "19744bfc-d5cb-4787-8b60-3b45da032c45", false, "paciente48" },
                    { "34bc776d-44d5-4d00-a342-250bc38d3bbd", 0, "7601cc14-5792-4be2-97fc-6e1741faae38", null, false, false, null, "Nombres 57 Apellidos 57", null, "PACIENTE47", "AQAAAAEAACcQAAAAEGir7l3v/fqFrXKHc/vsf3Oe+/f926UoTgh4z3+M7dvcKyEHHicnbQxRlMC1s75tZA==", null, false, "1281154d-c6c7-4aa2-977a-abc361c2acc4", false, "paciente47" },
                    { "164b779e-405f-4551-ab7b-87f766e7b8a3", 0, "d99bb280-95ba-4763-a14e-bd66b0e13b8c", null, false, false, null, "Nombres 81 Apellidos 81", null, "PACIENTE71", "AQAAAAEAACcQAAAAEKKAodM3Vu98v8RNPmNpIV3CkqLZctID25spvyKxts2yaoiJcZkScuQoIvy/whgFCA==", null, false, "aa456596-cf0e-4ab0-b883-2df359588099", false, "paciente71" },
                    { "336d74fb-41bc-48b4-b092-1581c0facb80", 0, "7530545f-96ff-4525-b339-de96f7cfe218", null, false, false, null, "Nombres 82 Apellidos 82", null, "PACIENTE72", "AQAAAAEAACcQAAAAEPK+M1DcKt0Ja/bzG2VGLT51TLJbmjQ3hLNJR71D1lUg6FnsN9fA9F5UtcSuwMo6Pg==", null, false, "1418848f-6814-4f6a-9500-db5907f01e39", false, "paciente72" },
                    { "118ea14a-a1ac-43f6-b6ae-1759636cb005", 0, "61ac791d-f1a0-434d-bbc3-341e42fd5ee1", null, false, false, null, "Nombres 83 Apellidos 83", null, "PACIENTE73", "AQAAAAEAACcQAAAAEAZsZ/b+BYxFQ1Dm+CZbRD/FosIKrmoD/xKDio/zMKXLy//EEAGgW4ttdMTTCjh5Yw==", null, false, "a0c3141f-c9c8-428f-b73a-3eadd6f8c631", false, "paciente73" },
                    { "a06bf318-6f00-44f9-b68d-4a0203941d15", 0, "e5026581-a3db-462e-9569-72fb44dac801", null, false, false, null, "Nombres 84 Apellidos 84", null, "PACIENTE74", "AQAAAAEAACcQAAAAEIbDMjSvS3bXE0gazHZMG74opvvg7AT2TvNJdhQCeJP0OfiBDTbZe905hq6C4WcW3w==", null, false, "d37d9160-d83f-4629-9f49-582eb18b4d9d", false, "paciente74" },
                    { "493ff3da-8f95-41e6-b05a-82b256315c51", 0, "dc9db571-293d-4df6-94f8-52ffbd87508b", null, false, false, null, "Nombres 108 Apellidos 108", null, "PACIENTE98", "AQAAAAEAACcQAAAAECX6OBREZQE35owjAGC+lCFN3whBkHSfhshkDv8/40Dp2a/DVdQgYpTm+9Spk6BkPQ==", null, false, "ab2d8195-b6fb-4b10-ad2f-99a1a6ac26b5", false, "paciente98" },
                    { "aea55a88-5894-46f6-ae14-6fdd9eb5f49e", 0, "67b10772-2272-4bf6-90ef-8b79390e1e5f", null, false, false, null, "Nombres 107 Apellidos 107", null, "PACIENTE97", "AQAAAAEAACcQAAAAECLDsjO35rNaHWeFvDpHvpTQ+JHHAyDsQqw8u63AYCFg7464N5GBjh3/mdDiPQB36g==", null, false, "02fd3b16-ca8e-4c30-8a69-7a7a9a866bb1", false, "paciente97" },
                    { "d31d7d64-a5b2-448c-a4b3-117698d31a41", 0, "7b580c77-1363-411e-8022-0a423030c189", null, false, false, null, "Nombres 106 Apellidos 106", null, "PACIENTE96", "AQAAAAEAACcQAAAAEEvrHKBXBuMaSMhcVCiVZtm4xV13knJSgxAafim0T9yrs6qI5DR3xe13nUhIuUkAzw==", null, false, "874474f9-6341-4c15-9b10-1eb2ec42f8c0", false, "paciente96" },
                    { "ea186623-f60d-4a09-8977-a0ca51887fe5", 0, "40a8b771-ee2b-4dd7-b7e0-383cc0724fdd", null, false, false, null, "Nombres 105 Apellidos 105", null, "PACIENTE95", "AQAAAAEAACcQAAAAEGMk+O+fzsMiaNQ827BPtMqQSNzaSHKMmGc9f5NqnM+tgsPi09zbGVicUvyKuf/OMQ==", null, false, "1604bd18-9b7c-4f39-bd6a-3a96cbe71d64", false, "paciente95" },
                    { "233ea798-267d-43c2-919e-f3fdb4f04aac", 0, "44685bf4-69f3-41ae-9408-1d3297dd9efe", null, false, false, null, "Nombres 104 Apellidos 104", null, "PACIENTE94", "AQAAAAEAACcQAAAAEIV6bphNW/74NZGjdCAqY779mKh5nvC+tI/ZrLagpH2aB5NznH45ad5QDNUvhhJWOg==", null, false, "127cb588-60ad-4088-b25a-a92902efd966", false, "paciente94" },
                    { "1af46771-40f1-4195-a44c-b19243eb5d84", 0, "12190311-2394-434f-8a8d-532fd67de82d", null, false, false, null, "Nombres 103 Apellidos 103", null, "PACIENTE93", "AQAAAAEAACcQAAAAEMmHJGldDJ6jpwTz/gvor4QWVtvQPAjdUMKxgdS6j6OLG1wtkcHe2hP/EPvtS7m+fg==", null, false, "28460c8e-dc60-4f92-8cde-ed499ed9d577", false, "paciente93" },
                    { "0fb03339-8037-4058-98b0-9c4c0fcdf0bf", 0, "36996ca0-f36f-45ad-8dc3-ec52a828f4f0", null, false, false, null, "Nombres 102 Apellidos 102", null, "PACIENTE92", "AQAAAAEAACcQAAAAEGMVMfBKdzxuRQCfZ9S6pJH7x3cosTl9DGtLLJB2Rw3pqIjY5SN5w/fCtN5Aoj6rbQ==", null, false, "37d0489d-1734-45f7-ba60-6ad5da4c70b3", false, "paciente92" },
                    { "76e563c2-784d-48f1-888d-4a0545c99e7e", 0, "e4b5ba15-cc94-4a1e-9c17-528ff7b1b008", null, false, false, null, "Nombres 101 Apellidos 101", null, "PACIENTE91", "AQAAAAEAACcQAAAAEGcEkFIADmXbN8j6bLNVEPBHrF5qLQVj/pB9zyh+UfPplc0782nPyQpExstdblqNXg==", null, false, "cf2c78ce-d789-4ac3-b331-d70d062550f2", false, "paciente91" },
                    { "bb8d2b53-69a6-4efe-9349-70418441213c", 0, "7b947895-eb7f-4f70-872f-0904769376d3", null, false, false, null, "Nombres 100 Apellidos 100", null, "PACIENTE90", "AQAAAAEAACcQAAAAECwCYvc+9dKTJKA9lTNM4LMQ+wbFTF/ztX0C5WMU9miLPEvcnIY5+PslHbz20eDVtQ==", null, false, "d20e72eb-ffdd-4d06-9979-e342652ffd39", false, "paciente90" },
                    { "54784d2f-4983-40f1-ab34-a217190bde95", 0, "d4c0388b-cd00-494b-b15f-9364baafe15e", null, false, false, null, "Nombres 99 Apellidos 99", null, "PACIENTE89", "AQAAAAEAACcQAAAAEPkV5was8dWbYCHO7SaU5gvETEYZFwGnzwOduEj3SCrecgBbLC7C3olW6FjjMx/7uw==", null, false, "ba1ed0ef-cd50-4cad-b8dc-dfbddbe89416", false, "paciente89" },
                    { "40cc0c1d-759e-4830-b514-5a3c806cc149", 0, "09b3eff6-55b8-47ce-9723-f427daa2143e", null, false, false, null, "Nombres 98 Apellidos 98", null, "PACIENTE88", "AQAAAAEAACcQAAAAEMHQpErm+j2mmD91ig9Xm/jKJ7PCHV4sgumrEzM5nBQkm4+eot2XPlvtAjmPdCBkcg==", null, false, "4cc169dd-e021-4eec-868c-ffc86a4ca799", false, "paciente88" },
                    { "257f6b05-a283-41a3-b959-37d0e7f1e369", 0, "124d89b4-ce04-4acf-ae8e-62685d03892b", null, false, false, null, "Nombres 56 Apellidos 56", null, "PACIENTE46", "AQAAAAEAACcQAAAAEO+7a5J2Q14vwSmdQQq/aMS4Mc61j5j/d99YkS0NBN038VJanz0oj+Z0BkZ6i7bJsQ==", null, false, "db4354b8-36cc-4e92-8270-6a17af5c1f2c", false, "paciente46" }
                });

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NombreCompleto", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "2929d71f-2c3d-447e-960e-965261e0791c", 0, "b3838dcc-e12f-49df-b5ba-d1ed0f5df502", null, false, false, null, "Nombres 97 Apellidos 97", null, "PACIENTE87", "AQAAAAEAACcQAAAAEFIauZtDLzmGAHIN+6ixosACxinBfOAdh7KlwjyMcgo4SeQjsJmvme+kL55B3e3W2g==", null, false, "5eb09735-cb15-45f6-9393-9bf280328f67", false, "paciente87" },
                    { "bccb4c0e-15f3-45d1-aa0d-c6a01cf71b88", 0, "b0b691c3-fd8f-4dc3-9154-345523ba2a09", null, false, false, null, "Nombres 95 Apellidos 95", null, "PACIENTE85", "AQAAAAEAACcQAAAAEJ7M+fPc4nic41IqTqdfFt5rk4/CYUr4twdlBgjz9daVvaUfricm/NbPH3SdsRNUzw==", null, false, "75e0e506-c768-4f55-b48b-89e61fe60b1d", false, "paciente85" },
                    { "08b3cfa8-00d1-4a48-8b23-6daef1c2d7bf", 0, "d9c1bf2a-944a-4c47-960b-595868a9fe5f", null, false, false, null, "Nombres 94 Apellidos 94", null, "PACIENTE84", "AQAAAAEAACcQAAAAECwMsE6fW2Vdg5Z5f8pX/etRB43GVojXONTKWeSAqaQjQaaVU/DbDWTlOhrVNKRkxw==", null, false, "fe1a6e40-93bb-457a-bd23-5aa68c725d5e", false, "paciente84" },
                    { "dad96e9b-0309-4b88-be7a-38a08d93d4e1", 0, "7e8f3c62-05a7-4303-b686-be3c74c7c4ec", null, false, false, null, "Nombres 93 Apellidos 93", null, "PACIENTE83", "AQAAAAEAACcQAAAAEIMidvVLLpBXFTY77sFj8txWFj3Hl0QMhkva3qs+KUgBgEYcJV3g+i6aVxS5N7lwAQ==", null, false, "12b28fbc-84d6-41e4-bc65-412e88b2dc79", false, "paciente83" },
                    { "88fc1227-afc7-4f85-8280-c8984c19fa61", 0, "6ffd522c-f4c6-4665-a570-b73757752eef", null, false, false, null, "Nombres 92 Apellidos 92", null, "PACIENTE82", "AQAAAAEAACcQAAAAEFhClYSXA6fE73nUFZRsEDNrggWiks8rKN7afcRwjZkO37HusKlXEAli/HhC6jFLFg==", null, false, "a664a10e-376d-40d4-893c-1455ae092a4c", false, "paciente82" },
                    { "455205c7-5cee-43d7-9935-b9b2b561afdf", 0, "a38bb990-eb0c-405f-bf86-b08131b3d4a8", null, false, false, null, "Nombres 91 Apellidos 91", null, "PACIENTE81", "AQAAAAEAACcQAAAAEG77gdCtz75HuYz/xrSyI/bqyELeIHhXpOMtXAGL3xXrcyvj/gey2H0amjVFY9jR2g==", null, false, "0742a377-1e33-4a67-8412-983624703c2f", false, "paciente81" },
                    { "28f76da8-046b-4e67-9704-796afc260ab7", 0, "20395906-7837-4949-827d-ff3d9e03f93f", null, false, false, null, "Nombres 90 Apellidos 90", null, "PACIENTE80", "AQAAAAEAACcQAAAAEG+rcpoUHp82dDVwY439hZdlzIHWPZ817LbcQZDug/zl0SnfzVyyb2sNozo5r3cOOQ==", null, false, "251c9cc2-c320-41e3-ad67-58dd00c5c919", false, "paciente80" },
                    { "b4518c95-1ad5-4e7e-9d03-fec7445dcade", 0, "c79e7998-8387-4378-8d73-feea85bf253a", null, false, false, null, "Nombres 89 Apellidos 89", null, "PACIENTE79", "AQAAAAEAACcQAAAAEBNeMfAMLiAN62tkXfcE8OCMeLXx7P9R5jdFAJHiqKW+SoGL3QkAnB9npp8WbEnG3g==", null, false, "46166dfd-fff0-499a-bbae-aff3ce8e913d", false, "paciente79" },
                    { "a5d25413-69e2-440a-b6ef-50e32ccffde0", 0, "d0bae4f8-7e53-4a9d-b583-934015569eae", null, false, false, null, "Nombres 88 Apellidos 88", null, "PACIENTE78", "AQAAAAEAACcQAAAAEFIF8P/daOFWuE/0Mvd+JfNdSOrDiT73m9O7aHi706utAhYZtx19aStx/QRiUAPYrw==", null, false, "fac40a7b-2462-4238-95e2-d7f4e2be7fab", false, "paciente78" },
                    { "5d436ad5-b7bf-47c5-a3fd-90d2762d0aaf", 0, "e31f8744-acf2-44eb-85b0-6e3e0109a2af", null, false, false, null, "Nombres 87 Apellidos 87", null, "PACIENTE77", "AQAAAAEAACcQAAAAEFQQMLBrzDpAh/cOgnD9jY0QCO16tVXE/MT67DVvXy5UaX7WV5rPEHfi4yORjTuOgQ==", null, false, "d0cb4e29-175a-497a-90b7-6cc1e953406e", false, "paciente77" },
                    { "70b04840-5607-47a9-968c-733ea7143da0", 0, "c27ab702-207b-4a44-ba53-d57506a599a0", null, false, false, null, "Nombres 86 Apellidos 86", null, "PACIENTE76", "AQAAAAEAACcQAAAAEMJbP/gVzdK3h9vMIFVQyn9IjhHRI9cpeT5H74QB45N9acqTyWHb3hftiRak/jsAPw==", null, false, "8d196551-9f0c-49b6-a337-a892feb06b9e", false, "paciente76" },
                    { "e91e3215-4f8c-4fe4-b20f-a8717d50eb69", 0, "35844566-d563-4954-b1dc-7c9b95bbbee2", null, false, false, null, "Nombres 85 Apellidos 85", null, "PACIENTE75", "AQAAAAEAACcQAAAAELt+oGIUAvqq9CMcPGqiNx78y8VNSd+MbzpgOv6MnhvwyGfhFTt7dFauh00d/SCD2A==", null, false, "509a29ce-af2e-45aa-af38-372fcce060f1", false, "paciente75" },
                    { "a6051997-9a95-4dca-9da6-41c7a3f9c309", 0, "c37fb0c2-2d65-41a8-8f20-5815755e9a9d", null, false, false, null, "Nombres 96 Apellidos 96", null, "PACIENTE86", "AQAAAAEAACcQAAAAEI+A+smlkz9PeAU/ZaNj5IX9/gFezNEcMYebv2zfEC9Xm9wFEpQu5Wx747wuDiGoow==", null, false, "478f1b08-4023-4927-b33e-48fb1aad60ad", false, "paciente86" },
                    { "290d5825-5736-4750-9da8-e058de6f0927", 0, "41898774-40b4-4dc5-83c5-e57340473240", null, false, false, null, "Nombres 55 Apellidos 55", null, "PACIENTE45", "AQAAAAEAACcQAAAAENCWpi9TgpL99thjPm4Ht3j930NqW3x68dCiIkefUUj4CMWq4zdedw7lzvcXUPDnVA==", null, false, "b362d246-ded7-4d37-bb53-b50cf994970c", false, "paciente45" },
                    { "a9936a39-fac3-4005-b906-55a69c74c8f7", 0, "27f2098c-005e-4ca4-b2ce-6186709dd579", null, false, false, null, "Nombres 54 Apellidos 54", null, "PACIENTE44", "AQAAAAEAACcQAAAAEPyeNfYG2ZDvUSTFA3PsvQD9z4ARBR5NkKisqLL9SN5D2NddEix2oFvH1tbnsyHqFg==", null, false, "34feb147-3fc0-4fa7-86d0-7ec87b5b6fad", false, "paciente44" },
                    { "1c3cd480-4d8b-4155-bc18-aa8a6d104906", 0, "ccfd2576-3a8f-4932-a3e7-0a8e0b96bd45", null, false, false, null, "Nombres 53 Apellidos 53", null, "PACIENTE43", "AQAAAAEAACcQAAAAEI55raj64YbZ/EdBKp6O/nh3tdCot1uuhbWnKv9EF8xXEh3JhQdAhI6dbMvPE/W81w==", null, false, "58add1b2-23fc-4697-83dc-0e0ca874d079", false, "paciente43" },
                    { "0899019f-177e-4730-819f-9c1e67662592", 0, "c6026d33-cdf7-4a14-89c3-caa5194c296f", null, false, false, null, "Nombres 24 Apellidos 24", null, "PACIENTE14", "AQAAAAEAACcQAAAAEGwdewUU0rPTSMiXvXaLCJ4K+1oQGZ2MAhHCyFwqqlb+CWf/vwGN320fk7pEvBWWQA==", null, false, "eceaeb6f-d53b-45c7-9e0f-3bb128fdaa30", false, "paciente14" },
                    { "32ae00e3-b23a-426a-b61b-12dd92b63e6d", 0, "1fbc08a5-ce17-4bee-86fe-7d13c1766927", null, false, false, null, "Nombres 23 Apellidos 23", null, "PACIENTE13", "AQAAAAEAACcQAAAAEEyCvGI2i7aMRwtHFufvfbUYpNkHDa4Oex9cB0BwBioUeKJu645xh/6X+9pzgQXvaw==", null, false, "713bc94c-c43d-4537-b205-86cacb6afd2f", false, "paciente13" },
                    { "db93e967-67c9-4f74-8acd-f81a40fe5e5e", 0, "1122163b-9085-4f29-a39f-17db49e04dde", null, false, false, null, "Nombres 22 Apellidos 22", null, "PACIENTE12", "AQAAAAEAACcQAAAAEBHkyqsL5jXKHpq5RA/69pjKnSHqErXkuQbn8mpz29An6noFEM2h7EbG/Js6kdtsWw==", null, false, "9ca61d53-cacc-4ddb-8329-cf6a4b3acb09", false, "paciente12" },
                    { "218a712d-98db-4c22-8f30-0e878647ab36", 0, "2b6cd17d-da56-488d-bfc0-591adfac0833", null, false, false, null, "Nombres 21 Apellidos 21", null, "PACIENTE11", "AQAAAAEAACcQAAAAEDUL1Vz/a+w594aAdzBsK/PVO+HlLrYrnCAk1U449Cs9mJzOuHSBYqWO9WG3y5HHFQ==", null, false, "f2e7b778-7a3e-4364-9d0c-de4cf8a29a77", false, "paciente11" },
                    { "22530143-1831-4614-a347-711789595852", 0, "36f2be5c-f3ac-48fd-9730-c1e151c7a7c9", null, false, false, null, "Nombres 20 Apellidos 20", null, "PACIENTE10", "AQAAAAEAACcQAAAAEOnbCxI3p3irdKtAiaSjFsDLflLMmkzBteqz4uOQKyDv1Nlwncq9hNjxtKAkW3fgjw==", null, false, "d9c63fc5-5566-4846-862d-c4f4e8891109", false, "paciente10" },
                    { "8342ada0-2dda-4c6e-8faa-2b6994741d85", 0, "77d932e4-2afc-4115-8799-873ae1bd41f9", null, false, false, null, "Nombres 19 Apellidos 19", null, "PACIENTE9", "AQAAAAEAACcQAAAAEP5MHJvCjQZeIYt0dEBet6izpNqUIsd4R80vXYH00k881sbL/dQJdOBEz4NoeAD0FA==", null, false, "259ce108-91f7-41ee-8d45-b1bde12d3287", false, "paciente9" },
                    { "89470e2c-3f83-4a9a-9f7e-9f48c5f2b1c5", 0, "0aa04e83-d864-4fe6-bce7-e6b484ba325f", null, false, false, null, "Nombres 18 Apellidos 18", null, "PACIENTE8", "AQAAAAEAACcQAAAAEKOTDIX/o8RgyXs1DNCq1HU/GDHpynaC3euCiRJUAi+hG8we/FohyN3lz136HCMaiw==", null, false, "d73f9b36-d748-4181-93b5-8a2cf4f12abe", false, "paciente8" },
                    { "4cde87e8-116b-4e0c-9563-ae0cccfd24df", 0, "cf5b081d-b2e8-4fd7-a283-2d5fa81fa80b", null, false, false, null, "Nombres 17 Apellidos 17", null, "PACIENTE7", "AQAAAAEAACcQAAAAEMGPUbUqhabiHpNBO7mYvy33BpfiA9Ycp+rI9DGFBDKPQlR0QaXLVkzAEL4AqESY3A==", null, false, "11db6342-3f4e-459b-9e81-a2da44eb259e", false, "paciente7" },
                    { "0749f085-fb61-4d77-8f79-86b296cb205c", 0, "cda4c1d1-aaf7-4a83-81da-396c8e2a6bd2", null, false, false, null, "Nombres 16 Apellidos 16", null, "PACIENTE6", "AQAAAAEAACcQAAAAEO0Afz/rGxrPiNWAnuKgCLpc45A/qn0VTrMIX/sy+q3kHeTipkdcbATHjjrSPvG4FQ==", null, false, "71c66339-1f82-42b3-8102-8d5767dbfed2", false, "paciente6" },
                    { "2d160faa-c906-46a3-9a74-ec2097879a95", 0, "29dd95c6-03a3-4ff9-9b6c-842eab226a79", null, false, false, null, "Nombres 15 Apellidos 15", null, "PACIENTE5", "AQAAAAEAACcQAAAAELcgLvlFRgIzwsXFqYld78gMrGQ3YQx9IgDtIXIAS4NETB4VX32xWT/g2D+o0eVB3Q==", null, false, "1276c37f-22e5-4ae2-9f1e-289ab356666f", false, "paciente5" },
                    { "9e69547a-7ba4-456c-aa6e-a6e47a891a14", 0, "0416e269-aa9a-4bea-87b5-102e68b07d00", null, false, false, null, "Nombres 14 Apellidos 14", null, "PACIENTE4", "AQAAAAEAACcQAAAAEHk6zu+h0VWJgQDSOYH6UlOu+C0RtYYDfvh6IFHVJPguyPHZQJogNj1k48LYSiREvA==", null, false, "b8342613-fc56-4d27-b396-a2cd32bf4dbe", false, "paciente4" },
                    { "629bcd5c-a9a6-4188-b312-dc65b93929f3", 0, "b2787451-2cfa-4329-a15e-1fbd11800379", null, false, false, null, "Nombres 25 Apellidos 25", null, "PACIENTE15", "AQAAAAEAACcQAAAAEAu+YNcGndPpeF562gDJGHBvCPVUr1VAIHkVYXH0plH3wuDze+yBhOGEpzgE7fCZaw==", null, false, "d0844fb3-1d6c-4ad4-a304-c3e5feba1d1a", false, "paciente15" },
                    { "67e4e381-ac15-4994-a4cb-0fd4b077f2fd", 0, "e72a401d-22f1-41cc-94c4-35c806f6d1fd", null, false, false, null, "Nombres 13 Apellidos 13", null, "PACIENTE3", "AQAAAAEAACcQAAAAEEkIbdEzsEIYm8C3JQ1qW1IOf2aP59kgXglnhbyfNKnvG14C74qoO9LK/lkEqnkiKw==", null, false, "3a9acdb2-675b-4e09-8d9f-e6d815c34a0f", false, "paciente3" },
                    { "fc87006d-41da-4af5-9617-a5d6caee53a2", 0, "d4d5facc-f153-4a01-8473-f4b37c3e60fe", null, false, false, null, "Nombres 11 Apellidos 11", null, "PACIENTE1", "AQAAAAEAACcQAAAAEKGUdiGS5b8yyT8llg2C+wzXCsXTF/pLfh9IIb26vd/avrzabDC7oWSB8tC5B3kB9w==", null, false, "69438549-c866-4261-9a61-472c888e79c0", false, "paciente1" },
                    { "2ef4e493-478d-4433-bf76-d3fe49d468d8", 0, "00e13e1b-a825-4f4d-abc4-f3419641ff45", null, false, false, null, "Nombres 10 Apellidos 10", null, "ADMIN10", "AQAAAAEAACcQAAAAEN7TnAC2fHhmIouep/z93WQm6JK2UiLvUyko0LsFLldAJElnIoyCvzoqeAkoEJ+sjQ==", null, false, "c9224937-9b1d-44fe-a8ea-ebfee9067d58", false, "admin10" },
                    { "03daa74e-a602-4a3c-93eb-6733dcc38440", 0, "4510f830-a77a-4e8c-a10c-25948d3be9c6", null, false, false, null, "Nombres 9 Apellidos 9", null, "ADMIN9", "AQAAAAEAACcQAAAAEOSl2jTt+sdBUz+EGwgVZneQvBCzytEwqaUpoCt6JdErxdid/IIVxVO4lGEn2ljt2Q==", null, false, "3ee1c1d4-c7e1-4a8d-adcb-e954d2c166c5", false, "admin9" },
                    { "26e4db4d-0a55-4650-924b-64302bba2028", 0, "527430a3-3c01-47cd-8923-4fe2d7ab80f2", null, false, false, null, "Nombres 8 Apellidos 8", null, "ADMIN8", "AQAAAAEAACcQAAAAEGve6Almr7eq9xrXRdBGpM5V4KKzhVSwEX+i7xLm4lq1M7eF7Ye9hRustA3hPhSpVw==", null, false, "ab444345-a606-4224-adc3-73a25b600b85", false, "admin8" },
                    { "e61ba7db-8adf-4faa-a6e0-42d0cca5d773", 0, "5e522d0a-f578-4ca7-959b-16bf54858210", null, false, false, null, "Nombres 7 Apellidos 7", null, "ADMIN7", "AQAAAAEAACcQAAAAEMuA/Zo8TQESWCnWKTuXQHS8yCItbg0eDuCEehh7dLh1pTqgYwk09SVzTaIfPUMfcw==", null, false, "a1f994bf-7665-4e72-adca-4083abc65456", false, "admin7" },
                    { "d1633117-42ce-43d3-90d4-d3d80a4ebdd7", 0, "072b616c-56ca-4565-a8ff-f4804b2db2ad", null, false, false, null, "Nombres 6 Apellidos 6", null, "ADMIN6", "AQAAAAEAACcQAAAAEHo6CTYUksTV0dzDpub8C3UM7sjrsyZ8fxvtbFt3jLu2R5KEwa/j1/k8dJ8wwZGGJg==", null, false, "34aedf10-bdb0-4853-a48e-9390d6fdde02", false, "admin6" },
                    { "8364a7ba-3d95-4aa6-bc22-7f223cad8110", 0, "440b8079-e5cd-4f28-bbc8-0e12d707ddfb", null, false, false, null, "Nombres 5 Apellidos 5", null, "ADMIN5", "AQAAAAEAACcQAAAAECRt+Kqrx0Jq+/QO2V7uKWq7Qr+dRClFIEBovezhVysyql+A6ntt+872GOWRnHTL+A==", null, false, "f33effe1-1c12-4ad4-9f8d-b82e26a40c2a", false, "admin5" },
                    { "cfa96164-a08b-4c61-87f7-80d86811c1fa", 0, "9e7202b2-77b4-4c72-ae24-ba6f68673b2d", null, false, false, null, "Nombres 4 Apellidos 4", null, "ADMIN4", "AQAAAAEAACcQAAAAEEG5QrLmdyWa6ZDhXLSMevJesje2Ohb9WhNcRcJCoWxMKKqzEWeedmql0RQLVrh9pw==", null, false, "e73cfa78-8080-4253-9e0a-5830c34a4696", false, "admin4" },
                    { "2b064cbd-6222-4a3a-8a9e-f3533295d7c2", 0, "0ed2f263-32ac-4540-bedd-100112922d61", null, false, false, null, "Nombres 3 Apellidos 3", null, "ADMIN3", "AQAAAAEAACcQAAAAEIV1XkRKe+lv2ytQTPcyOCYeaHbLDdW5fHF8t4QuAtRqB8+VSEe5LfAdWcDjSTMFbw==", null, false, "cf5c9dbe-ced0-47df-bb83-3482275358f3", false, "admin3" },
                    { "fade2f16-c69c-4c8c-9469-d64111c171e9", 0, "52ac32be-f141-4f0c-804e-0f2aedaf2b6b", null, false, false, null, "Nombres 2 Apellidos 2", null, "ADMIN2", "AQAAAAEAACcQAAAAEJvvVJbANd6xI1Dn0BRbhPPiAaevJcvll5yUFrWESNsaD+nb7HUk0gB3eqYnodYi+g==", null, false, "312f8c42-f40a-4c17-9f23-5da53f742dce", false, "admin2" },
                    { "abf3c9d6-e975-46dd-85b7-3ab97480a06a", 0, "77a2ee6d-fad3-4f0c-b5cf-536572c07ef7", null, false, false, null, "Nombres 1 Apellidos 1", null, "ADMIN1", "AQAAAAEAACcQAAAAEFBqhK4dTKtisvaue9V0e5Mgt8+Ey0ZZWDDOwWbrIwNqjgIzRYQcUy5CkSxrQbYbsw==", null, false, "c27a0513-59f5-426a-8916-2ddf23525c71", false, "admin1" },
                    { "9f4a6abe-8189-4caf-bb0a-b77c586b000f", 0, "7579b30f-e580-46c1-8df1-b6fc91f2027b", null, false, false, null, "Nombres 12 Apellidos 12", null, "PACIENTE2", "AQAAAAEAACcQAAAAEEKjmDlGmjgmI0RE4vxHJ9XDydTh4EVWPSBL5E4SKGF/RzA3X/9iIbvOgZMeaaLSWQ==", null, false, "237869ce-7101-472b-975e-b4854c327be1", false, "paciente2" },
                    { "599b671b-ee11-46e0-8b18-0a39116a8dc4", 0, "16772848-e674-4828-8bee-6ffdf6724e52", null, false, false, null, "Nombres 109 Apellidos 109", null, "PACIENTE99", "AQAAAAEAACcQAAAAECNG1Ql3joxmqr2iA+XJk/GO7sFYJRefV/BMXZXMTVV1uu1xz+LyFux5r0pNjrAaQQ==", null, false, "41ff68e2-a70b-4b7a-957c-c18fab4601b3", false, "paciente99" }
                });

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NombreCompleto", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "93d197f8-f2ee-4245-827c-1ff01a3ec7ec", 0, "216e8c19-036c-449a-9cf5-5ab6d780d465", null, false, false, null, "Nombres 26 Apellidos 26", null, "PACIENTE16", "AQAAAAEAACcQAAAAEJ0lDftmO9SbtyHZ35P/D47SQJkWnGDyiVmegSHaQNLQaePJ0D4+ev5t0e+a/9uDlA==", null, false, "7e348c78-1d64-4b3f-8953-1ad730997e37", false, "paciente16" },
                    { "b425da28-64bd-4c09-82f6-2d86bdab738d", 0, "6f29a4d3-51db-4a27-b242-5db8cf28260c", null, false, false, null, "Nombres 28 Apellidos 28", null, "PACIENTE18", "AQAAAAEAACcQAAAAEPSMGE3R+nOdJY5rpznCrcVO3dVLmIcQn/zRpqzoRQCzpdGDS8PBeojiDbFwRCRWhQ==", null, false, "cc83d4c4-6c9a-4ad5-a2d3-25c0bb56c034", false, "paciente18" },
                    { "855c7af2-94fe-4725-817e-d13adcd346cc", 0, "7197c3b6-55eb-45b3-ad9a-42554d92206e", null, false, false, null, "Nombres 52 Apellidos 52", null, "PACIENTE42", "AQAAAAEAACcQAAAAEI+p/zwR2ANDw7+O55cGCXHmzPwUGOe60YlygHFuAPPgQNuq8Jrw1EakBKV24GK9bA==", null, false, "b06cea18-af87-48e5-873c-c554b94910ca", false, "paciente42" },
                    { "7414a517-4e22-4cc9-8065-b9f9e5dfc5e1", 0, "05b821e2-c33d-45cb-912a-f493b8a98c81", null, false, false, null, "Nombres 51 Apellidos 51", null, "PACIENTE41", "AQAAAAEAACcQAAAAENTCA7ZDQWX9JYnx3zlaUQi+jiYhwjKwE71egAxRnwNUpFiyZih7p+5S/lPE/C+fdg==", null, false, "681f7e9a-3647-42a4-ac64-1d70f97a1e36", false, "paciente41" },
                    { "03562687-677d-44de-bb98-092aa48868f9", 0, "aa431910-0eb3-4129-9c70-ffca6c0e930e", null, false, false, null, "Nombres 50 Apellidos 50", null, "PACIENTE40", "AQAAAAEAACcQAAAAELNHScFiBT5WTsyX8/GZO6mASMPiCxGLMmJ9xw3gM+mgSOzCa1749+UhBTxcW/WCZQ==", null, false, "84172dba-640c-48bc-a209-95183d967755", false, "paciente40" },
                    { "308ecf85-d730-4643-a0a0-9126a620432f", 0, "5620d001-0975-46a4-81af-1830632345da", null, false, false, null, "Nombres 49 Apellidos 49", null, "PACIENTE39", "AQAAAAEAACcQAAAAEOaD1rHEK0e7cH+3tRaFH7EcjBLV4q8b4KP55zg8R+aEBFRmz26xsBc51lii040hrQ==", null, false, "60b7d098-f5ab-4827-b013-695fed40d6f6", false, "paciente39" },
                    { "66826096-4680-46e2-b4ac-796391ed5955", 0, "bc02420f-212b-48ed-95d4-0385e7789b51", null, false, false, null, "Nombres 48 Apellidos 48", null, "PACIENTE38", "AQAAAAEAACcQAAAAEAnXwWJJayRfbUcpFPa+huIXE6lacSBmmXtI7v/JaYOejRgIisjlvDT2yGZFBw97mw==", null, false, "2d273866-d63e-4fde-ba18-b0b904f038ed", false, "paciente38" },
                    { "fe4faeff-e9eb-49ea-8666-ba209ee75dda", 0, "a2c19b5e-8344-45db-a2fa-abf01b66a148", null, false, false, null, "Nombres 47 Apellidos 47", null, "PACIENTE37", "AQAAAAEAACcQAAAAEJS9FjuzPPE4VKy+u5850jXN9UsI0zmKuuX0poOpcPWRgvoVGkzuWBJ2Cq0Nc4GwPw==", null, false, "adba6da2-9893-4f19-87b1-4efd9794ea7b", false, "paciente37" },
                    { "40eea69e-7393-4427-b345-c1c97f217dd7", 0, "33dd75a3-9eff-4075-88bc-e3d601686919", null, false, false, null, "Nombres 46 Apellidos 46", null, "PACIENTE36", "AQAAAAEAACcQAAAAEKsGXX4BlVoCRZ4gW0rkekROsRyIoWlPky7F8bdCoqAadpNzk5Z56WgM0+MvVNZ1nw==", null, false, "29dd9223-86cf-4da2-a7ac-a12b351c754b", false, "paciente36" },
                    { "017eeb23-0198-41cc-af7d-4fa3a04cc11f", 0, "d37e4943-8171-44af-8c67-1ee384a321e0", null, false, false, null, "Nombres 45 Apellidos 45", null, "PACIENTE35", "AQAAAAEAACcQAAAAEPUJ9+trm9LMkVYT2PBnO5CSmbUqqrMsTzwQNp7qtWgDZnI2h801XdlH2x1Js1CtLw==", null, false, "08fb1ad9-c6bb-490e-9437-6aaf0128f41b", false, "paciente35" },
                    { "fcbd55f2-dddc-4323-a1f7-4f7cae669732", 0, "5dbf7d84-2788-41bc-af01-9dc27ed73d78", null, false, false, null, "Nombres 44 Apellidos 44", null, "PACIENTE34", "AQAAAAEAACcQAAAAEK7x5/2h8jHA6LbYb2REliQ5SmNG1neryziLuLmBhr1KGuT7/V2ui5lucq9FBiAqiA==", null, false, "a5bfde85-d91c-4d13-ac0e-5e00a4b32e16", false, "paciente34" },
                    { "3e43e3ff-03c6-4de3-b3f2-8b5b8ea41488", 0, "0f06ab64-ffa7-450a-ac9e-4f6cb67bab4f", null, false, false, null, "Nombres 43 Apellidos 43", null, "PACIENTE33", "AQAAAAEAACcQAAAAEB+aXDiOP/21tND7tONTtN7/mnuSLonCeaMJdMZT2jrqPaZ9D59r1hh2EGxDyzdvig==", null, false, "8dd07cb7-7263-41ed-a129-3cbfb7df0fb2", false, "paciente33" },
                    { "e0f8bc04-44f7-4a6c-a6d6-afd2ee4f4e40", 0, "4a1de445-e52d-4dc5-85eb-e09764f924f6", null, false, false, null, "Nombres 42 Apellidos 42", null, "PACIENTE32", "AQAAAAEAACcQAAAAELl4d18toc9/VUxyrrnoim/Fu/UL/b08B//fSCezWaZxQGdkSNohrNbC0syP+FliVQ==", null, false, "3728c50f-5b0e-4c83-814d-45dbd5b11ff9", false, "paciente32" },
                    { "3652e55e-089a-469a-9816-a1456f96b888", 0, "51768998-293c-4712-865a-e30d34de6979", null, false, false, null, "Nombres 27 Apellidos 27", null, "PACIENTE17", "AQAAAAEAACcQAAAAEF75vcY4N1CjrcIKOPRWGIWZgZxWC+x/gG5VXPBVbN7r/f5UPMpRLvxj69HF4KgDHA==", null, false, "4f6a24dc-4e81-4c9f-a43f-715c96db067c", false, "paciente17" },
                    { "f5fda1db-ec12-46ff-a6fd-328cfc5dbeeb", 0, "fb22f152-d24e-452b-9658-c3f8f1584aec", null, false, false, null, "Nombres 41 Apellidos 41", null, "PACIENTE31", "AQAAAAEAACcQAAAAEHwLZJO6oW0qTM4X2Z4kEXeJInadh0sxbB5elU5FuQ6pw1jEamsJe4Wrmb13z0jxWA==", null, false, "ed4b7757-a156-4632-8520-8f6b87c6efd8", false, "paciente31" },
                    { "e71adc3c-f178-4407-a03c-807ff0f1412f", 0, "999011fe-dc34-438a-be8a-4d34b5c06c22", null, false, false, null, "Nombres 39 Apellidos 39", null, "PACIENTE29", "AQAAAAEAACcQAAAAEIXMowkxxiQhm0qppye52pD/pgte/KW0Y7xzGNT/3BKoXh8L+NuC1RDY3C+3nywoPA==", null, false, "8e98930d-2ecc-41a6-8af3-a4e6ccea9bed", false, "paciente29" },
                    { "42463b90-8786-4c5a-9c72-46272a7a76c4", 0, "867e0a6c-db24-4fc4-aa8e-ce0871a18648", null, false, false, null, "Nombres 38 Apellidos 38", null, "PACIENTE28", "AQAAAAEAACcQAAAAEDIt701skWm2BO1rF/y3jjM9acxvwyPN0/7gDRa50BEeSfAJlxxwezXUkrsoJYnD7A==", null, false, "a64378b2-35e1-4380-abcc-9ce567a720b7", false, "paciente28" },
                    { "71562a5a-6e39-40b4-907e-80cc79bb9161", 0, "06c5fe38-afcb-4a71-8900-d2038f439108", null, false, false, null, "Nombres 37 Apellidos 37", null, "PACIENTE27", "AQAAAAEAACcQAAAAEA2XolKRxaKomMae197RteS7fagD5nf24+LVwZmY5v+OSKMKNWqvB5ZHFVy9t6ZHGQ==", null, false, "2c5913c8-9273-44d7-b0a0-b43c1be32cf7", false, "paciente27" },
                    { "099b64aa-e59b-4a6a-bf2c-f9a9116fb34f", 0, "3828bef1-e81c-430e-9e3d-767492306bd5", null, false, false, null, "Nombres 36 Apellidos 36", null, "PACIENTE26", "AQAAAAEAACcQAAAAECfrI19akAERzdGhv7Ud0LmrkaT1X5zXRKl2XiwQBTIKlMZ+Udtdszv7EG0+bY96oA==", null, false, "f6699859-355d-4cc5-aaa5-3cb3ec8bd367", false, "paciente26" },
                    { "a6aea1ec-a2eb-4b1f-af5d-815b0745d723", 0, "9b15d7d0-ff26-4355-b491-33610488e984", null, false, false, null, "Nombres 35 Apellidos 35", null, "PACIENTE25", "AQAAAAEAACcQAAAAEMVuyX4xB42FpwhPgnh+ggnBWvH3no3GzERV3kZABIk6ETesWbH23Y1nYt+MCAtwBg==", null, false, "90f0977f-08c5-4e8a-ae83-af81369db884", false, "paciente25" },
                    { "2a9f2a7a-7c2c-4bb8-86fe-ad5d512bedbb", 0, "b0690482-ded9-4aaa-b6d3-47253a4a1447", null, false, false, null, "Nombres 34 Apellidos 34", null, "PACIENTE24", "AQAAAAEAACcQAAAAEEI41HWT07F2LX93cbWX116rS9BmcYgscVLbwUEtHHiWqv/x/gxUTPDagZRQIbbzQA==", null, false, "14de6bed-2147-4c94-a4d8-e93454d75e1c", false, "paciente24" },
                    { "9554fb1e-1841-4639-ab3a-016062ac1c19", 0, "e76c7ac0-c085-4851-9920-8b2f62c4ec72", null, false, false, null, "Nombres 33 Apellidos 33", null, "PACIENTE23", "AQAAAAEAACcQAAAAECfEaRXqrvf7DFhNm2POP4H2FxGXXqKu196gUoHZTEzb/06SjvaZa/EDhrVyuhSuUQ==", null, false, "b3535b8f-21a3-44af-9c86-9239ca90811f", false, "paciente23" },
                    { "bac5cc48-5e80-4bf9-91f0-2ddc392bd733", 0, "c3c39dcb-2078-4e26-8193-86ebdb606bb0", null, false, false, null, "Nombres 32 Apellidos 32", null, "PACIENTE22", "AQAAAAEAACcQAAAAEMnkvuqREBfkKp4R9vky4Uzrd8MXnMgEO7Z9hYPtw5QIvmZ33qszNr2ENde97JkCzA==", null, false, "64f0207b-97ca-4bbe-a531-aeb9b86f2678", false, "paciente22" },
                    { "70c4bb92-4de4-4367-9268-698ee78766a3", 0, "deb05521-f9c2-4969-9be1-5d214fba2810", null, false, false, null, "Nombres 31 Apellidos 31", null, "PACIENTE21", "AQAAAAEAACcQAAAAENUc9JfBJa13VGC9fi/Sl5FK1npGanQgJGUnUHCsxSOeEL7L7NPQs5qLSRzm5tLxTg==", null, false, "0cecbfcd-bab1-4d67-b013-cb4155abc7a3", false, "paciente21" },
                    { "6f23e3cb-dbae-4c35-956b-df381a9f2263", 0, "b0f954f4-b932-4796-90ad-de95e345e9a7", null, false, false, null, "Nombres 30 Apellidos 30", null, "PACIENTE20", "AQAAAAEAACcQAAAAENoAhikK2e1l3dpkdBSza5ReCU7TF88/mmsfOSy/qbVL+lx7+ehMJpJcDg4lrYEBaw==", null, false, "79648f43-16fa-4caa-a417-d719b297c476", false, "paciente20" },
                    { "a92a53a0-6779-4f34-9c73-3e1a3ceb5b02", 0, "bd17197c-d41a-44f6-8fe7-cdd69ce48e59", null, false, false, null, "Nombres 29 Apellidos 29", null, "PACIENTE19", "AQAAAAEAACcQAAAAENvbZBAWd3jXpfBhErpP0L4Xe1q2KCkjAz/0b+FaJbrcqiz1q2sk0/sEl2fXrUglNQ==", null, false, "b5e6b851-05f0-4f03-98ce-e217e65ab569", false, "paciente19" },
                    { "5fa23993-02fa-4f6a-a0ab-bd3f644b53c1", 0, "fbb4dfe1-2632-4e66-99dc-4c15e4108dcd", null, false, false, null, "Nombres 40 Apellidos 40", null, "PACIENTE30", "AQAAAAEAACcQAAAAEOyViS2pJazz6NoG1bH0PXH60RWMaajXikRhh7Jkzaf1lTZIarRmJ6LmieRSCJgNoA==", null, false, "0526b448-1c16-489c-bba3-9302dafbee2a", false, "paciente30" },
                    { "0fc5f66e-44e6-4674-a493-c12190167903", 0, "77e66825-4917-4901-86e0-7376cee46dca", null, false, false, null, "Nombres 110 Apellidos 110", null, "PACIENTE100", "AQAAAAEAACcQAAAAEGaDPq3NngJO4S6YoSKKstJGsO1I1Edev7ioW+0k3AH7zIOCj6+qgrvNzO6cT/opNQ==", null, false, "1db37e78-2b52-47f6-af8f-99bf682a3101", false, "paciente100" }
                });

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId", "Discriminator" },
                values: new object[,]
                {
                    { "2301D884-221A-4E7D-B509-0113DCC043E1", "abf3c9d6-e975-46dd-85b7-3ab97480a06a", "RolUsuario" },
                    { "7D9B7113-A8F8-4035-99A7-A20DD400F6A3", "fc45b81d-a6f4-4564-a148-65340a2ebfc4", "RolUsuario" },
                    { "7D9B7113-A8F8-4035-99A7-A20DD400F6A3", "44a08975-0c9d-445a-bb56-7e7a73713c56", "RolUsuario" },
                    { "7D9B7113-A8F8-4035-99A7-A20DD400F6A3", "d687feaf-58ed-450d-a90f-d758ab94c490", "RolUsuario" },
                    { "7D9B7113-A8F8-4035-99A7-A20DD400F6A3", "cddbded3-b071-4cda-a0e3-e5c07eacf050", "RolUsuario" },
                    { "7D9B7113-A8F8-4035-99A7-A20DD400F6A3", "135c4e31-4642-457a-aac6-6fd0a4c84002", "RolUsuario" },
                    { "7D9B7113-A8F8-4035-99A7-A20DD400F6A3", "06bb0d90-f8f4-4859-9946-f462cce1debd", "RolUsuario" },
                    { "7D9B7113-A8F8-4035-99A7-A20DD400F6A3", "39967775-50d3-42ac-ab1b-af73976332d4", "RolUsuario" },
                    { "7D9B7113-A8F8-4035-99A7-A20DD400F6A3", "e5705e91-f019-402e-beec-58211c586fa0", "RolUsuario" },
                    { "7D9B7113-A8F8-4035-99A7-A20DD400F6A3", "9496c3cb-9bdb-4aee-8122-26389a2142f6", "RolUsuario" },
                    { "7D9B7113-A8F8-4035-99A7-A20DD400F6A3", "9fe2c51b-cd80-4693-863a-62dc2e8b2e84", "RolUsuario" },
                    { "7D9B7113-A8F8-4035-99A7-A20DD400F6A3", "58a7c671-5463-4612-9ca5-5b9f1d531ee0", "RolUsuario" },
                    { "7D9B7113-A8F8-4035-99A7-A20DD400F6A3", "b3480801-2136-4452-90aa-32158e249661", "RolUsuario" },
                    { "7D9B7113-A8F8-4035-99A7-A20DD400F6A3", "e8b98ef5-f136-44ba-bdbd-224127df9995", "RolUsuario" },
                    { "7D9B7113-A8F8-4035-99A7-A20DD400F6A3", "8e1387d7-f4db-4b83-acde-d2d9765d2233", "RolUsuario" },
                    { "7D9B7113-A8F8-4035-99A7-A20DD400F6A3", "0964ca1b-95c7-4da2-ae3b-786c4f485139", "RolUsuario" },
                    { "7D9B7113-A8F8-4035-99A7-A20DD400F6A3", "29417803-fc0f-4674-8368-ec8d58202145", "RolUsuario" },
                    { "7D9B7113-A8F8-4035-99A7-A20DD400F6A3", "c98ce1bc-d9f7-4d42-ba50-003a1834add9", "RolUsuario" },
                    { "7D9B7113-A8F8-4035-99A7-A20DD400F6A3", "1c17547d-63cc-4993-8595-60307f54b60d", "RolUsuario" },
                    { "7D9B7113-A8F8-4035-99A7-A20DD400F6A3", "6c4aec57-9672-4284-93b0-261bca0dae04", "RolUsuario" },
                    { "7D9B7113-A8F8-4035-99A7-A20DD400F6A3", "6ac1add2-25f7-473f-b1f6-9d04db1a939e", "RolUsuario" },
                    { "7D9B7113-A8F8-4035-99A7-A20DD400F6A3", "9bca5ab3-9665-486b-8aee-e0411413a000", "RolUsuario" },
                    { "7D9B7113-A8F8-4035-99A7-A20DD400F6A3", "5259e159-a707-4bdb-af32-b2d3888e120a", "RolUsuario" },
                    { "7D9B7113-A8F8-4035-99A7-A20DD400F6A3", "f6748d90-0bc6-4706-b813-d14023d1c3de", "RolUsuario" },
                    { "7D9B7113-A8F8-4035-99A7-A20DD400F6A3", "164b779e-405f-4551-ab7b-87f766e7b8a3", "RolUsuario" },
                    { "7D9B7113-A8F8-4035-99A7-A20DD400F6A3", "336d74fb-41bc-48b4-b092-1581c0facb80", "RolUsuario" },
                    { "7D9B7113-A8F8-4035-99A7-A20DD400F6A3", "118ea14a-a1ac-43f6-b6ae-1759636cb005", "RolUsuario" },
                    { "7D9B7113-A8F8-4035-99A7-A20DD400F6A3", "a06bf318-6f00-44f9-b68d-4a0203941d15", "RolUsuario" },
                    { "7D9B7113-A8F8-4035-99A7-A20DD400F6A3", "493ff3da-8f95-41e6-b05a-82b256315c51", "RolUsuario" },
                    { "7D9B7113-A8F8-4035-99A7-A20DD400F6A3", "aea55a88-5894-46f6-ae14-6fdd9eb5f49e", "RolUsuario" },
                    { "7D9B7113-A8F8-4035-99A7-A20DD400F6A3", "d31d7d64-a5b2-448c-a4b3-117698d31a41", "RolUsuario" },
                    { "7D9B7113-A8F8-4035-99A7-A20DD400F6A3", "ea186623-f60d-4a09-8977-a0ca51887fe5", "RolUsuario" },
                    { "7D9B7113-A8F8-4035-99A7-A20DD400F6A3", "233ea798-267d-43c2-919e-f3fdb4f04aac", "RolUsuario" },
                    { "7D9B7113-A8F8-4035-99A7-A20DD400F6A3", "1af46771-40f1-4195-a44c-b19243eb5d84", "RolUsuario" },
                    { "7D9B7113-A8F8-4035-99A7-A20DD400F6A3", "0fb03339-8037-4058-98b0-9c4c0fcdf0bf", "RolUsuario" },
                    { "7D9B7113-A8F8-4035-99A7-A20DD400F6A3", "76e563c2-784d-48f1-888d-4a0545c99e7e", "RolUsuario" },
                    { "7D9B7113-A8F8-4035-99A7-A20DD400F6A3", "bb8d2b53-69a6-4efe-9349-70418441213c", "RolUsuario" },
                    { "7D9B7113-A8F8-4035-99A7-A20DD400F6A3", "54784d2f-4983-40f1-ab34-a217190bde95", "RolUsuario" },
                    { "7D9B7113-A8F8-4035-99A7-A20DD400F6A3", "40cc0c1d-759e-4830-b514-5a3c806cc149", "RolUsuario" },
                    { "7D9B7113-A8F8-4035-99A7-A20DD400F6A3", "34bc776d-44d5-4d00-a342-250bc38d3bbd", "RolUsuario" },
                    { "7D9B7113-A8F8-4035-99A7-A20DD400F6A3", "2929d71f-2c3d-447e-960e-965261e0791c", "RolUsuario" },
                    { "7D9B7113-A8F8-4035-99A7-A20DD400F6A3", "bccb4c0e-15f3-45d1-aa0d-c6a01cf71b88", "RolUsuario" }
                });

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId", "Discriminator" },
                values: new object[,]
                {
                    { "7D9B7113-A8F8-4035-99A7-A20DD400F6A3", "08b3cfa8-00d1-4a48-8b23-6daef1c2d7bf", "RolUsuario" },
                    { "7D9B7113-A8F8-4035-99A7-A20DD400F6A3", "dad96e9b-0309-4b88-be7a-38a08d93d4e1", "RolUsuario" },
                    { "7D9B7113-A8F8-4035-99A7-A20DD400F6A3", "88fc1227-afc7-4f85-8280-c8984c19fa61", "RolUsuario" },
                    { "7D9B7113-A8F8-4035-99A7-A20DD400F6A3", "455205c7-5cee-43d7-9935-b9b2b561afdf", "RolUsuario" },
                    { "7D9B7113-A8F8-4035-99A7-A20DD400F6A3", "28f76da8-046b-4e67-9704-796afc260ab7", "RolUsuario" },
                    { "7D9B7113-A8F8-4035-99A7-A20DD400F6A3", "b4518c95-1ad5-4e7e-9d03-fec7445dcade", "RolUsuario" },
                    { "7D9B7113-A8F8-4035-99A7-A20DD400F6A3", "a5d25413-69e2-440a-b6ef-50e32ccffde0", "RolUsuario" },
                    { "7D9B7113-A8F8-4035-99A7-A20DD400F6A3", "5d436ad5-b7bf-47c5-a3fd-90d2762d0aaf", "RolUsuario" },
                    { "7D9B7113-A8F8-4035-99A7-A20DD400F6A3", "70b04840-5607-47a9-968c-733ea7143da0", "RolUsuario" },
                    { "7D9B7113-A8F8-4035-99A7-A20DD400F6A3", "e91e3215-4f8c-4fe4-b20f-a8717d50eb69", "RolUsuario" },
                    { "7D9B7113-A8F8-4035-99A7-A20DD400F6A3", "a6051997-9a95-4dca-9da6-41c7a3f9c309", "RolUsuario" },
                    { "7D9B7113-A8F8-4035-99A7-A20DD400F6A3", "257f6b05-a283-41a3-b959-37d0e7f1e369", "RolUsuario" },
                    { "7D9B7113-A8F8-4035-99A7-A20DD400F6A3", "290d5825-5736-4750-9da8-e058de6f0927", "RolUsuario" },
                    { "7D9B7113-A8F8-4035-99A7-A20DD400F6A3", "a9936a39-fac3-4005-b906-55a69c74c8f7", "RolUsuario" },
                    { "7D9B7113-A8F8-4035-99A7-A20DD400F6A3", "629bcd5c-a9a6-4188-b312-dc65b93929f3", "RolUsuario" },
                    { "7D9B7113-A8F8-4035-99A7-A20DD400F6A3", "0899019f-177e-4730-819f-9c1e67662592", "RolUsuario" },
                    { "7D9B7113-A8F8-4035-99A7-A20DD400F6A3", "32ae00e3-b23a-426a-b61b-12dd92b63e6d", "RolUsuario" },
                    { "7D9B7113-A8F8-4035-99A7-A20DD400F6A3", "db93e967-67c9-4f74-8acd-f81a40fe5e5e", "RolUsuario" },
                    { "7D9B7113-A8F8-4035-99A7-A20DD400F6A3", "218a712d-98db-4c22-8f30-0e878647ab36", "RolUsuario" },
                    { "7D9B7113-A8F8-4035-99A7-A20DD400F6A3", "22530143-1831-4614-a347-711789595852", "RolUsuario" },
                    { "7D9B7113-A8F8-4035-99A7-A20DD400F6A3", "8342ada0-2dda-4c6e-8faa-2b6994741d85", "RolUsuario" },
                    { "7D9B7113-A8F8-4035-99A7-A20DD400F6A3", "89470e2c-3f83-4a9a-9f7e-9f48c5f2b1c5", "RolUsuario" },
                    { "7D9B7113-A8F8-4035-99A7-A20DD400F6A3", "4cde87e8-116b-4e0c-9563-ae0cccfd24df", "RolUsuario" },
                    { "7D9B7113-A8F8-4035-99A7-A20DD400F6A3", "0749f085-fb61-4d77-8f79-86b296cb205c", "RolUsuario" },
                    { "7D9B7113-A8F8-4035-99A7-A20DD400F6A3", "2d160faa-c906-46a3-9a74-ec2097879a95", "RolUsuario" },
                    { "7D9B7113-A8F8-4035-99A7-A20DD400F6A3", "93d197f8-f2ee-4245-827c-1ff01a3ec7ec", "RolUsuario" },
                    { "7D9B7113-A8F8-4035-99A7-A20DD400F6A3", "9e69547a-7ba4-456c-aa6e-a6e47a891a14", "RolUsuario" },
                    { "7D9B7113-A8F8-4035-99A7-A20DD400F6A3", "9f4a6abe-8189-4caf-bb0a-b77c586b000f", "RolUsuario" },
                    { "7D9B7113-A8F8-4035-99A7-A20DD400F6A3", "fc87006d-41da-4af5-9617-a5d6caee53a2", "RolUsuario" },
                    { "2301D884-221A-4E7D-B509-0113DCC043E1", "2ef4e493-478d-4433-bf76-d3fe49d468d8", "RolUsuario" },
                    { "2301D884-221A-4E7D-B509-0113DCC043E1", "03daa74e-a602-4a3c-93eb-6733dcc38440", "RolUsuario" },
                    { "2301D884-221A-4E7D-B509-0113DCC043E1", "26e4db4d-0a55-4650-924b-64302bba2028", "RolUsuario" },
                    { "2301D884-221A-4E7D-B509-0113DCC043E1", "e61ba7db-8adf-4faa-a6e0-42d0cca5d773", "RolUsuario" },
                    { "2301D884-221A-4E7D-B509-0113DCC043E1", "d1633117-42ce-43d3-90d4-d3d80a4ebdd7", "RolUsuario" },
                    { "2301D884-221A-4E7D-B509-0113DCC043E1", "8364a7ba-3d95-4aa6-bc22-7f223cad8110", "RolUsuario" },
                    { "2301D884-221A-4E7D-B509-0113DCC043E1", "cfa96164-a08b-4c61-87f7-80d86811c1fa", "RolUsuario" },
                    { "2301D884-221A-4E7D-B509-0113DCC043E1", "2b064cbd-6222-4a3a-8a9e-f3533295d7c2", "RolUsuario" },
                    { "2301D884-221A-4E7D-B509-0113DCC043E1", "fade2f16-c69c-4c8c-9469-d64111c171e9", "RolUsuario" },
                    { "7D9B7113-A8F8-4035-99A7-A20DD400F6A3", "67e4e381-ac15-4994-a4cb-0fd4b077f2fd", "RolUsuario" },
                    { "7D9B7113-A8F8-4035-99A7-A20DD400F6A3", "599b671b-ee11-46e0-8b18-0a39116a8dc4", "RolUsuario" },
                    { "7D9B7113-A8F8-4035-99A7-A20DD400F6A3", "3652e55e-089a-469a-9816-a1456f96b888", "RolUsuario" },
                    { "7D9B7113-A8F8-4035-99A7-A20DD400F6A3", "a92a53a0-6779-4f34-9c73-3e1a3ceb5b02", "RolUsuario" }
                });

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId", "Discriminator" },
                values: new object[,]
                {
                    { "7D9B7113-A8F8-4035-99A7-A20DD400F6A3", "1c3cd480-4d8b-4155-bc18-aa8a6d104906", "RolUsuario" },
                    { "7D9B7113-A8F8-4035-99A7-A20DD400F6A3", "855c7af2-94fe-4725-817e-d13adcd346cc", "RolUsuario" },
                    { "7D9B7113-A8F8-4035-99A7-A20DD400F6A3", "7414a517-4e22-4cc9-8065-b9f9e5dfc5e1", "RolUsuario" },
                    { "7D9B7113-A8F8-4035-99A7-A20DD400F6A3", "03562687-677d-44de-bb98-092aa48868f9", "RolUsuario" },
                    { "7D9B7113-A8F8-4035-99A7-A20DD400F6A3", "308ecf85-d730-4643-a0a0-9126a620432f", "RolUsuario" },
                    { "7D9B7113-A8F8-4035-99A7-A20DD400F6A3", "66826096-4680-46e2-b4ac-796391ed5955", "RolUsuario" },
                    { "7D9B7113-A8F8-4035-99A7-A20DD400F6A3", "fe4faeff-e9eb-49ea-8666-ba209ee75dda", "RolUsuario" },
                    { "7D9B7113-A8F8-4035-99A7-A20DD400F6A3", "40eea69e-7393-4427-b345-c1c97f217dd7", "RolUsuario" },
                    { "7D9B7113-A8F8-4035-99A7-A20DD400F6A3", "017eeb23-0198-41cc-af7d-4fa3a04cc11f", "RolUsuario" },
                    { "7D9B7113-A8F8-4035-99A7-A20DD400F6A3", "fcbd55f2-dddc-4323-a1f7-4f7cae669732", "RolUsuario" },
                    { "7D9B7113-A8F8-4035-99A7-A20DD400F6A3", "3e43e3ff-03c6-4de3-b3f2-8b5b8ea41488", "RolUsuario" },
                    { "7D9B7113-A8F8-4035-99A7-A20DD400F6A3", "b425da28-64bd-4c09-82f6-2d86bdab738d", "RolUsuario" },
                    { "7D9B7113-A8F8-4035-99A7-A20DD400F6A3", "e0f8bc04-44f7-4a6c-a6d6-afd2ee4f4e40", "RolUsuario" },
                    { "7D9B7113-A8F8-4035-99A7-A20DD400F6A3", "5fa23993-02fa-4f6a-a0ab-bd3f644b53c1", "RolUsuario" },
                    { "7D9B7113-A8F8-4035-99A7-A20DD400F6A3", "e71adc3c-f178-4407-a03c-807ff0f1412f", "RolUsuario" },
                    { "7D9B7113-A8F8-4035-99A7-A20DD400F6A3", "42463b90-8786-4c5a-9c72-46272a7a76c4", "RolUsuario" },
                    { "7D9B7113-A8F8-4035-99A7-A20DD400F6A3", "71562a5a-6e39-40b4-907e-80cc79bb9161", "RolUsuario" },
                    { "7D9B7113-A8F8-4035-99A7-A20DD400F6A3", "099b64aa-e59b-4a6a-bf2c-f9a9116fb34f", "RolUsuario" },
                    { "7D9B7113-A8F8-4035-99A7-A20DD400F6A3", "a6aea1ec-a2eb-4b1f-af5d-815b0745d723", "RolUsuario" },
                    { "7D9B7113-A8F8-4035-99A7-A20DD400F6A3", "2a9f2a7a-7c2c-4bb8-86fe-ad5d512bedbb", "RolUsuario" },
                    { "7D9B7113-A8F8-4035-99A7-A20DD400F6A3", "9554fb1e-1841-4639-ab3a-016062ac1c19", "RolUsuario" },
                    { "7D9B7113-A8F8-4035-99A7-A20DD400F6A3", "bac5cc48-5e80-4bf9-91f0-2ddc392bd733", "RolUsuario" },
                    { "7D9B7113-A8F8-4035-99A7-A20DD400F6A3", "70c4bb92-4de4-4367-9268-698ee78766a3", "RolUsuario" },
                    { "7D9B7113-A8F8-4035-99A7-A20DD400F6A3", "6f23e3cb-dbae-4c35-956b-df381a9f2263", "RolUsuario" },
                    { "7D9B7113-A8F8-4035-99A7-A20DD400F6A3", "f5fda1db-ec12-46ff-a6fd-328cfc5dbeeb", "RolUsuario" },
                    { "7D9B7113-A8F8-4035-99A7-A20DD400F6A3", "0fc5f66e-44e6-4674-a493-c12190167903", "RolUsuario" }
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
