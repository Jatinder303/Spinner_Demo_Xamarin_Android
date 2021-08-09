using Android.App;
using Android.OS;
using Android.Runtime;
using AndroidX.AppCompat.App;
using System;
using Android.Content;
using Android.Views;
using Android.Widget;

namespace Spinner_Demo_Xamarin_Android
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        Spinner spCity;
        ImageView imgCity;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            // Get our button from the layout resource,
            // and attach an event to it

            spCity = FindViewById<Spinner>(Resource.Id.spCity);
            imgCity = FindViewById<ImageView>(Resource.Id.imgCity);

            spCity.ItemSelected += new EventHandler<AdapterView.ItemSelectedEventArgs>(spinner_ItemSelected);


            var adapter = ArrayAdapter.CreateFromResource(this, Resource.Array.City_Names, Android.Resource.Layout.SimpleSpinnerItem);
            adapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            spCity.Adapter = adapter;
        }
        public void spinner_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            Spinner spinner = (Spinner)sender;

            if (String.Format("{0}", spinner.GetItemAtPosition(e.Position)) == "Hamilton")
            {
                imgCity.SetImageResource(Resource.Drawable.hamilton);
            }
            else if (String.Format("{0}", spinner.GetItemAtPosition(e.Position)) == "Auckland")
            {
                imgCity.SetImageResource(Resource.Drawable.auckland);
            }
            else if (String.Format("{0}", spinner.GetItemAtPosition(e.Position)) == "Christchurch")
            {
                imgCity.SetImageResource(Resource.Drawable.christchurch);
            }
            else if (String.Format("{0}", spinner.GetItemAtPosition(e.Position)) == "Wellington")
            {
                imgCity.SetImageResource(Resource.Drawable.wellington);
            }

        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}