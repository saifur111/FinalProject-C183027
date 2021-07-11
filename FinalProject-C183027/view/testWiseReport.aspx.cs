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
    public partial class testWiseReport : System.Web.UI.Page
    {
        
        protected void showButton_Click(object sender, EventArgs e)
        {
            reportManagerFunctions R_Manager = new reportManagerFunctions();

            test_WiseReportGridView.DataSource = R_Manager.GetTestWiseReport(fromDateInput.Text, toDateInput.Text);
           
            test_WiseReportGridView.DataBind();

            Console.WriteLine();
            
            for (int i = 0; i < test_WiseReportGridView.Rows.Count; i++)
            {
                Console.WriteLine(test_WiseReportGridView.Rows[i].Cells[3].Text);
            }

            double total = 0;
            for (int i = 0; i < test_WiseReportGridView.Rows.Count; i++)
            {
                total += Double.Parse(test_WiseReportGridView.Rows[i].Cells[3].Text);
                
            }
            totalInput.Text = (total).ToString();
        }

        protected void pdfButton_Click(object sender, EventArgs e)
        {
            PDFManagersAllFunctions aPdfManager = new PDFManagersAllFunctions();
            Document pdfDocument = new Document(PageSize.A4, 50f, 50f, 50f, 50f);
            PdfWriter.GetInstance(pdfDocument, Response.OutputStream);

            pdfDocument.Open();
            pdfDocument.Add(aPdfManager.GetTestWiseReportPdfParagraph(fromDateInput.Text, toDateInput.Text, test_WiseReportGridView, totalInput.Text));
            pdfDocument.Close();

            fromDateInput.Text = string.Empty;
            toDateInput.Text = string.Empty;
            test_WiseReportGridView.DataSource = null;
            test_WiseReportGridView.DataBind();
            totalInput.Text = String.Empty;

            Response.ContentType = "application/pdf";
            Response.AppendHeader("content-disposition", "attachment;filename=TestWiseReport.pdf");
            Response.Write(pdfDocument);
            Response.Flush();
            Response.End();
        }
    }
}