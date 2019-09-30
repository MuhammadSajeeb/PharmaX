using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.draw;
using P.Persistancis.Repositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PharmaX.WebApp.Purchase
{
    public partial class List : System.Web.UI.Page
    {
        PurchaseRepository _PurchaseRepository = new PurchaseRepository();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                GetAllPurchase();
            }
        }
        public void GetAllPurchase()
        {
            PurchaseListGridView.DataSource = _PurchaseRepository.GetAllPurchase();
            PurchaseListGridView.DataBind();
        }

        protected void PurchaseListGridView_SelectedIndexChanged(object sender, EventArgs e)
        {
            string Id = (PurchaseListGridView.SelectedRow.Cells[2].Text);
            Response.Redirect("Details.aspx?id=" + Id);
        }
        string SupplierName,PurchaseId,PurchaseDate,isPayment;
        decimal Amount, Discount, GrandTotal;
        protected void PurchaseListGridView_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if(e.CommandName == "PurchaseId")
            {
                int index;
                index = Convert.ToInt32(e.CommandArgument.ToString());

                SupplierName = PurchaseListGridView.Rows[index].Cells[1].Text;
                PurchaseId = PurchaseListGridView.Rows[index].Cells[2].Text;
                Amount= Convert.ToDecimal(PurchaseListGridView.Rows[index].Cells[3].Text);
                Discount = Convert.ToDecimal(PurchaseListGridView.Rows[index].Cells[4].Text);
                GrandTotal = Convert.ToDecimal(PurchaseListGridView.Rows[index].Cells[5].Text);
                isPayment = PurchaseListGridView.Rows[index].Cells[6].Text;
                PurchaseDate = PurchaseListGridView.Rows[index].Cells[7].Text;
                CreatePdf();
            }

        }
        string s = "_";
        public void CreatePdf()
        {
            Response.Clear();
            Response.ContentType = "application/pdf";
            Response.AddHeader("content-disposition", "attachment;filename=PurchaseInvoice_" + 001 + "" + s + "" + DateTime.Now.ToString() + ".pdf");
            Response.Cache.SetCacheability(HttpCacheability.NoCache);

            Document document = new Document();
            document = new Document(PageSize.A4, 20f, 20f, 25f, 0f);//left,right,top,bottom
            MemoryStream ms = new MemoryStream();
            PdfWriter writer = PdfWriter.GetInstance(document, Response.OutputStream);

            document.Open();

            // Section-Image
            string imageURL = @"F:\Web Form Project\PharmaX\PharmaX\PharmaX.WebApp\Purchase\img\pharmax_logo.jpg";
            iTextSharp.text.Image jpg = iTextSharp.text.Image.GetInstance(imageURL);
            //Resize image depend upon your need
            jpg.ScaleToFit(140f, 120f);
            //Give space before image
            jpg.SpacingBefore = 10f;
            //Give some space after the image
            jpg.SpacingAfter = 1f;
            jpg.Alignment = Element.ALIGN_CENTER;

            document.Add(jpg);
            //end section image

            //topsite design create table and start
            float[] topcontentwd = new float[1] { 200 };
            PdfPCell cell;
            PdfPTable tbltopcontent = new PdfPTable(topcontentwd);
            tbltopcontent.WidthPercentage = 100;
            //start first-row-tbltopcontent
            cell = new PdfPCell(new Phrase("12/3 Mirbagh Moghbazer Hatirjheel", FontFactory.GetFont(FontFactory.TIMES_ROMAN,8, iTextSharp.text.Font.BOLD)));
            cell.HorizontalAlignment = 1;
            cell.VerticalAlignment = 1;
            cell.BorderWidth = 0f;
            //cell.FixedHeight = 20f;
            tbltopcontent.AddCell(cell);
            //start second-row-tbltopcontent
            cell = new PdfPCell(new Phrase("Dhaka 1217", FontFactory.GetFont(FontFactory.TIMES_ROMAN,7, iTextSharp.text.Font.BOLD)));
            cell.HorizontalAlignment = 1;
            cell.VerticalAlignment = 1;
            cell.BorderWidth = 0f;
            //cell.FixedHeight = 20f;
            tbltopcontent.AddCell(cell);
            //start third-row-tbltopcontent
            cell = new PdfPCell(new Phrase("Contact - 01916429918", FontFactory.GetFont(FontFactory.TIMES_ROMAN, 6, iTextSharp.text.Font.BOLD)));
            cell.HorizontalAlignment = 1;
            cell.VerticalAlignment = 1;
            cell.BorderWidth = 0f;
            //cell.FixedHeight = 20f;
            tbltopcontent.AddCell(cell);
            tbltopcontent.CompleteRow();
            document.Add(tbltopcontent);
            //end tbltopcontent

            float[] topcontentinform = new float[3] { 0.4f,0.2f,3f };
            PdfPTable tbltopcontentinform = new PdfPTable(topcontentinform);
            tbltopcontentinform.WidthPercentage = 100;
            //start first-row-tbltopcontentinform
            cell = new PdfPCell(new Phrase("Purchase Id", FontFactory.GetFont(FontFactory.TIMES_ROMAN, 9, iTextSharp.text.Font.NORMAL)));
            cell.HorizontalAlignment = 0;
            cell.VerticalAlignment = 0;
            cell.BorderWidth = 0f;
            //cell.FixedHeight = 20f;
            tbltopcontentinform.AddCell(cell);
            cell = new PdfPCell(new Phrase("-", FontFactory.GetFont(FontFactory.TIMES_ROMAN, 9, iTextSharp.text.Font.NORMAL)));
            cell.HorizontalAlignment = 0;
            cell.VerticalAlignment = 0;
            cell.BorderWidth = 0f;
            //cell.FixedHeight = 20f;
            tbltopcontentinform.AddCell(cell);
            cell = new PdfPCell(new Phrase(PurchaseId, FontFactory.GetFont(FontFactory.TIMES_ROMAN, 9, iTextSharp.text.Font.NORMAL)));
            cell.HorizontalAlignment = 0;
            cell.VerticalAlignment = 0;
            cell.BorderWidth = 0f;
            //cell.FixedHeight = 20f;
            tbltopcontentinform.AddCell(cell);
            //end-first row
            //start second-row-tbltopcontentinform
            cell = new PdfPCell(new Phrase("Supplier Name", FontFactory.GetFont(FontFactory.TIMES_ROMAN, 9, iTextSharp.text.Font.NORMAL)));
            cell.HorizontalAlignment = 0;
            cell.VerticalAlignment = 0;
            cell.BorderWidth = 0f;
            //cell.FixedHeight = 20f;
            tbltopcontentinform.AddCell(cell);
            cell = new PdfPCell(new Phrase("-", FontFactory.GetFont(FontFactory.TIMES_ROMAN, 9, iTextSharp.text.Font.NORMAL)));
            cell.HorizontalAlignment = 0;
            cell.VerticalAlignment = 0;
            cell.BorderWidth = 0f;
            //cell.FixedHeight = 20f;
            tbltopcontentinform.AddCell(cell);
            cell = new PdfPCell(new Phrase(SupplierName, FontFactory.GetFont(FontFactory.TIMES_ROMAN, 9, iTextSharp.text.Font.NORMAL)));
            cell.HorizontalAlignment = 0;
            cell.VerticalAlignment = 0;
            cell.BorderWidth = 0f;
            //cell.FixedHeight = 20f;
            tbltopcontentinform.AddCell(cell);
            //end-second row
            //start third-row-tbltopcontentinform
            cell = new PdfPCell(new Phrase("Purchase Date", FontFactory.GetFont(FontFactory.TIMES_ROMAN, 9, iTextSharp.text.Font.NORMAL)));
            cell.HorizontalAlignment = 0;
            cell.VerticalAlignment = 0;
            cell.BorderWidth = 0f;
            //cell.FixedHeight = 20f;
            tbltopcontentinform.AddCell(cell);
            cell = new PdfPCell(new Phrase("-", FontFactory.GetFont(FontFactory.TIMES_ROMAN, 9, iTextSharp.text.Font.NORMAL)));
            cell.HorizontalAlignment = 0;
            cell.VerticalAlignment = 0;
            cell.BorderWidth = 0f;
            //cell.FixedHeight = 20f;
            tbltopcontentinform.AddCell(cell);
            cell = new PdfPCell(new Phrase(PurchaseDate, FontFactory.GetFont(FontFactory.TIMES_ROMAN, 9, iTextSharp.text.Font.NORMAL)));
            cell.HorizontalAlignment = 0;
            cell.VerticalAlignment = 0;
            cell.BorderWidth = 0f;
            //cell.FixedHeight = 20f;
            tbltopcontentinform.AddCell(cell);
            //end-third row
            tbltopcontentinform.CompleteRow();
            //start end-Allrow-tbltopcontentinform
            document.Add(tbltopcontentinform);
            //end table-topcontent

            //empty  pdftable start
            float[] dtemptywd = new float[1] {200};
            PdfPTable dtempty = new PdfPTable(dtemptywd);
            dtempty.WidthPercentage = 100;

            dtempty.CompleteRow();
            document.Add(dtempty);
            //end empty table

            //LineSeparator line = new LineSeparator(0f, 100, null, Element.ALIGN_CENTER, -2);
            //document.Add(line);

            //midtabl-content start
            float[] midcontenttblwidthHeader = new float[6] { 15,10,10,10,10,10 };
            // Create the PDF Table specifying the number of columns
            PdfPTable tblmidcontentheader = new PdfPTable(midcontenttblwidthHeader);
            tblmidcontentheader.WidthPercentage = 100;

            //header create
            cell = new PdfPCell(new Phrase("Item", FontFactory.GetFont(FontFactory.TIMES_ROMAN, 9, iTextSharp.text.Font.BOLD)));
            cell.HorizontalAlignment = 1;
            cell.VerticalAlignment = 1;
            cell.BorderWidth = 1f;
            cell.Padding = 5;
            cell.BackgroundColor = BaseColor.LIGHT_GRAY;
            tblmidcontentheader.AddCell(cell);

            cell = new PdfPCell(new Phrase("Batch", FontFactory.GetFont(FontFactory.TIMES_ROMAN, 9, iTextSharp.text.Font.BOLD)));
            cell.HorizontalAlignment = 1;
            cell.VerticalAlignment = 1;
            cell.BorderWidth = 1f;
            cell.Padding = 5;
            cell.BackgroundColor = BaseColor.LIGHT_GRAY;
            tblmidcontentheader.AddCell(cell);

            cell = new PdfPCell(new Phrase("Qty", FontFactory.GetFont(FontFactory.TIMES_ROMAN, 9, iTextSharp.text.Font.BOLD)));
            cell.HorizontalAlignment = 1;
            cell.VerticalAlignment = 1;
            cell.BorderWidth = 1f;
            cell.Padding = 5;
            cell.BackgroundColor = BaseColor.LIGHT_GRAY;
            tblmidcontentheader.AddCell(cell);

            cell = new PdfPCell(new Phrase("Rate", FontFactory.GetFont(FontFactory.TIMES_ROMAN, 9, iTextSharp.text.Font.BOLD)));
            cell.HorizontalAlignment = 1;
            cell.VerticalAlignment = 1;
            cell.BorderWidth = 1f;
            cell.Padding = 5;
            cell.BackgroundColor = BaseColor.LIGHT_GRAY;
            tblmidcontentheader.AddCell(cell);

            cell = new PdfPCell(new Phrase("Total", FontFactory.GetFont(FontFactory.TIMES_ROMAN, 9, iTextSharp.text.Font.BOLD)));
            cell.HorizontalAlignment = 1;
            cell.VerticalAlignment = 1;
            cell.BorderWidth = 1f;
            cell.Padding = 5;
            cell.BackgroundColor = BaseColor.LIGHT_GRAY;
            tblmidcontentheader.AddCell(cell);

            cell = new PdfPCell(new Phrase("Expire", FontFactory.GetFont(FontFactory.TIMES_ROMAN, 9, iTextSharp.text.Font.BOLD)));
            cell.HorizontalAlignment = 1;
            cell.VerticalAlignment = 1;
            cell.BorderWidth = 1f;
            cell.Padding = 5;
            cell.BackgroundColor = BaseColor.LIGHT_GRAY;
            tblmidcontentheader.AddCell(cell);
            //end-header
            tblmidcontentheader.CompleteRow();

            document.Add(tblmidcontentheader);
            //end-header mid content 

            //line start
            //LineSeparator line2 = new LineSeparator(0f, 100, null, Element.ALIGN_CENTER, -2);
            //document.Add(line2);
            //end-line

            //Start-row-tablemidcontentrow
            float[] midcontenttblwidthRow = new float[6] { 15, 10, 10, 10, 10, 10 };
            // Create the PDF Table specifying the number of columns
            PdfPTable tblmidcontentRow = new PdfPTable(midcontenttblwidthRow);
            tblmidcontentRow.WidthPercentage = 100;


            //sql Query for retrive data... start
            SqlConnection con = new SqlConnection("Data Source = localhost; Initial Catalog = PharmaX; Integrated Security = TRUE");
            SqlCommand cm = new SqlCommand("Select Item,Batch,Qty,CostPrice,TotalPrice,Expire from PurchaseDetails where PurchaseId='" + PurchaseId + "'", con);
            con.Open();
            SqlDataReader dr;
            dr = cm.ExecuteReader();
            //end query
            foreach (var list in dr)
            {
                //start row
                cell = new PdfPCell(new Phrase(dr["Item"].ToString(), FontFactory.GetFont(FontFactory.TIMES_ROMAN, 8, iTextSharp.text.Font.NORMAL)));
                cell.HorizontalAlignment = 1;
                cell.VerticalAlignment = 1;
                cell.BorderWidth = 1f;
                cell.Padding = 5;
                tblmidcontentRow.AddCell(cell);

                cell = new PdfPCell(new Phrase(dr["Batch"].ToString(), FontFactory.GetFont(FontFactory.TIMES_ROMAN, 8, iTextSharp.text.Font.NORMAL)));
                cell.HorizontalAlignment = 1;
                cell.VerticalAlignment = 1;
                cell.BorderWidth = 1f;
                cell.Padding = 5;
                tblmidcontentRow.AddCell(cell);

                cell = new PdfPCell(new Phrase(dr["Qty"].ToString(), FontFactory.GetFont(FontFactory.TIMES_ROMAN, 8, iTextSharp.text.Font.NORMAL)));
                cell.HorizontalAlignment = 1;
                cell.VerticalAlignment = 1;
                cell.BorderWidth = 1f;
                cell.Padding = 5;
                tblmidcontentRow.AddCell(cell);

                cell = new PdfPCell(new Phrase(dr["CostPrice"].ToString(), FontFactory.GetFont(FontFactory.TIMES_ROMAN, 8, iTextSharp.text.Font.NORMAL)));
                cell.HorizontalAlignment = 1;
                cell.VerticalAlignment = 1;
                cell.BorderWidth = 1f;
                cell.Padding = 5;
                tblmidcontentRow.AddCell(cell);

                cell = new PdfPCell(new Phrase(dr["TotalPrice"].ToString(), FontFactory.GetFont(FontFactory.TIMES_ROMAN, 8, iTextSharp.text.Font.NORMAL)));
                cell.HorizontalAlignment = 1;
                cell.VerticalAlignment = 1;
                cell.BorderWidth = 1f;
                cell.Padding = 5;
                tblmidcontentRow.AddCell(cell);

                cell = new PdfPCell(new Phrase(dr["Expire"].ToString(), FontFactory.GetFont(FontFactory.TIMES_ROMAN, 8, iTextSharp.text.Font.NORMAL)));
                cell.HorizontalAlignment = 1;
                cell.VerticalAlignment = 1;
                cell.BorderWidth = 1f;
                cell.Padding = 5;
                tblmidcontentRow.AddCell(cell);
                //end row
            }
            document.Add(tblmidcontentRow);
            //end-row-tablemidcontentrow

            //start purchasecontent
            float[] purchasecontentwd = new float[3] { 300,5,20 };
            PdfPTable tblPurchaseContent = new PdfPTable(purchasecontentwd);
            tblPurchaseContent.WidthPercentage = 100;


            cell = new PdfPCell(new Phrase("Total Amount", FontFactory.GetFont(FontFactory.TIMES_ROMAN, 9, iTextSharp.text.Font.BOLD)));
            cell.HorizontalAlignment = 2;
            cell.VerticalAlignment = 2;
            cell.BorderWidth = 0f;
            cell.Padding = 3;
            //cell.BorderColor = BaseColor.LIGHT_GRAY;
            //cell.FixedHeight = 20f;
            tblPurchaseContent.AddCell(cell);

            cell = new PdfPCell(new Phrase(":", FontFactory.GetFont(FontFactory.TIMES_ROMAN, 9, iTextSharp.text.Font.NORMAL)));
            cell.HorizontalAlignment = 1;
            cell.VerticalAlignment = 1;
            cell.BorderWidth = 0f;
            cell.Padding = 3;
            //cell.BorderColor = BaseColor.LIGHT_GRAY;
            //cell.FixedHeight = 20f;
            tblPurchaseContent.AddCell(cell);

            cell = new PdfPCell(new Phrase(Convert.ToDecimal(Amount).ToString(), FontFactory.GetFont(FontFactory.TIMES_ROMAN, 9, iTextSharp.text.Font.BOLD)));
            cell.HorizontalAlignment = 0;
            cell.VerticalAlignment = 0;
            cell.BorderWidth = 0f;
            cell.Padding = 3;
            //cell.BorderColor = BaseColor.LIGHT_GRAY;
            //cell.FixedHeight = 20f;
            tblPurchaseContent.AddCell(cell);

            // second row strat

            cell = new PdfPCell(new Phrase("Discount Amount", FontFactory.GetFont(FontFactory.TIMES_ROMAN, 9, iTextSharp.text.Font.BOLD)));
            cell.HorizontalAlignment = 2;
            cell.VerticalAlignment = 2;
            cell.BorderWidth = 0f;
            cell.Padding = 3;
            //cell.BorderColor = BaseColor.LIGHT_GRAY;
            //cell.FixedHeight = 20f;
            tblPurchaseContent.AddCell(cell);

            cell = new PdfPCell(new Phrase(":", FontFactory.GetFont(FontFactory.TIMES_ROMAN, 9, iTextSharp.text.Font.NORMAL)));
            cell.HorizontalAlignment = 1;
            cell.VerticalAlignment = 1;
            cell.BorderWidth = 0f;
            cell.Padding = 3;
            //cell.BorderColor = BaseColor.LIGHT_GRAY;
            //cell.FixedHeight = 20f;
            tblPurchaseContent.AddCell(cell);

            cell = new PdfPCell(new Phrase(Convert.ToDecimal(Discount).ToString(), FontFactory.GetFont(FontFactory.TIMES_ROMAN, 9, iTextSharp.text.Font.BOLD)));
            cell.HorizontalAlignment = 0;
            cell.VerticalAlignment = 0;
            cell.BorderWidth = 0f;
            cell.Padding = 3;
            //cell.BorderColor = BaseColor.LIGHT_GRAY;
            //cell.FixedHeight = 20f;
            tblPurchaseContent.AddCell(cell);

            //third row start

            cell = new PdfPCell(new Phrase("Grand Total", FontFactory.GetFont(FontFactory.TIMES_ROMAN, 9, iTextSharp.text.Font.BOLD)));
            cell.HorizontalAlignment = 2;
            cell.VerticalAlignment = 2;
            cell.BorderWidth = 0f;
            cell.Padding = 3;
            //cell.BorderColor = BaseColor.LIGHT_GRAY;
            //cell.FixedHeight = 20f;
            tblPurchaseContent.AddCell(cell);

            cell = new PdfPCell(new Phrase(":", FontFactory.GetFont(FontFactory.TIMES_ROMAN, 9, iTextSharp.text.Font.NORMAL)));
            cell.HorizontalAlignment = 1;
            cell.VerticalAlignment = 1;
            cell.BorderWidth = 0f;
            cell.Padding = 3;
            //cell.BorderColor = BaseColor.LIGHT_GRAY;
            //cell.FixedHeight = 20f;
            tblPurchaseContent.AddCell(cell);

            cell = new PdfPCell(new Phrase(Convert.ToDecimal(GrandTotal).ToString(), FontFactory.GetFont(FontFactory.TIMES_ROMAN, 9, iTextSharp.text.Font.BOLD)));
            cell.HorizontalAlignment = 0;
            cell.VerticalAlignment = 0;
            cell.BorderWidth = 0f;
            cell.Padding = 3;
            //cell.BorderColor = BaseColor.LIGHT_GRAY;
            //cell.FixedHeight = 20f;
            tblPurchaseContent.AddCell(cell);

            //fourth row start

            cell = new PdfPCell(new Phrase("Payment Status", FontFactory.GetFont(FontFactory.TIMES_ROMAN, 9, iTextSharp.text.Font.BOLD)));
            cell.HorizontalAlignment = 2;
            cell.VerticalAlignment = 2;
            cell.BorderWidth = 0f;
            cell.Padding = 3;
            //cell.BorderColor = BaseColor.LIGHT_GRAY;
            //cell.FixedHeight = 20f;
            tblPurchaseContent.AddCell(cell);

            cell = new PdfPCell(new Phrase(":", FontFactory.GetFont(FontFactory.TIMES_ROMAN, 9, iTextSharp.text.Font.NORMAL)));
            cell.HorizontalAlignment = 1;
            cell.VerticalAlignment = 1;
            cell.BorderWidth = 0f;
            cell.Padding = 3;
            //cell.BorderColor = BaseColor.LIGHT_GRAY;
            //cell.FixedHeight = 20f;
            tblPurchaseContent.AddCell(cell);

            cell = new PdfPCell(new Phrase(isPayment, FontFactory.GetFont(FontFactory.TIMES_ROMAN, 9, iTextSharp.text.Font.BOLD)));
            cell.HorizontalAlignment = 0;
            cell.VerticalAlignment = 0;
            cell.BorderWidth = 0f;
            cell.Padding = 3;
            //cell.BorderColor = BaseColor.LIGHT_GRAY;
            //cell.FixedHeight = 20f;
            tblPurchaseContent.AddCell(cell);
            tblPurchaseContent.CompleteRow();
            //end of row

            document.Add(tblPurchaseContent);
            //end table purchase content



            //document close now
            document.Close();
            Response.Flush();
            Response.End();

        }
        private static Phrase FormatPhrase(string value)
        {
            return new Phrase(value, FontFactory.GetFont(FontFactory.TIMES_ROMAN, 8));
        }
        private static Phrase FormatHeaderPhrase(string value)
        {
            return new Phrase(value, FontFactory.GetFont(FontFactory.TIMES_ROMAN, 9, iTextSharp.text.Font.BOLD));
        }
        private static Phrase FormatNormal(string value)
        {
            return new Phrase(value, FontFactory.GetFont(FontFactory.TIMES_ROMAN, 9, iTextSharp.text.Font.NORMAL));
        }
        private static Phrase FormatHeaderPhrase1(string value)
        {
            return new Phrase(value, FontFactory.GetFont(FontFactory.TIMES_ROMAN, 11, iTextSharp.text.Font.BOLD));
        }


    }
}