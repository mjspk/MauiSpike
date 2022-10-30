using MauiPlanets;
using Microsoft.Maui.Controls.Hosting;
using System.Security.Permissions;

namespace MauiPlanets.Views;

public partial class StartPage2 : ContentPage
{
	public StartPage2()
	{
		InitializeComponent();
	}

    async void ExploreNow_Clicked(object sender, System.EventArgs e)
	{
        await Shell.Current.GoToAsync($"//{nameof(PlanetsPage)}");
    }
}
