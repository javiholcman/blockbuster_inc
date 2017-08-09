using System;
using UIKit;
using Xamarin.Forms;

[assembly: ExportRenderer(typeof(ListView), typeof(BlockBuster.iOS.ListViewRenderer))]

namespace BlockBuster.iOS
{
	public class ListViewRenderer : Xamarin.Forms.Platform.iOS.ListViewRenderer
	{
		public ListViewRenderer()
		{
		}

		protected override void OnElementChanged(Xamarin.Forms.Platform.iOS.ElementChangedEventArgs<Xamarin.Forms.ListView> e)
		{
			base.OnElementChanged(e);

			if (e.NewElement != null)
			{
				Control.SeparatorColor = UIColor.Gray.ColorWithAlpha(0.3f);
				Control.TableFooterView = new UIView();
			}
		}
	}
}
