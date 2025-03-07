using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PdfSharp.Drawing;
using PdfSharp.Drawing.Layout;
using PdfSharp.Pdf;

namespace RecipeBook.RecipeCreatorModules
{
    public class PdfCreator
    {
        private PdfDocument _currentDoc;
        private PdfPage _currentPage;
        private XGraphics _gfx;
        private XTextFormatter _formatter;
        private XRect _rect;
        private string _totalText = "";

        public PdfCreator()
        {
            // Create a new PDF file
            _currentDoc = new PdfDocument();
            _currentPage = _currentDoc.AddPage();
            _gfx = XGraphics.FromPdfPage(_currentPage);
            _formatter = new XTextFormatter(_gfx);
            _rect = new XRect(10, 10, _currentPage.Width, _currentPage.Height - 15);
        }

        public void AddLine(string line)
        {
            // Add a line to the PDF file

            _totalText += line + "\n";
        }

        public void SavePdf(string defaultName)
        {
            FinalizePage();
            string filename = "";
            using(SaveFileDialog dialog = new SaveFileDialog())
            {
                dialog.Filter = "PDF files (*.pdf)|*.pdf";
                dialog.DefaultExt = "pdf";
                dialog.FileName = defaultName; 
                dialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                dialog.Title = "Save PDF file";

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    filename = dialog.FileName;
                    _currentDoc.Save(filename);
                }
            }

            // Save the PDF file
            var p = new Process();
            p.StartInfo = new ProcessStartInfo(filename)
            {
                UseShellExecute = true
            };
            p.Start();
        }

        private void FinalizePage()
        {
            // Finalize the current page
            _formatter.DrawString(_totalText, new XFont("Arial", 10, XFontStyleEx.Regular), XBrushes.Black, _rect);
        }
    }

    public enum FontType
    {
        NORMAL,
        ITALIC,
        BOLD,
    }

    public enum TextPosition
    {
        LEFT,
        CENTER,
        RIGHT,
    }
}