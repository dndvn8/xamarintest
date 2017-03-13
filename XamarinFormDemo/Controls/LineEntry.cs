using System;
using Xamarin.Forms;

namespace XamarinFormDemo
{
	public class LineEntry : Entry
	{
		public static readonly BindableProperty BorderColorProperty = BindableProperty.Create<LineEntry, Color>
		(p => p.BorderColor, Color.White);

		public Color BorderColor { 
			get { return (Color)GetValue(BorderColorProperty); }
			set { SetValue(BorderColorProperty, value); }
		}
	}
}
