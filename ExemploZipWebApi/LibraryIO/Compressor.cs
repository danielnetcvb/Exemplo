using System.IO;
using System.IO.Compression;

namespace LibraryIO
{
    public class Compressor
    {

        public static MemoryStream CriaZip(Stream stream, string nomeEntry)
        {
            MemoryStream ms = new MemoryStream();

            using (ZipArchive zip = new ZipArchive(ms, ZipArchiveMode.Create, true))
            {
                var entry = zip.CreateEntry(nomeEntry, CompressionLevel.Optimal);
                using (var s = entry.Open())
                {
                    stream.Position = 0;
                    stream.CopyTo(s);
                }
            }

            ms.Position = 0;

            return ms;
        }

    }
}
