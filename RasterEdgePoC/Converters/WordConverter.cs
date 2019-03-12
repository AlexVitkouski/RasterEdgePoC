using System.Drawing;
using System.IO;
using RasterEdge.Imaging.Basic;
using RasterEdge.XDoc.Word;

namespace RasterEdgePoC.Converters
{
    class WordConverter : IConverter
    {
        public Image Convert(string filePath)
        {
            var doc = GetDocument(filePath);
            BasePage page = doc.GetPage(0);
            Size size = new Size(612, 792);
            Bitmap bmp = page.ConvertToImage(size);
            //page.Dispose();
            return bmp;
        }

        private BaseDocument GetDocument(string filePath)
        {
            var ext = Path.GetExtension(filePath)??"";
            switch (ext.ToLower())
            {
                case ".docx":
                    return new DOCXDocument(filePath);
                case ".doc":
                case ".dot":
                    return new DOCDocument(filePath);
                case ".rtf":
                    return new RTFDocument(filePath);
                case ".odt":
                    return new ODTDocument(filePath);
                default:
                    return new DOCXDocument(filePath);
            }
        }
    }
}
