using System;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using System.Diagnostics;

namespace MobilePlanningMap
{
	public class MapPage : ContentPage
	{
        DrawableMap map;

        public MapPage (DrawableMap _map)
		{
            map = _map;
            var aucklandPosition = new Position(-36.845215, 174.752436);
            map.MoveToRegion(MapSpan.FromCenterAndRadius(aucklandPosition, Distance.FromMiles(0.5)));

            var pin = new Pin
            {
                Type = PinType.Place,
                Position = aucklandPosition,
                Label = "Auckland",
                Address = "Somewhere in the depths of the JAFA wonderland"
            };
            map.Pins.Add(pin);

			// create map style buttons
			var street = new Button { Text = "Street" };
			var hybrid = new Button { Text = "Hybrid" };
			var satellite = new Button { Text = "Satellite" };
			street.Clicked += HandleClicked;
			hybrid.Clicked += HandleClicked;
			satellite.Clicked += HandleClicked;
			var segments = new StackLayout { Spacing = 30,
				HorizontalOptions = LayoutOptions.CenterAndExpand,
				Orientation = StackOrientation.Horizontal, 
				Children = {street, hybrid, satellite}
			};

			// put the page together
			var stack = new StackLayout { Spacing = 0 };
            stack.Children.Add(App.WorksiteLabel);
			stack.Children.Add(map);
			stack.Children.Add (segments);
			Content = stack;
		}

		void HandleClicked (object sender, EventArgs e)
		{
			var b = sender as Button;
			switch (b.Text) {
			case "Street":
				map.MapType = MapType.Street;
				break;
			case "Hybrid":
				map.MapType = MapType.Hybrid;
				break;
			case "Satellite":
				map.MapType = MapType.Satellite;
				break;
			}
		}
	}
}
