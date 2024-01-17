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
    public class EditarProductoViewModel
    {

        public string Nombre { get; set; }
        public string Cantidad { get; set; }
        public string Descripcion { get; set; }

        private Producto ProductoEncontrado { get; set; }


        public EditarProductoViewModel()
        {

        }

        public EditarProductoViewModel(int IdProducto)
        {
            ProductoEncontrado = App.productoRepository.Get(IdProducto);
            Nombre = ProductoEncontrado.Nombre;
            Descripcion = ProductoEncontrado.Descripcion;
            Cantidad = ProductoEncontrado.Cantidad.ToString();

        }

        public ICommand ActualizarProducto =>
            new Command(async () =>
            {
                ProductoEncontrado.Nombre = Nombre;
                ProductoEncontrado.Cantidad = Int32.Parse(Cantidad);
                ProductoEncontrado.Descripcion = Descripcion;
                App.productoRepository.Update(ProductoEncontrado);
                ActualizarLista();
                await App.Current.MainPage.Navigation.PopAsync();
                
            });

        private void ActualizarLista()
        {
            App.productoRepository.GetAll().ForEach(Util.ListaProductos.Add);
        }

    }
}
