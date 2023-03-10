const express = require('express');
const router = express.Router();
const orderController = require('../controllers/orderController');

// Ruta para listar pedidos

router.get('/list', orderController.list);

module.exports = router;