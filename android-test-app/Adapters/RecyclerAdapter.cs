using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using android_test_app.otherCs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace android_test_app.Adapters
{
    internal class RecyclerAdapter : RecyclerView.Adapter
    {
        List<Task> taskList;

        public RecyclerAdapter(List<Task> taskList)
        {
            this.taskList = taskList;
        }

        public  class myViewHolder : RecyclerView.ViewHolder
        {
            public TextView taskTitle { get; private set; }
            public TextView taskDate { get; private set; }

            public myViewHolder(View itemView) : base(itemView)
            {
                taskTitle = itemView.FindViewById<TextView>(Resource.Id.taskTitle);
                taskDate = itemView.FindViewById<TextView>(Resource.Id.taskDate);
            }
        }

        public override int ItemCount => taskList.Count;

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            myViewHolder vh = holder as myViewHolder;

            vh.taskTitle.Text = taskList[position].TaskName;
            vh.taskDate.Text = taskList[position].date.ToString();
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            View view = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.taskCard_layout, parent, false);

            myViewHolder holder = new myViewHolder(view);

            return holder;
        }
    }
}