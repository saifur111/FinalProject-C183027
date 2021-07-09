using FinalProject_C183027.rootClasses;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FinalProject_C183027.view
{
    public partial class typeWiseReport : System.Web.UI.Page
    {
        PDFManagersAllFunctions P_Manager = new PDFManagersAllFunctions();
        reportManagerFunctions R_Manager = new reportManagerFunctions();

        public void pdf_PrintFunction()
        {
            Document pdfDocument = new Document(PageSize.A4, 50f, 50f, 50f, 50f);
            PdfWriter.GetInstance(pdfDocument, Response.OutputStream);

            pdfDocument.Open();
            pdfDocument.Add(P_Manager.GetTypeWiseReportPdfParagraph(fromDateInput.Text, toDateInput.Text, typeWiseReportGridView, totalInput.Text));
            pdfDocument.Close();

            fromDateInput.Text = string.Empty;
            toDateInput.Text = string.Empty;
            typeWiseReportGridView.DataSource = null;
            typeWiseReportGridView.DataBind();
            totalInput.Text = String.Empty;

            Response.ContentType = "application/pdf";
            Response.AppendHeader("content-disposition", "attachment;filename=Type_Wise_Report.pdf");
            Response.Write(pdfDocument);
            Response.Flush();
            Response.End();
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void showButton_Click(object sender, EventArgs e)
        {
            typeWiseReportGridView.DataSource = R_Manager.GetTypeWiseReportView(fromDateInput.Text, toDateInput.Text);

            typeWiseReportGridView.DataBind();

            double total = 0;
            
            for (int i = 0; i < typeWiseReportGridView.Rows.Count; i++)
            {
                try
                {
                    total += Double.Parse(typeWiseReportGridView.Rows[i].Cells[3].Text);
                }
                catch
                {
                    typeWiseReportGridView.Rows[i].Cells[3].Text = "0";
                    continue;
                }
            }
            totalInput.Text = (total).ToString();
            totalInput.ForeColor = Color.Red;
        }

        protected void pdfButton_Click(object sender, EventArgs e)
        {
            pdf_PrintFunction();

        }
    }
}