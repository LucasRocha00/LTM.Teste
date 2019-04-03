using LTM.Teste.Contracts.Business;
using LTM.Teste.Contracts.ContractModel;
using LTM.Teste.Contracts.Repository;
using LTM.Teste.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;

namespace LTM.Teste.Business
{
    public class DocumentoBusiness : IDocumentoBusiness
    {
        public IDocumentoRepository documentoRepository;
        [InjectionConstructor]
        public DocumentoBusiness(IDocumentoRepository documentoRepository)
        {
            this.documentoRepository = documentoRepository;
        }

        public void Excluir(int idDocumento)
        {
            documentoRepository.Excluir(idDocumento);
        }

        public List<DocumentoContractModel> Listar()
        {
           var documentos = documentoRepository.Listar();

            var documentosCM = new List<DocumentoContractModel>();

            foreach (var documento in documentos)
            {
                documentosCM.Add(new DocumentoContractModel {
                    Id = documento.Id,
                    Nome = documento.Nome,
                    Usuario = documento.Usuario,
                    DataUltimoAcesso = documento.DataUltimoAcesso,
                    DataUpload = documento.DataUpload,
                    TamanhoArquivo = documento.TamanhoArquivo,
                    Arquivo = documento.Arquivo
                });
            }

            return documentosCM;
        }

        public DocumentoContractModel Obter(int Id)
        {
            var documento = documentoRepository.Obter(Id);

            documento = Documento.AlterarDataUltimoAcesso(documento);
            documentoRepository.Salvar(documento);

            return new DocumentoContractModel
            {
                Id = documento.Id,
                Nome = documento.Nome,
                Usuario = documento.Usuario,
                DataUltimoAcesso = documento.DataUltimoAcesso,
                DataUpload = documento.DataUpload,
                TamanhoArquivo = documento.TamanhoArquivo,
                Arquivo = documento.Arquivo
            };
        }

        public void Salvar(DocumentoContractModel documentoCM)
        {
            Documento documento = Documento.Criar(documentoCM.Nome, documentoCM.Usuario, documentoCM.Arquivo);
            documentoRepository.Salvar(documento);
        }
    }
}
