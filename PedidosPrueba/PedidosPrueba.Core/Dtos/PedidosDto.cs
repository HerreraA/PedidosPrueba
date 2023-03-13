using System;

namespace PedidosPrueba.Core.Dtos
{
    public class PedidosDto
    {
        public int? IdPedido { get; set; }
        public DateTime? FechaPedido { get; set; }
        public int? NumeroPedido { get; set; }
        public int? ValorPedido { get; set; }
        public string Estado { get; set; }
        public string Observaciones { get; set; }
        public int? IdUsuarioCreacion { get; set; }

        public PedidosDto()
        {
            IdPedido = null;
            FechaPedido = null;
            NumeroPedido = null;
            ValorPedido = null;
            Estado = null;
            Observaciones = null;
            IdUsuarioCreacion = null;
        }
    }
}