const express = require('express');
const router = express.Router();
const loginController = require('../controllers/loginController');

// Ruta para renderizar el Login

router.get('', loginController.index);


module.exports = router;
