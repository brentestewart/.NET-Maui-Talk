using LairTracker.ViewModels;

namespace LairTracker.Views;

public partial class VillainsPage : ContentPage
{
	public VillainsPage(VillainsViewModel viewModel)
	{
		InitializeComponent();
		this.BindingContext = viewModel;
	}
}