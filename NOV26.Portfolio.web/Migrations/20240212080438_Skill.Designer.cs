﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NOV26.Portfolio.web.Data;

#nullable disable

namespace NOV26.Portfolio.web.Migrations
{
    [DbContext(typeof(NOV26PortfoliowebContext))]
    [Migration("20240212080438_Skill")]
    partial class Skill
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.1");

            modelBuilder.Entity("NOV26.Portfolio.web.Models.PersonalInformationModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("CompletedProjects")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DOB")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Summary")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("UserPhotoUrl")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("ZipCode")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("PersonalInformationModel");
                });

            modelBuilder.Entity("NOV26.Portfolio.web.Models.ResumeModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("DESC");

                    b.Property<int>("EndYear")
                        .HasColumnType("INTEGER")
                        .HasColumnName("END_YEAR");

                    b.Property<string>("InstitutionName")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("INSTITUTION_NAME");

                    b.Property<int>("StartYear")
                        .HasColumnType("INTEGER")
                        .HasColumnName("START_YEAR");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("TITLE");

                    b.HasKey("Id");

                    b.ToTable("ResumeModel");
                });

            modelBuilder.Entity("NOV26.Portfolio.web.Models.ServiceModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Icon")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("ServiceModel");
                });

            modelBuilder.Entity("NOV26.Portfolio.web.Models.SkillModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<decimal>("SkillPct")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("SkillModel");
                });
#pragma warning restore 612, 618
        }
    }
}
