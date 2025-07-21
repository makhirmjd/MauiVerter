using MauiVerter.ViewModels;
using MauiVerter.Views;

namespace MauiVerter
{
    public partial class App : Application
    {
        private readonly MenuPageViewModel viewModel;

        public App(MenuPageViewModel viewModel)
        {
            InitializeComponent();
            this.viewModel = viewModel;
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            return new Window(new MenuPageView(viewModel));
        }
    }
}