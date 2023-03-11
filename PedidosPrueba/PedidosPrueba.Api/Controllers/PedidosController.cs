using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PedidosPrueba.Core.Entidades;
using PedidosPrueba.Core.Interfaces;
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
        // instancia del servicio 
        private readonly IPedidosServicio _iPedidosServicio;
        
        //constructor
        public PedidosController(IPedidosServicio iPedidosServicio)
        {
            _iPedidosServicio = iPedidosServicio;
        }

        [HttpGet]
        [Route("ObtenerListaPedisos")]
        public List<Pedidos> ObtenerListadoPedidos()
        {
           return _iPedidosServicio.ObtenerListadoPedidos();
           
        }
    }
}
