app.config(function ($routeProvider) {

    $routeProvider
        .when('/', {
            templateUrl: 'app/features/Documents/Index/documentIndex.html',
            controller: 'documentIndexCtrl',
        })

        .when('/document', {
            templateUrl: 'app/features/Documents/Index/documentIndex.html',
            controller: 'documentIndexCtrl',
        })
        
        .otherwise({ redirectTo: '/' });
});