using Microsoft.EntityFrameworkCore;
using System;

namespace MyUWP.Models
{   
    public class RoomDbContext:DbContext
    {
        public DbSet<Room> Rooms { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder)
        {
            dbContextOptionsBuilder.UseSqlite("Data Source=Room.db");
        }
    }
    public class Room
    {
        public int RoomId { get; set; }
        public string RoomName { get; set; }
        public string I2C_Slave_Address { get; set; }
        public string RoomImagePath { get; set; }
    }
}
