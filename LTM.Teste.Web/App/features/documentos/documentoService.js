app.service('documentoService', function ($http) {

    this.salvar = function (data, sucessoCallback, erroCallback) {
        $http.post('../api/Documentos/Post', data).success(sucessoCallback).error(erroCallback);
    };

    this.listar = function (sucessoCallback, erroCallback) {
       return $http.get('../api/Documentos')
            .then(function (response) {
                sucessoCallback(response.data);
           },
           function () { erroCallback(); });
    }

    this.downloadDocumento = function (idDocumento, sucessCallback, errorCallback) {
        $http({
            url: '../api/DocumentoArquivo/' + idDocumento,
            method: "GET",
            responseType: 'arraybuffer'
        }).success(function (data, status, headers, config) {
            var blob = new Blob([data], { type: "application/pdf" });
            var objectUrl = URL.createObjectURL(blob);
            window.open(objectUrl);
        }).error(function (data, status, headers, config) {
            });
    };
})