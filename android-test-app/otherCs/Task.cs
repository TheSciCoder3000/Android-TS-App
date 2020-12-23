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
    public class Task
    {
        public int id { get; set; }
        public string TaskName { get; set; }

        // change tha date var to whatever var/class the database uses to store dates
        public int date { get; set; }

        public bool isSelected = false;

        public void SetSelected(bool selected)
        {
            isSelected = selected;
        }


        public static List<Task> AllSelectedTasks(List<Task> taskList)
        {
            List<Task> selectedList = new List<Task>();
            for (int i = 0; i > taskList.Count; i++)
            {
                if (taskList[i].isSelected)
                {
                    selectedList.Add(taskList[i]);
                }
            }
            return selectedList;
        } 

        public Task (int id, string taskName, int date)
        {
            this.id = id;
            this.TaskName = taskName;
            this.date = date;
        }



    }
}