﻿// <auto-generated />
using System;
using Infra.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Infra.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20220825021448_UserEntityMigration")]
    partial class UserEntityMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Domain.Entities.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<bool>("Active")
                        .HasColumnType("boolean")
                        .HasColumnName("active");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("timestamp")
                        .HasColumnName("created_on");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar")
                        .HasColumnName("email");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar")
                        .HasColumnName("name");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar")
                        .HasColumnName("password");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("varchar")
                        .HasColumnName("role");

                    b.Property<DateTime?>("UpdatedOn")
                        .HasColumnType("timestamp")
                        .HasColumnName("updated_on");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("varchar")
                        .HasColumnName("username");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("Username")
                        .IsUnique();

                    b.ToTable("users", (string)null);
                });
#pragma warning restore 612, 618
        }
    }
}
