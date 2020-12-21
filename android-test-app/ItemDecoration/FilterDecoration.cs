using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.Widget;
using Android.Util;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace android_test_app.ItemDecoration
{
    class FilterDecoration : RecyclerView.ItemDecoration
    {
        int R_margin, T_margin, L_margin, B_margin;
        Context context;

        public FilterDecoration(int r_margin, int t_margin, int l_margin, int b_margin, Context context)
        {
            R_margin = dpToPx(context, r_margin);
            T_margin = dpToPx(context, t_margin);
            L_margin = dpToPx(context, l_margin);
            B_margin = dpToPx(context, b_margin);
            this.context = context;
        }

        public static int dpToPx(Context context, int dp)
        {
            DisplayMetrics displayMetrics = context.Resources.DisplayMetrics;
            return (int)TypedValue.ApplyDimension(ComplexUnitType.Dip, dp, displayMetrics);
        }


        public override void GetItemOffsets(Rect outRect, View view, RecyclerView parent, RecyclerView.State state)
        {
            outRect.Right = R_margin;
            outRect.Top = T_margin;
            outRect.Left = L_margin;
            outRect.Bottom = B_margin;
        }
    }
}