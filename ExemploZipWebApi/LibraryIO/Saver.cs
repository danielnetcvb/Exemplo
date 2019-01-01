using System.IO;

namespace LibraryIO
{
    public class Saver
    {


        public void SalvaArquivo(Stream stream, string caminho)
        {
            using (FileStream fs = new FileStream(caminho, FileMode.Create))
            {
                stream.CopyTo(fs);
                fs.Flush();
            }
        }

        public void SalvaArquivoComCompressao(Stream stream, string caminho)
        {
            using (var zip = Compressor.CriaZip(stream, Path.GetFileNameWithoutExtension(new FileInfo(caminho).Name)))
            {
                SalvaArquivo(zip, caminho);
            }
        }


    }
}
