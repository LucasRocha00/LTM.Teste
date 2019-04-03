app.controller('documentIndexCtrl', function ($http,$scope, $location, $filter, growl, NgTableParams, documentoService) {
    var vm = $scope;

    init();

    function init() {
        if (sessionStorage.usuarioLogado == null)
            $location.path('/login')
        $scope.dataLoading = true;
        documentoService.listar(ListarDocumentosSucesso, ListarDocumentosErro);
        
        vm.exibirBotaoNovo = sessionStorage.usuarioAdmin;
    }
    
    vm.tableParams = new NgTableParams({}, { });

    vm.downloadFile = downloadFile;

    function downloadFile(idDocumentoArquivo) {
        documentoService.downloadDocumento(idDocumentoArquivo, downloadDocumentoSucesso, downloadDocumentoErro);
    }

    function downloadDocumentoSucesso() {
       
    };

    function downloadDocumentoErro() {
        growl.error("Ocorreu um erro ao fazer o download do documento selecionado!");
    };

    function ListarDocumentosSucesso(data) {
        $scope.documentos = data;
        $scope.dataLoading = false;
    }

    function ListarDocumentosErro() {
        growl.error("Ocorreu um erro ao listar os documentos!");
        $scope.dataLoading = false;
    }

    $scope.abrirNovo = function () {
        $location.path('document/novo')
    };
});