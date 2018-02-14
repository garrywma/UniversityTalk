using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

using UCL2.Model;
using UCL2.ViewModel;
using AppServiceHelpers;
using AppServiceHelpers.Abstractions;

namespace UCL2.View
{
	public partial class LecturesPage : ContentPage
	{
		LecturesViewModel vm;
		public LecturesPage()
		{
			InitializeComponent();

			vm = new LecturesViewModel(App.AzureClient);

			BindingContext = vm;


			ListViewLectures.ItemSelected += ListViewLectures_ItemSelected;

		}

		private async void ListViewLectures_ItemSelected(object sender, SelectedItemChangedEventArgs e)
		{
			var lecture = e.SelectedItem as Lecture;
			if (lecture == null)
				return;

			await Navigation.PushAsync(new DetailsPage(lecture));

			ListViewLectures.SelectedItem = null;

		}
		protected override void OnAppearing()
		{
			base.OnAppearing();

			vm.RefreshCommand.Execute(null);
		}

	}
}
