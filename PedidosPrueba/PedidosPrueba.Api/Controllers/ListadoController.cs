using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PedidosPrueba.Core.Interfaces.Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PedidosPrueba.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ListadoController : ControllerBase
    {
        //instancia del servicio
        private readonly IListadoServicio _iListadoServicio;

        //constructor

        public ListadoController (IListadoServicio iListadoServicio)
        {
            _iListadoServicio = iListadoServicio;
        }

        [HttpGet]
        [Route("ObtenerListaUsuario")]

        public string ObtenerListaUsuario()
        {
            return _iListadoServicio.ObtenerListaUsuario();
        }

    }
}
