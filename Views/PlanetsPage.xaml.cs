using System.Collections.ObjectModel;
using System.Diagnostics.Metrics;

namespace MauiPlanets.Views;

public partial class PlanetsPage : ContentPage
{
    private const uint AnimationDuration = 800u;
    private PlanetsViewModel _viewModel;

    public PlanetsPage()
	{
		InitializeComponent();
        BindingContext=_viewModel=new PlanetsViewModel(this);

    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        _viewModel.OnAppearing();
    }

   

    async void ProfilePic_Clicked(object sender, System.EventArgs e)
    {
        // Reveal our menu and move the main content out of the view
        _ = MainContentGrid.TranslateTo(-this.Width * 0.5, this.Height * 0.1, AnimationDuration, Easing.CubicIn);
        await MainContentGrid.ScaleTo(0.8, AnimationDuration);
        _ = MainContentGrid.FadeTo(0.8, AnimationDuration);
    }

    async void GridArea_Tapped(object sender, System.EventArgs e)
    {
        await CloseMenu();
    }

    private async Task CloseMenu()
    {
        //Close the menu and bring back back the main content
        _ = MainContentGrid.FadeTo(1, AnimationDuration);
        _ = MainContentGrid.ScaleTo(1, AnimationDuration);
        await MainContentGrid.TranslateTo(0, 0, AnimationDuration, Easing.CubicIn);
    }


    public class PlanetsViewModel : BindableObject
    {
        public PlanetsViewModel(Page page) 
        {
            Page = page;
        }
        public Command SelectionChangedCommand
        {
            get => new Command(SelectionChanged);
        }

        private async void SelectionChanged(object obj)
        {
            if (obj == null) return;
            await Page.Navigation.PushAsync(new PlanetDetailsPage(obj as Planet));
        }

        internal async void OnAppearing()
        {
            /// loading items on appearing as async operation not block the UI
            var p = new List<Planet>();
            var allP = new List<Planet>();
            var t1 = Task.Run(()=>p=PlanetsService.GetFeaturedPlanets());
            var t2 = Task.Run(() => allP=PlanetsService.GetAllPlanets());
            await Task.WhenAll( t1, t2);
            PPlanets = new ObservableCollection<Planet>(p);
            AllPlanets1=new ObservableCollection<Planet>(allP);
            AllPlanets2=new ObservableCollection<Planet>(allP);
        }
        ObservableCollection<Planet> _PPlanets;
        public ObservableCollection<Planet> PPlanets
        {
            get => _PPlanets;
            set { _PPlanets = value; OnPropertyChanged(); }
        }
        ObservableCollection<Planet> _AllPlanets1;
        public ObservableCollection<Planet> AllPlanets1
        {
            get => _AllPlanets1;
            set { _AllPlanets1 = value; OnPropertyChanged(); }
        }
        ObservableCollection<Planet> _AllPlanets2;
        public ObservableCollection<Planet> AllPlanets2
        {
            get => _AllPlanets2;
            set { _AllPlanets2 = value; OnPropertyChanged(); }
        }
        public Page Page { get; }
    }
}
