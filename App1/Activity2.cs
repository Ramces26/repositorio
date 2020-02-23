using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Support.V4.Widget;
using Android.Views;
using Android.Content;

//using App1.Fragments;
using Android.Support.V7.App;
using Android.Support.V4.View;
using Android.Support.Design.Widget;
using Android.Widget;
using System;
using System.Threading;
using System.Threading.Tasks;
using Android.Util;
using App1.Fragments;

namespace App1
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar",NoHistory =true)]
    public class Activity2 : AppCompatActivity
    {

        DrawerLayout drawerLayout;
        NavigationView navigationView;

        public const string TAG = "Activity2";
        IMenuItem previousItem;
        protected override void OnCreate(Bundle savedInstanceState)
        {


            base.OnCreate(savedInstanceState);
            //notificacion hubs
            if (Intent.Extras != null)
            {
                foreach (var key in Intent.Extras.KeySet())
                {
                    if (key != null)
                    {
                        var value = Intent.Extras.GetString(key);
                        Log.Debug(TAG, "Key: {0} Value: {1}", key, value);
                    }
                }
            }
            //Thread.Sleep(1000);
            SetContentView(Resource.Layout.activity_main);

            var toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
            if (toolbar != null)
            {
                SetSupportActionBar(toolbar);
                //Thread.Sleep(2000);
                SupportActionBar.SetDisplayHomeAsUpEnabled(true);
                SupportActionBar.SetHomeButtonEnabled(true);


            }

            drawerLayout = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);

            //Set hamburger items menu


            //aqui tenes que cambiarlo por ic_menu
            SupportActionBar.SetHomeAsUpIndicator(Resource.Drawable.ic_menu);

            //setup navigation view
            navigationView = FindViewById<NavigationView>(Resource.Id.nav_view);

            //handle navigation
            navigationView.NavigationItemSelected += (sender, e) =>
            {
                if (previousItem != null)
                    previousItem.SetChecked(false);

                navigationView.SetCheckedItem(e.MenuItem.ItemId);

                previousItem = e.MenuItem;

                switch (e.MenuItem.ItemId)
                {
                    case Resource.Id.nav_camera:
                        ListItemClicked(0);
                        break;
                    case Resource.Id.nav_gallery:
                        ListItemClicked(1);
                        break;
                    case Resource.Id.nav_slideshow:
                        ListItemClicked(2);
                        break;
                    //case Resource.Id.nav_home_4:
                    //    ListItemClicked(3);
                    //    break;
                    //case Resource.Id.nav_home_5:
                    //    ListItemClicked(4);
                    //    break;
                    //case Resource.Id.nav_home_6:
                    //    ListItemClicked(5);
                    //    break;
                    //case Resource.Id.nav_home_7:
                    //    ListItemClicked(6);
                    //    break;
                }


                drawerLayout.CloseDrawers();



            };


            //if first time you will want to go ahead and click first item.
            if (savedInstanceState == null)
            {
                navigationView.SetCheckedItem(Resource.Id.nav_camera);
                ListItemClicked(0);
            }
        }


        int oldPosition = -1;
        private void ListItemClicked(int position)
        {
            //this way we don't load twice, but you might want to modify this a bit.
            if (position == oldPosition)
                return;

            oldPosition = position;

            //Fragment fragment = null;

            Android.Support.V4.App.Fragment fragment = null;
        
            switch (position)
            {
                case 0:
                    //fragment = Fragment1.NewInstance();
                    FragmentTransaction ft = FragmentManager.BeginTransaction();
                    Fragment f1 = new Fragment1();
                    ft.Replace(Resource.Layout.content_main, f1);
                    ft.AddToBackStack(null);
                    ft.Commit();
                    //fragment = f1;
                    break;
                //case 1:
                //    fragment = Fragment2.NewInstance();
                //    break;
                //case 2:
                //    fragment = Fragment3.NewInstance();
                //    break;

                //case 3:
                //    fragment = Fragment4.NewInstances();
                //    break;
                //case 4:
                //    fragment = Fragment5.NewInstances();
                //    break;
                //case 5:
                //    fragment = Fragment6.NewInstance();
                //    break;
                //case 6:
                //    fragment = Fragment7.NewInstances();
                //    break;
            }
            //SupportFragmentManager.BeginTransaction()
            //    .Replace(Resource.Layout.content_main,f1)
            //    .Commit();
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Android.Resource.Id.Home:
                    drawerLayout.OpenDrawer(GravityCompat.Start);
                    return true;
            }
            return base.OnOptionsItemSelected(item);
        }
        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.menu_main, menu);
            return base.OnCreateOptionsMenu(menu);
        }


    }
}
