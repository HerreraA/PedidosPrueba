using PedidosPrueba.Core.Entidades;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PedidosPrueba.Core.Interfaces
{
    public interface IPedidosServicio
    {
        // Obtener un registro de pedido por id.
        Task<Pedidos> ObtenerPedido(int idPedido);

        // Obtener todos los pedidos.
        List<Pedidos> ObtenerListadoPedidos();

        // Agregar nuevo un pedido.
        Task<Respuesta> AgregarPedido(Pedidos infoPedido);

        // Actualizar un pedido.
        Task<Respuesta> EditarPedido(int idPedido, Pedidos infoPedido);

        // Eliminar un pedido.
        Task<Respuesta> EliminarPedido(int idPedido);
    }
}