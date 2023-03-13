using Microsoft.EntityFrameworkCore;
using PedidosPrueba.Core.Entidades;
using PedidosPrueba.Core.Interfaces.Repositorios;
using PedidosPrueba.Infraestructure.Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PedidosPrueba.Infraestructure.Repositorios
{
    public class UsuariosRepositorio : IUsuariosRepositorio
    {
        //Intancia del contexto.
        private readonly PedidosPruebaContext _contexto;

        //Constructor.
        public UsuariosRepositorio(PedidosPruebaContext contexto)
        {
            _contexto = contexto;
        }

        // Consultar usuarios.
        public async Task<Usuarios> ConsultarUsuarioPorId(int idUsuario)
        {
            try
            {
                return await _contexto.Usuarios.FindAsync(idUsuario);
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Error al consultar el usuario por identificador.", ex);
            }
        }

        public IEnumerable<Usuarios> ObtenerListaUsuarios()
        {
            try
            {
                return _contexto.Usuarios.AsEnumerable();
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Error al consultar todos los usuario.", ex);
            }
        }

        public async Task<Usuarios> ConsultarUsuarioPorFiltro(Expression<Func<Usuarios, bool>> filtroUsuario)
        {
            try
            {
                return await _contexto.Usuarios.FirstOrDefaultAsync(filtroUsuario);
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Error al consultar el usuario por filtro.", ex);
            }
        }

        public async Task<IEnumerable<Usuarios>> ConsultarUsuariosPorFiltro(Expression<Func<Usuarios, bool>> filtroUsuarios)
        {
            try
            {
                return await _contexto.Usuarios.Where(filtroUsuarios).ToListAsync();
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Error al consultar todos los usuario por filtro.", ex);
            }
        }

        // Adicionar usuarios.
        public void Adicionar(Usuarios infoUsuario)
        {
            try
            {
                _contexto.Usuarios.Add(infoUsuario);
                _contexto.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Error al momento de adicionar el usuario.", ex);
            }
        }

        // Actualizar usuarios.
        public void Actualizar(Usuarios objActualizar)
        {
            try
            {
                _contexto.Usuarios.Update(objActualizar);
                _contexto.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Error al momento de actualizar el usuario.", ex);
            }
        }

        // Eliminar usuario.
        public async Task Eliminar(int idUsuario)
        {
            try
            {
                Usuarios entidad = await ConsultarUsuarioPorId(idUsuario);
                _contexto.Usuarios.Remove(entidad);
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Error al momento de eliminar el usuario.", ex);
            }
        }
    }
}