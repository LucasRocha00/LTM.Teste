app.controller('dashboardCtrl', function ($scope, $location) {
    if (sessionStorage.usuarioLogado == null)
        $location.path('/login')
});