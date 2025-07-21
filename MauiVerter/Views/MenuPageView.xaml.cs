using MauiVerter.ViewModels;

namespace MauiVerter.Views;

public partial class MenuPageView : ContentPage
{
	public MenuPageView(MenuPageViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
    }
}