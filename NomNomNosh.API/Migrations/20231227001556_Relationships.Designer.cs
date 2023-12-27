﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NomNomNosh.Infrastructure.Data;

#nullable disable

namespace NomNomNosh.API.Migrations
{
    [DbContext(typeof(AppDbContext_NomNomNosh))]
    [Migration("20231227001556_Relationships")]
    partial class Relationships
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("NomNomNosh.Domain.Entities.Member", b =>
                {
                    b.Property<Guid>("Member_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("First_Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Last_Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Profile_Image")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Member_Id");

                    b.ToTable("Members");
                });

            modelBuilder.Entity("NomNomNosh.Domain.Entities.Recipe", b =>
                {
                    b.Property<Guid>("Recipe_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Average_Rating")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Main_Image")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("Member_Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Published_Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Recipe_Id");

                    b.HasIndex("Member_Id");

                    b.ToTable("Recipes");
                });

            modelBuilder.Entity("NomNomNosh.Domain.Entities.RecipeComment", b =>
                {
                    b.Property<Guid>("RecipeComment_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("Member_Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("RecipeComment_Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("RecipeComment_Date")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("Recipe_Id")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("RecipeComment_Id");

                    b.HasIndex("Member_Id");

                    b.HasIndex("Recipe_Id");

                    b.ToTable("RecipeComments");
                });

            modelBuilder.Entity("NomNomNosh.Domain.Entities.RecipeImage", b =>
                {
                    b.Property<Guid>("RecipeImage_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("Recipe_Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RecipeImage_Id");

                    b.HasIndex("Recipe_Id");

                    b.ToTable("RecipeImages");
                });

            modelBuilder.Entity("NomNomNosh.Domain.Entities.RecipeRate", b =>
                {
                    b.Property<Guid>("RecipeRate_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("Member_Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Rating_Value")
                        .HasColumnType("decimal(18,2)");

                    b.Property<Guid>("Recipe_Id")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("RecipeRate_Id");

                    b.HasIndex("Member_Id");

                    b.HasIndex("Recipe_Id");

                    b.ToTable("RecipeRates");
                });

            modelBuilder.Entity("NomNomNosh.Domain.Entities.RecipeSaved", b =>
                {
                    b.Property<Guid>("RecipeSaved_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("Member_Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("Recipe_Id")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("RecipeSaved_Id");

                    b.HasIndex("Member_Id");

                    b.HasIndex("Recipe_Id");

                    b.ToTable("RecipeSaved");
                });

            modelBuilder.Entity("NomNomNosh.Domain.Entities.RecipeStep", b =>
                {
                    b.Property<Guid>("RecipeStep_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("Recipe_Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RecipeStep_Id");

                    b.HasIndex("Recipe_Id");

                    b.ToTable("RecipeSteps");
                });

            modelBuilder.Entity("NomNomNosh.Domain.Entities.Recipe", b =>
                {
                    b.HasOne("NomNomNosh.Domain.Entities.Member", "Member")
                        .WithMany("Recipes")
                        .HasForeignKey("Member_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Member");
                });

            modelBuilder.Entity("NomNomNosh.Domain.Entities.RecipeComment", b =>
                {
                    b.HasOne("NomNomNosh.Domain.Entities.Member", "Member")
                        .WithMany("RecipeComments")
                        .HasForeignKey("Member_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NomNomNosh.Domain.Entities.Recipe", "Recipe")
                        .WithMany("RecipeComments")
                        .HasForeignKey("Recipe_Id")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Member");

                    b.Navigation("Recipe");
                });

            modelBuilder.Entity("NomNomNosh.Domain.Entities.RecipeImage", b =>
                {
                    b.HasOne("NomNomNosh.Domain.Entities.Recipe", "Recipe")
                        .WithMany("RecipeImages")
                        .HasForeignKey("Recipe_Id")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Recipe");
                });

            modelBuilder.Entity("NomNomNosh.Domain.Entities.RecipeRate", b =>
                {
                    b.HasOne("NomNomNosh.Domain.Entities.Member", "Member")
                        .WithMany("RecipeRates")
                        .HasForeignKey("Member_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NomNomNosh.Domain.Entities.Recipe", "Recipe")
                        .WithMany("RecipeRates")
                        .HasForeignKey("Recipe_Id")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Member");

                    b.Navigation("Recipe");
                });

            modelBuilder.Entity("NomNomNosh.Domain.Entities.RecipeSaved", b =>
                {
                    b.HasOne("NomNomNosh.Domain.Entities.Member", "Member")
                        .WithMany("RecipesSaved")
                        .HasForeignKey("Member_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NomNomNosh.Domain.Entities.Recipe", "Recipe")
                        .WithMany("RecipesSaved")
                        .HasForeignKey("Recipe_Id")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Member");

                    b.Navigation("Recipe");
                });

            modelBuilder.Entity("NomNomNosh.Domain.Entities.RecipeStep", b =>
                {
                    b.HasOne("NomNomNosh.Domain.Entities.Recipe", "Recipe")
                        .WithMany("RecipeSteps")
                        .HasForeignKey("Recipe_Id")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Recipe");
                });

            modelBuilder.Entity("NomNomNosh.Domain.Entities.Member", b =>
                {
                    b.Navigation("RecipeComments");

                    b.Navigation("RecipeRates");

                    b.Navigation("Recipes");

                    b.Navigation("RecipesSaved");
                });

            modelBuilder.Entity("NomNomNosh.Domain.Entities.Recipe", b =>
                {
                    b.Navigation("RecipeComments");

                    b.Navigation("RecipeImages");

                    b.Navigation("RecipeRates");

                    b.Navigation("RecipeSteps");

                    b.Navigation("RecipesSaved");
                });
#pragma warning restore 612, 618
        }
    }
}
