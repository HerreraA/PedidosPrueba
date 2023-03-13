using Microsoft.EntityFrameworkCore;
using PedidosPrueba.Core.Entidades;
using PedidosPrueba.Core.Interfaces.Repositorios;
using PedidosPrueba.Infraestructure.Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PedidosPrueba.Infraestructure.Repositorios
{
    public class PedidoRepositorio : IPedidosRepositorio
    {

        // Intancia del contexto
        private readonly PedidosPruebaContext _contexto;

        // Constructor
        public PedidoRepositorio(PedidosPruebaContext contexto)
        {
            _contexto = contexto;
        }

        // Consultar Pedidos.
        public async Task<Pedidos> ConsultarPedidoPorId(int idPedido)
        {
            try
            {
                return await _contexto.Pedidos.FindAsync(idPedido);
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Error al consultar el pedido por identificador.", ex);
            }
        }

        public IEnumerable<Pedidos> ObtenerListaPedidos()
        {
            try
            {
                return _contexto.Pedidos.AsEnumerable();
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Error al consultar todos los pedidos.", ex);
            }
        }

        public async Task<Pedidos> ConsultarPedidoPorFiltro(Expression<Func<Pedidos, bool>> filtroPedido)
        {
            try
            {
                return await _contexto.Pedidos.FirstOrDefaultAsync(filtroPedido);
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Error al consultar el pedido por filtro.", ex);
            }
        }

        public async Task<IEnumerable<Pedidos>> ConsultarPedidosPorFiltro(Expression<Func<Pedidos, bool>> filtroPedidos)
        {
            try
            {
                return await _contexto.Pedidos.Where(filtroPedidos).ToListAsync();
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Error al consultar todos los pedido por filtro.", ex);
            }
        }

        // Adicionar Pedidos.
        public void Adicionar(Pedidos infoPedido)
        {
            try
            {
                _contexto.Pedidos.Add(infoPedido);
                _contexto.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Error al momento de adicionar el pedido.", ex);
            }
        }

        // Actualizar Pedidos.
        public void Actualizar(Pedidos objActualizar)
        {
            try
            {
                _contexto.Pedidos.Update(objActualizar);
                _contexto.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Error al momento de actualizar el pedido.", ex);
            }
        }

        // Eliminar Pedido.
        public async Task Eliminar(int idPedido)
        {
            try
            {
                Pedidos entidad = await ConsultarPedidoPorId(idPedido);
                _contexto.Pedidos.Remove(entidad);
                _contexto.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Error al momento de eliminar el pedido.", ex);
            }
        }
    }
}