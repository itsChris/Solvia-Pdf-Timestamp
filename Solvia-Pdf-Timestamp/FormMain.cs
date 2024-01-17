using System.Diagnostics;

namespace Solvia_Pdf_Timestamp
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
            AllowDrop = true;
            DragEnter += new DragEventHandler(Form_DragEnter);
            DragDrop += new DragEventHandler(Form_DragDrop);
        }

        private void Form_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy; // This shows the copy cursor
            else
                e.Effect = DragDropEffects.None; // This shows the no-drop cursor
        }

        private void Form_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            foreach (string file in files)
            {
                PdfService pdfService = new PdfService();
                string dateTimeStamp = DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss");
                string pdf = pdfService.AddTimestamp(file, file + $"-{dateTimeStamp}-timestamped.pdf");
                OpenPdf(pdf);
            }
        }

        private static void OpenPdf(string filePath)
        {
            try
            {
                Process.Start(new ProcessStartInfo(filePath) { UseShellExecute = true });
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while opening the file: " + ex.Message);
            }
        }
    }
}