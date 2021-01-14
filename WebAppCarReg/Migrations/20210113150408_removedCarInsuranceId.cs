using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAppCarReg.Migrations
{
    public partial class removedCarInsuranceId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Id",
                table: "CarInsurances");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "CarInsurances",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
