using System;
using System.Collections.Generic;

using MonoCross.Navigation;


namespace ExampleApp
{
    public class WelcomeScreenController : MXController<object>, IMXController
    {
        public override string Load(Dictionary<string, string> parameters)
        {
			string guid;
			if (parameters.TryGetValue("DataID", out guid))
	        {
				//TODO:  could use guid to clear from dataset
				DataSet.ClearData();
			}
			
            return ViewPerspective.Default;
        }
    }
}
