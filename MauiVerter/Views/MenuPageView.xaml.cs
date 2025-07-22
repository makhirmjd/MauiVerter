using MauiVerter.ViewModels;

namespace MauiVerter.Views;

public partial class MenuPageView : ContentPage
{
    private readonly ConverterPageViewModel converterPageViewModel;

    public MenuPageView(MenuPageViewModel viewModel, ConverterPageViewModel converterPageViewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
        this.converterPageViewModel = converterPageViewModel;
    }

    private void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {
        if (sender is Grid grid)
        {
            Label? label = grid.Children.OfType<Label>().FirstOrDefault();   
            if (label is not null)
            {
                string quantityName = label.Text;
                converterPageViewModel.SetMeasure(quantityName);
                ConverterPageView converterPageView = new (converterPageViewModel);
                Navigation.PushAsync(converterPageView);
            }
        }
    }
}