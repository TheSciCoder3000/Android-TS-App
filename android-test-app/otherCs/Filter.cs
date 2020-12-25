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

namespace android_test_app.otherCs
{
    class Filter 
    {
        // ------------- Initialization -------------
        public string filterName { get;  set; }
        public int FilterId { get; private set; }
        public bool isSelected = false;
        public void SetSelected(bool selected)
        {
            isSelected = selected;
        }



        // ------------- Constructor -------------
        public Filter(string filterName, int id)
        {
            this.filterName = filterName;
            FilterId = id;
        }



        // ------------- Other Fucntions -------------
        public static List<Filter> AllSelectedTasks(List<Filter> filterList)
        {
            List<Filter> selectedList = new List<Filter>();
            for (int i = 0; i > filterList.Count; i++)
            {
                if (filterList[i].isSelected)
                {
                    selectedList.Add(filterList[i]);
                }
            }
            return selectedList;
        }

        public Task Tags()
        {
            return null;
        }
    }
}