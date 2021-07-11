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

        protected void showButton_Click(object sender, EventArgs e)
        {
            PDFManagersAllFunctions P_Manager = new PDFManagersAllFunctions();
            type_WiseReportGridView.DataSource = R_Manager.GetTypeWiseReport(fromDateInput.Text, toDateInput.Text);
            type_WiseReportGridView.DataBind();

            double total = 0;
            for (int i = 0; i < type_WiseReportGridView.Rows.Count; i++)
            {
                try
                {
                    total += Convert.ToDouble(type_WiseReportGridView.Rows[i].Cells[3].Text);
                }
                catch
                {
                    type_WiseReportGridView.Rows[i].Cells[3].Text = "0";
                    continue;
                }   
            }
            totalInput.Text = (total).ToString();
            totalInput.ForeColor = Color.Red;
        }

        protected void pdfButton_Click(object sender, EventArgs e)
        {
            Document pdfDocument = new Document(PageSize.A4, 50f, 50f, 50f, 50f);
            PdfWriter.GetInstance(pdfDocument, Response.OutputStream);

            pdfDocument.Open();
            pdfDocument.Add(P_Manager.GetTypeWiseReportPdfParagraph(fromDateInput.Text, toDateInput.Text, type_WiseReportGridView, totalInput.Text));
            pdfDocument.Close();

            fromDateInput.Text = string.Empty;
            toDateInput.Text = string.Empty;
            type_WiseReportGridView.DataSource = null;
            type_WiseReportGridView.DataBind();
            totalInput.Text = String.Empty;

            Response.ContentType = "application/pdf";
            Response.AppendHeader("content-disposition", "attachment;filename=TypeWiseReport.pdf");
            Response.Write(pdfDocument);
            Response.Flush();
            Response.End();
        }
    }
}