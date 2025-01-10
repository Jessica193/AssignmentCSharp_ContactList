using MobileApp.ViewModels;

namespace MobileApp.Pages;

public partial class EditPage : ContentPage
{
	public EditPage(EditViewModel viewModel)
	{
		InitializeComponent();
        BindingContext = viewModel;
    }
}