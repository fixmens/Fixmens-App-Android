using System;
using Android.App;

namespace FixMens.Services
{
    public class MyTransactions
    {
       
        public static int ReplaceFragment(Activity origin, int containerViewId, Fragment fragment)
			{
				try
				{
					return origin.FragmentManager.BeginTransaction().Replace(containerViewId, fragment).Commit();
				}
				catch (System.Exception ex)
				{
					throw ex;
				}
			}

			public static int AddFragment(Activity origin, int containerViewId,Fragment fragment, string backstack = null)
			{
				try
				{
					return origin.FragmentManager.BeginTransaction().Add(containerViewId, fragment).AddToBackStack(backstack).Commit();
				}
				catch (System.Exception ex)
				{
					throw ex;
				}
			}

		
    }
}
