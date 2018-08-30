using Android.App;
using Android.OS;
using Android.Content.PM;

namespace MobilePlanningMap.Android
{
	[Activity (Label = "MobilePlanningMap.Android.Android", Icon = "@drawable/icon", Theme = "@style/MainTheme", MainLauncher = true, 
		ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
	public class MainActivity :	global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
	{
		protected override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);

			global::Xamarin.Forms.Forms.Init (this, savedInstanceState);
			global::Xamarin.FormsMaps.Init (this, savedInstanceState);
	                LoadApplication (new App ());
		}
	}
}
