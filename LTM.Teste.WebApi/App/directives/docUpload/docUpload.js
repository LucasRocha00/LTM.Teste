app.directive('ltmDocupload', function () {

    return {
        restrict: 'E',
        templateUrl: 'directives/docUpload/docUpload.html',
        scope: {
            model: '=ngModel',
            accept: '@',
            required: '@ngRequired',
            name: '@',
            callBack: "=callBack",
            callBackError: "="
        },
        controller: function ($scope, $element, $window) {
            var obj = new Object();
            $scope.required = $scope.required === "true" || $scope.required === true;
            $scope.model;

            $element.find("input[type=file]").unbind().bind("change", function (changeEvent) {

                if (changeEvent.currentTarget.files.length == 0) {
                    $scope.$apply(function () {
                        $scope.model = obj;
                        changeEvent.currentTarget.value = null;
                    });
                }

                else {

                    obj.Name = changeEvent.currentTarget.files[0].name;
                    obj.Size = changeEvent.currentTarget.files[0].size;
                    obj.Type = changeEvent.currentTarget.files[0].type;
                    obj.Path = changeEvent.currentTarget.files[0].path;

                    var reader = new FileReader();

                    reader.onload = function (loadEvent) {
                        $scope.$apply(function () {
                            obj.Data = loadEvent.target.result.split(',')[1];
                            $scope.model = obj;
                            $scope.model.Src = "data:" + $scope.model.path + ";base64," + $scope.model.Data;
                            changeEvent.currentTarget.value = null;
                            if ($scope.callBack)
                                $scope.callBack($scope.model);
                        });
                    }
                    reader.readAsDataURL(changeEvent.target.files[0]);
                };
            });

            $scope.openFile = function () {

                var image = new Image();
                image.src = "data:" + $scope.model.path + ";base64," + $scope.model.DataFull;
                $window.open(image.src, "_blank");
            };
        }
    };
});