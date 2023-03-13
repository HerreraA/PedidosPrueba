using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PedidosPrueba.Core.Dtos;
using PedidosPrueba.Core.Entidades;
using PedidosPrueba.Core.Interfaces;
using PedidosPrueba.Core.Interfaces.Servicios;
using PedidosPrueba.Core.Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PedidosPrueba.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidosController : ControllerBase
    {

        // Instancia de IMapper 
        private readonly IMapper _iMapper;

        // Instancia del servicio 
        private readonly IPedidosServicio _iPedidosServicio;

        // Constructor
        public PedidosController(IMapper iMapper, IPedidosServicio iPedidosServicio)
        {
            _iMapper = iMapper;
            _iPedidosServicio = iPedidosServicio;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PedidosDto>> ObtenerRegistro(int id)
        {
            Pedidos respuesta = await _iPedidosServicio.ObtenerPedido(id);
            return Ok(_iMapper.Map<PedidosDto>(respuesta));
        }

        [HttpGet]
        [Route("ObtenerLista")]
        public ActionResult<List<PedidosDto>> ObtenerLista()
        {
            List<Pedidos> pedidos = _iPedidosServicio.ObtenerListadoPedidos();
            return Ok(_iMapper.Map<List<PedidosDto>>(pedidos));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<RespuestaDto>> Editar(int id, PedidosDto objPedido)
        {
            Pedidos infoPedido = _iMapper.Map<Pedidos>(objPedido);
            Respuesta respuesta = await _iPedidosServicio.EditarPedido(id, infoPedido);
            return Ok(_iMapper.Map<RespuestaDto>(respuesta));
        }

        [HttpPost]
        [Route("Agregar")]
        public async Task<ActionResult<RespuestaDto>> Agregar(PedidosDto objPedido)
        {
            Pedidos infoPedido = _iMapper.Map<Pedidos>(objPedido);
            Respuesta respuesta = await _iPedidosServicio.AgregarPedido(infoPedido);
            return Ok(_iMapper.Map<RespuestaDto>(respuesta));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<RespuestaDto>> Eliminar(int id)
        {
            Respuesta respuesta = await _iPedidosServicio.EliminarPedido(id);
            return Ok(_iMapper.Map<RespuestaDto>(respuesta));
        }
    }
}
