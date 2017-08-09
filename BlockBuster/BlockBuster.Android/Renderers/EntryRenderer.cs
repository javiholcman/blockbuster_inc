using System;
using BlockBuster.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(Entry), typeof(CEntryRenderer))]

namespace BlockBuster.Droid
{
	public class CEntryRenderer : EntryRenderer
	{
		public CEntryRenderer()
		{
		}

		protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
		{
			base.OnElementChanged(e);

			Control.SetBackgroundColor(Color.Transparent.ToAndroid());
			Control.SetPadding(3, 3, 3, 0);
		}
	}
}
