using LTM.Teste.Contracts.ContractModel;
using LTM.Teste.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LTM.Teste.Contracts.Business
{
    public interface IDocumentoBusiness
    {
        void Salvar(DocumentoContractModel documento);
        List<DocumentoContractModel> Listar();
        DocumentoContractModel Obter(int Id);

        void Excluir(int idDocumento);
    }
}
