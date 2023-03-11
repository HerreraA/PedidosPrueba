using PedidosPrueba.Core.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace PedidosPrueba.Core.Interfaces.Repositorios
{
    public interface IPedidosRepositorio
    {
        IEnumerable<Pedidos> ObtenerListaPedidos();
    }
}
