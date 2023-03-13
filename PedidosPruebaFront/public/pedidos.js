window.onload = () => {

  let objJsonUsuario = window.localStorage.getItem('usuarioLogeado')
  let usuarioLogeado = JSON.parse(objJsonUsuario)
  // Variables globales
  let idSeleccionadoEdit = 0;

  // querysSelectors
  let agregarPedido = document.querySelector(".agregarPedido")
  let inputsCrearFecha = document.querySelector(".inputsCrearFecha")
  inputsCrearFecha.valueAsDate = new Date()

  // Crear pedidos
  let botonCrear = document.querySelector(".botonCrear")
  let errorGeneral = document.querySelectorAll(".errorGeneral")
  // querysSelectors - Crear producto

  // let inputsCrearFecha = document.querySelector(".inputsCrearFecha")
  let inputsCrearValor = document.querySelector(".inputsCrearValor")
  let inputsCrearNumeroPedido = document.querySelector(".inputsCrearNumeroPedido")
  let inputsCrearEstado = document.querySelector(".inputsCrearEstado")
  let inputsCrearObservaciones = document.querySelector(".inputsCrearObservaciones")
  let inputsValidacion = document.querySelectorAll(".validacion")

  // querysSelectors - Editar producto
  let inputEditarFecha = document.querySelector(".inputsEditarFecha")
  let inputEditarValor = document.querySelector(".inputsEditarValor")
  let inputEditarNumeroPedido = document.querySelector(".inputsEditarNumeroPedido")
  let inputEditarEstado = document.querySelector(".inputsEditarEstado")
  let inputEditarObservaciones = document.querySelector(".inputsEditarObservaciones")
  let inputsValidacionEditar = document.querySelectorAll(".validacionEditar")
  let apagarInputs = document.querySelectorAll(".apagarInputs")
  let tituloEditar = document.querySelector(".tituloEditar")
  let validarCamposEditar = false;

  // http://localhost:44304/api/Pedidos/ObtenerLista

  fetch("https://localhost:44303/api/Pedidos/ObtenerLista")
    .then(data => data.json())
    .then(listaPedidos => {

      // Generar filas de pedidos
      crearListaPedidos(listaPedidos);

      // querysSelectors - Botones de editar y borrar.
      let botonesEditar = document.querySelector(".botonesEditar")
      let botonesEditarP = document.querySelectorAll(".botonesEditarP")
      let botonesBorrar = document.querySelectorAll(".botonBorrar")

      for (let i = 0; i < listaPedidos.length; i++) {
        // Evento para botonesEditarP de pedidos - boton abrir el editar
        botonesEditarP[i].addEventListener("click", () => {
          // Apagar y prender opciones  de los inputs de edicion.
          if(listaPedidos[i].estado != "P" ){
            tituloEditar.innerHTML = "Detalle del pedido"
            apagarInputs.forEach(input => input.disabled = true)
            botonesEditar.style.display = "none"
          }else{
            tituloEditar.innerHTML = "Editar pedido"
            apagarInputs.forEach(input => input.disabled = false)
            botonesEditar.style.display = "block"
          }
          // DEJAR GENERAL EL ID DEL PEDIDO OBTENDIO
          idSeleccionadoEdit = listaPedidos[i].idPedido
          // TRAER INFORMACION DEL DETALLE PARA EDITAR
          traerInformacionPedido(listaPedidos[i].idPedido)
        })

        // Evento para eliminar de pedidos
        botonesBorrar[i].addEventListener("click", () => {
          eliminarPedido(listaPedidos[i].idPedido);
        });
      }

      //Evento para editar un pedido - enviar objeto al endponit
      botonesEditar.addEventListener("click", (e) => {
        validarCamposEditar = validacionCampos(inputsValidacionEditar)
        if (validarCamposEditar) {
          console.log("Se puede crear - Editar");
          editarPedido(idSeleccionadoEdit, mapearObjetoPedidosEditar());
        } else {
          console.log("Hubo campos sin llenar - Editar");
          e.preventDefault();
        }
      })
    })

  validarCaposAlMomento(inputsValidacion);
  validarCaposAlMomento(inputsValidacionEditar);

  // Evento para crear pedido
  let validarCampos = false;
  botonCrear.addEventListener('click', (e) => {
    validarCampos = validacionCampos(inputsValidacion)
    console.log(validarCampos);
    if (validarCampos) {
      console.log('Se puede crear - Crear');
      crearPedido(mapearObjetoPedidosCrear());
    } else {
      console.log("Hubo campos sin llenar - Crear");
      e.preventDefault();
    }
  })

  // METODO PARA CREAR LA LISTA PEDIDOS
  function crearListaPedidos(listaPedidos) {

    listaPedidos.forEach(element => {
      // Generar etiquetas por cada uno de los pedidos encontrados
      let columna1 = document.createElement('td')
      columna1.textContent = element.fechaPedido

      let columna2 = document.createElement('td')
      columna2.textContent = element.numeroPedido

      let columna3 = document.createElement('td')
      columna3.textContent = element.valorPedido

      let columna4 = document.createElement('td')
      columna4.textContent = element.estado

      let columna5 = document.createElement('td')
      columna5.textContent = element.observaciones

      // Botonos para editar y borrar un pedido
      let botones = document.createElement('td')
      botones.className = "d-flex justify-content-evenly"
      botones.innerHTML += `
          <button style="margin: 5px" type="button" class="btn btn-primary" data-bs-toggle="modal" data-bs-target="#FormularioEditar">
            <i class="fa-solid fa-pencil botonesEditarP"></i>
          </button>
          <button style="margin: 5px" type="button" class="btn btn-danger botonBorrar">
            <i class="fa-solid fa-trash"></i>
          </button>`

      let fila = document.createElement('tr')
      fila.appendChild(columna1)
      fila.appendChild(columna2)
      fila.appendChild(columna3)
      fila.appendChild(columna4)
      fila.appendChild(columna5)
      fila.appendChild(botones)

      agregarPedido.appendChild(fila)
    })
  }

  // METODO PARA CREAR UN PEDIDO
  function crearPedido(obj) {
    console.log(obj);
    fetch("https://localhost:44303/api/Pedidos/Agregar", {
      method: "POST",
      body: JSON.stringify(obj),
      headers: {
        'Content-Type': 'application/json'
      }
    })
      .then(data => data.json())
      .then(result => {
        !result.estado ? errorGeneral[1].innerHTML = result.mensaje : window.location.reload()
      })
  }

  // METODO PARA EDIDAR UN PEDIDO 
  function editarPedido(idProducto, obj) {
    console.log(obj);
    console.log("entre al metodo para Editar");
    fetch(`https://localhost:44303/api/Pedidos/${idProducto}`, {
      method: "PUT",
      body: JSON.stringify(obj),
      headers: {
        'Content-Type': 'application/json'
      }
    })
      .then(data => data.json())
      .then(result => {
        console.log(result);
        !result.estado ? errorGeneral[0].innerHTML = result.mensaje : window.location.reload()
      })
  }

  // METODO PARA BORRAR UN PEDIDO
  function eliminarPedido(idProducto) {
    console.log("entre al metodo para Borrar");
    fetch(`https://localhost:44303/api/Pedidos/${idProducto}`, {
      method: "DELETE",
      headers: {
        'Content-Type': 'application/json'
      }
    })
      .then(data => data.json())
      .then(result => {
        console.log(result);
        window.location.reload()
      })
  }

  // METODO PARA TRAER LA INFORMACION DEL PEDIDO YA EXISTENTE POR ID
  function traerInformacionPedido(id) {
    fetch(`https://localhost:44303/api/Pedidos/${id}`)
      .then(data => data.json())
      .then(pedido => {
        agregarInformacionEditar(pedido)
      })
  }

  // GENERAR OBJETO PEDIDOS CREAR
  function mapearObjetoPedidosCrear() {
    console.log(usuarioLogeado.idUsuario);
    return {
      fechaPedido: inputsCrearFecha.value,
      numeroPedido: inputsCrearNumeroPedido.value,
      valorPedido: inputsCrearValor.value,
      estado: inputsCrearEstado.value,
      observaciones: inputsCrearObservaciones.value,
      idUsuarioCreacion: usuarioLogeado.idUsuario
    }
  }

  // GENERAR OBJETO PEDIDOS EDITAR
  function mapearObjetoPedidosEditar() {
   
 console.log(usuarioLogeado.idUsuario);
    return {
      //SE OBTIENE POR UNA VARIABLE GLOBAL
      idPedido: idSeleccionadoEdit,
      fechaPedido: inputEditarFecha.value,
      numeroPedido: inputEditarNumeroPedido.value,
      valorPedido: inputEditarValor.value,
      estado: inputEditarEstado.value,
      observaciones: inputEditarObservaciones.value,
      // CAMBIAR AL ID EN EL LOCAL STORAGE
      idUsuarioCreacion: usuarioLogeado.idUsuario
    }
  }

  // METODO PARA AGREGAR INFORMACIÓN A LOS INPUTS
  function agregarInformacionEditar(pedido) {

    inputEditarFecha.value = pedido.fechaPedido.split('T')[0];
    inputEditarValor.value = pedido.valorPedido;
    inputEditarNumeroPedido.value = pedido.numeroPedido;
    inputEditarObservaciones.value = pedido.observaciones;

    switch (pedido.estado) {
      case "P":
        inputEditarEstado.children[0].selected = true
        inputEditarEstado.children[0].value = "P"
        break;
      case "D":
        inputEditarEstado.children[1].selected = true
        inputEditarEstado.children[1].value = "D"
        break;
      case "E":
        inputEditarEstado.children[2].selected = true
        inputEditarEstado.children[2].value = "E"
        break;
    }
  }

  // METODO PARA VALIDACION DE LOS CAMPOS
  function validacionCampos(inputs) {
    camposCorrectos = true;
    for (let i = 0; i < inputs.length; i++) {
      console.log(inputs[i].value.length);

      if (inputs[i].value.length == 0) {
        console.log("FALLO");
        inputs[i].parentNode.querySelector(".errors").textContent = "*Campo obligatorio"
        camposCorrectos = false
      } else {
        console.log("LOGRO");
        inputs[i].parentNode.querySelector(".errors").textContent = ""
      }
    }
    return camposCorrectos
  }

  // Evento para validar campo al momento - CREAR
  function validarCaposAlMomento(inputs) {
    inputs.forEach(input => {
      input.addEventListener('keyup', (e) => {
        obtenerPadre = input.parentNode
        if (e.target.value.length > 0) {
          obtenerPadre.querySelector(".errors").textContent = " "
          validarCampos = true
        }
        else if (e.target.value.length == 0) {
          obtenerPadre.querySelector(".errors").textContent = "*Campo obligatorio"
          validarCampos = false
        }
      })
    })
  }
}