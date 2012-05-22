using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using MonoCross.Navigation;

namespace ExampleApp
{
    public class App : MXApplication
    {
        public override void OnAppLoad()
        {
            // Set the application title
            Title = "Example App";

            // Add navigation mappings
			var welcome = new WelcomeScreenController();
            NavigationMap.Add("WelcomeScreen", welcome);
			NavigationMap.Add("WelcomeScreen/Data/{DataID}", welcome);
						
			DashboardController dashboardController = new DashboardController();
			NavigationMap.Add("Dashboard", dashboardController);
			NavigationMap.Add("Dashboard/CreateData/{name}", dashboardController);
			NavigationMap.Add("Dashboard/{UserId}", dashboardController);

            // Set default navigation URI
            NavigateOnLoad = "WelcomeScreen";
        }
		
		public static bool LoggedIn = false;
    }
}
