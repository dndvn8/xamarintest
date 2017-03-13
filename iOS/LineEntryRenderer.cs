using Xamarin.Forms.Platform.iOS;
using Xamarin.Forms;
using UIKit;
using XamarinFormDemo.iOS;
using System.ComponentModel;
using CoreAnimation;
using Foundation;

[assembly: ExportRenderer(typeof(XamarinFormDemo.LineEntry), typeof(LineEntryRenderer))]
namespace XamarinFormDemo.iOS
{
	public class LineEntryRenderer : EntryRenderer
	{
		protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
		{
			base.OnElementChanged(e);

			if (Control != null)
			{
				Control.BorderStyle = UITextBorderStyle.None;

				var view = (Element as LineEntry);

				if (view != null)
				{
					DrawBorder(view);
				}
			}
		}

		protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			base.OnElementPropertyChanged(sender, e);
			var view = (LineEntry)Element;

			if (e.PropertyName.Equals(view.BorderColor))
				DrawBorder(view);
		}

		void DrawBorder(LineEntry view)
		{
			var borderLayer = new CALayer();
			borderLayer.MasksToBounds = true;
			borderLayer.Frame = new CoreGraphics.CGRect(0f, Frame.Height / 2, Frame.Width, 1f);
			borderLayer.BorderColor = view.BorderColor.ToCGColor();
			borderLayer.BorderWidth = 1.0f;

			Control.Layer.AddSublayer(borderLayer);
			Control.BorderStyle = UITextBorderStyle.None;
		}
	}
}