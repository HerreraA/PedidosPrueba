using PedidosPrueba.Core.Entidades;
using PedidosPrueba.Core.Interfaces;
using PedidosPrueba.Core.Interfaces.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PedidosPrueba.Core.Servicios
{
    public class PedidosServicio : IPedidosServicio
    {
        // Instancio el repositorio
        private readonly IPedidosRepositorio _iPedidosRepositorio;

        // Constructor
        public PedidosServicio(IPedidosRepositorio iPedidosRepositorio)
        {
            _iPedidosRepositorio = iPedidosRepositorio;
        }

        // Obtener un registro de pedido por id.
        public async Task<Pedidos> ObtenerPedido(int idPedido)
        {
            return await _iPedidosRepositorio.ConsultarPedidoPorId(idPedido);
        }

        // Obtener todos los pedidos.
        public List<Pedidos> ObtenerListadoPedidos()
        {
            List<Pedidos> valorRepo = _iPedidosRepositorio.ObtenerListaPedidos().ToList();
            return valorRepo;
        }

        // Agregar nuevo un pedido.
        public async Task<Respuesta> AgregarPedido(Pedidos infoPedido)
        {
            try
            {
                Pedidos pedidoPorNumeroPedido = await _iPedidosRepositorio.ConsultarPedidoPorFiltro(x => x.NumeroPedido == infoPedido.NumeroPedido);

                if (pedidoPorNumeroPedido != null)
                {
                    return new Respuesta() { Estado = false, Mensaje = "NO PUEDEN EXISTIR DOS PEDIDOS CON EL MISMO NÚMERO" };
                }
                else
                {
                    _iPedidosRepositorio.Adicionar(infoPedido);
                    return new Respuesta() { Estado = true, Mensaje = "GUARDADO CORRECTAMENTE", Resultado = infoPedido };
                }

            }
            catch (Exception)
            {
                return new Respuesta() { Estado = false, Mensaje = "SE PRESENTO UN ERROR AL AGREGAR EL PEDIDO" };
            }
        }

        // Actualizar un pedido.
        public async Task<Respuesta> EditarPedido(int idPedido, Pedidos infoPedido)
        {
            try
            {
                Pedidos pedido = await _iPedidosRepositorio.ConsultarPedidoPorId(idPedido);

                if (pedido is null)
                {
                    return new Respuesta() { Estado = false, Mensaje = "EL PEDIDO A MODIFICAR NO EXISTE" };
                }
                else
                {
                    // Estado => -P: Pedidos pendientes -D: Pedidos despachados -E: Pedidos en proceso
                    if (pedido.Estado != "P")
                    {
                        return new Respuesta() { Estado = false, Mensaje = "EL PEDIDO DEBE ESTAR EN ESTADO PENDIENTE" };
                    }
                    else
                    {
                        if (pedido.NumeroPedido != infoPedido.NumeroPedido)
                        {
                            Pedidos pedidoPorNumeroPedido = await _iPedidosRepositorio.ConsultarPedidoPorFiltro(x => x.NumeroPedido == infoPedido.NumeroPedido);

                            if (pedidoPorNumeroPedido != null)
                            {
                                return new Respuesta() { Estado = false, Mensaje = "NO PUEDEN EXISTIR DOS PEDIDOS CON EL MISMO NÚMERO" };
                            }
                        }

                        pedido.FechaPedido = infoPedido.FechaPedido;
                        pedido.NumeroPedido = infoPedido.NumeroPedido;
                        pedido.ValorPedido = infoPedido.ValorPedido;
                        pedido.Estado = infoPedido.Estado;
                        pedido.Observaciones = infoPedido.Observaciones;
                        pedido.IdUsuarioCreacion = infoPedido.IdUsuarioCreacion;

                        _iPedidosRepositorio.Actualizar(pedido);
                        return new Respuesta() { Estado = true, Mensaje = "GUARDADO CORRECTAMENTE", Resultado = infoPedido };
                    }
                }
            }
            catch (Exception ex)
            {
                return new Respuesta() { Estado = false, Mensaje = "SE PRESENTO UN ERROR AL EDITAR EL PEDIDO", Resultado = infoPedido };
            }
        }

        // Eliminar un pedido.
        public async Task<Respuesta> EliminarPedido(int idPedido)
        {
            try
            {
                await _iPedidosRepositorio.Eliminar(idPedido);
                return new Respuesta() { Estado = true, Mensaje = "ELIMINADO CORRECTAMENTE" };
            }
            catch (Exception ex)
            {
                return new Respuesta() { Estado = false, Mensaje = "SE PRESENTO UN ERROR AL ELIMINAR EL PEDIDO" };
            }
        }
    }
}