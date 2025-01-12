﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using skibidi_gamebook.Server.Data;

#nullable disable

namespace skibidi_gamebook.Server.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20250112171410_dfghjmk")]
    partial class dfghjmk
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.11");

            modelBuilder.Entity("skibidi_gamebook.Server.Models.Character", b =>
                {
                    b.Property<int>("CharacterId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("img")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int?>("whereId")
                        .HasColumnType("INTEGER");

                    b.HasKey("CharacterId");

                    b.ToTable("Characters");
                });

            modelBuilder.Entity("skibidi_gamebook.Server.Models.Connection", b =>
                {
                    b.Property<int>("ConnectionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("FromId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Lock")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int?>("RequierementId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("ToId")
                        .HasColumnType("INTEGER");

                    b.HasKey("ConnectionId");

                    b.HasIndex("FromId");

                    b.HasIndex("ToId")
                        .IsUnique();

                    b.ToTable("Connections");
                });

            modelBuilder.Entity("skibidi_gamebook.Server.Models.Item", b =>
                {
                    b.Property<int>("ItemId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<string>("Img")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int?>("RequierementId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("RoomId")
                        .HasColumnType("INTEGER");

                    b.HasKey("ItemId");

                    b.HasIndex("RoomId");

                    b.ToTable("Items");
                });

            modelBuilder.Entity("skibidi_gamebook.Server.Models.Room", b =>
                {
                    b.Property<int>("RoomId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Img")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("RoomId");

                    b.ToTable("Rooms");
                });

            modelBuilder.Entity("skibidi_gamebook.Server.Models.Connection", b =>
                {
                    b.HasOne("skibidi_gamebook.Server.Models.Room", "From")
                        .WithMany("Connections")
                        .HasForeignKey("FromId");

                    b.HasOne("skibidi_gamebook.Server.Models.Room", "To")
                        .WithOne("Connection")
                        .HasForeignKey("skibidi_gamebook.Server.Models.Connection", "ToId");

                    b.Navigation("From");

                    b.Navigation("To");
                });

            modelBuilder.Entity("skibidi_gamebook.Server.Models.Item", b =>
                {
                    b.HasOne("skibidi_gamebook.Server.Models.Connection", "Connection")
                        .WithOne("Requierement")
                        .HasForeignKey("skibidi_gamebook.Server.Models.Item", "ItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("skibidi_gamebook.Server.Models.Room", "Rooms")
                        .WithMany("Items")
                        .HasForeignKey("RoomId");

                    b.Navigation("Connection");

                    b.Navigation("Rooms");
                });

            modelBuilder.Entity("skibidi_gamebook.Server.Models.Room", b =>
                {
                    b.HasOne("skibidi_gamebook.Server.Models.Character", "Character")
                        .WithOne("where")
                        .HasForeignKey("skibidi_gamebook.Server.Models.Room", "RoomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Character");
                });

            modelBuilder.Entity("skibidi_gamebook.Server.Models.Character", b =>
                {
                    b.Navigation("where");
                });

            modelBuilder.Entity("skibidi_gamebook.Server.Models.Connection", b =>
                {
                    b.Navigation("Requierement");
                });

            modelBuilder.Entity("skibidi_gamebook.Server.Models.Room", b =>
                {
                    b.Navigation("Connection");

                    b.Navigation("Connections");

                    b.Navigation("Items");
                });
#pragma warning restore 612, 618
        }
    }
}
