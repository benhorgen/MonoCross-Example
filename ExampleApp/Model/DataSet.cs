using System;

namespace ExampleApp
{
	public class DataSet
	{
		public static DataSet SetData(string name) 
		{
			if (string.IsNullOrEmpty(name)) { throw new ArgumentException("Cannot be null or string.Empty", "name"); } 
			if (_instance == null) { _instance = new DataSet(); }
			Instance._name = name;
			return Instance;
		}
		
		public static void ClearData() 
		{
			Instance._name = string.Empty;
		}

		public string Name { get { return _name; } }
		string _name;
		
		public static DataSet Instance
		{
			get { return _instance; }
		}
		
		private DataSet() { }		
		private static DataSet _instance;		
	}
}

