using ProductoMVVMSQLite.Models;
using ProductoMVVMSQLite.Utils;
using PropertyChanged;
using System.Windows.Input;

namespace ProductoMVVMSQLite.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class EditarProductoViewModel
    {

        public string Nombre { get; set; }
        public string Cantidad { get; set; }
        public string Descripcion { get; set; }

        private Producto producto { get; set; }


        public EditarProductoViewModel()
        {

        }

        public EditarProductoViewModel(int IdProducto)
        {
            producto = App.productoRepository.Get(IdProducto);
            Nombre = producto.Nombre;
            Descripcion = producto.Descripcion;
            Cantidad = producto.Cantidad.ToString();

        }

        public ICommand ActualizarProducto =>
            new Command(async () =>
            {
                producto.Nombre = Nombre;
                producto.Cantidad = Int32.Parse(Cantidad);
                producto.Descripcion = Descripcion;
                App.productoRepository.Update(producto);
                ActualizarLista();
                await App.Current.MainPage.Navigation.PopAsync();
                
            });

        private void ActualizarLista()
        {
            Util.ListaProductos.Clear();
            App.productoRepository.GetAll().ForEach(Util.ListaProductos.Add);
        }

    }
}
