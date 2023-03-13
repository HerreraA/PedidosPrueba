using PedidosPrueba.Core.Entidades;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PedidosPrueba.Core.Interfaces.Repositorios
{
    public interface IUsuariosRepositorio
    {
        Task<Usuarios> ConsultarUsuarioPorId(int idUsuario);

        IEnumerable<Usuarios> ObtenerListaUsuarios();

        Task<Usuarios> ConsultarUsuarioPorFiltro(Expression<Func<Usuarios, bool>> filtroUsuario);

        Task<IEnumerable<Usuarios>> ConsultarUsuariosPorFiltro(Expression<Func<Usuarios, bool>> filtroUsuarios);

        // Adicionar usuarios.
        void Adicionar(Usuarios infoUsuario);

        // Actualizar usuarios.
        void Actualizar(Usuarios objActualizar);

        // Eliminar usuario.
        Task Eliminar(int idUsuario);
    }
}