window.onload = () => {
    let agregarPedido = document.querySelector(".agregarPedido")

    fetch("https://young-sands-07814.herokuapp.com/api/products?limit=10&offset=0")
    .then(data => data.json())
    .then(listaProductos => {
        // productosObtenidos = listaProductos;
        listaProductos.forEach(element => {
            agregarPedido.innerHTML += `<tr>
            <td>${element.title}</td>
            <td>${element.price}</td>
            <td>${element.description}</td>
            <td>@${element.category.name}</td>
            <td>${element.category.name}</td>
            <td class="d-flex justify-content-evenly">
                <button type="button" class="btn btn-primary" data-bs-toggle="modal" data-bs-target="#FormularioEditar">
                  <i class="fa-solid fa-pencil"></i>
                </button>
                <button type="button" class="btn btn-danger">
                  <i class="fa-solid fa-trash"></i>
              </button>
            </td>
          </tr>`
        });  
    })


    let inputsCrear = document.querySelectorAll(".inputsCrear");
    let botonPrueba = document.querySelector(".botonPrueba");
    let inputP = document.getElementById("Valor").value;

    botonPrueba.addEventListener('click', (e)=>{
        console.log(inputP);
    })

     // traes usuarios
    fetch("https://young-sands-07814.herokuapp.com/api/users")
    .then(data => data.json())
    .then(listaUsuarios => {
        console.log(listaUsuarios);
    })

    // fetch("https://young-sands-07814.herokuapp.com/api/products", {
    //    method: "POST",
    //    body:  JSON.stringify(
    //     {
    //         title: "ProductoNuevo",
    //         price: 322,
    //         description: "prueba andy",
    //         categoryId: 4,
    //         images: ["https://placeimg.com/640/480/any?r=0.08562212953556525"]
    //     },
    //    ),
    //    headers: {
    //     'Content-Type' : 'application/json'
    //    }
    // })
    // .then(data => data.json())
    // .then(listaUsuarios => {
    //     console.log(listaUsuarios);
    // })
}