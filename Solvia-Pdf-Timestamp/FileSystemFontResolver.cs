using PdfSharp.Fonts;

namespace Solvia_Pdf_Timestamp
{
    public class FileSystemFontResolver : IFontResolver
    {
        public byte[] GetFont(string faceName)
        {
            string fontPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), faceName + ".ttf");
            return File.ReadAllBytes(fontPath);
        }

        public FontResolverInfo ResolveTypeface(string familyName, bool isBold, bool isItalic)
        {
            string fontName = familyName;
            if (isBold && isItalic)
            {
                fontName += " Bold Italic";
            }
            else if (isBold)
            {
                fontName += " Bold";
            }
            else if (isItalic)
            {
                fontName += " Italic";
            }

            return new FontResolverInfo(fontName);
        }
    }
}
