using System;
using System.Collections.Generic;

namespace PedidosPrueba.Core.Dtos
{
    public class UsuariosDto
    {
        public int? IdUsuario { get; set; }
        public string UsuarioLogin { get; set; }
        public string Password { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public int? ReintentosPassword { get; set; }
        public bool? Estado { get; set; }

        public UsuariosDto()
        {
            IdUsuario = null;
            UsuarioLogin = null;
            Password = null;
            FechaCreacion = null;
            ReintentosPassword = null;
            Estado = null;
        }
    }
}