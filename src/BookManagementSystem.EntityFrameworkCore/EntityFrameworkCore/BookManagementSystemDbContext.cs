using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using BookManagementSystem.Authorization.Roles;
using BookManagementSystem.Authorization.Users;
using BookManagementSystem.MultiTenancy;
using BookManagementSystem.Books;
using BookManagementSystem.Authors;
using BookManagementSystem.BookAuthors;
using BookManagementSystem.EBooks;
using BookManagementSystem.EBookAuthors;
using BookManagementSystem.BookBorrows;
using BookManagementSystem.BookHistories;
using BookManagementSystem.Forums;
using BookManagementSystem.ForumReplies;
using BookManagementSystem.Suggestions;
using BookManagementSystem.Feedbacks;
using BookManagementSystem.EBooksFeedback;

namespace BookManagementSystem.EntityFrameworkCore
{
    public class BookManagementSystemDbContext : AbpZeroDbContext<Tenant, Role, User, BookManagementSystemDbContext>
    {
        /* Define a DbSet for each entity of the application */

        public BookManagementSystemDbContext(DbContextOptions<BookManagementSystemDbContext> options)
        : base(options)
        {
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<BookAuthor> BookAuthors { get; set; }
        public DbSet<EBook> EBooks { get; set; }
        public DbSet<EBookAuthor> EBookAuthors { get; set; }
        public DbSet<BookBorrow> BookBorrows { get; set; }
        public DbSet<BookHistory> BookHistories { get; set; }
        public DbSet<Forum> Forums { get; set; }
        public DbSet<ForumReply> ForumReplies { get; set; }
        public DbSet<Suggestion> Suggestions { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }
        public DbSet<EBookFeedback> EBookFeedbacks { get; set; }
        
    }
}
