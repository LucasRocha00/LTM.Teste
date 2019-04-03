app.controller('documentIndexCtrl', function ($http,$scope, $location, $filter, growl, NgTableParams, documentoService) {
    var vm = $scope;

    init();

    function init() {
        if (sessionStorage.usuarioLogado == null)
            $location.path('/login')

        documentoService.listar(ListarDocumentosSucesso, ListarDocumentosErro);
        
        vm.exibirBotaoNovo = sessionStorage.usuarioAdmin;
    }
    
    vm.tableParams = new NgTableParams({}, { });

    vm.downloadFile = downloadFile;

    function downloadFile(idDocumentoArquivo) {
        documentoService.downloadDocumento(idDocumentoArquivo, downloadDocumentoSucesso, downloadDocumentoErro);
    }

    function downloadDocumentoSucesso() {
        alert('sucesso!');
    };

    function downloadDocumentoErro() {
        alert('erro!');
    };

    function ListarDocumentosSucesso(data) {
        $scope.documentos = data;
    }

    function ListarDocumentosErro() { growl.error("Ocorreu um erro ao listar os documentos!"); }

    $scope.abrirNovo = function () {
        $location.path('document/novo')
    };
});