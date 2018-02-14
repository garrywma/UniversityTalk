using System;

using Xamarin.Forms;

namespace FDSpeakers
{
	public class SpeakersPage : ContentPage
	{
		public SpeakersPage()
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

