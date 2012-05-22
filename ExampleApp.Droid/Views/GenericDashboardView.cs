using System;
using Android.App;
using Android.Util;
using Android.Widget;
using System.Collections.Generic;

using MonoCross.Droid;
using Android.Dialog;

namespace ExampleApp.Droid
{
    [Activity(Label = "Dashboard View")]
    public class GenericDashboardView 
#if DIALOG
		: MXDialogActivityView<DataSet>
#else
		: MXActivityView<DataSet> 
#endif
    {
        public override void Render()
        {

#if DIALOG
			//Shared UI here
			EntryElement _name = null;
			var dialogSection = GenericDashboardViewDialogSections.CreateDialogSection(out _name);
			
			//TODO:  Build button code here
			
			this.Root = new RootElement(null) { dialogSection };		
#else
 			SetContentView(Resource.Layout.GenericDashboardView);	 
			
			Button b = (Button)FindViewById(Resource.Id.createDataButton);
			b.Click += (sender, e) => 
			{
				string uri = "WelcomeScreen/" + Guid.NewGuid().ToString().Substring(0, 8);
				MXDroidContainer.Navigate(this, uri); 
			};
#endif
        }
    }
}