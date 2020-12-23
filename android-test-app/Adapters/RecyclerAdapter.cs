using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using android_test_app.MyActionMode;
using android_test_app.otherCs;
using System;
using System.Collections.Generic;
using android_test_app.fragments;
using System.Linq;
using System.Text;
using ActionMode = Android.Views.ActionMode;

namespace android_test_app.Adapters
{
    internal class RecyclerAdapter : RecyclerView.Adapter
    {
        // -------------- Initialization --------------
        List<Task> taskList;
        RecyclerView recyclerView;
        Context context;
        todos_fragment parent_fragment;
        public View mActivity;
        private Todo_ActionMode mActionMode;
        private ActionMode actionMode;
        public event EventHandler<int> ItemClick;



        // -------------- Constructor --------------
        public RecyclerAdapter(List<Task> taskList, RecyclerView recyclerView, View view, todos_fragment fragment)
        {
            this.taskList = taskList;
            this.recyclerView = recyclerView;
            context = view.Context;
            mActivity = view;
            parent_fragment = fragment;
        }



        // -------------- View Holder Class --------------
        public class myViewHolder : RecyclerView.ViewHolder
        {
            public TextView taskTitle { get; private set; }
            public TextView taskDate { get; private set; }
            public View mainView { get; set; }

            public myViewHolder(View itemView, Action<int, View> listener, Action<object, View.LongClickEventArgs> longClickListener) : base(itemView)
            {
                mainView = itemView;
                taskTitle = itemView.FindViewById<TextView>(Resource.Id.taskTitle);
                taskDate = itemView.FindViewById<TextView>(Resource.Id.taskDate);

                // Connect the click and Long Click to view events
                // ItemView.Click += (sender, e) => listener(base.Position, ItemView);
                // itemView.LongClick += (sender, e) => longClickListener(sender, e);
            }
        }



        // -------------- Overrides --------------
        public override int ItemCount => taskList.Count;

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            myViewHolder vh = holder as myViewHolder;
            /*
            vh.mainView.Click -= test_click;
            vh.mainView.Click += test_click;
            */
            vh.mainView.Click += delegate (Object sender, EventArgs e)
            {
                
            };
            
            vh.mainView.LongClick -= test_longClick;
            vh.mainView.LongClick += test_longClick;
            
            vh.taskTitle.Text = taskList[position].TaskName;
            vh.taskDate.Text = taskList[position].date.ToString();
        }

        private void test_click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            View view = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.taskCard_layout, parent, false);

            // Create a View Holder
            myViewHolder holder = new myViewHolder(view, onClick, test_longClick);

            return holder;
        }



        // -------------- Other Functions --------------
        private void test_longClick(object sender, View.LongClickEventArgs e)
        {
            if (actionMode == null)
            {
                mActionMode = new Todo_ActionMode(mActivity.Context, this);
                actionMode = mActivity.StartActionMode(mActionMode);
                parent_fragment.freeze_layout(true);
            }
        }

        public void FinishActionMode()
        {
            if (actionMode != null)
            {
                actionMode.Finish();
                actionMode = null;
                parent_fragment.freeze_layout(false);
            }
        }

        void onClick(int position, View view)
        {
            if (actionMode != null)
            {
                Toast.MakeText(this.context, "action mode is visible", ToastLength.Long).Show();
                taskList[position].SetSelected(true);

            }
            else
            {
                Toast.MakeText(this.context, "action mode is invisible", ToastLength.Long).Show();
            }
                
        }

    }
}