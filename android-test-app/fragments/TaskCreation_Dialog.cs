using Android.Support.V4.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.Support.V7.Widget;
using android_test_app.Adapters;
using Filter = android_test_app.otherCs.Filter;

namespace android_test_app.fragments
{
    public class TaskCreation_Dialog : DialogFragment
    {
        List<Filter> tagList = new List<Filter>();

        private RecyclerView recyclerView;
        private RecyclerView.Adapter mAdapter;
        private RecyclerView.LayoutManager layoutManager;

        Button TaskCreate_btn, TagCreate_btn;

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            base.OnCreateView(inflater, container, savedInstanceState);
            // Use this to return your custom view for this Fragment
            View view = inflater.Inflate(Resource.Layout.taskCreationDialog, container, false);

            // !!!!!!--------- Change this to get list of tags from the database ---------!!!!!!
            tagList = fillTagList();

            // ------Task Creation Btns Code------
            recyclerView = view.FindViewById<RecyclerView>(Resource.Id.TagSet_selection);

            layoutManager = new LinearLayoutManager(view.Context, LinearLayoutManager.Horizontal, false);

            recyclerView.SetLayoutManager(layoutManager);

            mAdapter = new TagSelectionAdapter(tagList);

            recyclerView.SetAdapter(mAdapter);

            if (mAdapter.ItemCount > 0)
            {
                TextView tagWarning = view.FindViewById<TextView>(Resource.Id.EmptyTagWarning);
                tagWarning.Visibility = ViewStates.Gone;
            }

            // ------Task Creation Btns Code------
            TaskCreate_btn = view.FindViewById<Button>(Resource.Id.TaskCreate_btn);
            TagCreate_btn = view.FindViewById<Button>(Resource.Id.TagCreate_btn);

            TaskCreate_btn.Click += TaskCreate_btn_Click;
            TagCreate_btn.Click += TagCreate_btn_Click;

            return view;
        }

        private List<Filter> fillTagList()
        {
            List<Filter> tempList = new List<Filter>
            {
                new Filter("School", 0),
                new Filter("Work", 1),
                new Filter("Health", 2),
                new Filter("App Dev", 3),
            };
            return null;
        }

        private void TagCreate_btn_Click(object sender, EventArgs e)
        {
            // Get Tag name
            Button btn = (Button)sender;
            View view = btn.RootView;
            EditText TagName_Input = view.FindViewById<EditText>(Resource.Id.TagName_Input);

            // !!!!!--------- Send to database ---------!!!!!
        }

        private void TaskCreate_btn_Click(object sender, EventArgs e)
        {
            // Task name
            Button btn = (Button)sender;
            View view = btn.RootView;
            EditText TaskName_Input = view.FindViewById<EditText>(Resource.Id.TaskName_Input);

            // Date
            // Tag selected

            // !!!!!--------- Send to database ---------!!!!!
        }

    }
}