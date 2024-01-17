using ProductoMVVMSQLite.ViewModels;

namespace ProductoMVVMSQLite.Views;

public partial class EditarProductoPage : ContentPage
{
	public EditarProductoPage()
	{
		InitializeComponent();
		BindingContext = new EditarProductoViewModel();
	}

    public EditarProductoPage(int IdProducto)
    {
        InitializeComponent();
        BindingContext = new EditarProductoViewModel(IdProducto);
    }
}