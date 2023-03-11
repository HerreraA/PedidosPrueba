using PedidosPrueba.Core.Entidades;
using PedidosPrueba.Core.Interfaces;
using PedidosPrueba.Core.Interfaces.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PedidosPrueba.Core.Servicios
{
   public class PedidosServicio : IPedidosServicio
    {
        // instancio el repositorio
        private readonly IPedidosRepositorio _iPedidosRepositorio;

        //constructor
        public PedidosServicio(IPedidosRepositorio iPedidosRepositorio)
        {
            _iPedidosRepositorio = iPedidosRepositorio;
        }

        public List<Pedidos> ObtenerListadoPedidos()
        {
           List<Pedidos> valorRepo = _iPedidosRepositorio.ObtenerListaPedidos().ToList();
            return valorRepo;
        }
        public void ObtenerPedidoId()
        {

        }
    }
}
