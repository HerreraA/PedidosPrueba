    let nombreUsuario1 = document.querySelector('.nombreUsuario')
    
    // usar nombre se usuario del localstorage
    let local = window.localStorage.getItem('usuarioLogeado');
    let obj = JSON.parse(local)
    nombreUsuario1.innerHTML = 'Hola ' + obj.usuarioLogin