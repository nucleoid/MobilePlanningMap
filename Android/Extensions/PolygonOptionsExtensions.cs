using System.Linq;
using Android.Gms.Maps.Model;

namespace MobilePlanningMap.Android.Extensions
{
    public static class PolygonOptionExtensions
    {
        public static double PointsId(this PolygonOptions poly)
        {
            return poly.Points.Sum(x => x.Latitude + x.Longitude);
        }
    }
}
