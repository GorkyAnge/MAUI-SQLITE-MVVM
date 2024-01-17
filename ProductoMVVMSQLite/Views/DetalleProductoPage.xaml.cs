using ProductoMVVMSQLite.ViewModels;

namespace ProductoMVVMSQLite.Views;

public partial class DetalleProductoPage : ContentPage
{
	public DetalleProductoPage()
	{
		InitializeComponent();
		BindingContext = new DetalleProductoViewModel();
	}

    public DetalleProductoPage(int IdProducto)
    {
        InitializeComponent();
        BindingContext = new DetalleProductoViewModel(IdProducto);
    }
}