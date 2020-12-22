using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace android_test_app.MyActionMode
{
    class Todo_ActionMode : Java.Lang.Object, ActionMode.ICallback
    {
        private Context context;

        public Todo_ActionMode(Context context)
        {
            this.context = context;
        }

        public bool OnActionItemClicked(ActionMode mode, IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Resource.Id.task_completed:
                    Console.WriteLine("dash icon");
                    return true;
                case Resource.Id.task_delete:
                    Console.WriteLine("todo icon");
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
            mode.Dispose();
        }

        public bool OnPrepareActionMode(ActionMode mode, IMenu menu)
        {
            return false;
        }
    }
}