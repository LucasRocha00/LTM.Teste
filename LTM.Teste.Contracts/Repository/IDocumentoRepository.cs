using LTM.Teste.Contracts.ContractModel;
using LTM.Teste.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LTM.Teste.Contracts.Repository
{
    public interface IDocumentoRepository
    {
        void Salvar(Documento documento);
        List<Documento> Listar();
        void Excluir(int idDocumento);
        Documento Obter(int id);
    }
}
