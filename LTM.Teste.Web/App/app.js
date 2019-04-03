var app = angular.module('app', ['ngRoute', 'ngTable', 'angular-growl','ngCookies']);

app.config(['growlProvider', function (growlProvider) {
    growlProvider.globalTimeToLive(2000);
    growlProvider.globalDisableCountDown(true);
}]);


app.controller("mainController", function ($http,$scope, $location) {

    $scope.Autenticado = sessionStorage.usuarioLogado != null;

    $scope.exibirMenu = function (show) {
        $scope.Autenticado = show;
    };

    $scope.deslogar = function () {
        sessionStorage.usuarioLogado = null;
        $scope.Autenticado = null;
        $location.path('/login');
    }
});