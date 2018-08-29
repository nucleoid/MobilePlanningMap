using System.Collections.Generic;
using CoreLocation;

namespace MobilePlanningMap.iOS
{
    public class WorksitePolygon
    {
        public Worksite Worksite { get; set; }
        public IList<CLLocationCoordinate2D> Coords { get; set; }
    }
}
