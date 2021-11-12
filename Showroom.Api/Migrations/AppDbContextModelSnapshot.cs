﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Showroom.Api.Models;

namespace Showroom.Api.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.11")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Showroom.Models.Project", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OwnerId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProjectPath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProjectThumbnail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProjectType")
                        .HasColumnType("int");

                    b.Property<double>("Rating")
                        .HasColumnType("float");

                    b.Property<int>("Views")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Projects");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "This is just a test, this should influence 90% of people.",
                            Name = "Test 1",
                            OwnerId = "200",
                            ProjectPath = "Projects/TestProject1",
                            ProjectThumbnail = "images/Untitled1.png",
                            ProjectType = 0,
                            Rating = 0.0,
                            Views = 0
                        },
                        new
                        {
                            Id = 2,
                            Description = "This is description of test project number 2. This is also awesome project.",
                            Name = "Test 2",
                            OwnerId = "250",
                            ProjectPath = "Projects/TestProject2",
                            ProjectThumbnail = "images/Untitled2.png",
                            ProjectType = 1,
                            Rating = 0.0,
                            Views = 0
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
