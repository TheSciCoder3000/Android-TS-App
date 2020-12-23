using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V4.View;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace android_test_app.otherCs
{
    class LockableViewPager : ViewPager
    {
        // ------------ Initialization ------------
        public bool SwipeLocked { get; set; }
        Context mContext;



        // ------------ Constructors ------------
        public LockableViewPager(Context context) : base(context)
        {
            Init(context, null);
        }

        public LockableViewPager(Context context,  Android.Util.IAttributeSet attrs) : base (context, attrs)
        {
            Init(context, attrs);
        }




        // ------------ Overrides ------------
        public override bool OnTouchEvent(MotionEvent e)
        {
            return !SwipeLocked && base.OnTouchEvent(e);
        }

        public override bool OnInterceptTouchEvent(MotionEvent ev)
        {
            return !SwipeLocked && base.OnInterceptTouchEvent(ev);
        }

        public override bool CanScrollHorizontally(int direction)
        {
            return !SwipeLocked && base.CanScrollHorizontally(direction);
        }



        // ------------ Other Functions ------------
        private void Init(Context context, Android.Util.IAttributeSet attrs)
        {
            mContext = context;
        }

    }
}