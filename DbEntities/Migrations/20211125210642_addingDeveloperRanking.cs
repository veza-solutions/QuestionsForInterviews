using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DbEntities.Migrations
{
    public partial class addingDeveloperRanking : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "DeveloperRankId",
                table: "Tests",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "DeveloperRankId",
                table: "Questions",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "DeveloperRankId",
                table: "QuestionAnswers",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "DeveloperRanks",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RankName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeveloperRanks", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tests_DeveloperRankId",
                table: "Tests",
                column: "DeveloperRankId");

            migrationBuilder.CreateIndex(
                name: "IX_Questions_DeveloperRankId",
                table: "Questions",
                column: "DeveloperRankId");

            migrationBuilder.CreateIndex(
                name: "IX_QuestionAnswers_DeveloperRankId",
                table: "QuestionAnswers",
                column: "DeveloperRankId");

            migrationBuilder.AddForeignKey(
                name: "FK_QuestionAnswers_DeveloperRanks_DeveloperRankId",
                table: "QuestionAnswers",
                column: "DeveloperRankId",
                principalTable: "DeveloperRanks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_DeveloperRanks_DeveloperRankId",
                table: "Questions",
                column: "DeveloperRankId",
                principalTable: "DeveloperRanks",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Tests_DeveloperRanks_DeveloperRankId",
                table: "Tests",
                column: "DeveloperRankId",
                principalTable: "DeveloperRanks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_QuestionAnswers_DeveloperRanks_DeveloperRankId",
                table: "QuestionAnswers");

            migrationBuilder.DropForeignKey(
                name: "FK_Questions_DeveloperRanks_DeveloperRankId",
                table: "Questions");

            migrationBuilder.DropForeignKey(
                name: "FK_Tests_DeveloperRanks_DeveloperRankId",
                table: "Tests");

            migrationBuilder.DropTable(
                name: "DeveloperRanks");

            migrationBuilder.DropIndex(
                name: "IX_Tests_DeveloperRankId",
                table: "Tests");

            migrationBuilder.DropIndex(
                name: "IX_Questions_DeveloperRankId",
                table: "Questions");

            migrationBuilder.DropIndex(
                name: "IX_QuestionAnswers_DeveloperRankId",
                table: "QuestionAnswers");

            migrationBuilder.DropColumn(
                name: "DeveloperRankId",
                table: "Tests");

            migrationBuilder.DropColumn(
                name: "DeveloperRankId",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "DeveloperRankId",
                table: "QuestionAnswers");
        }
    }
}
