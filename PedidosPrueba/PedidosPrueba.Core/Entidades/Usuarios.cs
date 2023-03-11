using System;
using System.Collections.Generic;

namespace PedidosPrueba.Core.Entidades
{
    public partial class Usuarios
    {
        public Usuarios()
        {
            Pedidos = new HashSet<Pedidos>();
        }

        public int IdUsuario { get; set; }
        public string UsuarioLogin { get; set; }
        public string Password { get; set; }
        public DateTime FechaCreacion { get; set; }

        public virtual ICollection<Pedidos> Pedidos { get; set; }
    }
}
