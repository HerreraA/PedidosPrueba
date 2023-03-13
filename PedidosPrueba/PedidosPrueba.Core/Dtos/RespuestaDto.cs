namespace PedidosPrueba.Core.Dtos
{
    public class RespuestaDto
    {
        public string Mensaje { get; set; }

        public bool? Estado { get; set; }

        public object Resultado { get; set; }

        public RespuestaDto()
        {
            Mensaje = null;
            Estado = null;
            Resultado = null;
        }
    }
}