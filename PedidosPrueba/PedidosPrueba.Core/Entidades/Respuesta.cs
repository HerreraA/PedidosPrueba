using System;
using System.Collections.Generic;
using System.Text;

namespace PedidosPrueba.Core.Entidades
{
    public class Respuesta
    {
        public object Resultado { get; set; }

        public string Mensaje { get; set; }

        public bool Estado { get; set; }
    }
}