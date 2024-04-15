using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace UserLogin.Models
{
    public partial class DemoDbcontext : DbContext
    {
        public DemoDbcontext()
        {
        }

        public DemoDbcontext(DbContextOptions<DemoDbcontext> options)
            : base(options)
        {
        }

        public virtual DbSet<TblUser> TblUsers { get; set; } = null!;
        public virtual DbSet<TblUserDetail> TblUserDetails { get; set; } = null!;
        public object EntryForms { get; internal set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

                optionsBuilder.UseSqlServer("Server=LATA\\SQLEXPRESS;Database=DemoDb;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TblUser>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("tbl_User");

                entity.Property(e => e.EmailId)
                    .HasMaxLength(100)
                    .HasColumnName("Email_Id")
                    .IsFixedLength();

                entity.Property(e => e.Password)
                    .HasMaxLength(100)
                    .IsFixedLength();

                entity.Property(e => e.UserName)
                    .HasMaxLength(100)
                    .IsFixedLength();
            });

            modelBuilder.Entity<TblUserDetail>(entity =>
            {
                entity.HasKey(e => e.MobileNum)
                    .HasName("PK__tbl_User__393CE5E5D59E5225");

                entity.ToTable("tbl_UserDetails");

                entity.Property(e => e.MobileNum)
                    .ValueGeneratedNever()
                    .HasColumnName("Mobile_num");

                entity.Property(e => e.Address).HasMaxLength(100);

                entity.Property(e => e.DisplayImage).HasColumnType("image");

                entity.Property(e => e.EmailId)
                    .HasMaxLength(100)
                    .HasColumnName("Email_Id");

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
