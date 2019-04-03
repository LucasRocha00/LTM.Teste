app.controller('documentFormCtrl', function ($scope, $location, documentoService) {
    var vm = $scope;
    vm.salvar = salvar;
    vm.fileCallback = fileCallback;

    init();

    function init() {
        //vm.arquivo = {data: ""};
        vm.documento = { nome: "", usuario: "Lucas", arquivo: "" };
        
        
    }

    function fileCallback(file) {
        vm.documento.arquivo = file.Data;
    }

    vm.voltar = function () {
        $location.path('/document')
        //window.location = "#/";
    };

    function salvar() {
        vm.documento.arquivo = vm.documento.arquivo.Data;
        documentoService.salvar(vm.documento);
    };
    
});