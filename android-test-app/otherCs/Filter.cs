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
        public string filterName { get;  set; }

        public bool isSelected = false;
        public void SetSelected(bool selected)
        {
            isSelected = selected;
        }

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

        public Filter(string filterName)
        {
            this.filterName = filterName;
        }
         
    }
}