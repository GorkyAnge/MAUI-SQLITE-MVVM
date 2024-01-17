using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        private Producto _producto { get; set; }


        public DetalleProductoViewModel()
        {

        }

        public DetalleProductoViewModel(int IdProducto)
        {
            _producto = App.productoRepository.Get(IdProducto);
            Nombre = _producto.Nombre;
            Descripcion = _producto.Descripcion;
            Cantidad = _producto.Cantidad.ToString();

        }
        public ICommand EditarProducto =>
            new Command(async () =>
            {
                if (_producto != null)
                {
                    int IdProducto = _producto.IdProducto;
                    await App.Current.MainPage.Navigation.PopAsync();
                    await App.Current.MainPage.Navigation.PushAsync(new EditarProductoPage(IdProducto));
                    _producto = null;
                }              

            });

        public ICommand BorrarProducto =>
            new Command(async () =>
            {
                if (_producto != null)
                {
                    int IdProducto = _producto.IdProducto;
                    App.productoRepository.Delete(_producto);
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
