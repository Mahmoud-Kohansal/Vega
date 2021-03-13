using Microsoft.EntityFrameworkCore.Migrations;

namespace Vega.Migrations
{
    public partial class SeedDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO makes (Name) VALUES('Make1')");
            migrationBuilder.Sql("INSERT INTO makes (Name) VALUES('Make2')");
            migrationBuilder.Sql("INSERT INTO makes (Name) VALUES('Make3')");

            migrationBuilder.Sql("INSERT INTO models (Name, MakeId) VALUES('Make1-ModelA',(SELECT Id FROM makes WHERE Name='Make1'))");
            migrationBuilder.Sql("INSERT INTO models (Name, MakeId) VALUES('Make1-ModelB',(SELECT Id FROM makes WHERE Name='Make1'))");
            migrationBuilder.Sql("INSERT INTO models (Name, MakeId) VALUES('Make1-ModelC',(SELECT Id FROM makes WHERE Name='Make1'))");

            migrationBuilder.Sql("INSERT INTO models (Name, MakeId) VALUES('Make2-ModelA',(SELECT Id FROM makes WHERE Name='Make2'))");
            migrationBuilder.Sql("INSERT INTO models (Name, MakeId) VALUES('Make2-ModelB',(SELECT Id FROM makes WHERE Name='Make2'))");
            migrationBuilder.Sql("INSERT INTO models (Name, MakeId) VALUES('Make2-ModelC',(SELECT Id FROM makes WHERE Name='Make2'))");

            migrationBuilder.Sql("INSERT INTO models (Name, MakeId) VALUES('Make3-ModelA',(SELECT Id FROM makes WHERE Name='Make3'))");
            migrationBuilder.Sql("INSERT INTO models (Name, MakeId) VALUES('Make3-ModelB',(SELECT Id FROM makes WHERE Name='Make3'))");
            migrationBuilder.Sql("INSERT INTO models (Name, MakeId) VALUES('Make3-ModelC',(SELECT Id FROM makes WHERE Name='Make3'))");


        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM makes");

        }
    }
}
