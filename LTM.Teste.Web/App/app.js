var app = angular.module('app', ['ngRoute', 'ngTable', 'angular-growl','ngCookies']);

app.config(['growlProvider', function (growlProvider) {
    growlProvider.globalTimeToLive(2000);
    growlProvider.globalDisableCountDown(true);
}]);


app.controller("mainController", function ($http,$scope, $location) {

     //$scope.Autenticado = false; // default visibility state
     //var vm = $scope;
     //vm.Autenticado = false;

    $scope.Autenticado = sessionStorage.usuarioLogado != null;

    $scope.exibirMenu = function (show) {
        $scope.Autenticado = show;
    };

    $scope.deslogar = function () {
        sessionStorage.usuarioLogado = null;
        $scope.Autenticado = null;
        $location.path('/login');
    }


    // other application-level things ...
});


//app.run(['$rootScope', '$location', '$localStorage', '$http',
//    function ($rootScope, $location, $cookieStore, $http) {
//        // keep user logged in after page refresh
//        $rootScope.globals = $cookieStore.get('globals') || {};
//        if ($rootScope.globals.currentUser) {
//            $http.defaults.headers.common['Authorization'] = 'Basic ' + $rootScope.globals.currentUser.authdata; // jshint ignore:line
//        }

//        $rootScope.$on('$locationChangeStart', function (event, next, current) {
//            // redirect to login page if not logged in
//            if ($location.path() !== '/login' && !$rootScope.globals.currentUser) {
//                $location.path('/login');
//            }
//        });
//    }]);