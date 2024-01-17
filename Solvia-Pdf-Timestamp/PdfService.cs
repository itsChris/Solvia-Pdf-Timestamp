using PdfSharp.Drawing;
using PdfSharp.Fonts;
using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;

namespace Solvia_Pdf_Timestamp
{
    public class PdfService
    {
        public PdfService()
        {
            GlobalFontSettings.FontResolver = new FileSystemFontResolver();
        }

        public string AddTimestamp(string pdfPathIn, string pdfPathOut)
        {
            // Open an existing document for editing and loop through its pages
            PdfDocument document = PdfReader.Open(pdfPathIn);
            // Iterate through all pages (in case you want to add timestamp to all pages)
            foreach (PdfPage page in document.Pages)
            {
                // Create graphics for drawing
                XGraphics gfx = XGraphics.FromPdfPage(page);

                // Create a font
                XFont font = new XFont("Arial", 14);

                // Create the timestamp
                string timestamp = "Timestamp: " + DateTime.Now.ToString();

                // Define a brush
                XBrush brush = XBrushes.Red;

                // Draw the timestamp at the desired location
                gfx.DrawString(timestamp, font, brush, new XRect(0, 0, page.Width, page.Height),
                               XStringFormats.TopLeft);
            }

            // Save the document...
            document.Save(pdfPathOut);
            return pdfPathOut;
        }
    }
}
