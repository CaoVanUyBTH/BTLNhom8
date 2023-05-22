﻿// <auto-generated />
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

            modelBuilder.Entity("BTLNhom8.Models.Monhoc", b =>
                {
                    b.Property<string>("Ma_mon")
                        .HasColumnType("TEXT");

                    b.Property<int>("Diem")
                        .HasColumnType("INTEGER");

                    b.Property<string>("StudentID")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Ten_mon")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Ma_mon");

                    b.HasIndex("StudentID");

                    b.ToTable("Monhoc");
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

                    b.HasKey("StudentID");

                    b.HasIndex("FacultyID");

                    b.ToTable("Student");
                });

            modelBuilder.Entity("BTLNhom8.Models.Monhoc", b =>
                {
                    b.HasOne("BTLNhom8.Models.Student", "Student")
                        .WithMany()
                        .HasForeignKey("StudentID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Student");
                });

            modelBuilder.Entity("BTLNhom8.Models.Student", b =>
                {
                    b.HasOne("BTLNhom8.Models.Faculty", "Faculty")
                        .WithMany()
                        .HasForeignKey("FacultyID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Faculty");
                });
#pragma warning restore 612, 618
        }
    }
}
