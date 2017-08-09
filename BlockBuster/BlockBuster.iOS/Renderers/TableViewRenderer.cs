using System;
using UIKit;
using Xamarin.Forms;

[assembly: ExportRenderer(typeof(TableView), typeof(BlockBuster.iOS.TableViewRenderer))]

namespace BlockBuster.iOS
{
	public class TableViewRenderer : Xamarin.Forms.Platform.iOS.TableViewRenderer
	{
		public TableViewRenderer()
		{
		}

		protected override void OnElementChanged(Xamarin.Forms.Platform.iOS.ElementChangedEventArgs<Xamarin.Forms.TableView> e)
		{
			base.OnElementChanged(e);

			if (e.NewElement != null)
			{
				Control.SeparatorColor = UIColor.Clear;
				Control.AllowsSelection = false;
			}
		}
	}
}
