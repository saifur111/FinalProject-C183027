using FinalProject_C183027.rootClasses;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FinalProject_C183027.view
{
    public partial class unpaidBillReport : System.Web.UI.Page
    {
        reportManagerFunctions R_Manager = new reportManagerFunctions();
        PDFManagersAllFunctions P_Manager = new PDFManagersAllFunctions();
        public void pdf_PrintFunction()
        {
            Document pdfDocument = new Document(PageSize.A4, 50f, 50f, 50f, 50f);
            PdfWriter.GetInstance(pdfDocument, Response.OutputStream);

            pdfDocument.Open();
            pdfDocument.Add(P_Manager.GetUnpaidBillReportPdfParagraph(fromDateInput.Text, toDateInput.Text, unpaidBillReportGridView, totalInput.Text));
            pdfDocument.Close();

            fromDateInput.Text = string.Empty;
            toDateInput.Text = string.Empty;
            unpaidBillReportGridView.DataSource = null;
            unpaidBillReportGridView.DataBind();
            totalInput.Text = String.Empty;

            Response.ContentType = "application/pdf";
            Response.AppendHeader("content-disposition", "attachment;filename=UnpaidBillReport.pdf");
            Response.Write(pdfDocument);
            Response.Flush();
            Response.End();

        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        
        protected void showButton_Click(object sender, EventArgs e)
        {
            unpaidBillReportGridView.DataSource = R_Manager.GetUnpaidBillReportView(fromDateInput.Text, toDateInput.Text);

            unpaidBillReportGridView.DataBind();

            double sum = 0;
            for (int i = 0; i < unpaidBillReportGridView.Rows.Count; i++)
            {
                sum += Double.Parse(unpaidBillReportGridView.Rows[i].Cells[4].Text);
            }
            totalInput.Text = sum.ToString();
        }

        protected void pdfButton_Click(object sender, EventArgs e)
        {
            pdf_PrintFunction();
        }
    }
}