﻿using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V4.Content;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Filter = android_test_app.otherCs.Filter;

namespace android_test_app.Adapters
{
    class RecyclerAdapterFilter : RecyclerView.Adapter
    {
        // -------------- Initialization --------------
        List<Filter> filterList;
        Context context;
        myFilterViewHolder currSelectedView;



        // -------------- Constructor --------------
        public RecyclerAdapterFilter(List<Filter> filterList, View view)
        {
            this.filterList = filterList;
            context = view.Context;
        }



        // -------------- View Holder Class --------------
        public class myFilterViewHolder : RecyclerView.ViewHolder
        {
            public TextView filterName { get; private set; }
            public View mainView { get; set; }
            public CardView FilterContainer { get; set; }
            public int holderId { get; set; }

            public myFilterViewHolder(View itemView) : base(itemView)
            {
                mainView = itemView;
                filterName = itemView.FindViewById<TextView>(Resource.Id.filterName);
                FilterContainer = itemView.FindViewById<CardView>(Resource.Id.filterContainer);
            }
        }



        // -------------- Overrides --------------
        public override int ItemCount => filterList.Count;

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            myFilterViewHolder vh = holder as myFilterViewHolder;

            // Set Click events
            vh.mainView.Click += delegate (Object sender, EventArgs e)
            {
                
                if (!filterList[position].isSelected)
                {
                    // Unselect previous 
                    currSelectedView.FilterContainer.SetCardBackgroundColor(ContextCompat.GetColor(context, Resource.Color.filterBackgroundUnclicked));
                    Filter filterObj = filterList.Find(i => i.FilterId == currSelectedView.holderId);
                    Console.WriteLine(filterObj.filterName);
                    filterObj.SetSelected(false);

                    // Select the clicked filter
                    vh.FilterContainer.SetCardBackgroundColor(ContextCompat.GetColor(context, Resource.Color.colorAccent));
                    currSelectedView = vh;
                    filterList[position].SetSelected(true);

                }
                
            };

            // Assign filter property to view holder variables
            vh.filterName.Text = filterList[position].filterName;
            vh.holderId = filterList[position].FilterId;

            // Select the first filter
            if (vh.filterName.Text == "All")
            {
                vh.FilterContainer.SetCardBackgroundColor(ContextCompat.GetColor(context, Resource.Color.colorAccent));
                filterList[position].SetSelected(true);
                currSelectedView = vh;
            }

        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            View view = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.FilterWidget_layout, parent, false);

            // Create view holder using view
            myFilterViewHolder holder = new myFilterViewHolder(view);

            return holder;
        }

    }
}