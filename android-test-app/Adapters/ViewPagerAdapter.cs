using Android.Support.V4.App;
using System.Collections.Generic;

namespace android_test_app.Adapters
{
    class ViewPagerAdapter : FragmentPagerAdapter
    {
        // -------------- Initialization --------------
        public List<Fragment> _fragments { get; set; }
        public List<string> fragmentNames { get; set; }



        // -------------- Constructor --------------
        public ViewPagerAdapter(FragmentManager fm) : base(fm)
        {
            _fragments = new List<Fragment>();
            fragmentNames = new List<string>();
        }



        // -------------- Overrides --------------
        public override int Count => _fragments.Count;

        public override Fragment GetItem(int position) => _fragments[position];



        // -------------- Other Functions --------------
        public void AddFragment(Fragment _fragment, string name)
        {
            _fragments.Add(_fragment);
            fragmentNames.Add(name);
        }

    }
}