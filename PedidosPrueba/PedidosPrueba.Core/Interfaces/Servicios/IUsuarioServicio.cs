using PedidosPrueba.Core.Entidades;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PedidosPrueba.Core.Interfaces.Servicios
{
    public interface IUsuariosServicio
    {
        // Método para las validaciones del logeo.
        Task<Respuesta> Loguear(Usuarios infoUsuario);

        // Método para consultar todos los usuarios
        public List<Usuarios> ObtenerListaUsuarios();
    }
}