﻿using log4net;
using LTM.Teste.Contracts.Business;
using LTM.Teste.Contracts.ContractModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using System.Threading.Tasks;
using System.Web.Http;
using Unity;

namespace LTM.Teste.Web.Controllers
{
    public class DocumentosController : ApiController
    {
        private UnityContainer objContainer = new UnityContainer();
        private IDocumentoBusiness documentoBusiness;
        private readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public DocumentosController(IDocumentoBusiness documentoBusiness)
        {
            this.documentoBusiness = documentoBusiness;
        }

        //GET: api/Documentos
        [HttpGet]
        public List<DocumentoContractModel> Get()
        {
            try
            {
                return documentoBusiness.Listar();
            }
            catch (Exception ex)
            {
                this.log.Error("Falha - documentoBusiness.Listar :", ex);
                return null;
            }
        }

        // POST: api/Documentos
        [HttpPost]
        public void Post([FromBody] DocumentoContractModel documento)
        {
            try
            {
                documentoBusiness.Salvar(documento);
            }
            catch (Exception ex)
            {
                this.log.Error("Falha - documentoBusiness.Salvar :", ex);
            }
        }

        [Route("api/DocumentoArquivo/{id:int}")]
        public async Task<IHttpActionResult> GetDocumentoArquivo(int id)
        {
            //var result = new HttpResponseMessage(HttpStatusCode.OK);

            try
            {
                var arquivo = documentoBusiness.Obter(id).Arquivo;
                var dataBytes = Convert.FromBase64String(arquivo);

                var result = new HttpResponseMessage(HttpStatusCode.OK) { Content = new ByteArrayContent(dataBytes) };
                result.Content.Headers.ContentType = new MediaTypeHeaderValue("application/pdf");
                result.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment") { FileName = "file.pdf" };

                return this.ResponseMessage(result);
            }
            catch (Exception ex)
            {
                this.log.Error("Falha - GetDocumentoArquivo :", ex);
                return null;
            }
        }
    }
}
