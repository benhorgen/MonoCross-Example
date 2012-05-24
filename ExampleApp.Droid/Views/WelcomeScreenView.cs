using System;
using Android.App;
using Android.Dialog;
using Android.Util;
using Android.Widget;
using Android.Views;
using MonoCross.Droid;

namespace ExampleApp.Droid
{
    [Activity(Label = "Welcome Screen View")]
    public class WelcomeScreenView : MXActivityView<object>
    {	
        public override void Render()
        {
			SetContentView(Resource.Layout.WelcomeView);
			
			Button b = (Button)FindViewById(Resource.Id.myButton);
			if (b != null) { b.Click += (sender, e) => 
				{ 
					MXDroidContainer.Navigate("Dashboard");  }; 
			}
        }
    }
	
}