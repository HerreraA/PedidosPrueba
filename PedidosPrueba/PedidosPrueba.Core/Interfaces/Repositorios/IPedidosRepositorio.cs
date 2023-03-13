using PedidosPrueba.Core.Entidades;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PedidosPrueba.Core.Interfaces.Repositorios
{
    public interface IPedidosRepositorio
    {
        Task<Pedidos> ConsultarPedidoPorId(int idPedido);

        IEnumerable<Pedidos> ObtenerListaPedidos();

        Task<Pedidos> ConsultarPedidoPorFiltro(Expression<Func<Pedidos, bool>> filtroPedido);

        Task<IEnumerable<Pedidos>> ConsultarPedidosPorFiltro(Expression<Func<Pedidos, bool>> filtroPedidos);

        void Adicionar(Pedidos infoPedido);

        void Actualizar(Pedidos objActualizar);

        Task Eliminar(int idPedido);
    }
}