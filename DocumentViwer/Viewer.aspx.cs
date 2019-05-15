using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

using EO.Pdf;
using EO.Pdf.Acm;
using EO.Pdf.Contents;
using EO.Pdf.Drawing;

namespace DocumentViwer
{
    public partial class Viewer : System.Web.UI.Page
    {
        // call this program like http://localhost/web_projects/DocumentViwer/Viewer.aspx?id=4755477&skip=1&type=image/jpeg
        MemoryStream ms;
        String eoLicense = "5Grc0Qng5na0wMAe6KDl5QUg8Z61kZvnrqXg5/YZ8p61kZt14+30EO2s3MKe" +
  "tZ9Zl6TNF+ic3PIEEMidtbjF37BvrrbE2691pvD6DuSn6unaD71GgaSxy591" +
  "4+30EO2s3OnP566l4Of2GfKe3MKetZ9Zl6TNDOul5vvPuIlZl6Sxy59Zl8Dy" +
  "D+NZ6/0BELxbvNO/++OfmaQHEPGs4PP/6KFtpbSzy653hI6xy59Zs7PyF+uo" +
  "7sKetZ9Zl6TNGvGd3PbaGeWol+jyH+R2mbrA3LJoqbTC3aFZ7ekDHuio5cGz" +
  "36FZpsKetZ9Zl6TNHuig5eUFIPGetczZ3OOmyNTG9+166NbF89U=";
        protected void Page_Load(object sender, EventArgs e)
        {
            EO.Pdf.Runtime.AddLicense(eoLicense);
            ShowReport();
        }

        protected System.Drawing.Image CreateSizedImage(Stream stream)
        {
            //This method takes an uploaded image file and resizes it to be as close to an 8.5 x 11 PDF as possible.
            //try
            //{
                System.Drawing.Image sdImage = System.Drawing.Image.FromStream(stream);
                double pdfAspect = 8.5 / 11;
                double aspectRatio = Convert.ToDouble(sdImage.Size.Width) / Convert.ToDouble(sdImage.Size.Height);
                int newWidth;
                int newHeight;

                //PDF w x h = 816 x 1056 (based on 8.5" x 11" at 96 dpi).
                if (aspectRatio <= pdfAspect)
                {
                    //If image aspect ratio is less than pdf aspect, image is taller than pdf. 
                    //   Resize based on pdf height
                    newHeight = 1050;
                    newWidth = Convert.ToInt32(1050 * aspectRatio);
                }
                else
                {
                    //If image aspect ratio is greater than pdf aspect, image is wider than pdf. 
                    //   Resize based on pdf width
                    newWidth = 810;
                    newHeight = Convert.ToInt32(810 / aspectRatio);
                }

                //I got the following logic from an online forum:
                System.Drawing.Image newImage = new Bitmap(newWidth, newHeight);

                System.Drawing.Graphics graphic = System.Drawing.Graphics.FromImage(newImage);
                graphic.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphic.SmoothingMode = SmoothingMode.HighQuality;
                graphic.PixelOffsetMode = PixelOffsetMode.HighQuality;
                graphic.CompositingQuality = CompositingQuality.HighQuality;
                graphic.DrawImage(sdImage, 0, 0, newWidth, newHeight);

                System.Drawing.Imaging.ImageCodecInfo[] info = ImageCodecInfo.GetImageEncoders();
                EncoderParameters encoderParameters;
                encoderParameters = new EncoderParameters(1);
                encoderParameters.Param[0] = new EncoderParameter(Encoder.Quality, 100L);

                ms = new MemoryStream();
                newImage.Save(ms, info[1], encoderParameters);
                ms.Close();
                return newImage;
            //}
            //catch
            //{
            //    throw;
            //}
        }

        private byte[] GetDoc(byte[] bValue)
        {
            //string record_id = imageRLogID().ToString();
            // = Data.Get_PDF_rec(record_id);
            //if (imageType().Contains("image"))
            //{
                PdfDocument pdfDoc;
                PdfPage pdfPage;
                PdfImage pdfImage;
                System.Drawing.Image sdImage;
                byte[] buf;
                pdfPage = null;
                sdImage = null;
                pdfImage = null;
                pdfDoc = new PdfDocument();
                pdfPage = pdfDoc.Pages.Add();
                MemoryStream memStream = new MemoryStream(bValue);
                sdImage = CreateSizedImage(memStream);

                pdfImage = new PdfImage(sdImage);
                PdfImageContent content = new PdfImageContent(pdfImage);
                content.GfxMatrix.Translate(0, 0);
                content.AutoScale();
                pdfPage.Contents.Add(content);

                MemoryStream ms = new MemoryStream();

                pdfPage.Document.Save(ms);
                buf = ms.ToArray();
                return buf;
            //}
            //return bValue;

        }

        private void ShowReport()
        {

            this.EnableViewState = false;
            string strID = string.Empty;
            if (!string.IsNullOrEmpty(Request.Params["session"]))
            {
                strID = SQLStatic.Sessions.GetSessionValue(Request.Cookies["Session_ID"].Value.ToString(), "docid");
            }
            else
            {
                strID = Request.Params["id"];
                if (Request.Params["skip"] == null)
                    strID = Data.ResolveID(Request.Params["id"]);
            }
            DataTable tbl = null;
            if (Request.Params["Fax"] == null)
                tbl = Data.GetActualDocument(strID);
            else
                tbl = Data.GetActualFacDocument(strID);

            string strLength = tbl.Rows[0]["length"].ToString();
            
             byte[] buf = (byte[])tbl.Rows[0]["report_file"];
             if  ((!string.IsNullOrEmpty( Request.Params["type"])) && (Request.Params["type"].Contains("image")))
                 buf = GetDoc(buf);
             Int32 intLength = buf.Length;
            //--------- Save to file  and send the file
            //string pdfFileName = Data.GenerateID("0") + ".pdf";
            //string strFileName = Request.PhysicalApplicationPath + "\\TempFiles\\" + pdfFileName.ToUpper().Replace("VIEWER.ASPX", "");
            //string strURL = Request.Path.ToUpper().Replace("VIEWER.ASPX", "") + "/TempFiles/" + pdfFileName;
            //System.IO.FileStream sr = File.Create(strFileName);
            //sr.Write((byte[])tbl.Rows[0]["report_file"], 0, intLength);
            //sr.Flush();
            //sr.Close();
            //Response.Redirect(strURL);

            //---------- send strem "application/pdf"
            Response.Clear();
            Response.ContentType = "application/pdf";
            string pdfFileName = Data.GenerateID("0") + ".pdf";
            Response.AddHeader("Content-Disposition", "inline; filename=" + pdfFileName);
            //Response.AddHeader("Content-Disposition", "inline; filename=" + pdfFileName + "#toolbar=0");
            // Response.AddHeader("Content-Disposition", "inline; filename=" + docName); PENDING TESTIN
            Response.OutputStream.Write(buf, 0, intLength);
            Response.Flush();
            Response.End();
        }
    }
}