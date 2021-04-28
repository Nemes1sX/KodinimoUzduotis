using Microsoft.EntityFrameworkCore.Migrations;

namespace KodinimoUzduotis.Migrations
{
    public partial class IntialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CodeSolutions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    Solution = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CodeSolutions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Success = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "CodeSolutions",
                columns: new[] { "Id", "Description", "Name", "Solution" },
                values: new object[] { 1, "Fibonacci sequence, such that each number is the sum of the two preceding ones, starting from 0 and 1", "Fibonacci", "<?php $n=10; echo round(pow((sqrt(5)+1)/2, $n) / sqrt(5)); ?> " });

            migrationBuilder.InsertData(
                table: "CodeSolutions",
                columns: new[] { "Id", "Description", "Name", "Solution" },
                values: new object[] { 2, "Sum of digits of a number just add all the digits.", "Digit sum", "<?php $num = 14597;  $sum = 0; $rem = 0; for ($i = 0; $i <= strlen($num);$i++)  {  $rem =$num % 10;  $sum = $sum + $rem;  $num =$num / 10; } echo $sum; } ?>" });

            migrationBuilder.InsertData(
                table: "CodeSolutions",
                columns: new[] { "Id", "Description", "Name", "Solution" },
                values: new object[] { 3, "A number can be written in reverse order.", "Reverse number", "<?php  $num = 23456;  $revnum = 0; while ($num > 1)  {  $rem = $num % 10;  $revnum = ($revnum * 10) + $rem;  $num = ($num / 10) } echo $revnum;  ?>" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CodeSolutions");

            migrationBuilder.DropTable(
                name: "Players");
        }
    }
}
