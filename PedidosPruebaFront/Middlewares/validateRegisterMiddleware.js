const { body } = require('express-validator');
const path = require('path');

module.exports = [

    body('usuario')
        .notEmpty().withMessage('*Campo obligatorio'),
    body('contraseña')
        .notEmpty().withMessage('*Campo obligatorio')

]