using System;
using System.Drawing;

using MonoTouch.UIKit;
using MonoTouch.Dialog;
using MonoTouch.Foundation;
using MonoTouch.CoreGraphics;

using ExampleApp;
using MonoCross.Touch;
using System.Collections.Generic;

namespace ExampleApp.Touch
{
	public partial class GenericDashboardView : DialogViewWithBackground<DataSet>
	{
		public GenericDashboardView () : base(UITableViewStyle.Grouped, null, true, "images/Wallpaper.png") { }

		public override void Render() 
		{
			ConstructUI();			
			
			if (Model != null)
			{
				_name.Value = Model.Name;			
			}
		}
		EntryElement _name;
		Section _dialogSection = null;
		
		private bool ConstructUI()
		{
			// check if UI has already been built
			if (!_uiContructed)
			{
				Title = "";
				
				float labelHeight = 44;
				float containerWidth = 300;
				
				List<Section> sections = new List<Section>();
				
				//Shared UI here
				_dialogSection = GenericDashboardViewDialogSections.CreateDialogSection(out _name);
				sections.Add(_dialogSection);
				
				sections.Add(CreateButtonSection(labelHeight, containerWidth));
				
				Root = new RootElement("Create Data");
				Root.Add(sections);
			
				// UI construction completed
				_uiContructed = true;
			}
			return _uiContructed;
		}
		bool _uiContructed = false;

		Section CreateNoDataImageSection(float labelHeight, float containerWidth)
		{
			//Section w/ a the No Data image
			var imageSection = new Section();
			var loc = new PointF(0, 10);
			var size = new SizeF(containerWidth, 130);
			var viewRect = new RectangleF(loc, size);
			UIView containingView = new UIView(viewRect);
			containingView.Layer.CornerRadius = 15f;
			containingView.BackgroundColor = UIColor.White;
			containingView.Layer.BorderWidth = 5.0f;
			containingView.Layer.BorderColor = new CGColor(0.5f, 1.0f);
			
			float centering = (containerWidth - 86)/2;
			var imgNoData = new UIImageView(new RectangleF(centering,10,86, 75));
			imgNoData.Image = UIImage.FromFile("images/WarningIcon.png");
			containingView.Add(imgNoData);
			
			var noDataLabel = new UILabel(new RectangleF(0, 76, containerWidth, labelHeight));
			noDataLabel.Text = "No Data Available";
			noDataLabel.BackgroundColor = UIColor.Clear;
			noDataLabel.TextAlignment = UITextAlignment.Center;
			containingView.Add(noDataLabel);
			
			UIViewElement warningImageElement = new UIViewElement(string.Empty, containingView, true);
			warningImageElement.Flags = UIViewElement.CellFlags.DisableSelection | UIViewElement.CellFlags.Transparent;				
			imageSection.Add(warningImageElement);
			
			return imageSection;
		}

		Section CreateButtonSection(float labelHeight, float containerWidth)
		{
			Section buttonSection = new Section();
			GlassButton button = new GlassButton(new RectangleF(0, 0, containerWidth, labelHeight));
			button.SetTitleColor(UIColor.FromRGBA(255, 255, 0, 255), UIControlState.Normal);
			button.HorizontalAlignment = UIControlContentHorizontalAlignment.Center;
			button.SetTitle("Create Dataset", UIControlState.Normal);
			button.TouchUpInside += (o, e) => 
			{
				string name = _name.Summary();
				if (string.IsNullOrEmpty(name)) 
				{
					//show an alert if data is not filled
					new UIAlertView(string.Empty, "Enter a name", null, "OK", null).Show(); 
				}
				else { 
					// navigate to next screen
					MXTouchContainer.Navigate("Dashboard/CreateData/" + name); 
				}
			};
			UIViewElement imageElement = new UIViewElement(string.Empty, button, true);
			imageElement.Flags = UIViewElement.CellFlags.DisableSelection | UIViewElement.CellFlags.Transparent;				
			buttonSection.Add(imageElement);
			
			return buttonSection;
		}
	}
	
	public abstract class DialogViewWithBackground<T> : MXTouchDialogView<T>
	{
		public DialogViewWithBackground (UITableViewStyle style, RootElement root, bool pushing, string image) : base (style, root, pushing)
		{
			_background = UIImage.FromFile(image);
		}
		UIImage _background;
		
	    public override void LoadView ()
		{
			base.LoadView ();
			
			TableView.BackgroundColor = UIColor.Clear;
	        ParentViewController.View.BackgroundColor = UIColor.FromPatternImage(_background);
	    }
	}	
}

