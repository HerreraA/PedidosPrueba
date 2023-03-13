using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PedidosPrueba.Core.Dtos;
using PedidosPrueba.Core.Entidades;
using PedidosPrueba.Core.Interfaces.Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PedidosPrueba.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        // Instancia de IMapper 
        private readonly IMapper _iMapper;

        // Instancia del servicio.
        private readonly IUsuariosServicio _iUsuariosServicio;

        // Constructor.
        public UsuariosController(IMapper iMapper, IUsuariosServicio iListadoServicio)
        {
            _iMapper = iMapper;
            _iUsuariosServicio = iListadoServicio;
        }

        // Login.
        [HttpPost]
        [Route("Loguear")]

        public async Task<ActionResult<RespuestaDto>> Loguear(LoginDto loginUsuario)
        {
            Usuarios infoUsuario = _iMapper.Map<Usuarios>(loginUsuario);
            Respuesta respuesta = await _iUsuariosServicio.Loguear(infoUsuario);
            return Ok(_iMapper.Map<RespuestaDto>(respuesta));
        }

        // Obtener todos los usuarios.
        [HttpGet]
        [Route("ObtenerLista")]

        public ActionResult<List<UsuariosDto>> ObtenerLista()
        {
            return Ok(_iUsuariosServicio.ObtenerListaUsuarios());
        }
    }
}