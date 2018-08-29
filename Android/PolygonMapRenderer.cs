using Android.Content;
using Android.Gms.Maps.Model;
using MobilePlanningMap;
using MobilePlanningMap.Android;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Maps.Android;
using System.Collections.Generic;
using Android.Gms.Maps;
using System.Linq;
using MobilePlanningMap.Android.Extensions;

[assembly: ExportRenderer(typeof(DrawableMap), typeof(PolygonMapRenderer))]
namespace MobilePlanningMap.Android
{
    public class PolygonMapRenderer : MapRenderer
    {
        IList<Worksite> worksites;
        IList<WorksitePolygon> polygons;

        public PolygonMapRenderer(Context context) : base(context)
        {
            polygons = new List<WorksitePolygon>();
        }

        protected override void OnElementChanged(Xamarin.Forms.Platform.Android.ElementChangedEventArgs<Map> e)
        {
            base.OnElementChanged(e);

            if (e.OldElement != null)
            {
                // Unsubscribe
            }

            if (e.NewElement != null)
            {
                var formsMap = (DrawableMap)e.NewElement;
                worksites = formsMap.Worksites;
                Control.GetMapAsync(this);
            }
        }

        protected override void OnMapReady(GoogleMap map)
        {
            base.OnMapReady(map);

            foreach(var worksite in worksites) 
            {
                var polygonOptions = new PolygonOptions();
                polygonOptions.InvokeFillColor(unchecked((int)0xFF00FFFF));
                polygonOptions.InvokeStrokeColor(unchecked((int)0xFF0000FF));
                polygonOptions.InvokeStrokeWidth(10.0f);

                foreach (var position in worksite.GeneratePolygonPositions())
                {
                    polygonOptions.Add(new LatLng(position.Latitude, position.Longitude));
                }

                if (polygonOptions.Points.Count > 0)
                {
                    var worksitePoly = new WorksitePolygon { Worksite = worksite, Polygon = polygonOptions };
                    polygons.Add(worksitePoly);
                    var polygon = NativeMap.AddPolygon(worksitePoly.Polygon);
                    polygon.Clickable = true;
                }
            }

            map.PolygonClick += (sender, e) => {
                var poly = e.Polygon;
                var targetWorksite = polygons.FirstOrDefault(x => x.Polygon.PointsId() == poly.PointsId());

                if (targetWorksite != null)
                {
                    App.WorksiteLabel.Text = targetWorksite.Worksite.name;
                    App.WorksiteLabel.IsVisible = true;
                }
            };
        }
    }
}
