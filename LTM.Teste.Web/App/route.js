app.config(function ($routeProvider) {

    $routeProvider
        .when('/dashboard', {
            templateUrl: 'features/dashboard/index.html',
            controller: 'dashboardCtrl',
        })

        .when('/document', {
            templateUrl: 'features/documentos/index/documentIndex.html',
            controller: 'documentIndexCtrl',
        })

        .when('/document/novo', {
            templateUrl: 'features/documentos/cadastro/documentForm.html',
            controller: 'documentFormCtrl',
        })

        .when('/', {
            controller: 'loginController',
            templateUrl: 'features/login/login.html'
        })

        .when('/login', {
            controller: 'loginController',
            templateUrl: 'features/login/login.html'
        })

        .otherwise({ redirectTo: '/login' });
});