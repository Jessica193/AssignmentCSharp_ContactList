using MobileApp.ViewModels;

namespace MobileApp.Pages;

public partial class AddPage : ContentPage
{
    public AddPage(AddViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}