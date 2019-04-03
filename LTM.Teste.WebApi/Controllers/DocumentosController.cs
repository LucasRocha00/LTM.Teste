using LTM.Teste.Business;
using LTM.Teste.Contracts.Business;
using LTM.Teste.Contracts.ContractModel;
using LTM.Teste.Contracts.Repository;
using LTM.Teste.Repository.Features;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Http;
using Unity;

namespace LTM.Teste.WebApi.Controllers
{
    public class DocumentosController : ApiController
    {
        private UnityContainer objContainer = new UnityContainer();
        private IDocumentoBusiness documentoBusiness;
        public DocumentosController(IDocumentoBusiness documentoBusiness)
        {
            this.documentoBusiness = documentoBusiness;
        }

        // POST: api/Documentos
        [HttpPost]
        public void Post([FromBody] DocumentoContractModel documento)
        {
            documentoBusiness.Salvar(documento);
        }

        //GET: api/Documentos
        [HttpGet]
        public List<DocumentoContractModel> Get()
        {
            return documentoBusiness.Listar();
        }

        //[HttpGet]
        //[Route("api/Teste")]
        //public HttpResponseMessage Teste()
        //{

        //}

        //GET: api/DocumentoArquivo/id
        [Route("api/DocumentoArquivo/{id:int}")]
        public async Task<IHttpActionResult> GetDocumentoArquivo(int id)
        {
            //var result = new HttpResponseMessage(HttpStatusCode.OK);

            //var arquivo = documentoBusiness.Obter(id).Arquivo;
            //var dataBytes = Convert.FromBase64String(arquivo);


            //var res = new HttpResponseMessage();
            //res.Content = new ByteArrayContent(dataBytes);
            //return res;


            byte[] bytes = new byte[2];
            var result = new HttpResponseMessage(HttpStatusCode.OK) { Content = new ByteArrayContent(bytes) };
            result.Content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
            result.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment") { FileName = "test.csv" };


            return this.ResponseMessage(result);
        }
    }
}
