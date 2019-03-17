﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Microsoft.Maps.MapControl.WPF;
using mycity.DAL;
using mycity.DAL.Models;

namespace mycity
{
    /// <summary>
    /// Interaction logic for showData.xaml
    /// </summary>
    public partial class showData : Window
    {
        public showData()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            using (mycityDbContext myDbC = new mycityDbContext())
            {
                var myplaces = myDbC.Places;
                foreach (Places p in myplaces)
                    lstBox.Items.Add(p.Name);

            }

        }

        private void LstBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            using (mycityDbContext dbC = new mycityDbContext())
            {
                var myplaces = dbC.Places;
                Location location = new Location();
                foreach (Places p in myplaces)
                {
                    if (lstBox.SelectedItem.ToString() == p.Name)
                    {
                        try
                        {
                            location.Latitude = p.Location.Coordinate.X;
                            location.Longitude = p.Location.Coordinate.Y;
                            myMap.Center = location;
                        }
                        catch
                        {
                            location.Latitude = myMap.Center.Latitude + 1;
                            location.Longitude = myMap.Center.Longitude + 1;
                            myMap.Center = location;
                            myMap.ZoomLevel = myMap.ZoomLevel - 1;

                        }
                        Pushpin pp = new Pushpin();
                        pp.Location = location;
                        myMap.Children.Add(pp);
                        Label lblMa = new Label();
                        lblMa.Content = "burada xaml obje olabilir";
                        MapLayer.SetPosition(lblMa, location);
                        myMap.Children.Add(lblMa);
                    }
                    {

                    }


                }
            }
        }
    }
}