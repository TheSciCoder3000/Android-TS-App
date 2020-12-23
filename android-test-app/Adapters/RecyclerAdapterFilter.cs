using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
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



        // -------------- Constructor --------------
        public RecyclerAdapterFilter(List<Filter> filterList)
        {
            this.filterList = filterList;
        }



        // -------------- View Holder Class --------------
        public class myFilterViewHolder : RecyclerView.ViewHolder
        {
            public TextView filterName { get; private set; }

            public myFilterViewHolder(View itemView) : base(itemView)
            {
                filterName = itemView.FindViewById<TextView>(Resource.Id.filterName);
            }
        }



        // -------------- Overrides --------------
        public override int ItemCount => filterList.Count;

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            myFilterViewHolder vh = holder as myFilterViewHolder;

            vh.filterName.Text = filterList[position].filterName;
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