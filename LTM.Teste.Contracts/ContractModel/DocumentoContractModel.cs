using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LTM.Teste.Contracts.ContractModel
{
    public class DocumentoContractModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Usuario { get; set; }
        public DateTime DataUpload { get; set; }
        public DateTime DataUltimoAcesso { get; set; }
        public decimal TamanhoArquivo { get; set; }
        public string Arquivo { get; set; }
        public FileModel Arquivoz { get; set; }
        public byte[] ArquivoBase64 { get; set; }
    }
}
