using PedidosPrueba.Core.Entidades;
using PedidosPrueba.Core.Interfaces.Repositorios;
using PedidosPrueba.Infraestructure.Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PedidosPrueba.Infraestructure.Repositorios
{
    public class PedidoRepositorio : IPedidosRepositorio
    {

        //Intancia del contexto
        private readonly PedidosPruebaContext _contexto;

        //Constructor
        public PedidoRepositorio(PedidosPruebaContext contexto)
        {
            _contexto = contexto;
        }

        public IEnumerable<Pedidos> ObtenerListaPedidos()
        {
            return _contexto.Pedidos.AsEnumerable();
        }
    }
}
