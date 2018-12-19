'use strict';
var express = require('express');
var router = express.Router();
var empServ = require('../controllers/employeesCtrl');

router.get('/', function (req, res) {
    res.render('employees');
});

router.get('/json', function (req, res) {
    empServ.getEmployees(res);
});

module.exports = router;