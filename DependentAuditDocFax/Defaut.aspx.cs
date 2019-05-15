using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using EO.Pdf;
using EO.Pdf.Acm;
using EO.Pdf.Contents;
using EO.Pdf.Drawing; 



namespace DependentAuditDocFax
{
    public partial class Defaut : System.Web.UI.Page
    {
        String eoLicense = "5Grc0Qng5na0wMAe6KDl5QUg8Z61kZvnrqXg5/YZ8p61kZt14+30EO2s3MKe" +
            "tZ9Zl6TNF+ic3PIEEMidtbjF37BvrrbE2691pvD6DuSn6unaD71GgaSxy591" +
            "4+30EO2s3OnP566l4Of2GfKe3MKetZ9Zl6TNDOul5vvPuIlZl6Sxy59Zl8Dy" +
            "D+NZ6/0BELxbvNO/++OfmaQHEPGs4PP/6KFtpbSzy653hI6xy59Zs7PyF+uo" +
            "7sKetZ9Zl6TNGvGd3PbaGeWol+jyH+R2mbrA3LJoqbTC3aFZ7ekDHuio5cGz" +
            "36FZpsKetZ9Zl6TNHuig5eUFIPGetczZ3OOmyNTG9+166NbF89U=";
        protected void Page_Load(object sender, EventArgs e)
        {
            EO.Pdf.Runtime.AddLicense(eoLicense);
            GetPDFs();
        }

        public static PdfDocument CreatePdfFromBytes(byte[] bytPdf)
        {
            PdfDocument pdf;
            using (MemoryStream ms = new MemoryStream(bytPdf))
            {
                pdf = new PdfDocument(ms);
            }
            return pdf;
        }

        public static byte[] MergePDFs(PdfDocument[] pdfArray)
        {
            //*** Must Clear the bookmarks from each PDF in the array
            foreach (PdfDocument pdfDoc in pdfArray)
            {
                if (pdfDoc.Bookmarks.Count > 0)
                    pdfDoc.Bookmarks.Clear();
            }

            //Create a single byte array representing merged PDF documents using EO.PDF functions
            //  Each PDF in the array can have more than one page - we don't care about the number of pages.
            PdfDocument pdfMerged = PdfDocument.Merge(pdfArray);
            byte[] pdfByte;
            using (MemoryStream ms = new MemoryStream())
            {
                pdfMerged.Save(ms);
                ms.Flush();
                pdfByte = ms.ToArray();
            }
            return pdfByte;
        }

        private  void GetPDFs()
        {
            DataTable dsRecords = Data.getblob(null);
            PdfDocument[] mergedPdfArray = new PdfDocument[dsRecords.Rows.Count];
            for (int i=0; i< dsRecords.Rows.Count; i++)
            {
                mergedPdfArray[i] = CreatePdfFromBytes((byte[])dsRecords.Rows[i]["DATA_INFO"]);
            }
            byte[] bytMergedPDFs = MergePDFs(mergedPdfArray);

            SQLStatic.Sessions.SetBLOBSessionValue(Request.Cookies["Session_ID"].Value.ToString(), "All", bytMergedPDFs);

            //byte[] PDFBlob = SQLStatic.Sessions.GetBLOBSessionValue(Request.Cookies["Session_ID"].Value.ToString(),"1063694  542952");

            //PdfDocument pdf = CreatePdfFromBytes(PDFBlob);

            //PdfDocument[] pdfarray;
            //= pdfarray[0]
        }


    }
}