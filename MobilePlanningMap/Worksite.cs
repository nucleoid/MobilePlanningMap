using System.Collections.Generic;
using Xamarin.Forms.Maps;

namespace MobilePlanningMap
{
    public class Worksite
    {
        public int id { get; set; }
        public string name { get; set; }
        public Location location { get; set; }

        public List<Position> GeneratePolygonPositions() {
            var positions = new List<Position>();
            if (location != null && location.geometry != null && location.geometry.coordinates != null && location.geometry.coordinates.Count > 0)
            {
                foreach (var coord in location.geometry.coordinates[0])
                {
                    var lat = coord[1];
                    var lon = coord[0];
                    positions.Add(new Position(lat, lon));
                }
            }
            return positions;
        }
    }

    public class Location
    {
        public string type { get; set; }
        public object properties { get; set; }
        public Geometry geometry { get; set; }
    }

    public class Geometry {
        public string type { get; set; }
        public List<List<List<float>>> coordinates { get; set; }
    }
}
