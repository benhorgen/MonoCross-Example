using System;
using System.Drawing;
using MonoTouch.UIKit;
using MonoTouch.Dialog;
using MonoTouch.CoreGraphics;
using MonoTouch.Foundation;

using MonoCross.Touch;

using ExampleApp;

namespace ExampleApp.Touch
{
	public partial class DashboardView : MXTouchViewController<DataSet>
	{
		public DashboardView () : base ("DashboardView", null) 
		{
			Model = DataSet.Instance;
		}
		
		public override void Render () 
		{
			ConstructUI();
			
			if (_userIdValueLabel != null) _userIdValueLabel.Text =  Model.Name;
		}
			
		private bool ConstructUI()
		{
			// check if UI has already been built
			if (!_uiContructed)
			{
				Title = "Dashboard";
				
				UIImageView imgBackground = new UIImageView (new RectangleF (0, 0, 320, 480));
				imgBackground.Image = UIImage.FromFile ("images/Wallpaper.png");
				this.Add (imgBackground);
				
				float yLoc = 0;
				float labelHeight = 44;				
				
				var loc = new PointF(10, 75);
				var size = new SizeF(300, labelHeight);
				var viewRect = new RectangleF(loc, size);
				UIView statsView = new UIView(viewRect);
				statsView.BackgroundColor = UIColor.Clear;
				
				var labelSize = new SizeF(150, labelHeight);
				
				var rect = new RectangleF(new PointF(0, yLoc), labelSize);
				var userIdLabel = new UILabel(rect);
				userIdLabel.Text = "DataSet GUID:";
				userIdLabel.Layer.BorderColor = new CGColor(1.0f, 0.0f, 0.0f, 1.0f);
				userIdLabel.Layer.CornerRadius = 15f;
				userIdLabel.BackgroundColor = UIColor.FromWhiteAlpha(0.5f, 0.5f);
				
				var labelRect = new RectangleF();
				var labelStart = labelSize.Width - 20;
				labelRect.Width = size.Width - labelStart;
				labelRect.Height = labelHeight;
				labelRect.Location = new PointF(labelStart, yLoc);
				_userIdValueLabel = new UILabel(labelRect);
				_userIdValueLabel.BackgroundColor = UIColor.FromWhiteAlpha(0.5f, 0.5f);
				_userIdValueLabel.Layer.CornerRadius = 15f;
				_userIdValueLabel.Text = Model != null ? Model.Name : "NULL";
				
				statsView.Add(userIdLabel);
				statsView.Add(_userIdValueLabel);
				this.Add(statsView);
				
				//float buttonStart = labelRect.Y + labelHeight + 10;
				loc = new PointF(10, 20);
				size = new SizeF(300, 44);
				rect = new RectangleF(loc, size);
				GlassButton b = new GlassButton(rect);
				b.SetTitleColor(UIColor.FromRGBA(255, 255, 0, 255), UIControlState.Normal);
				b.HorizontalAlignment = UIControlContentHorizontalAlignment.Center;
				b.SetTitle("Delete Data", UIControlState.Normal);
				b.TouchUpInside += (o, e) => { 
					string s = !string.IsNullOrEmpty(s) ? Model.Name : s = "NoData";
					MXTouchContainer.Navigate("WelcomeScreen/Data/" + s);  
				};
				this.Add(b);
				
				var button = new UIBarButtonItem(UIBarButtonSystemItem.Refresh);
				button.Clicked += delegate(object sender, EventArgs e) {
						MXTouchContainer.Navigate("WelcomeScreen");
				};
				NavigationItem.SetRightBarButtonItem(button, true);
				
				
			
				// UI construction completed
				_uiContructed = true;
			}
			return _uiContructed;
		}
		UILabel _userIdValueLabel;
		bool _uiContructed = false;		
		
		#region UIViewControler overrides
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
		#endregion
	}
}

