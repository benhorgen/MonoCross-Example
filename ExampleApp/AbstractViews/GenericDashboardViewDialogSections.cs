using System;

#if MONOTOUCH
using MonoTouch.Dialog;
#endif

#if MONOANDROID
using Android.Dialog;
#endif

namespace ExampleApp
{
	public static class GenericDashboardViewDialogSections
	{

		public static Section CreateDialogSection(out EntryElement name)
		{
			Section entrySection = new Section();
#if MONOANDROID
			//TODO:  Clean up the interface of Android.Dialog
			name = new EntryElement("Name", string.Empty);
#else
			name = new EntryElement("Name", "enter name", null);
#endif
			entrySection.Add(name);
			
			entrySection.Add(new BooleanElement("Is Cool", false));
			entrySection.Add(new FloatElement(null, null, 50));
			entrySection.Add(new DateElement("Today", DateTime.Now));
			
			return entrySection;
		}		
	}
}

