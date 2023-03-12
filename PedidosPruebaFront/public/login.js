window.onload = () => {

    let inputs = document.querySelectorAll('.form-control')
    let errors = document.querySelectorAll('.error')
    let boton = document.getElementById('boton')
    let contador = 0;
    
boton.addEventListener('click', (e)=> {
    for(let i=0; i < inputs.length; i++){
        if (inputs[i].value == "" || inputs[i].value.length == 0){
            errors[i].innerHTML = "*Campo obligatorio"
            e.preventDefault();
        } else if (inputs[i].value != "" || inputs[i].value.length != 0){
            errors[i].innerHTML = " "
        }
    }
})   
}



