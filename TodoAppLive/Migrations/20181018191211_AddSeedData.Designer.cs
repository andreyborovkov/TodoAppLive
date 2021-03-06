﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TodoAppLive.Models;

namespace TodoAppLive.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20181018191211_AddSeedData")]
    partial class AddSeedData
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TodoAppLive.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CategoryId");

                    b.Property<string>("Name");

                    b.Property<int?>("TodoId");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("TodoId");

                    b.ToTable("Categories");

                    b.HasData(
                        new { Id = 1, Name = "Home" },
                        new { Id = 2, Name = "Business" }
                    );
                });

            modelBuilder.Entity("TodoAppLive.Models.Todo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description");

                    b.Property<DateTime>("DueDate");

                    b.HasKey("Id");

                    b.ToTable("Todos");

                    b.HasData(
                        new { Id = 1, Description = "Code something", DueDate = new DateTime(2018, 10, 18, 15, 12, 10, 639, DateTimeKind.Local) }
                    );
                });

            modelBuilder.Entity("TodoAppLive.Models.TodoCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CategoryId");

                    b.Property<int>("TodoId");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("TodoId");

                    b.ToTable("TodoCategories");
                });

            modelBuilder.Entity("TodoAppLive.Models.Category", b =>
                {
                    b.HasOne("TodoAppLive.Models.Category")
                        .WithMany("TodoCategories")
                        .HasForeignKey("CategoryId");

                    b.HasOne("TodoAppLive.Models.Todo")
                        .WithMany("TodoCategories")
                        .HasForeignKey("TodoId");
                });

            modelBuilder.Entity("TodoAppLive.Models.TodoCategory", b =>
                {
                    b.HasOne("TodoAppLive.Models.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("TodoAppLive.Models.Todo", "Todo")
                        .WithMany()
                        .HasForeignKey("TodoId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
