using System.Drawing;
using System.IO;
using RasterEdge.Imaging.Basic;
using RasterEdge.XDoc.PowerPoint;

namespace RasterEdgePoC.Converters
{
    class PowerPointConverter : IConverter
    {
        public Image Convert(string filePath)
        {
            BaseDocument pp = GetPresentation(filePath);
            BasePage page = pp.GetPage(0);
            Bitmap bmp = page.ConvertToImage();
            //pp.Dispose();
            return bmp;
        }

        private BaseDocument GetPresentation(string filePath)
        {
            var ext = Path.GetExtension(filePath) ?? "";
            switch (ext.ToLower())
            {
                case ".pptx":
                    return new PPTXDocument(filePath);
                case ".ppt":
                case ".pot":
                case ".pps":
                    return new PPTDocument(filePath);
                case ".odp":
                    return new ODPDocument(filePath);
                default:
                    return new PPTXDocument(filePath);
            }
        }
    }
}
