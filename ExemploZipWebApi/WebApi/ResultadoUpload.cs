using System;

namespace WebApi
{
    public class ResultadoUpload
    {
        public bool Sucesso { get; set; }
        public string MensagemErro { get; set; }


        public static ResultadoUpload CriaSucesso()
        {
            return new ResultadoUpload() { Sucesso = true };
        }

        public static ResultadoUpload CriaErro(Exception ex)
        {
            return new ResultadoUpload() { Sucesso = false, MensagemErro = ex.Message };
        }
    }
}