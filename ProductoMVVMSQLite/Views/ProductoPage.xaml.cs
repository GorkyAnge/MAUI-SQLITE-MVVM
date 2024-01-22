using ProductoMVVMSQLite.ViewModels;

namespace ProductoMVVMSQLite.Views;

public partial class ProductoPage : ContentPage
{
	public ProductoPage()
	{
		InitializeComponent();
		BindingContext = new ProductoViewModel();
	}
    private void OnClickShowDetails(object sender, SelectedItemChangedEventArgs e)
    {
        ((ProductoViewModel)BindingContext).DetallesProducto.Execute(null);
    }

}