using BuddyNetworks.Roosters.Views;

namespace MauiPlanets;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		MainPage = new StartPage2();
		//MainPage = new NavigationPage(new PlanetDetailsPage(PlanetsService.GetPlanet("Uranus")));
    }
}

