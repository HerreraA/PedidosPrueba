using PedidosPrueba.Core.Entidades;
using PedidosPrueba.Core.Interfaces.Repositorios;
using PedidosPrueba.Core.Interfaces.Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PedidosPrueba.Core.Servicios
{
    public class UsuariosServicio : IUsuariosServicio
    {
        // Instancia del repositorio.
        private readonly IUsuariosRepositorio _iUsuariosRepositorio;

        // Constructor.
        public UsuariosServicio(IUsuariosRepositorio iUsuariosRepositorio)
        {
            _iUsuariosRepositorio = iUsuariosRepositorio;
        }

        // Método para las validaciones del logeo.
        public async Task<Respuesta> Loguear(Usuarios infoUsuario)
        {
            Usuarios usuarioDB = await _iUsuariosRepositorio.ConsultarUsuarioPorFiltro(x => x.UsuarioLogin == infoUsuario.UsuarioLogin);

            if (usuarioDB is null)
            {
                return new Respuesta() { Mensaje = "EL ID DE USUARIO INGRESADO NO EXISTE", Estado = false };
            }
            else if (!(bool)usuarioDB.Estado)
            {
                return new Respuesta() { Mensaje = "SU USUARIO HA SIDO BLOQUEADO; Por favor comuniquese con soporte técnico", Estado = false };
            }
            else
            {
                // Validar la contraseña.
                bool contrasenaValida = infoUsuario.Password.Equals(usuarioDB.Password);

                if (!contrasenaValida)
                {
                    // Agregar reintento fallido.
                    string mensaje = AgregarReintento(usuarioDB);
                    return new Respuesta() { Mensaje = mensaje, Estado = false };
                }
                else
                {
                    RestablecerReintentos(usuarioDB);
                    // Permite al usuario realizar el login.
                    return new Respuesta() { Resultado = usuarioDB, Estado = contrasenaValida, Mensaje = "USUARIO VALIDO" };
                }
            }
        }

        // Método para consultar todos los usuarios.
        public List<Usuarios> ObtenerListaUsuarios()
        {
            return _iUsuariosRepositorio.ObtenerListaUsuarios().ToList();
        }

        // Método para agregar reintento fallido.
        private string AgregarReintento(Usuarios usuarioDB)
        {
            usuarioDB.ReintentosPassword = (byte)(usuarioDB.ReintentosPassword + 1);
            _iUsuariosRepositorio.Actualizar(usuarioDB);

            if (usuarioDB.ReintentosPassword >= 3)
            {
                bool bloqueUsuario = BloquearUsuario(usuarioDB);
                return bloqueUsuario
                    ? "SU USUARIO HA SIDO BLOQUEADO; Por favor comuniquese con soporte técnico"
                    : "SE PRESENTO UN ERROR; Por favor comuniquese con soporte técnico";
            }
            else
            {
                return $"CONTRASEÑA NO VALIDA; {usuarioDB.ReintentosPassword} reintento de 3";
            }
        }

        // Método para restablecer reintentos cuando el usuario se loguea correctamente.
        private void RestablecerReintentos(Usuarios usuarioDB)
        {
            usuarioDB.ReintentosPassword = 0;
            _iUsuariosRepositorio.Actualizar(usuarioDB);
        }

        // Método para bloquear usuario.
        private bool BloquearUsuario(Usuarios usuarioDB)
        {
            try
            {
                usuarioDB.Estado = false;
                _iUsuariosRepositorio.Actualizar(usuarioDB);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}