using LTM.Teste.Contracts.ContractModel;
using LTM.Teste.Contracts.Repository;
using LTM.Teste.Entities;
using LTM.Teste.Repository.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LTM.Teste.Repository.Features
{
    public class DocumentoRepository : IDocumentoRepository
    {
        private readonly DocumentManagerContext documentManagerContext;
        public DocumentoRepository(DocumentManagerContext documentManagerContext)
        {
            this.documentManagerContext = documentManagerContext;
        }

        public void Excluir(int idDocumento)
        {
            Documento documento = documentManagerContext.Documento.FirstOrDefault(x => x.Id == idDocumento);

            if (documento != null)
            {
                documentManagerContext.Documento.Remove(documento);
                documentManagerContext.SaveChanges();              
            }
            else
            {
                throw new Exception("Documento não encontrado!");
            }
        }

        public List<Documento> Listar()
        {
            return documentManagerContext.Documento.OrderBy(x => x.DataUpload).ToList();
        }

        public Documento Obter(int id)
        {
            return documentManagerContext.Documento.FirstOrDefault(x => x.Id == id);
        }

        public void Salvar(Documento documento)
        {
            documentManagerContext.Documento.Add(documento);
            documentManagerContext.SaveChanges();
        }
    }
}
