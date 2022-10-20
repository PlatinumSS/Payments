using Microsoft.EntityFrameworkCore;
using Payments.Entities;

namespace Payments
{
    public class Context : DbContext
    {
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Parent> Parents { get; set; }

        public Context()
        {
        }

        public Context(DbContextOptions<Context> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Payment>().Property(payment => payment.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<Account>().Property(account => account.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<Parent>().Property(parent => parent.Id).ValueGeneratedOnAdd();

            modelBuilder.Entity<Parent>()
                .HasMany(parent => parent.Children)
                .WithOne(account => account.Parent)
                .HasForeignKey(account => account.ParentId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Account>().HasIndex(account => account.AccNum).IsUnique();
            modelBuilder.Entity<Parent>().HasIndex(parent => parent.AccNum).IsUnique();
            modelBuilder.Entity<Account>().HasKey(account => account.Id);
            modelBuilder.Entity<Parent>().HasKey(parent => parent.Id);
        }
    }
}