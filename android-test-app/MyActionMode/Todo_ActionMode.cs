using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using android_test_app.Adapters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace android_test_app.MyActionMode
{
    class Todo_ActionMode : Java.Lang.Object, ActionMode.ICallback
    {
        // ------------ Initialization ------------
        private Context context;
        private RecyclerAdapter mAdapter;



        // ------------ Constructor ------------
        public Todo_ActionMode(Context context, RecyclerAdapter adapter)
        {
            this.context = context;
            mAdapter = adapter;
        }



        // ------------ Call back Methods ------------
        public bool OnActionItemClicked(ActionMode mode, IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Resource.Id.task_completed:
                    mAdapter.FinishActionMode();
                    return true;
                case Resource.Id.task_delete:
                    return true;

                default:
                    return false;
            }
        }

        public bool OnCreateActionMode(ActionMode mode, IMenu menu)
        {
            mode.MenuInflater.Inflate(Resource.Menu.ContextualMenu, menu);
            return true;
        }

        public void OnDestroyActionMode(ActionMode mode)
        {
            mAdapter.FinishActionMode();
            mode.Dispose();
        }

        public bool OnPrepareActionMode(ActionMode mode, IMenu menu)
        {
            return false;
        }
    }
}