using System;
using System.Collections.Generic;
using System.Linq;
using Android.App;
using Android.Content;

using MonoCross.Navigation;
using MonoCross.Droid;

namespace ExampleApp.Droid
{
    [BroadcastReceiver]
    [IntentFilter(new string[] { "ExampleApp.droid.MainReceiver" })]
    public class MainReceiver : BroadcastReceiver
    {
        public override void OnReceive(Context context, Intent intent)
        {
            // initialize app
			var theApp = new App();
			MonoCross.Droid.MXDroidContainer.Initialize(theApp, context);

            // initialize views
            MXDroidContainer.AddView<object>(typeof(WelcomeScreenView));
			MXDroidContainer.AddView<DataSet>(typeof(DashboardView));
			MXDroidContainer.AddView<DataSet>(new GenericDashboardView(), ViewPerspective.Create);

            // navigate to first view
            MXDroidContainer.Navigate(null, MXContainer.Instance.App.NavigateOnLoad);
        }
    }
}