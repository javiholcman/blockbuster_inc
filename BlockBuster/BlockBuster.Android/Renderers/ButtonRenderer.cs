using System;
using System.ComponentModel;
using BlockBuster.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(Button), typeof(CButtonRenderer))]

namespace BlockBuster.Droid
{
	public class CButtonRenderer : ButtonRenderer
	{
		/// <summary>
		/// Called when [element changed].
		/// </summary>
		/// <param name="e">The e.</param>
		protected override void OnElementChanged(ElementChangedEventArgs<Button> e)
		{
			base.OnElementChanged(e);

			var view = (Button)e.NewElement;

			if (view != null)
			{
				//SetPadding(view);
				//SetHorizontalTextAlignment(view);
				//Control.SetBackgroundColor(Color.Transparent.ToAndroid());
			}
		}

		/// <summary>
		/// Handles the <see cref="E:ElementPropertyChanged" /> event.
		/// </summary>
		/// <param name="sender">The sender.</param>
		/// <param name="e">The <see cref="System.ComponentModel.PropertyChangedEventArgs"/> instance containing the event data.</param>
		protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			base.OnElementPropertyChanged(sender, e);

			var view = (Button)Element;

		}



	}
}
