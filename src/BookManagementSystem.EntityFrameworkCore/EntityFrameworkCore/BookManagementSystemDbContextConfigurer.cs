using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace BookManagementSystem.EntityFrameworkCore
{
    public static class BookManagementSystemDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<BookManagementSystemDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<BookManagementSystemDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}
