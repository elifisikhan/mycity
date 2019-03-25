
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
using mycity.Services;
using NetTopologySuite;
using NetTopologySuite.Geometries;
using NetTopologySuite.IO;
using NetTopologySuite.Operation.Polygonize;

namespace mycity
{
    /// <summary>
    /// Interaction logic for CreatePlace.xaml
    /// </summary>
    public partial class CreatePlace : Window
    {
        private PlaceService _placeService;

        public CreatePlace()
        {
            InitializeComponent();

            this._placeService = new PlaceService(new mycityDbContext());
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


                    //---------- Polygon 

                    //var geometryFactory = NtsGeometryServices.Instance.CreateGeometryFactory(srid: 4326);

                    //var currentLocation = geometryFactory.CreatePolygon(new Coordinate[]
                    //    {
                    //    new Coordinate(40.11605375, 26.41308546,0),
                    //    new Coordinate(40.11464251, 26.41647577,0),
                    //    new Coordinate(40.11201688, 26.41780615,0),
                    //    new Coordinate(40.11116352, 26.41128302,0),
                    //    new Coordinate(40.11605375, 26.41308546,0),
                    //                        }) as NetTopologySuite.Geometries.Polygon;

                    //----------


                    //---------- Polyline

                    //var geometryFactory = NtsGeometryServices.Instance.CreateGeometryFactory(srid: 4326);
                    //var currentLocation = geometryFactory.CreateLineString(new Coordinate[]
                    //    {
                    //    new Coordinate( 40.1462734, 26.4089441,0),
                    //    new Coordinate(40.1185151, 26.4110470,0),
                    //    new Coordinate(40.0957357, 26.4086866,0),
                    //    new Coordinate(40.1097850, 26.4271402,0),
                    //});
                    //----------


                    double lat = Convert.ToDouble(txtBoxPlaceLatitude.Text);
                    double lng = Convert.ToDouble(txtBoxPlaceLongitude.Text);

                    
                    NetTopologySuite.Geometries.Point currentLocation = new NetTopologySuite.Geometries.Point(lat, lng)
                    {
                        SRID = 4326
                    };
                    Places place = new Places()
                    {

                        Type = txtBoxPlaceType.Text,
                        Name = txtBoxPlaceName.Text,
                        Tel = txtPhone.Text,
                        Address = txtAddress.Text,
                        Location = currentLocation,

                    };

                    this._placeService.Add(place);


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
