using Microsoft.EntityFrameworkCore.Migrations;

namespace JobGetter.Migrations
{
    public partial class uploadfile : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CVName",
                table: "JobOpportunityRequests",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CVName",
                table: "JobOpportunityRequests");
        }
    }
}
