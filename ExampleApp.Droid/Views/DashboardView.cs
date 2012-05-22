using System;
using Android.App;
using Android.Dialog;
using Android.Util;
using Android.Widget;
using MonoCross.Droid;

namespace ExampleApp.Droid
{
    [Activity(Label = "Dashboard View")]
    public class DashboardView : MXActivityView<DataSet>
    {
        public override void Render()
        {
			SetContentView(Resource.Layout.DashboardView);
			
			// populate the Guid in the textview
			TextView t = (TextView)FindViewById(Resource.Id.txtGuidId);
			t.Text = Model.Name;
			
			Button b = (Button)FindViewById(Resource.Id.myDeleteButton);
			b.Click += (sender, e) => 
			{ 
				string s = !string.IsNullOrEmpty(s) ? Model.Name : s = "NoData";
				MXDroidContainer.Navigate(this, "WelcomeScreen/Data/" + s); 
			};
        }
    }
}