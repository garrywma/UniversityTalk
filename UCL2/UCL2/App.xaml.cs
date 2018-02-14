using Xamarin.Forms;
using AppServiceHelpers;
using AppServiceHelpers.Abstractions;
using UCL2.View;
namespace UCL2
{
	public partial class App : Application
	{
		public static IEasyMobileServiceClient AzureClient;
		public App()
		{
			InitializeComponent();
		
			// 1. Create a new EasyMobileServiceClient.
			AzureClient = EasyMobileServiceClient.Create();

			// 2. Initialize the library with the URL of the Azure Mobile App you created in Step #1.
			// Example: https://appservicehelpers.azurewebsites.net
			AzureClient.Initialize("https://ucl-1.azurewebsites.net");

			// 3. Register a model with the EasyMobileServiceClient to create a table.
			AzureClient.RegisterTable<Model.Lecture>();

			// 4. Finalize the schema for our database. All table registrations must be done before this step.
			AzureClient.FinalizeSchema();

			var content = new LecturesPage();

			MainPage = new NavigationPage(content);
		}

		protected override void OnStart()
		{
			// Handle when your app starts
		}

		protected override void OnSleep()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume()
		{
			// Handle when your app resumes
		}
	}
}
