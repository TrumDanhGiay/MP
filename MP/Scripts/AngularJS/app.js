var app = angular.module('app', []);

app.factory('APIcall', ['$http', function ($http) {
    var url = '/Token';
    var dataFactory = {};

    dataFactory.check = function (acc) {
        return $http.post(url, acc, {
            headers: { 'Content-Type': 'application/x-www-form-urlencoded' }
        }).then(function (response) {
            console.log(response);
            window.location.href = "/View/Admin";
            }).catch(function (error) {
                console.log(error);
            })
    };
    return dataFactory;
}]);

app.controller('appController', ['$scope', 'APIcall', function ($scope, APIcall, dataFactory) {

    $scope.login = function () {
        var acc = "grant_type=password&username=trang.duong39@yahoo.com.vn&password=25021996Aa";
        APIcall.check(acc);
    };
}]);


