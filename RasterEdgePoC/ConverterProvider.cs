using RasterEdgePoC.Converters;

namespace RasterEdgePoC
{
    class ConverterProvider
    {
        readonly WordConverter wordConverter =new WordConverter();
        readonly ExcelConverter excelConverter =new ExcelConverter();
        readonly PowerPointConverter powerPointConverter = new PowerPointConverter();
        
        public IConverter GetConverter(string filePath)
        {
            switch (AppChooser.Choose(filePath))
            {
                case SupportedApplications.Word:
                    return wordConverter;
                case SupportedApplications.Excel:
                    return excelConverter;
                case SupportedApplications.PowerPoint:
                    return powerPointConverter;
                default:
                    return null;
            }
        }
    }
}
