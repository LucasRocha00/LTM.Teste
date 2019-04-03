app.controller('loginController', function($scope, $location, loginService) {

    loginService.ClearCredentials();

    $scope.login = function () {
        $scope.dataLoading = true;
        loginService.Login($scope.username, $scope.password, function (response) {
            if (response.success) {
                loginService.SetCredentials($scope.username, $scope.password);
                $location.path('/dashboard');
                $scope.exibirMenu(true);
            } else {
                $scope.error = response.message;
                $scope.dataLoading = false;
            }
        });
    };
})