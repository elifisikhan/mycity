using System;
using System.Collections.Generic;
using GeoAPI.Geometries;

namespace mycity.DAL.Models
{
    public partial class Places
    {
        public int PlacesId { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
        public string Pic1Url { get; set; }
        public string Pic2Url { get; set; }
        public string Tel { get; set; }
        public string Url { get; set; }
        public string Address { get; set; }
        public IGeometry Location { get; set; }
        public string geo_type { get; set; }
    }
}
