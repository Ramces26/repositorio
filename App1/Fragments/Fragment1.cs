﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;

namespace App1.Fragments
{
    public class Fragment1 : Fragment
    {
        public Fragment1()
        {

        }
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }
        public static Fragment1 NewInstance()
        {

            var frag1 = new Fragment1 { Arguments = new Bundle() };
            return frag1;
            //var bundle = new Bundle();
            //return new Fragment1 { Arguments = bundle };
        }
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment

            //View view = inflater.Inflate(Resource.Layout.layout1, container, false);
            //return base.OnCreateView(inflater, container, savedInstanceState);
            return inflater.Inflate(Resource.Layout.layout1, container, false);
            //return view;
        }
    }
}