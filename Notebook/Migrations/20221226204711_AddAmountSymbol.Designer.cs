﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Notebook.Domain;

#nullable disable

namespace Notebook.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20221226204711_AddAmountSymbol")]
    partial class AddAmountSymbol
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Notebook.Models.GraphKeyPoint", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("NumberOfPoint")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<double>("XValue")
                        .HasColumnType("float");

                    b.Property<double>("YValue")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("GraphKeyPoints");
                });

            modelBuilder.Entity("Notebook.Models.KeyboardPoint", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<long>("LeftLimit")
                        .HasColumnType("bigint");

                    b.Property<int>("NumberOfChar")
                        .HasColumnType("int");

                    b.Property<long>("RightLimit")
                        .HasColumnType("bigint");

                    b.Property<string>("Symbol")
                        .IsRequired()
                        .HasColumnType("nvarchar(1)");

                    b.Property<long>("Time")
                        .HasColumnType("bigint");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("KeyboardPoints");
                });

            modelBuilder.Entity("Notebook.Models.Note", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateUpdated")
                        .HasColumnType("datetime2");

                    b.Property<string>("NoteText")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Notes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DateCreated = new DateTime(2022, 12, 26, 23, 47, 10, 878, DateTimeKind.Local).AddTicks(6474),
                            DateUpdated = new DateTime(2022, 12, 26, 23, 47, 10, 878, DateTimeKind.Local).AddTicks(6475),
                            NoteText = ""
                        });
                });

            modelBuilder.Entity("Notebook.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("AmountOfAttempt")
                        .HasColumnType("int");

                    b.Property<int>("AmountOfSymbol")
                        .HasColumnType("int");

                    b.Property<string>("CodePhrase")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateRegister")
                        .HasColumnType("datetime2");

                    b.Property<int>("DeltaPixels")
                        .HasColumnType("int");

                    b.Property<int>("ErrorRate")
                        .HasColumnType("int");

                    b.Property<bool>("HasGraphKey")
                        .HasColumnType("bit");

                    b.Property<bool>("HasKeyboard")
                        .HasColumnType("bit");

                    b.Property<int>("NoteId")
                        .HasColumnType("int");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PathToImage")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("NoteId")
                        .IsUnique();

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AmountOfAttempt = 3,
                            AmountOfSymbol = 0,
                            CodePhrase = "",
                            DateRegister = new DateTime(2022, 12, 23, 17, 33, 13, 0, DateTimeKind.Unspecified),
                            DeltaPixels = 10,
                            ErrorRate = 0,
                            HasGraphKey = false,
                            HasKeyboard = false,
                            NoteId = 1,
                            Password = "\\u0001\\0\\u0018\\u0002\\u0016\\u0004\\u0003\\u0005",
                            PathToImage = "",
                            Username = "login"
                        });
                });

            modelBuilder.Entity("Notebook.Models.GraphKeyPoint", b =>
                {
                    b.HasOne("Notebook.Models.User", "User")
                        .WithMany("GraphKeyPoints")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Notebook.Models.KeyboardPoint", b =>
                {
                    b.HasOne("Notebook.Models.User", "User")
                        .WithMany("KeyboardPoints")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Notebook.Models.User", b =>
                {
                    b.HasOne("Notebook.Models.Note", "Note")
                        .WithOne("User")
                        .HasForeignKey("Notebook.Models.User", "NoteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Note");
                });

            modelBuilder.Entity("Notebook.Models.Note", b =>
                {
                    b.Navigation("User")
                        .IsRequired();
                });

            modelBuilder.Entity("Notebook.Models.User", b =>
                {
                    b.Navigation("GraphKeyPoints");

                    b.Navigation("KeyboardPoints");
                });
#pragma warning restore 612, 618
        }
    }
}
