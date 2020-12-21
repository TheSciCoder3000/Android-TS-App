using System;
using System.Collections.Generic;
using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V4.App;
using Android.Support.V4.View;
using Android.Support.V7.App;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using android_test_app.Adapters;
using android_test_app.fragments;
using android_test_app.otherCs;

namespace android_test_app
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]
    public class MainActivity : FragmentActivity
    {
        // ViewPager and Bottom Navbar initialization
        ViewPager _viewPager;
        BottomNavigationView _navigationView;
        Android.Support.V4.App.Fragment[] _fragments;

        // Fragment Activity Initialization
        dash_fragment dashFrag = new dash_fragment();
        todos_fragment todoFrag = new todos_fragment();
        calendar_fragment calendarFrag = new calendar_fragment();
        settings_fragment settingFrag = new settings_fragment();

        

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);

            //Sets The layout
            SetContentView(Resource.Layout.content_main);

            // ViewPager Code
            _viewPager = FindViewById<ViewPager>(Resource.Id.viewpager);
            _viewPager.PageSelected += ViewPager_PageSelected;
            ViewPagerAdapter adapter = new ViewPagerAdapter(SupportFragmentManager);
            adapter.AddFragment(dashFrag, "Dashboard");
            adapter.AddFragment(todoFrag, "Todos");
            adapter.AddFragment(calendarFrag, "Calendar");
            adapter.AddFragment(settingFrag, "Settings");
            _viewPager.Adapter = adapter;

            _navigationView = FindViewById<BottomNavigationView>(Resource.Id.bottom_navigation);
            _navigationView.NavigationItemSelected += NavigationView_NavigationItemSelected;


        }            
        

        private void NavigationView_NavigationItemSelected(object sender, BottomNavigationView.NavigationItemSelectedEventArgs e)
        {
            _viewPager.SetCurrentItem(e.Item.Order, true);
            Console.WriteLine("nav pressed "+e.Item);

        }

        private void ViewPager_PageSelected(object sender, ViewPager.PageSelectedEventArgs e)
        {
            var item = _navigationView.Menu.GetItem(e.Position);
            _navigationView.SelectedItemId = item.ItemId;
        }

        protected override void OnDestroy()
        {
            _viewPager.PageSelected -= ViewPager_PageSelected;
            _navigationView.NavigationItemSelected -= NavigationView_NavigationItemSelected;
            base.OnDestroy();
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.menu_main, menu);
            return true;
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            int id = item.ItemId;
            if (id == Resource.Id.action_settings)
            {
                return true;
            }

            return base.OnOptionsItemSelected(item);
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
	}
}
