using ProductoMVVMSQLite.Models;
using ProductoMVVMSQLite.Utils;
using ProductoMVVMSQLite.Views;
using PropertyChanged;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace ProductoMVVMSQLite.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class ProductoViewModel
    {
        public ObservableCollection<Producto> ListaProductos { get; set; }

        public Producto producto {get;set;}

        public ProductoViewModel() {
            Util.ListaProductos = new ObservableCollection<Producto>(App.productoRepository.GetAll());
            ListaProductos = Util.ListaProductos;
        
        }

        public ICommand LoadProductos =>
           new Command(async () =>
           {
               Util.ListaProductos = new ObservableCollection<Producto>(App.productoRepository.GetAll());
               ListaProductos = Util.ListaProductos;
           });

        public ICommand CrearProducto =>
            new Command(async () =>
            {
               await App.Current.MainPage.Navigation.PushAsync(new NuevoProductoPage());
            });

        public ICommand DetallesProducto =>
            new Command(async () =>
            {
                if (producto != null)
                {
                    int IdProducto = producto.IdProducto;
                    await App.Current.MainPage.Navigation.PushAsync(new DetalleProductoPage(IdProducto));
                    producto = null;
                }
            });

    }
}
