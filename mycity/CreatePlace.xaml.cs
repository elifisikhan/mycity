
using GeoAPI.Geometries;
using Microsoft.Maps.MapControl.WPF;
using mycity.DAL.Models;
using NetTopologySuite;
using System;
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
using Microsoft.EntityFrameworkCore;
// # using mycity.Repositories;
// using mycity.Interfaces;

namespace mycity
{
    /// <summary>
    /// Interaction logic for CreatePlace.xaml
    /// </summary>
    public partial class CreatePlace : Window
    {
        public CreatePlace()
        {
            InitializeComponent();
        }

        private void MyMap_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Microsoft.Maps.MapControl.WPF.Location l = myMap.ViewportPointToLocation(e.GetPosition(myMap));
            txtBoxPlaceLatitude.Text = l.Latitude.ToString();
            txtBoxPlaceLongitude.Text = l.Longitude.ToString();
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Girilen veriler veri tabanına yazılacak, onaylıyor musunuz?", "My App", MessageBoxButton.YesNoCancel);
            switch (result)
            {
                case MessageBoxResult.Yes:

                    double lat = Convert.ToDouble(txtBoxPlaceLatitude.Text);
                    double lng = Convert.ToDouble(txtBoxPlaceLongitude.Text);

                    NetTopologySuite.Geometries.Point point = new NetTopologySuite.Geometries.Point(lat, lng)
                    {
                        SRID = 4326
                    };
                    Places place = new Places()
                    {

                        Type = txtBoxPlaceType.Text,
                        Name = txtBoxPlaceName.Text,
                        Tel = txtPhone.Text,
                        Address = txtAddress.Text,
                        Location = point,

                    };

                    using (mycityDbContext context = new mycityDbContext())
                    {
                        context.Add(place);
                        context.SaveChanges();
                    }


                    MessageBox.Show("Veriler başarıyla aktarıldı...");
                    txtBoxPlaceType.Text = "";
                    txtBoxPlaceName.Text = "";
                    txtBoxPlaceLatitude.Text = "";
                    txtBoxPlaceLongitude.Text = "";
                    myMap.Mode = new AerialMode(true);

                    break;
                case MessageBoxResult.No:
                    // MessageBox.Show("Oh well, too bad!", "My App");
                    break;
                case MessageBoxResult.Cancel:
                    txtBoxPlaceType.Text = "";
                    txtBoxPlaceName.Text = "";
                    txtBoxPlaceLatitude.Text = "";
                    txtBoxPlaceLongitude.Text = "";
                    myMap.Mode = new AerialMode(true);
                    break;
            }
        }
    }
}
