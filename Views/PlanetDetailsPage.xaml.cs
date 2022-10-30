namespace MauiPlanets.Views;

public partial class PlanetDetailsPage : ContentPage
{
    public PlanetDetailsPage()
    {
        InitializeComponent();

    }
    public PlanetDetailsPage(Planet planet)
	{
        InitializeComponent();
        BindingContext = planet;
    }

    async void BackButton_Clicked(System.Object sender, System.EventArgs e)
    {
		await Navigation.PopAsync();
    }
}
