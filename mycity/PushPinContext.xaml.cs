using mycity.DAL.Models;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace mycity
{
    /// <summary>
    /// Interaction logic for PushPinContext.xaml
    /// </summary>
    public partial class PushPinContext : UserControl
    {
        private Places place = null;
        public PushPinContext(Places place)
        {
            this.place = place;
            InitializeComponent();
            Render();
        }

        private void Render()
        {
            this.txtCaption.Text = place.Name;
            this.txtDescription.Text = place.Address;
            SetImage(place.Pic1Url, this.image);
            SetImage(place.Pic2Url, this.image2);
        }

        private void SetImage(string path, Image img)
        {
            try
            {
                Uri uri = null;
                if (!string.IsNullOrEmpty(path) && Uri.TryCreate(path, UriKind.Absolute, out uri))
                {
                    BitmapImage source = new BitmapImage();
                    source.BeginInit();
                    source.UriSource = uri;
                    source.EndInit();

                    img.Source = source;
                }
            }
            catch (Exception)
            {
            }
        }
    }
}
