window.onload = () => {

    let inputs = document.querySelectorAll('.form-control')
    let errors = document.querySelectorAll('.error')
    let boton = document.getElementById('boton')
    let bloqueoUsuario = document.querySelector('.alerta')
    let bloqueoUsuarioInfo = document.querySelector('.alertaInfo')
    let camposCorrectos = false


    // METODO PARA VALIDACION DE FORMULARIO
    boton.addEventListener('click', (e) => {

        for (let i = 0; i < inputs.length; i++) {
            if (inputs[i].value == "" || inputs[i].value.length == 0) {
                errors[i].innerHTML = "*Campo obligatorio"
                camposCorrectos = false
                e.preventDefault();
            } else {
                errors[i].innerHTML = " "
                camposCorrectos = true
            }
        }

        //CONSUMO DE API PARA VALIDAR INFORMACION DE LOGIN    
        if (camposCorrectos) {
            fetch("https://localhost:44303/api/Usuarios/Loguear", {
                method: "POST",
                body: JSON.stringify({
                    usuarioLogin: inputs[0].value,
                    password: inputs[1].value
                }),
                headers: {
                    'Content-Type': 'application/json'
                }
            })
                .then(data => data.json())
                .then(registro => {

                    console.log(registro);
                    let alerta = registro.mensaje.split(';')
                    console.log(alerta);

                    if (registro.estado == false) {
                        if (alerta.length == 2) {
                            bloqueoUsuario.innerHTML = alerta[0]
                            bloqueoUsuarioInfo.style.display = "block"
                            bloqueoUsuarioInfo.innerHTML = alerta[1]

                        } else {
                            bloqueoUsuario.innerHTML = registro.mensaje
                            bloqueoUsuarioInfo.style.display = "none"
                        }

                    } else {

                        window.localStorage.setItem('usuarioLogeado', JSON.stringify(registro.resultado))
                        window.location.href = "http://localhost:3001/order/list"

                    }
                })
        }
    })

}
