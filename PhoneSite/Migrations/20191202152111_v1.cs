using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PhoneSite.Migrations
{
    public partial class v1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FirmPhones",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NameFirm = table.Column<string>(nullable: true),
                    ImageFirm = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FirmPhones", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserName = table.Column<string>(nullable: true),
                    PasswordHash = table.Column<byte[]>(nullable: true),
                    PasswordSalt = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ModelPhones",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Model = table.Column<string>(nullable: true),
                    FirmPhoneId = table.Column<int>(nullable: false),
                    Display = table.Column<string>(nullable: true),
                    Camera = table.Column<string>(nullable: true),
                    Processor = table.Column<string>(nullable: true),
                    Storage = table.Column<string>(nullable: true),
                    Battery = table.Column<string>(nullable: true),
                    Others = table.Column<string>(nullable: true),
                    Price = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModelPhones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ModelPhones_FirmPhones_FirmPhoneId",
                        column: x => x.FirmPhoneId,
                        principalTable: "FirmPhones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ImagePhones",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ImageModelAddress = table.Column<string>(nullable: true),
                    ModelPhoneId = table.Column<int>(nullable: false),
                    isMain = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImagePhones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ImagePhones_ModelPhones_ModelPhoneId",
                        column: x => x.ModelPhoneId,
                        principalTable: "ModelPhones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ImagePhones_ModelPhoneId",
                table: "ImagePhones",
                column: "ModelPhoneId");

            migrationBuilder.CreateIndex(
                name: "IX_ModelPhones_FirmPhoneId",
                table: "ModelPhones",
                column: "FirmPhoneId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ImagePhones");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "ModelPhones");

            migrationBuilder.DropTable(
                name: "FirmPhones");
        }
    }
}
