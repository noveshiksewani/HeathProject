using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using HeathProject.Models;

#nullable disable

namespace HeathProject.DbContexts
{
    public partial class testContext : DbContext
    {
        public testContext()
        {
        }

        public testContext(DbContextOptions<testContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Address> Addresses { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }
        public virtual DbSet<Donation> Donations { get; set; }
        public virtual DbSet<EfmigrationsHistory> EfmigrationsHistories { get; set; }
        public virtual DbSet<Food> Foods { get; set; }
        public virtual DbSet<Money> Money { get; set; }
        public virtual DbSet<Oxygen> Oxygens { get; set; }
        public virtual DbSet<Plasma> Plasmas { get; set; }
        public virtual DbSet<Post> Posts { get; set; }
        public virtual DbSet<Privilage> Privilages { get; set; }
        public virtual DbSet<QuarantinePlace> QuarantinePlaces { get; set; }
        public virtual DbSet<User> Users { get; set; }

       /* protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySql("server=143.110.242.84;port=3306;user=admin;password=40ea713569aad7d225ae2bafef198d2fbebc29297810cff5;database=test", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.21-mysql"));
            }
        }*/

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_0900_ai_ci");

            modelBuilder.Entity<Comment>(entity =>
            {
                entity.Property(e => e.Timestamp).HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.HasOne(d => d.Post)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(d => d.PostId)
                    .HasConstraintName("Comments_post_postId_fk");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("Comments_User_userId_fk");
            });

            modelBuilder.Entity<Donation>(entity =>
            {
                entity.HasKey(e => e.DontationId)
                    .HasName("PRIMARY");

                entity.Property(e => e.TimeStamp)
                    .ValueGeneratedOnAddOrUpdate()
                    .HasDefaultValueSql("CURRENT_TIMESTAMP(6)");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Donations)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Donation_User_userId_fk");
            });

            modelBuilder.Entity<EfmigrationsHistory>(entity =>
            {
                entity.HasKey(e => e.MigrationId)
                    .HasName("PRIMARY");
            });

            modelBuilder.Entity<Food>(entity =>
            {
                entity.HasOne(d => d.User)
                    .WithMany(p => p.Foods)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("Food_User_userId_fk");
            });

            modelBuilder.Entity<Money>(entity =>
            {
                entity.Property(e => e.Amount).HasPrecision(18, 2);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Money)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("Money_User_userId_fk");
            });

            modelBuilder.Entity<Oxygen>(entity =>
            {
                entity.HasOne(d => d.User)
                    .WithMany(p => p.Oxygens)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("Oxygen_User_userId_fk");
            });

            modelBuilder.Entity<Plasma>(entity =>
            {
                entity.HasOne(d => d.User)
                    .WithMany(p => p.Plasmas)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("Plasma_User_userId_fk");
            });

            modelBuilder.Entity<Post>(entity =>
            {
                entity.Property(e => e.Timestamp)
                    .ValueGeneratedOnAddOrUpdate()
                    .HasDefaultValueSql("CURRENT_TIMESTAMP(6)");
            });

            modelBuilder.Entity<Privilage>(entity =>
            {
                entity.HasKey(e => e.MinitreeId)
                    .HasName("PRIMARY");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Privilages)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("Privilages_User_userId_fk");
            });

            modelBuilder.Entity<QuarantinePlace>(entity =>
            {
                entity.HasKey(e => e.PlaceId)
                    .HasName("PRIMARY");

                entity.HasOne(d => d.Address)
                    .WithMany(p => p.QuarantinePlaces)
                    .HasForeignKey(d => d.AddressId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("QuarantinePlace_Address_addressId_fk");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.QuarantinePlaces)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("QuarantinePlace_User_userId_fk");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Gender).IsFixedLength(true);

                entity.Property(e => e.Role).IsFixedLength(true);

                entity.HasOne(d => d.Address)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.AddressId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("User_Address_addressId_fk");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
