using PedidosPrueba.Core.Entidades;
using System;
using System.Collections.Generic;

namespace PedidosPrueba.Core.Entidades
{
    public partial class Pedidos
    {
        public int IdPedido { get; set; }
        public DateTime FechaPedido { get; set; }
        public int NumeroPedido { get; set; }
        public int ValorPedido { get; set; }
        public string Estado { get; set; }
        public string Observaciones { get; set; }
        public int? IdUsuarioCreacion { get; set; }

        public virtual Usuarios IdUsuarioCreacionNavigation { get; set; }
    }
}
