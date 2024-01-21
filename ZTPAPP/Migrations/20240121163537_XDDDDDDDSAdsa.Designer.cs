﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using projekt.Models;

#nullable disable

namespace ZTPAPP.Migrations
{
    [DbContext(typeof(WDbContext))]
    [Migration("20240121163537_XDDDDDDDSAdsa")]
    partial class XDDDDDDDSAdsa
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("FlashcardFlashcardSet", b =>
                {
                    b.Property<int>("FlashcardSetsId")
                        .HasColumnType("int");

                    b.Property<int>("FlashcardsId")
                        .HasColumnType("int");

                    b.HasKey("FlashcardSetsId", "FlashcardsId");

                    b.HasIndex("FlashcardsId");

                    b.ToTable("FlashcardFlashcardSet");
                });

            modelBuilder.Entity("FlashcardSetTest", b =>
                {
                    b.Property<int>("FlashcardSetsId")
                        .HasColumnType("int");

                    b.Property<int>("TestsId")
                        .HasColumnType("int");

                    b.HasKey("FlashcardSetsId", "TestsId");

                    b.HasIndex("TestsId");

                    b.ToTable("FlashcardSetTest");
                });

            modelBuilder.Entity("projekt.Models.Answer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("FlashcardId")
                        .HasColumnType("int");

                    b.Property<string>("GivenAnswer")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("TestId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("FlashcardId");

                    b.HasIndex("TestId");

                    b.ToTable("Answers");
                });

            modelBuilder.Entity("projekt.Models.Flashcard", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("SourceWord")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TranslatedWord")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Flashcards");
                });

            modelBuilder.Entity("projekt.Models.FlashcardSet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("FlashcardSets");
                });

            modelBuilder.Entity("projekt.Models.Test", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Tests");
                });

            modelBuilder.Entity("projekt.Models.TestHistory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("TestId")
                        .HasColumnType("int");

                    b.Property<string>("TestName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("points")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TestId");

                    b.ToTable("TestsHistories");
                });

            modelBuilder.Entity("projekt.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Mode")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("FlashcardFlashcardSet", b =>
                {
                    b.HasOne("projekt.Models.FlashcardSet", null)
                        .WithMany()
                        .HasForeignKey("FlashcardSetsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("projekt.Models.Flashcard", null)
                        .WithMany()
                        .HasForeignKey("FlashcardsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FlashcardSetTest", b =>
                {
                    b.HasOne("projekt.Models.FlashcardSet", null)
                        .WithMany()
                        .HasForeignKey("FlashcardSetsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("projekt.Models.Test", null)
                        .WithMany()
                        .HasForeignKey("TestsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("projekt.Models.Answer", b =>
                {
                    b.HasOne("projekt.Models.Flashcard", "Flashcard")
                        .WithMany()
                        .HasForeignKey("FlashcardId");

                    b.HasOne("projekt.Models.TestHistory", "Test")
                        .WithMany("Answers")
                        .HasForeignKey("TestId");

                    b.Navigation("Flashcard");

                    b.Navigation("Test");
                });

            modelBuilder.Entity("projekt.Models.TestHistory", b =>
                {
                    b.HasOne("projekt.Models.Test", "Test")
                        .WithMany("History")
                        .HasForeignKey("TestId");

                    b.Navigation("Test");
                });

            modelBuilder.Entity("projekt.Models.Test", b =>
                {
                    b.Navigation("History");
                });

            modelBuilder.Entity("projekt.Models.TestHistory", b =>
                {
                    b.Navigation("Answers");
                });
#pragma warning restore 612, 618
        }
    }
}
