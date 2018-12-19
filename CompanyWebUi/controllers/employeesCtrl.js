const http = require('http')

function getEmployees(res) {

    const options = {
        hostname: 'localhost',
        port: 55712,
        path: '/api/Employees',
        method: 'GET'
    }

    const req = http.request(options, (response) => {

        var dataSend;

        console.log('STATUS:' + response.statusCode);
        console.log('HEADERS: ' + JSON.stringify(response.headers));

        response.setEncoding('utf8');

        response.on('data', (chunk) => {

            dataSend = chunk;

            console.log('BODY:' + chunk);
        });

        response.on('end', () => {
            console.log('No more data in response.');

            res.send(dataSend);
        });
    });

    req.on('error', (error) => {
        res.send(error);
    })

    req.end()
}

exports.getEmployees = getEmployees;