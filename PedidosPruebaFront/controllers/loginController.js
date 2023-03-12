const {validationResult} = require('express-validator');

const loginController = {

    index: (req, res) =>{
        res.render ('login.ejs')
    },

    loginProcess: (req, res) =>{

    }
}

module.exports= loginController;