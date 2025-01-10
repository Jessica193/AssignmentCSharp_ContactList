using MobileApp.ViewModels;

namespace MobileApp.Pages;

public partial class ListPage : ContentPage
{
    public ListPage(ListViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}