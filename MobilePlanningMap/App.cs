using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace MobilePlanningMap
{
	public class App : Application
	{
        static MwsRestService MwsRestService { get; set; }
        public static Label WorksiteLabel { get; set; }

		public App ()
		{
            MainPage = new LoadingPage();
            MwsRestService = new MwsRestService();
            WorksiteLabel = new Label { IsVisible = false, HorizontalTextAlignment = TextAlignment.Center, FontAttributes = FontAttributes.Bold, FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)) };
		}

        protected override async void OnStart()
        {
            base.OnStart();

            var worksites = await MwsRestService.LatestAtWorksitesAsync();
            var map = new DrawableMap
            {
                MapType = MapType.Street,
                HeightRequest = 100,
                WidthRequest = 960,
                VerticalOptions = LayoutOptions.FillAndExpand,
                Worksites = worksites
            };
            MainPage = new MapPage(map) { Title = "Map/Zoom", Icon = "glyphish_74_location.png" };
        }
    }
}

