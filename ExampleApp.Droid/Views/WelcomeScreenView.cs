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
			if (b != null) 
			{
				Android.Graphics.Color color = Android.Graphics.Color.Rgb(0x62, 0x63, 0x70);
				Android.Graphics.PorterDuff.Mode mode = Android.Graphics.PorterDuff.Mode.Multiply;
				
				var c = new Android.Graphics.PorterDuffColorFilter(color, mode);
				b.Background.SetColorFilter(c);
				b.Click += (sender, e) => { MXDroidContainer.Navigate("Dashboard");  }; 
			}
        }
    }
	
}