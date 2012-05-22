using System;
using System.Drawing;

using MonoTouch.Foundation;
using MonoTouch.UIKit;
using MonoCross.Touch;
using MonoTouch.Dialog;


namespace ExampleApp.Touch
{
	public partial class WelcomeScreenView : MXTouchViewController<object>
	{
		//public WelcomeScreenView () : base ("WelcomeScreenView", null) { }
		
		public override void Render()
		{
			_uiContructed = ConstructUI();
			if (!_uiContructed)
			{
				throw new ApplicationException("Failed to render Welcome Screen UI");
			}
		}
		
		private bool ConstructUI()
		{
			// check if UI has already been built
			if (!_uiContructed)
			{
				Title = "Welcome!";
				
				UIImageView imgBackground = new UIImageView (new RectangleF (0, 0, 320, 480));
				imgBackground.Image = UIImage.FromFile ("images/Wallpaper.png");
				this.Add (imgBackground);
				
				var loc = new PointF(10, 20);
				var size = new SizeF(300, 44);
				var rect = new RectangleF(loc, size);
				GlassButton b = new GlassButton(rect);
				b.SetTitleColor(UIColor.FromRGBA(255, 255, 0, 255), UIControlState.Normal);
				b.HorizontalAlignment = UIControlContentHorizontalAlignment.Center;
				b.SetTitle("Next Screen", UIControlState.Normal);
				b.TouchUpInside += (o, e) => { MXTouchContainer.Navigate("Dashboard"); };
				this.Add(b);
			
				// UI construction completed
				_uiContructed = true;
			}
			return _uiContructed;
		}
		bool _uiContructed = false;
		
		#region UIViewController overrides
		public override void DidReceiveMemoryWarning ()
		{
			// Releases the view if it doesn't have a superview.
			base.DidReceiveMemoryWarning ();
			
			// Release any cached data, images, etc that aren't in use.
		}
		
		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			
			// Perform any additional setup after loading the view, typically from a nib.
		}
		
		public override void ViewDidUnload ()
		{
			base.ViewDidUnload ();
			
			// Clear any references to subviews of the main view in order to
			// allow the Garbage Collector to collect them sooner.
			//
			// e.g. myOutlet.Dispose (); myOutlet = null;
			
			ReleaseDesignerOutlets ();
		}
		
		public override bool ShouldAutorotateToInterfaceOrientation (UIInterfaceOrientation toInterfaceOrientation)
		{
			// Return true for supported orientations
			return (toInterfaceOrientation != UIInterfaceOrientation.PortraitUpsideDown);
		}
		
		public override void ViewWillAppear (bool animated)
		{
			base.ViewWillAppear (animated);
		}
		
		public override void ViewWillDisappear (bool animated)
		{
			base.ViewWillDisappear(animated);
			
//			if (NavigationController != null && NavigationController.NavigationBar != null)
//		    {
//				NavigationController.NavigationBar.SetBackgroundImage(null, UIBarMetrics.Default);
//			}
		}
		#endregion
	}
}

