using DinkToPdf.Contracts;
using DinkToPdf;

namespace GWI.Services.DinkToPdf
{
    public class DinkToPdf
    {
        private readonly IConverter _pdfConverter;

        public DinkToPdf(IConverter pdfConverter)
        {
            _pdfConverter = pdfConverter;
        }

        public byte[] GeneratePdf(string htmlContent)
        {
            var document = new HtmlToPdfDocument()
            {
                Objects = {
                new ObjectSettings() {
                    HtmlContent = htmlContent
                }
            }
            };

            return _pdfConverter.Convert(document);
        }
    }
}