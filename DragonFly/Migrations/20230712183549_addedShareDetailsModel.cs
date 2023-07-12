using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DragonFly.Migrations
{
    /// <inheritdoc />
    public partial class addedShareDetailsModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ShareDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MemberInformationId = table.Column<int>(type: "int", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false),
                    Month = table.Column<int>(type: "int", nullable: false),
                    NoOfShare = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShareDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShareDetails_MemberInformation_MemberInformationId",
                        column: x => x.MemberInformationId,
                        principalTable: "MemberInformation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ShareDetails_MemberInformationId",
                table: "ShareDetails",
                column: "MemberInformationId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ShareDetails");
        }
    }
}
