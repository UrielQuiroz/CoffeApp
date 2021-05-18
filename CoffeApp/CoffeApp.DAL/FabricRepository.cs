using CoffeApp.COMMON.Entidades;
using CoffeApp.COMMON.Interfaces;
using CoffeApp.COMMON.Validadores;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeApp.DAL.MsSQL
{
    public static class FabricRepository
    {
        public static IGenericRepository<CategoriaDeProducto> CategoriaDeProducto()
        {
            return new GenericRepository<CategoriaDeProducto>(new CategoriaDeProductoValidator());
        }

        public static IGenericRepository<ElementoEnMenu> ElementoEnMenu()
        {
            return new GenericRepository<ElementoEnMenu>(new ElementoEnMenuValidator());
        }

        public static IGenericRepository<ElementoEnPaquete> ElementoEnPaquete()
        {
            return new GenericRepository<ElementoEnPaquete>(new ElementoEnPaqueteValidator());
        }

        public static IGenericRepository<MenuComidaCorrida> MenuComidaCorrida()
        {
            return new GenericRepository<MenuComidaCorrida>(new MenuComidaCorridaValidator());
        }

        public static IGenericRepository<Paquete> Paquete()
        {
            return new GenericRepository<Paquete>(new PaqueteValidator());
        }

        public static IGenericRepository<Producto> Producto()
        {
            return new GenericRepository<Producto>(new ProductoValidator());
        }

        public static IGenericRepository<ProductosEnVenta> ProductosEnVenta()
        {
            return new GenericRepository<ProductosEnVenta>(new ProductosEnVentaValidator());
        }

        public static IGenericRepository<TipoUsuario> TipoUsuario()
        {
            return new GenericRepository<TipoUsuario>(new TipoUsuarioValidator());
        }

        public static IGenericRepository<Usuario> Usuario()
        {
            return new GenericRepository<Usuario>(new UsuarioValidator());
        }

        public static IGenericRepository<Venta> Venta()
        {
            return new GenericRepository<Venta>(new VentaValidator());
        }
    }
}
