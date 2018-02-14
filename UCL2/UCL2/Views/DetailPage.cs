using System;

using Xamarin.Forms;

namespace UCL2
{
	public class DetailPage : ContentPage
	{
		public DetailPage()
		{
			Content = new StackLayout
			{
				Children = {
					new Label { Text = "Hello ContentPage" }
				}
			};
		}
	}
}

