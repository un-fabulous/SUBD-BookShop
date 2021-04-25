using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using LaborExchangeDatabaseImplement.Models;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace LaborExchangeDatabaseImplement
{
    public partial class postgresContext : DbContext
    {
        public postgresContext()
        {
        }

        public postgresContext(DbContextOptions<postgresContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Authors> Authors { get; set; }
        public virtual DbSet<BookAuthor> BookAuthor { get; set; }
        public virtual DbSet<BookOrder> BookOrder { get; set; }
        public virtual DbSet<Books> Books { get; set; }
        public virtual DbSet<Orders> Orders { get; set; }
        public virtual DbSet<Publishinghouse> Publishinghouse { get; set; }
        public virtual DbSet<PublishinghouseBook> PublishinghouseBook { get; set; }
        public virtual DbSet<Status> Status { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=postgres;Username=postgres;Password=333");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasPostgresExtension("adminpack");

            modelBuilder.Entity<Authors>(entity =>
            {
                entity.HasKey(e => e.Authorid)
                    .HasName("authors_pkey");

                entity.ToTable("authors");

                entity.Property(e => e.Authorid).HasColumnName("authorid");

                entity.Property(e => e.Middlename)
                    .HasColumnName("middlename")
                    .HasMaxLength(255);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(255);

                entity.Property(e => e.Rating)
                    .HasColumnName("rating")
                    .HasColumnType("numeric(2,1)");

                entity.Property(e => e.Surname)
                    .IsRequired()
                    .HasColumnName("surname")
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<BookAuthor>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("book_author");

                entity.Property(e => e.Authorid)
                    .HasColumnName("authorid")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Bookid)
                    .HasColumnName("bookid")
                    .ValueGeneratedOnAdd();

                entity.HasOne(d => d.Author)
                    .WithMany()
                    .HasForeignKey(d => d.Authorid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("author_fker");

                entity.HasOne(d => d.Book)
                    .WithMany()
                    .HasForeignKey(d => d.Bookid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("book_fker");
            });

            modelBuilder.Entity<BookOrder>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("book_order");

                entity.Property(e => e.Bookid)
                    .HasColumnName("bookid")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Orderid)
                    .HasColumnName("orderid")
                    .ValueGeneratedOnAdd();

                entity.HasOne(d => d.Book)
                    .WithMany()
                    .HasForeignKey(d => d.Bookid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("book_fker");

                entity.HasOne(d => d.Order)
                    .WithMany()
                    .HasForeignKey(d => d.Orderid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("orders_fker");
            });

            modelBuilder.Entity<Books>(entity =>
            {
                entity.HasKey(e => e.Bookid)
                    .HasName("books_pkey");

                entity.ToTable("books");

                entity.Property(e => e.Bookid).HasColumnName("bookid");

                entity.Property(e => e.Amount).HasColumnName("amount");

                entity.Property(e => e.Genre)
                    .HasColumnName("genre")
                    .HasMaxLength(255);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(255);

                entity.Property(e => e.Price)
                    .HasColumnName("price")
                    .HasColumnType("numeric(10,2)");

                entity.Property(e => e.Rating)
                    .HasColumnName("rating")
                    .HasColumnType("numeric(2,1)");
            });

            modelBuilder.Entity<Orders>(entity =>
            {
                entity.HasKey(e => e.Orderid)
                    .HasName("orders_pkey");

                entity.ToTable("orders");

                entity.Property(e => e.Orderid).HasColumnName("orderid");

                entity.Property(e => e.Deliveryprice)
                    .HasColumnName("deliveryprice")
                    .HasColumnType("numeric(10,2)");

                entity.Property(e => e.Orderdate)
                    .HasColumnName("orderdate")
                    .HasColumnType("date");

                entity.Property(e => e.Statusid)
                    .HasColumnName("statusid")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Userid)
                    .HasColumnName("userid")
                    .ValueGeneratedOnAdd();

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.Statusid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("status_fker");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.Userid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("user_fker");
            });

            modelBuilder.Entity<Publishinghouse>(entity =>
            {
                entity.HasKey(e => e.Phid)
                    .HasName("publishinghouse_pkey");

                entity.ToTable("publishinghouse");

                entity.Property(e => e.Phid).HasColumnName("phid");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<PublishinghouseBook>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("publishinghouse_book");

                entity.Property(e => e.Bookid)
                    .HasColumnName("bookid")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Phid)
                    .HasColumnName("phid")
                    .ValueGeneratedOnAdd();

                entity.HasOne(d => d.Book)
                    .WithMany()
                    .HasForeignKey(d => d.Bookid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("book_fker");

                entity.HasOne(d => d.Ph)
                    .WithMany()
                    .HasForeignKey(d => d.Phid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("publishinghouse_fker");
            });

            modelBuilder.Entity<Status>(entity =>
            {
                entity.ToTable("status");

                entity.Property(e => e.Statusid).HasColumnName("statusid");

                entity.Property(e => e.State)
                    .IsRequired()
                    .HasColumnName("state")
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasKey(e => e.Userid)
                    .HasName("users_pkey");

                entity.ToTable("users");

                entity.Property(e => e.Userid).HasColumnName("userid");

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasMaxLength(255);

                entity.Property(e => e.Login)
                    .IsRequired()
                    .HasColumnName("login")
                    .HasMaxLength(255);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("password")
                    .HasMaxLength(255);

                entity.Property(e => e.Registrationdate)
                    .HasColumnName("registrationdate")
                    .HasColumnType("date");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
