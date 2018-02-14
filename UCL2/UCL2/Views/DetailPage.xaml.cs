using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

using UCL2.Model;
using Plugin.TextToSpeech;
using Plugin.ExternalMaps;
using Plugin.Calendars;
using Plugin.Calendars.Abstractions;
using System.Globalization;

namespace UCL2.View
{
	public partial class DetailsPage : ContentPage
	{


		Lecture lecture;
		public DetailsPage(Lecture item)
		{
			InitializeComponent();
			this.lecture = item;
			BindingContext = this.lecture;

			ButtonSpeak.Clicked += ButtonSpeak_Clicked;
			ButtonCalendar.Clicked += ButtonCalendar_Clicked;
			ButtonMap.Clicked += ButtonMap_Clicked;
		}


		private void ButtonSpeak_Clicked(object sender, EventArgs e)
		{
			CrossTextToSpeech.Current.Speak(this.lecture.biography);
		}

		private async void ButtonCalendar_Clicked(object sender, EventArgs e)
		{
			try
			{
				ButtonCalendar.IsEnabled = false;
				var calendars = await CrossCalendars.Current.GetCalendarsAsync();
				if (calendars.Count==0)
				{
					var calendar=await CrossCalendars.Current.CreateCalendarAsync("UCL");
					calendars.Add(calendar);
					await DisplayAlert("Calendar", "We've created a default UCL calendar", "OK");


				}
				var calEvent = new CalendarEvent();
				calEvent.Name = lecture.title;
				calEvent.Description = "Lecture by " + lecture.presenter;
				calEvent.Start = DateTime.ParseExact(lecture.starts, "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);
				calEvent.End = DateTime.ParseExact(lecture.ends, "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);
				calEvent.Location = lecture.venue + " at " + lecture.address;

				await CrossCalendars.Current.AddOrUpdateEventAsync(calendars.First(), calEvent);
				await DisplayAlert("Calendar", "Lecture added to your default calendar", "OK");
			}
			catch (Exception ex)
			{
				Console.Error.WriteLine(ex.Message);
			}
			finally
			{
				ButtonCalendar.IsEnabled = true;

			}
		}

		private async void ButtonMap_Clicked(object sender, EventArgs e)
		{
			var split = lecture.address.Split(',');
            if (split.Length > 2)
            {
                await CrossExternalMaps.Current.NavigateTo(lecture.venue, split[split.Length - 3], split[split.Length - 2], "", split[split.Length - 1], "UK", "");
            }
            else
            {
                await DisplayAlert("Alert", "Insufficient addrees detail to show a map", "OK");
            }
    
		}

		protected async override void OnDisappearing()
		{
			base.OnDisappearing();
			await App.AzureClient.Table<Lecture>().UpdateAsync(lecture);

		}
	}
}
