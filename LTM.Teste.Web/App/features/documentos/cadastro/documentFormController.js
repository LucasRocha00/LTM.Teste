app.controller('documentFormCtrl', function ($scope, $location, growl , documentoService) {
    var vm = $scope;
    vm.salvar = salvar;
    vm.voltar = voltar;

    init();

    function init() {
        if (sessionStorage.usuarioLogado == null)
            $location.path('/login')
        vm.documento = { nome: "", usuario: sessionStorage.usuarioLogado, arquivo: "" };
    }

    function voltar () {
        $location.path('/document')
    };

    function salvar() {
        if (vm.documento.arquivo == ""||vm.documento.arquivo == null) {
            growl.warning("Arquivo é obrigatório!");
            return;
        }

        if (vm.documento.usuario == ""||vm.documento.usuario == null) {
            growl.warning("Usuario é obrigatório!");
            return;
        }

        if (vm.documento.nome == ""||vm.documento.nome == null) {
            growl.warning("Nome do arquivo é obrigatório!");
            return;
        }


        vm.documento.arquivo = vm.documento.arquivo.Data;
        documentoService.salvar(vm.documento, salvarSucesso, salvarErro);
    };

    function salvarSucesso() {
        growl.success("Documento Salvo com Sucesso!");
        voltar();
    };

    function salvarErro() {
        growl.error("Ocorreu um erro ao salvar o documento!");
    };

    $scope.submit = function () {
        $scope.submitted = true;
        salvar();
    } 

    
});