var app = angular.module('empApp', ["ngRoute"]);

app.config(function ($routeProvider) {
    $routeProvider
        .when("/list", {
            templateUrl: "list.html",
            controller: "getEmployeesCtrl"
        })
        .otherwise(
        {
            templateUrl: "list.html",
            controller: "getEmployeesCtrl"
        })
});

app.controller('getEmployeesCtrl', function ($scope, $http) {

    $scope.loading = true;

    $scope.getEmployees = function () {

        $http.get('/employees/json').then(function (response) {

            $scope.employees = response.data;

            $scope.loading = false;

        }, function () {
            alert('Error');
        });
    };

    $scope.getEmployees();
});