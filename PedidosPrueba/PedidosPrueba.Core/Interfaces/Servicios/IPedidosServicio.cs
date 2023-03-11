using PedidosPrueba.Core.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace PedidosPrueba.Core.Interfaces
{
    public interface IPedidosServicio 
    {
        List<Pedidos> ObtenerListadoPedidos();
        void ObtenerPedidoId();
    }
}
