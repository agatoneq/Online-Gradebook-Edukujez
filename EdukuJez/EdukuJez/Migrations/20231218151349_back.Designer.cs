﻿// <auto-generated />
using System;
using EdukuJez.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EdukuJez.Migrations
{
    [DbContext(typeof(BaseContext))]
    [Migration("20231218151349_back")]
    partial class back
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.32")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EdukuJez.Repositories.Activity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Activities");
                });

            modelBuilder.Entity("EdukuJez.Repositories.Calendar", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Desc")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Calendar");
                });

            modelBuilder.Entity("EdukuJez.Repositories.ClassC", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Class")
                        .HasColumnType("int");

                    b.Property<string>("Day")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("GroupId")
                        .HasColumnType("int");

                    b.Property<string>("Hour")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("SubjectId")
                        .HasColumnType("int");

                    b.Property<string>("Surname")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("GroupId");

                    b.HasIndex("SubjectId");

                    b.ToTable("Classes");
                });

            modelBuilder.Entity("EdukuJez.Repositories.ClassUsers", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ClassId")
                        .HasColumnType("int");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ClassId");

                    b.HasIndex("UserId");

                    b.ToTable("ClassUsers");
                });

            modelBuilder.Entity("EdukuJez.Repositories.Grade", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ActivityId")
                        .HasColumnType("int");

                    b.Property<int>("GradeValue")
                        .HasColumnType("int");

                    b.Property<int>("GradeWeight")
                        .HasColumnType("int");

                    b.Property<int?>("SubjectId")
                        .HasColumnType("int");

                    b.Property<int?>("UsersId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ActivityId");

                    b.HasIndex("SubjectId");

                    b.HasIndex("UsersId");

                    b.ToTable("Grades");
                });

            modelBuilder.Entity("EdukuJez.Repositories.Group", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ParentGroupId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ParentGroupId");

                    b.ToTable("Groups");
                });

            modelBuilder.Entity("EdukuJez.Repositories.GroupUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("GroupId")
                        .HasColumnType("int");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("GroupId");

                    b.HasIndex("UserId");

                    b.ToTable("GroupUsers");
                });

            modelBuilder.Entity("EdukuJez.Repositories.Message", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Content")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsGroupMsg")
                        .HasColumnType("bit");

                    b.Property<int?>("SenderId")
                        .HasColumnType("int");

                    b.Property<string>("Topic")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("SenderId");

                    b.ToTable("Messages");
                });

            modelBuilder.Entity("EdukuJez.Repositories.MessageGroups", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("GroupId")
                        .HasColumnType("int");

                    b.Property<int?>("MessageId")
                        .HasColumnType("int");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("GroupId");

                    b.HasIndex("MessageId");

                    b.HasIndex("UserId");

                    b.ToTable("MessageGroups");
                });

            modelBuilder.Entity("EdukuJez.Repositories.MessageUsers", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("MessageId")
                        .HasColumnType("int");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MessageId");

                    b.HasIndex("UserId");

                    b.ToTable("MessageUsers");
                });

            modelBuilder.Entity("EdukuJez.Repositories.Post", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<bool>("IsUserSender")
                        .HasColumnType("bit");

                    b.Property<int?>("MessageId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MessageId");

                    b.ToTable("Post");
                });

            modelBuilder.Entity("EdukuJez.Repositories.Subject", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("SubjectDesc")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SubjectName")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("SubjectName")
                        .IsUnique();

                    b.ToTable("Subjects");
                });

            modelBuilder.Entity("EdukuJez.Repositories.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("UserLogin")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserPassword")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserSurname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("UserLogin")
                        .IsUnique();

                    b.ToTable("Users");
                });

            modelBuilder.Entity("EdukuJez.Repositories.ClassC", b =>
                {
                    b.HasOne("EdukuJez.Repositories.Group", "Group")
                        .WithMany("Classes")
                        .HasForeignKey("GroupId");

                    b.HasOne("EdukuJez.Repositories.Subject", "Subject")
                        .WithMany("Classes")
                        .HasForeignKey("SubjectId");
                });

            modelBuilder.Entity("EdukuJez.Repositories.ClassUsers", b =>
                {
                    b.HasOne("EdukuJez.Repositories.ClassC", "Class")
                        .WithMany("Users")
                        .HasForeignKey("ClassId");

                    b.HasOne("EdukuJez.Repositories.User", "User")
                        .WithMany("Clasess")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("EdukuJez.Repositories.Grade", b =>
                {
                    b.HasOne("EdukuJez.Repositories.Activity", "Activity")
                        .WithMany("Grades")
                        .HasForeignKey("ActivityId");

                    b.HasOne("EdukuJez.Repositories.Subject", "Subject")
                        .WithMany("Grades")
                        .HasForeignKey("SubjectId");

                    b.HasOne("EdukuJez.Repositories.User", "Users")
                        .WithMany("Grades")
                        .HasForeignKey("UsersId");
                });

            modelBuilder.Entity("EdukuJez.Repositories.Group", b =>
                {
                    b.HasOne("EdukuJez.Repositories.Group", "ParentGroup")
                        .WithMany("ChildGroups")
                        .HasForeignKey("ParentGroupId");
                });

            modelBuilder.Entity("EdukuJez.Repositories.GroupUser", b =>
                {
                    b.HasOne("EdukuJez.Repositories.Group", "Group")
                        .WithMany("Users")
                        .HasForeignKey("GroupId");

                    b.HasOne("EdukuJez.Repositories.User", "User")
                        .WithMany("Groups")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("EdukuJez.Repositories.Message", b =>
                {
                    b.HasOne("EdukuJez.Repositories.User", "Sender")
                        .WithMany()
                        .HasForeignKey("SenderId");
                });

            modelBuilder.Entity("EdukuJez.Repositories.MessageGroups", b =>
                {
                    b.HasOne("EdukuJez.Repositories.Group", null)
                        .WithMany("Messages")
                        .HasForeignKey("GroupId");

                    b.HasOne("EdukuJez.Repositories.Message", "Message")
                        .WithMany("GroupRecipients")
                        .HasForeignKey("MessageId");

                    b.HasOne("EdukuJez.Repositories.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("EdukuJez.Repositories.MessageUsers", b =>
                {
                    b.HasOne("EdukuJez.Repositories.Message", "Message")
                        .WithMany("Recipients")
                        .HasForeignKey("MessageId");

                    b.HasOne("EdukuJez.Repositories.User", "User")
                        .WithMany("Messages")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("EdukuJez.Repositories.Post", b =>
                {
                    b.HasOne("EdukuJez.Repositories.User", "User")
                        .WithOne("Post")
                        .HasForeignKey("EdukuJez.Repositories.Post", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EdukuJez.Repositories.Message", "Message")
                        .WithMany()
                        .HasForeignKey("MessageId");
                });
#pragma warning restore 612, 618
        }
    }
}
