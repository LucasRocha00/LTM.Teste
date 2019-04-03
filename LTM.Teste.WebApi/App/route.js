app.config(function ($routeProvider) {

    $routeProvider
        .when('/', {
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

        .otherwise({ redirectTo: '/' });
});