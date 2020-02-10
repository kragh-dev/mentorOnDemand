using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace MODWebApiMentor.Models
{
    public partial class modDBContext : DbContext
    {
        public modDBContext()
        {
        }

        public modDBContext(DbContextOptions<modDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Course> Course { get; set; }
        public virtual DbSet<Payment> Payment { get; set; }
        public virtual DbSet<Skill> Skill { get; set; }
        public virtual DbSet<Training> Training { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<Wallet> Wallet { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("server=J-A-R-V-I-S;database=modDB;trusted_connection=yes");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.3-servicing-35854");

            modelBuilder.Entity<Course>(entity =>
            {
                entity.ToTable("course");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Approved).HasColumnName("approved");

                entity.Property(e => e.CommissionAmount).HasColumnName("commission_amount");

                entity.Property(e => e.Duration).HasColumnName("duration");

                entity.Property(e => e.Fees).HasColumnName("fees");

                entity.Property(e => e.MentorId).HasColumnName("mentor_id");

                entity.Property(e => e.MentorName)
                    .IsRequired()
                    .HasColumnName("mentor_name")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.MentorYearsOfExp).HasColumnName("mentor_years_of_exp");

                entity.Property(e => e.Rating).HasColumnName("rating");

                entity.Property(e => e.SkillId).HasColumnName("skill_id");

                entity.Property(e => e.SkillName)
                    .IsRequired()
                    .HasColumnName("skill_name")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Status).HasColumnName("status");
            });

            modelBuilder.Entity<Payment>(entity =>
            {
                entity.ToTable("payment");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AmountPaid).HasColumnName("amount_paid");

                entity.Property(e => e.PaymentMethod)
                    .HasColumnName("payment_method")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.TransactionStatus)
                    .IsRequired()
                    .HasColumnName("transaction_status")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.UserId).HasColumnName("user_id");
            });

            modelBuilder.Entity<Skill>(entity =>
            {
                entity.ToTable("skill");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Prerequistes)
                    .HasColumnName("prerequistes")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Toc)
                    .IsRequired()
                    .HasColumnName("toc")
                    .HasMaxLength(40)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Training>(entity =>
            {
                entity.ToTable("training");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AmountPaid).HasColumnName("amount_paid");

                entity.Property(e => e.Approved).HasColumnName("approved");

                entity.Property(e => e.CommissionAmount).HasColumnName("commission_amount");

                entity.Property(e => e.Completed).HasColumnName("completed");

                entity.Property(e => e.CourseId).HasColumnName("course_id");

                entity.Property(e => e.CourseName)
                    .IsRequired()
                    .HasColumnName("course_name")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.EndDate)
                    .HasColumnName("end_date")
                    .HasColumnType("date");

                entity.Property(e => e.Fees).HasColumnName("fees");

                entity.Property(e => e.MentorId).HasColumnName("mentor_id");

                entity.Property(e => e.MentorName)
                    .IsRequired()
                    .HasColumnName("mentor_name")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PartFour).HasColumnName("part_four");

                entity.Property(e => e.PartOne).HasColumnName("part_one");

                entity.Property(e => e.PartThree).HasColumnName("part_three");

                entity.Property(e => e.PartTwo).HasColumnName("part_two");

                entity.Property(e => e.PaymentId).HasColumnName("payment_id");

                entity.Property(e => e.PaymentStatus).HasColumnName("payment_status");

                entity.Property(e => e.Progress).HasColumnName("progress");

                entity.Property(e => e.Rating).HasColumnName("rating");

                entity.Property(e => e.Rejected).HasColumnName("rejected");

                entity.Property(e => e.SkillId).HasColumnName("skill_id");

                entity.Property(e => e.SkillName)
                    .IsRequired()
                    .HasColumnName("skill_name")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.StartDate)
                    .HasColumnName("start_date")
                    .HasColumnType("date");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasColumnName("user_name")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("user");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Active).HasColumnName("active");

                entity.Property(e => e.Comments)
                    .HasColumnName("comments")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ContactNumber).HasColumnName("contact_number");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasColumnName("first_name")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasColumnName("last_name")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LinkedinUrl)
                    .HasColumnName("linkedin_url")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("password")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.RegCode)
                    .HasColumnName("reg_code")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Reject).HasColumnName("reject");

                entity.Property(e => e.Role)
                    .IsRequired()
                    .HasColumnName("role")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasColumnName("user_name")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.YearsOfExperience).HasColumnName("years_of_experience");
            });

            modelBuilder.Entity<Wallet>(entity =>
            {
                entity.ToTable("wallet");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Balance).HasColumnName("balance");

                entity.Property(e => e.UserId).HasColumnName("user_id");
            });
        }
    }
}
