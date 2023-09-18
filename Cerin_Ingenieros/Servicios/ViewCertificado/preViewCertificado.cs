using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PdfiumViewer;

namespace Cerin_Ingenieros.Servicios.ViewCertificado
{
    public partial class preViewCertificado : Form
    {
        PdfViewer pdf;
        public preViewCertificado()
        {
            InitializeComponent();
            pdf = new PdfViewer();
            this.Controls.Add(pdf);
            MostrarDocumento("C:/Users/YOBER/Documents/Certificado.pdf");
        }

        public void MostrarDocumento(string rutaDocumento)
        {
            byte[] bytes = System.IO.File.ReadAllBytes(rutaDocumento);
            var stream = new System.IO.MemoryStream(bytes);
            PdfDocument pdfDocument = PdfDocument.Load(stream);
            pdf.Document = pdfDocument;
        }
    }
}
