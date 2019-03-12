using System.Drawing;

namespace RasterEdgePoC.Converters
{
    interface IConverter
    {
        Image Convert(string filePath);
    }
}
