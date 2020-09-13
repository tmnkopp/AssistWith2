using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AssistWith.Data.Migrations
{
    public partial class profiles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    ClientID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Company = table.Column<string>(nullable: true),
                    ContactName = table.Column<string>(nullable: true),
                    ContactAddress = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    PasswordSalt = table.Column<string>(nullable: true),
                    WebsiteUrl = table.Column<string>(nullable: true),
                    SiteLogin = table.Column<string>(nullable: true),
                    SitePassword = table.Column<string>(nullable: true),
                    HostingUrl = table.Column<string>(nullable: true),
                    HostingLogin = table.Column<string>(nullable: true),
                    HostingPass = table.Column<string>(nullable: true),
                    FTPLogin = table.Column<string>(nullable: true),
                    FTPPass = table.Column<string>(nullable: true),
                    DBLogin = table.Column<string>(nullable: true),
                    DBPass = table.Column<string>(nullable: true),
                    Notes = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.ClientID);
                });

            migrationBuilder.CreateTable(
                name: "JobLeads",
                columns: table => new
                {
                    JobLeadId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    JobLeadCode = table.Column<string>(nullable: true),
                    CompanyName = table.Column<string>(nullable: true),
                    ContactName = table.Column<string>(nullable: true),
                    ContactPhone = table.Column<string>(nullable: true),
                    ContactAddress = table.Column<string>(nullable: true),
                    PortalUrl = table.Column<string>(nullable: true),
                    Username = table.Column<string>(nullable: true),
                    PasswordSalt = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    JobTitle = table.Column<string>(nullable: true),
                    JobSource = table.Column<string>(nullable: true),
                    JobSourceURL = table.Column<string>(nullable: true),
                    JobDescription = table.Column<string>(nullable: true),
                    ApplyDate = table.Column<DateTime>(nullable: true),
                    Notes = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobLeads", x => x.JobLeadId);
                });

            migrationBuilder.CreateTable(
                name: "Profiles",
                columns: table => new
                {
                    ProfileId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PROCODE = table.Column<string>(nullable: true),
                    ProfileUrl = table.Column<string>(nullable: true),
                    Username = table.Column<string>(nullable: true),
                    PasswordSalt = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: false),
                    Notes = table.Column<string>(nullable: true),
                    SortOrder = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profiles", x => x.ProfileId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "JobLeads");

            migrationBuilder.DropTable(
                name: "Profiles");
        }
    }
}
