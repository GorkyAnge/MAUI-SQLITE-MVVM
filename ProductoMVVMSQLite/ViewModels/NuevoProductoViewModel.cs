﻿using System;
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
    public class NuevoProductoViewModel
    {
        public string Nombre { get; set; }
        public string Cantidad { get; set; }
        public string Descripcion { get; set; }


        private Producto _producto { get; set; }

        public NuevoProductoViewModel()
        {

        }

        public NuevoProductoViewModel(int IdProducto)
        {
            _producto = App.productoRepository.Get(IdProducto);
            Nombre = _producto.Nombre;
            Descripcion = _producto.Descripcion;
            Cantidad = _producto.Cantidad.ToString();

        }
        public ICommand CrearProducto =>
            new Command(async () =>
            {
                Producto producto = new Producto
                {
                    Nombre = Nombre,
                    Descripcion = Descripcion,
                    Cantidad = Int32.Parse(Cantidad),
                };
                App.productoRepository.Add(producto);
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
