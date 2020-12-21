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
using android_test_app.otherCs;
using Android.Support.V7.Widget;
using android_test_app.Adapters;

namespace android_test_app.fragments
{
    public class todos_fragment : Fragment
    {
        // Temp Database Initialization
        List<Task> taskList = new List<Task>();

        //RecyclerView Initialization
        private RecyclerView recyclerView;
        private RecyclerView.Adapter mAdapter;
        private RecyclerView.LayoutManager layoutManager;


        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here

        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            View view = inflater.Inflate(Resource.Layout.todos_layout, container, false);

            // Add entries to temp task list
            taskList = fillTaskList();

            // RecyclerView Code
            recyclerView = view.FindViewById<RecyclerView>(Resource.Id.TasksLists);
            // recyclerView.HasFixedSize = true;
            layoutManager = new LinearLayoutManager(view.Context);
            recyclerView.SetLayoutManager(layoutManager);
            mAdapter = new RecyclerAdapter(taskList);
            recyclerView.SetAdapter(mAdapter);


            return recyclerView;
        }

        private List<Task> fillTaskList()
        {


            List<Task> mtaskList = new List<Task> {
                new Task(0, "play games", 2000),
                new Task(1, "Feed the dogs", 2002),
                new Task(2, "Make an app", 2004),
                new Task(3, "Filipino Quipper", 2050),
                new Task(4, "Participate in a Marathon", 2100),
                new Task(5, "Finish the app", 2004),
                new Task(6, "Empty my tank", 2152),
                new Task(7, "Refill my tank", 2006),
                new Task(8, "Feed the dogs", 2000),
                new Task(4, "Participate in a Marathon", 2100),
                new Task(3, "Filipino Quipper", 2050),
                new Task(1, "Play games", 2015),
                new Task(3, "Filipino Quipper", 2050)
            };

            return mtaskList;
        }

    }
}