using LTM.Teste.Contracts.Business;
using LTM.Teste.Contracts.ContractModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Http;
using Unity;

namespace LTM.Teste.Web.Controllers
{
    public class DocumentosController : ApiController
    {
        private UnityContainer objContainer = new UnityContainer();
        private IDocumentoBusiness documentoBusiness;
        public DocumentosController(IDocumentoBusiness documentoBusiness)
        {
            this.documentoBusiness = documentoBusiness;
        }

        //GET: api/Documentos
        [HttpGet]
        public List<DocumentoContractModel> Get()
        {
            return documentoBusiness.Listar();
        }

        // POST: api/Documentos
        [HttpPost]
        public void Post([FromBody] DocumentoContractModel documento)
        {
            documentoBusiness.Salvar(documento);
        }

        [Route("api/DocumentoArquivo/{id:int}")]
        public async Task<IHttpActionResult> GetDocumentoArquivo(int id)
        {
            //var result = new HttpResponseMessage(HttpStatusCode.OK);

            var arquivo = documentoBusiness.Obter(id).Arquivo;
            var dataBytes = Convert.FromBase64String(arquivo);

            var result = new HttpResponseMessage(HttpStatusCode.OK) { Content = new ByteArrayContent(dataBytes) };
            result.Content.Headers.ContentType = new MediaTypeHeaderValue("application/pdf");
            result.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment") { FileName = "file.pdf" };

            return this.ResponseMessage(result);
        }
    }
}
