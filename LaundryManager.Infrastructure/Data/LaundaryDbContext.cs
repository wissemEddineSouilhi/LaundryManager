using LaundryManager.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace LaundryManager.Infrastructure.Data
{
    internal class LaundaryDbContext : DbContext
    {

        internal DbSet<User> Users { get; set; }
        internal DbSet<Role> Roles { get; set; }
        internal DbSet<Command> Commands { get; set; }
        internal DbSet<Article> Articles { get; set; }
        internal DbSet<ArticleType> ArticleTypes { get; set; }
        internal DbSet<CommandStatus> CommandStatuses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.HasKey(u => u.Id);

                entity.Property(u => u.FirstName).IsRequired();
                entity.Property(u => u.LastName).IsRequired();
                entity.Property(u => u.Email).IsRequired();
                entity.Property(u => u.Password).IsRequired();
                entity.Property(u => u.CreationDate).IsRequired();

                entity.HasOne(u => u.Role)
                      .WithMany()
                      .HasForeignKey(u => u.RoleId)
                      .OnDelete(DeleteBehavior.Restrict);
            });


            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("Role");

                entity.HasKey(r => r.Id);

                entity.Property(r => r.Code).IsRequired();
                entity.Property(r => r.Name).IsRequired();
            });


            modelBuilder.Entity<Command>(entity =>
            {
                entity.ToTable("Command");

                entity.HasKey(c => c.Id);

                entity.Property(c => c.CreationDate).IsRequired();
                entity.Property(c => c.Reason);
                entity.Property(c => c.Comment);

                entity.HasOne(c => c.User)
                      .WithMany()
                      .HasForeignKey(c => c.UserId)
                      .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(c => c.Status)
                      .WithMany()
                      .HasForeignKey(c => c.StatusId)
                      .OnDelete(DeleteBehavior.Restrict);

            });


            modelBuilder.Entity<CommandStatus>(entity =>
            {
                entity.ToTable("CommandStatus");

                entity.HasKey(s => s.Id);

                entity.Property(s => s.Code).IsRequired();
                entity.Property(s => s.Name).IsRequired();
            });


            modelBuilder.Entity<Article>(entity =>
            {
                entity.ToTable("Article");

                entity.HasKey(a => a.Id);

                entity.Property(a => a.Name).IsRequired();
                entity.Property(a => a.Description);
                entity.Property(a => a.CreationDate).IsRequired();

                entity.HasOne(a => a.ArticleType)
                      .WithMany()
                      .HasForeignKey(a => a.ArticleTypeId);

                entity.HasOne(a => a.Command)
                      .WithMany()
                      .HasForeignKey(a => a.CommandId);
            });


            modelBuilder.Entity<ArticleType>(entity =>
            {
                entity.ToTable("ArticleType");

                entity.HasKey(at => at.Id);

                entity.Property(at => at.Code).IsRequired();
                entity.Property(at => at.Name).IsRequired();
            });


        }

        #region For migration only
        internal static bool isMigration = true;
        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder)
        {
            if (isMigration)
            {
                dbContextOptionsBuilder.UseSqlServer("Data Source= 127.0.0.1,1433;Initial Catalog=LaundryManagerDb;User Id=sa;Password=TestDeploymentPWD01@;TrustServerCertificate=True");
            }

        }
        #endregion
    }
}
