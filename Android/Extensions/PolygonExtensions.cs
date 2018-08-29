using System.Linq;
using Android.Gms.Maps.Model;

namespace MobilePlanningMap.Android.Extensions
{
    public static class PolygonExtensions
    {
        public static double PointsId(this Polygon poly)
        {
            return poly.Points.Sum(x => x.Latitude + x.Longitude);
        }
    }
}
