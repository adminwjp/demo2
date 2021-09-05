#if NET5_0
using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Shop.Migrations.Shop
{
    public partial class a7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "t_email_notify_product",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    status = table.Column<char>(type: "TEXT", maxLength: 50, nullable: false),
                    notifydate = table.Column<DateTime>(type: "TEXT", maxLength: 50, nullable: false),
                    product_name = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true),
                    receive_email = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true),
                    product_i_d = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true),
                    send_failure_count = table.Column<int>(type: "INTEGER", maxLength: 50, nullable: false),
                    account = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true),
                    seller_id = table.Column<long>(type: "INTEGER", maxLength: 50, nullable: true),
                    buyer_id = table.Column<long>(type: "INTEGER", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("id", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "t_email_notify_product");
        }
    }
}
#endif