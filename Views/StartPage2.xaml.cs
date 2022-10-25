using Microsoft.Maui.Controls.Hosting;

namespace BuddyNetworks.Roosters.Views;

public partial class StartPage2 : ContentPage
{
	public StartPage2()
	{
		InitializeComponent();
	}

	async void ExploreNow_Clicked(System.Object sender, System.EventArgs e)
	{
		Application.Current.MainPage = new NavigationPage(new PlanetsPage());
	}
}
