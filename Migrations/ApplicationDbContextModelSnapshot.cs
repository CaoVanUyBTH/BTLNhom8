﻿// <auto-generated />
using BTLNhom8.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BTLNhom8.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.5");

            modelBuilder.Entity("BTLNhom8.Models.Faculty", b =>
                {
                    b.Property<string>("FacultyID")
                        .HasColumnType("TEXT");

                    b.Property<string>("FacultyName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("FacultyID");

                    b.ToTable("Faculty");
                });

            modelBuilder.Entity("BTLNhom8.Models.Student", b =>
                {
                    b.Property<string>("StudentID")
                        .HasColumnType("TEXT");

                    b.Property<string>("FacultyID")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("StudentAddress")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("StudentName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("SubjectID")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("StudentID");

                    b.HasIndex("FacultyID");

                    b.HasIndex("SubjectID");

                    b.ToTable("Student");
                });

            modelBuilder.Entity("BTLNhom8.Models.Subject", b =>
                {
                    b.Property<string>("SubjectID")
                        .HasColumnType("TEXT");

                    b.Property<string>("SubjectName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("SubjectID");

                    b.ToTable("Subject");
                });

            modelBuilder.Entity("BTLNhom8.Models.Student", b =>
                {
                    b.HasOne("BTLNhom8.Models.Faculty", "Faculty")
                        .WithMany()
                        .HasForeignKey("FacultyID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BTLNhom8.Models.Subject", "Subject")
                        .WithMany()
                        .HasForeignKey("SubjectID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Faculty");

                    b.Navigation("Subject");
                });
#pragma warning restore 612, 618
        }
    }
}
