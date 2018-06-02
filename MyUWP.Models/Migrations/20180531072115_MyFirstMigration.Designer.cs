﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MyUWP.Models;

namespace MyUWP.Models.Migrations
{
    [DbContext(typeof(RoomDbContext))]
    [Migration("20180531072115_MyFirstMigration")]
    partial class MyFirstMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.0-rtm-30799");

            modelBuilder.Entity("MyUWP.Models.Room", b =>
                {
                    b.Property<int>("RoomId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("I2C_Slave_Address");

                    b.Property<string>("RoomImagePath");

                    b.Property<string>("RoomName");

                    b.HasKey("RoomId");

                    b.ToTable("Rooms");
                });
#pragma warning restore 612, 618
        }
    }
}
