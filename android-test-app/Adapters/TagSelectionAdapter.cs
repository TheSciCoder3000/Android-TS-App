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
    class TagSelectionAdapter : RecyclerView.Adapter
    {

        List<Filter> TagList = new List<Filter>();

        public TagSelectionAdapter(List<Filter> tagList)
        {
            TagList = tagList;
        }

        public class TagSelectionViewHolder : RecyclerView.ViewHolder
        {
            public View mainView { get; private set; }
            public Button TagBtn { get; private set; }
            public TagSelectionViewHolder(View itemView) : base(itemView)
            {
                mainView = itemView;
                TagBtn = itemView.FindViewById<Button>(Resource.Id.TagBtn);
            }
        }

        public override int ItemCount => getItemCount();

        private int getItemCount()
        {
            if (TagList == null)
            {
                return 0;
            }
            else
            {
                return TagList.Count;
            }
        }

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            TagSelectionViewHolder vh = holder as TagSelectionViewHolder;

            vh.TagBtn.Text = TagList[position].filterName;
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            View view = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.TagItems_layout, parent, false);

            // Create a View Holder
            TagSelectionViewHolder holder = new TagSelectionViewHolder(view);

            return holder;
        }
    }
}