app.service('documentoService', function ($http) {

    this.salvar = function (data/*, sucessCallback, errorCallback*/) {
        $http.post('../api/Documentos/Post', data);
    };

    this.listar = function (sucessCallback, errorCallback) {
       return $http.get('../api/Documentos/Get')
            .then(function (response) {
                sucessCallback(response.data);
            });
    }

    this.downloadDocumento = function (idDocumento, sucessCallback, errorCallback) {
        return $http.get('../api/Documentos/GetDocumentoArquivo/' + idDocumento)
            .then(function (response) {
                sucessCallback(response.data);
            });
    };
})