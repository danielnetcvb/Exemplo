using System.Web.Http;
using LibraryIO;
using System.Web;
using System.IO;

namespace WebApi.Controller
{
    public class UploadController : ApiController
    {


        public ResultadoUpload RecebeArquivo()
        {
            string diretorioDestino = HttpContext.Current.Server.MapPath("~/Arquivos/");
            var arquivo = HttpContext.Current.Request.Files["meuArquivo"];

            try
            {
                Saver saver = new Saver();
                saver.SalvaArquivo(arquivo.InputStream, Path.Combine(diretorioDestino, arquivo.FileName));
                saver.SalvaArquivoComCompressao(arquivo.InputStream, Path.Combine(diretorioDestino, string.Concat(arquivo.FileName, ".zip")));

                return ResultadoUpload.CriaSucesso();
            }
            catch(System.Exception ex)
            {
                return ResultadoUpload.CriaErro(ex);
            }

        }

    }
}