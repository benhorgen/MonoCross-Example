using System;
using MonoCross.Navigation;

namespace ExampleApp
{
	public class DashboardController : MXController<DataSet>, IMXController
	{
		public DashboardController() { Model = DataSet.Instance; }
		
		public override string Load (System.Collections.Generic.Dictionary<string, string> parameters)
		{
 			string viewPerspective = ViewPerspective.Default;
			
			string name;
			if (parameters.TryGetValue("name", out name))
			{
				DataSet.SetData(name);
			}
			Model = DataSet.Instance;
			
			// determine if data is available to buld a default view
			if (Model == null || string.IsNullOrEmpty(Model.Name))
			{
				viewPerspective = ViewPerspective.Create;
			}
			return viewPerspective;
		}
	}
}

