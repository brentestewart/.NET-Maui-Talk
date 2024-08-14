using LairTracker.ViewModels;

namespace LairTracker.Views;

public partial class VillainDetailsPage : ContentPage
{
	public VillainDetailsPage(VillainDetailsViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}