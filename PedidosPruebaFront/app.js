// require
const express = require('express');
const app = express();
const path = require('path');
const loginRouter = require('./routes/login');
const orderRouter = require('./routes/order');

// template engine
app.set("view engine", "ejs");
// app.set('views','./views')

app.use('/', loginRouter);

app.use('/order', orderRouter);


app.listen (3001, () => console.log('Alta de servidor: http://localhost:3001'));