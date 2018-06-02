using MyUWP.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace MyUWP
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            using (var Roomdb = new RoomDbContext())
            {
                RoomsListView.ItemsSource = Roomdb.Rooms.ToList();
            }
        }

        private void AddRoomBt_Click(object sender, RoutedEventArgs e)
        {
            using (var Roomdb = new RoomDbContext())
            {
                var Room = new Room()
                {
                    RoomId = int.Parse(Tb_RoomId.Text),
                    RoomName = Tb_RoomName.Text,
                    RoomImagePath = Tb_RoomImgaePath.Text,
                    I2C_Slave_Address = Tb_I2CAddress.Text
                };
                    Roomdb.Rooms.Add(Room);
                    Roomdb.SaveChanges();
                    RoomsListView.ItemsSource=Roomdb.Rooms.ToList();
            }
        }

        private void DeletRoomBt_Click(object sender, RoutedEventArgs e)
        {
            if (RoomsListView.SelectedItem!=null)
            {
                var room = RoomsListView.SelectedItem as Room;
                using (var Roomdb=new RoomDbContext())
                {
                    Roomdb.Rooms.Remove(room);
                    Roomdb.SaveChanges();
                    RoomsListView.ItemsSource = Roomdb.Rooms.ToList();
                }
            }
            else
            {
                return;
            }
        }

        private void UpdateRoomBt_Click(object sender, RoutedEventArgs e)
        {
            using (var Roomdb=new RoomDbContext())
            {
                var Room = new Room()
                {
                    RoomId = int.Parse(Tb_RoomId.Text),
                    RoomName = Tb_RoomName.Text,
                    RoomImagePath = Tb_RoomImgaePath.Text,
                    I2C_Slave_Address = Tb_I2CAddress.Text
                };
                var existingroom = Roomdb.Rooms.Find(Room.RoomId);
                existingroom = Room;
                Roomdb.Rooms.Update(existingroom);
                Roomdb.SaveChanges();
                RoomsListView.ItemsSource = Roomdb.Rooms.ToList();
            }
        }

        private void RoomsListView_ItemClick(object sender, ItemClickEventArgs e)
        {
            var room = e.ClickedItem as Room;
            Tb_RoomId.Text = room.RoomId.ToString();
            Tb_RoomName.Text = room.RoomName;
            Tb_I2CAddress.Text = room.I2C_Slave_Address;
            Tb_RoomImgaePath.Text = room.RoomImagePath;

        }
    }
}
