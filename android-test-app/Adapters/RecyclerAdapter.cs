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
        RecyclerView recyclerView;
        Context context;

        public RecyclerAdapter(List<Task> taskList, RecyclerView recyclerView, Context context)
        {
            this.taskList = taskList;
            this.recyclerView = recyclerView;
            this.context = context;
        }

        public  class myViewHolder : RecyclerView.ViewHolder
        {
            public TextView taskTitle { get; private set; }
            public TextView taskDate { get; private set; }
            public View mainView { get; set; }

            public myViewHolder(View itemView) : base(itemView)
            {
                mainView = itemView;
                taskTitle = itemView.FindViewById<TextView>(Resource.Id.taskTitle);
                taskDate = itemView.FindViewById<TextView>(Resource.Id.taskDate);
            }
        }

        public override int ItemCount => taskList.Count;

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            myViewHolder vh = holder as myViewHolder;

            vh.mainView.Click -= test_click;
            vh.mainView.Click += test_click;

            vh.mainView.LongClick -= test_longClick;
            vh.mainView.LongClick += test_longClick;

            vh.taskTitle.Text = taskList[position].TaskName;
            vh.taskDate.Text = taskList[position].date.ToString();
        }

        private void test_longClick(object sender, View.LongClickEventArgs e)
        {
            int position = recyclerView.GetChildAdapterPosition((View)sender);
            Task taskClicked = this.taskList[position];
            Toast.MakeText(this.context, "This is a long click at " + taskClicked.TaskName, ToastLength.Long).Show();
        }

        private void test_click(object sender, EventArgs e)
        {
            int position = recyclerView.GetChildAdapterPosition((View)sender);
            Task taskClicked = this.taskList[position];
            Toast.MakeText(this.context, "The task you clicked is " + taskClicked.TaskName, ToastLength.Long).Show();
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            View view = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.taskCard_layout, parent, false);

            myViewHolder holder = new myViewHolder(view);

            return holder;
        }
    }
}