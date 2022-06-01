using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Games_Storage.Migrations
{
    public partial class SeedGenreTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string sql = (@"
                Insert INTO Genres (Id, Name) Values (1, 'Strategy')
                Insert INTO Genres (Id, Name) Values (2, 'RPG')
                Insert INTO Genres (Id, Name) Values (3, 'Quest')
                Insert INTO Genres (Id, Name) Values (4, 'Arcade')
            ");

            migrationBuilder.Sql(sql);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            string sql = (@"
                Delete Genres Where Id = 1
                Delete Genres Where Id = 2
                Delete Genres Where Id = 3
                Delete Genres Where Id = 4
            ");

            migrationBuilder.Sql(sql);
        }
    }
}
