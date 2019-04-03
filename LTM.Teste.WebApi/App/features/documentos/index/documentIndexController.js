app.controller('documentIndexCtrl', function ($scope, $location, $filter, NgTableParams, documentoService) {
    var vm = $scope;

    var self = this;
    var data = [{ Usuario: "Moroni", DataUpload: 50 } /*,*/];
    vm.tableParams = new NgTableParams({}, { dataset: data });

    vm.downloadFile = downloadFile;

    function downloadFile(idFile) {
        documentoService.downloadFile(downloadDocumentoSucesso, downloadDocumentoErro);
    }

    function downloadDocumentoSucesso() {
        alert('sucesso!');
    };

    function downloadDocumentoErro() {
        alert('erro!');
    };

    var ListarDocumentosSucesso = function (data) {
        $scope.documentos = data;
    }


    var ListarDocumentosErro = function () { alert('Ocorreu um erro!'); }

    documentoService.listar(ListarDocumentosSucesso, ListarDocumentosErro);

    //$scope.documentos = documentoService.Listar();

    //$scope.documentos = [{ Usuario: 'christian', dataUpload: 21, autor: 'lucas', tamanho: "2.5mb" }, { Usuario: 'anthony', dataUpload: 88, autor: 'lucas',  tamanho: "2.5mb"}];

    $scope.abrirNovo = function () {
        $location.path('document/novo')
    };
});