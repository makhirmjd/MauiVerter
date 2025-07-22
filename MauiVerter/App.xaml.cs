using MauiVerter.ViewModels;
using MauiVerter.Views;

namespace MauiVerter
{
    public partial class App : Application
    {
        private readonly MenuPageViewModel viewModel;
        private readonly ConverterPageViewModel converterPageViewModel;

        public App(MenuPageViewModel viewModel, ConverterPageViewModel converterPageViewModel)
        {
            InitializeComponent();
            this.viewModel = viewModel;
            this.converterPageViewModel = converterPageViewModel;
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            return new Window(new NavigationPage(new MenuPageView(viewModel, converterPageViewModel)));
        }
    }
}