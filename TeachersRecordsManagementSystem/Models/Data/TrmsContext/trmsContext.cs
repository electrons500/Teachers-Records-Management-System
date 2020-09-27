using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using TeachersrRecordsManagementSystem.Models.ViewModel;

namespace TeachersrRecordsManagementSystem.Models.Data.TrmsContext
{
    public partial class trmsContext : DbContext
    {
        public trmsContext()
        {
        }

        public trmsContext(DbContextOptions<trmsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Admin> Admin { get; set; }
        public virtual DbSet<Banks> Banks { get; set; }
        public virtual DbSet<Gender> Gender { get; set; }
        public virtual DbSet<MaritalStatus> MaritalStatus { get; set; }
        public virtual DbSet<State> State { get; set; }
        public virtual DbSet<Teachers> Teachers { get; set; }
        public virtual DbSet<Title> Title { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Conn");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Admin>(entity =>
            {
                entity.HasKey(e => e.AdminId)
                    .IsClustered(false);

                entity.Property(e => e.Contact)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Othername)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Surname)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Banks>(entity =>
            {
                entity.HasKey(e => e.BankId)
                    .IsClustered(false);

                entity.Property(e => e.BankName)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Gender>(entity =>
            {
                entity.HasKey(e => e.GenderId)
                    .IsClustered(false);

                entity.Property(e => e.GenderName)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<MaritalStatus>(entity =>
            {
                entity.HasKey(e => e.MaritalId)
                    .IsClustered(false);

                entity.Property(e => e.MaritalStatusName)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<State>(entity =>
            {
                entity.HasKey(e => e.StateId)
                    .IsClustered(false);

                entity.Property(e => e.StateName)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<Teachers>(entity =>
            {
                entity.HasKey(e => e.TeacherId)
                    .IsClustered(false);

                entity.Property(e => e.AcademicQualification)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.AccountName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.BirthDate).HasColumnType("date");

                entity.Property(e => e.Contact)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.FirstAppointmentDate).HasColumnType("date");

                entity.Property(e => e.Hometown)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.ImageName).HasMaxLength(100);

                entity.Property(e => e.Othernames)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.ProfessionalQualification)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.RegisteredNumber)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Ssfno)
                    .HasColumnName("SSFno")
                    .HasMaxLength(50);

                entity.Property(e => e.StaffId)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Surname)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasOne(d => d.Bank)
                    .WithMany(p => p.Teachers)
                    .HasForeignKey(d => d.BankId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Banks_Teachers");

                entity.HasOne(d => d.Gender)
                    .WithMany(p => p.Teachers)
                    .HasForeignKey(d => d.GenderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Gender_Teachers");

                entity.HasOne(d => d.Marital)
                    .WithMany(p => p.Teachers)
                    .HasForeignKey(d => d.MaritalId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MaritalStatus_Teachers");

                entity.HasOne(d => d.State)
                    .WithMany(p => p.Teachers)
                    .HasForeignKey(d => d.StateId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_State_Teachers");

                entity.HasOne(d => d.Title)
                    .WithMany(p => p.Teachers)
                    .HasForeignKey(d => d.TitleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Title_Teachers");
            });

            modelBuilder.Entity<Title>(entity =>
            {
                entity.HasKey(e => e.TitleId)
                    .IsClustered(false);

                entity.Property(e => e.TitleName)
                    .IsRequired()
                    .HasMaxLength(10);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

        public DbSet<TeachersrRecordsManagementSystem.Models.ViewModel.TeachersViewModel> TeachersViewModel { get; set; }

        public DbSet<TeachersrRecordsManagementSystem.Models.ViewModel.BankViewModel> BankViewModel { get; set; }
    }
}
