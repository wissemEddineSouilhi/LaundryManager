using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LaundryManager.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddinitialData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
            table: "Role",
            columns: new[] { "Id", "Code", "Name" },
            values: new object[,]
            {
                { Guid.NewGuid(), 1, "Admin" },
                { Guid.NewGuid(), 2, "User" }
            }
            );

            migrationBuilder.InsertData(
            table: "ArticleType",
            columns: new[] { "Id", "Code", "Name" },
            values: new object[,]
            {
                { Guid.NewGuid(), 1, "T-Shirt" },
                { Guid.NewGuid(), 2, "Shirt" },
                { Guid.NewGuid(), 3, "Pants" },
                { Guid.NewGuid(), 4, "Socks" },
                { Guid.NewGuid(), 5, "Underwear" },
                { Guid.NewGuid(), 6, "Sweater" },
                { Guid.NewGuid(), 7, "Dress" },
                { Guid.NewGuid(), 8, "Skirt" },
                { Guid.NewGuid(), 9, "Jacket" },
                { Guid.NewGuid(), 10, "Coat" },
                { Guid.NewGuid(), 11, "Other" }
            }
            );

            migrationBuilder.InsertData(
            table: "CommandStatus",
            columns: new[] { "Id", "Code", "Name" },
            values: new object[,]
            {
                { Guid.NewGuid(), 0, "Pending" },
                { Guid.NewGuid(), 1, "Valid" },
                { Guid.NewGuid(), 2, "Invalid" }
            }
                );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                delete FROM [Role] ;
                delete FROM [ArticleType] ;
                delete FROM [CommandStatus] ;
            ");
        }
    }
}
