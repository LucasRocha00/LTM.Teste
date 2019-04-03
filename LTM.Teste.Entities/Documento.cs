using System;
//using System.ComponentModel.d

namespace LTM.Teste.Entities
{
    public class Documento
    {
        //[Key]
        public int Id { get; private set; }
        public string Nome { get; private set; }
        public string Usuario { get; private set; }
        public DateTime DataUpload { get; private set; }
        public DateTime DataUltimoAcesso { get; private set; }
        public decimal TamanhoArquivo { get; private set; }
        public string Arquivo { get; private set; }

        public static Documento Create(string Nome, string Usuario, string Arquivo)
        {
            if (string.IsNullOrEmpty(Nome))
                throw new Exception("Nome deve ser preenchido!");

            if (string.IsNullOrEmpty(Nome))
                throw new Exception("Usuario deve ser preenchido!");

            if (string.IsNullOrEmpty(Nome))
                throw new Exception("Arquivo é obrigatório!");

            Documento documento = new Documento();
            documento.Nome = Nome;
            documento.Usuario = Usuario;
            documento.Arquivo = Arquivo;
            documento.DataUpload = DateTime.Now;
            documento.DataUltimoAcesso = DateTime.Now;
            documento.TamanhoArquivo = Convert.FromBase64String(Arquivo).Length;

            return documento;
        }
    }
}
