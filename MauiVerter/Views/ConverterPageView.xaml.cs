using MauiVerter.ViewModels;

namespace MauiVerter.Views;

public partial class ConverterPageView : ContentPage
{
	public ConverterPageView(ConverterPageViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}