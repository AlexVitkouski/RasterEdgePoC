using System.Drawing;
using System.IO;
using RasterEdge.Imaging.Basic;
using RasterEdge.XDoc.Excel;

namespace RasterEdgePoC.Converters
{
    class ExcelConverter : IConverter
    {
        public Image Convert(string filePath)
        {
            var book = GetBook(filePath);
            BasePage page = book.GetPage(0);
            Bitmap bmp = page.ConvertToImage();
            //page.Dispose();
            return bmp;
        }

        private BaseDocument GetBook(string filePath)
        {
            var ext = Path.GetExtension(filePath) ?? "";
            switch (ext.ToLower())
            {
                case ".xlsx":
                    return new XLSXDocument(filePath);
                case ".xls":
                case ".xlt":
                    return new XLSDocument(filePath);
                default:
                    return new XLSXDocument(filePath);
            }
        }

    }
}
