using System.Collections.Generic;
using CoreLocation;
using MapKit;
using MobilePlanningMap;
using MobilePlanningMap.iOS;
using ObjCRuntime;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Maps.iOS;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(DrawableMap), typeof(PolygonMapRenderer))]
namespace MobilePlanningMap.iOS
{
    public class PolygonMapRenderer : MapRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<View> e)
        {
            base.OnElementChanged(e);

            if (e.OldElement != null)
            {
                var nativeMap = Control as MKMapView;
                if (nativeMap != null)
                {
                    nativeMap.RemoveOverlays(nativeMap.Overlays);
                    nativeMap.OverlayRenderer = null;
                }
            }

            if (e.NewElement != null)
            {
                var formsMap = (DrawableMap)e.NewElement;
                var nativeMap = Control as MKMapView;

                nativeMap.OverlayRenderer = GetOverlayRenderer;


                foreach (var worksite in formsMap.Worksites)
                {
                    var positions = worksite.GeneratePolygonPositions();

                    if (positions.Count > 0)
                    {
                        var coords = new List<CLLocationCoordinate2D>();
                        foreach(var position in positions)
                            coords.Add(new CLLocationCoordinate2D(position.Latitude, position.Longitude));

                        var blockOverlay = MKPolygon.FromCoordinates(coords.ToArray());
                        nativeMap.AddOverlay(blockOverlay);
                    }
                }
            }
        }

        MKOverlayRenderer GetOverlayRenderer(MKMapView mapView, IMKOverlay overlayWrapper)
        {
            if (!Equals(overlayWrapper, null))
            {
                var overlay = Runtime.GetNSObject(overlayWrapper.Handle) as IMKOverlay;
                return new MKPolygonRenderer(overlay as MKPolygon)
                {
                    FillColor = UIColor.Cyan,
                    StrokeColor = UIColor.Blue,
                    LineWidth = 2.5f
                };
            }
            return null;
        }
    }
}
