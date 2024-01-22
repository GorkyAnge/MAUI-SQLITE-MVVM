using ProductoMVVMSQLite.Models;
using ProductoMVVMSQLite.Utils;
using ProductoMVVMSQLite.Views;
using PropertyChanged;
using System.Windows.Input;

namespace ProductoMVVMSQLite.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class DetalleProductoViewModel
    {

        public string Nombre { get; set; }
        public string Cantidad { get; set; }
        public string Descripcion { get; set; }
        private Producto producto { get; set; }


        public DetalleProductoViewModel()
        {

        }

        public DetalleProductoViewModel(int IdProducto)
        {
            producto = App.productoRepository.Get(IdProducto);
            Nombre = producto.Nombre;
            Descripcion = producto.Descripcion;
            Cantidad = producto.Cantidad.ToString();

        }
        public ICommand EditarProducto =>
            new Command(async () =>
            {
                if (producto != null)
                {
                    int IdProducto = producto.IdProducto;
                    await App.Current.MainPage.Navigation.PopAsync();
                    await App.Current.MainPage.Navigation.PushAsync(new EditarProductoPage(IdProducto));
                    producto = null;
                }              

            });

        public ICommand BorrarProducto =>
            new Command(async () =>
            {
                if (producto != null)
                {
                    int IdProducto = producto.IdProducto;
                    App.productoRepository.Delete(producto);
                    ActualizarLista();
                    await App.Current.MainPage.Navigation.PopAsync();

                }

            });

        private void ActualizarLista()
        {
            Util.ListaProductos.Clear();
            App.productoRepository.GetAll().ForEach(Util.ListaProductos.Add);
        }

    }
}
