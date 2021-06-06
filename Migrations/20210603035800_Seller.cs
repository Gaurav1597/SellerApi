using Microsoft.EntityFrameworkCore.Migrations;

namespace SellerApi.Migrations
{
    public partial class Seller : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Sellerslist",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    sellername = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    company = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    producttype = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    commission = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sellerslist", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Sellerslist");
        }
    }
}
