const express = require('express');
const router = express.Router();
const loginController = require('../controllers/loginController');
const validationRegister = require('../Middlewares/validateRegisterMiddleware');

// Ruta para renderizar el Login

router.get('', loginController.index);

router.post('', loginController.loginProcess)

module.exports = router;
