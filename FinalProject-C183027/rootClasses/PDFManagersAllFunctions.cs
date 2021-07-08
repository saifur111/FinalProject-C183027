using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using iTextSharp;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace FinalProject_C183027.rootClasses
{
    public class PDFManagersAllFunctions
    {
        public Paragraph GetBillPdfParagraph(string printDate, int PatientId, string patientName, string dateOfBirth, string mobileNo, GridView aGridView, string totalFee)
        {
            var titleFont = FontFactory.GetFont("Candara", 18, Font.BOLD);
            Phrase headingPhrase = new Phrase("Bill Copy" + Environment.NewLine, titleFont);
            Phrase dotlinePhrase = new Phrase(".............................................................................................................................." + Environment.NewLine);
            Phrase printDatePhrase = new Phrase("Print Date: " + printDate + Environment.NewLine);
            Phrase billNoPhrase = new Phrase("Bill No: " + PatientId + Environment.NewLine);
            Phrase patientNamePhrase = new Phrase("Patient Name: " + patientName + Environment.NewLine);
            Phrase dateOfBirthPhrase = new Phrase("Date of Birth: " + dateOfBirth + Environment.NewLine);
            Phrase mobileNoPhrase = new Phrase("Mobile No: " + mobileNo + Environment.NewLine);
            Phrase selectedTestPhrase = new Phrase("Selected Tests are: " + Environment.NewLine);

            PdfPTable pdfTable = new PdfPTable(3);

            PdfPCell SN = new PdfPCell(new Phrase("SN"));
            SN.HorizontalAlignment = 1;
            pdfTable.AddCell(SN);
            PdfPCell TestName = new PdfPCell(new Phrase("Test Name"));
            TestName.HorizontalAlignment = 1;
            pdfTable.AddCell(TestName);
            PdfPCell Fee = new PdfPCell(new Phrase("Fee"));
            Fee.HorizontalAlignment = 1;
            pdfTable.AddCell(Fee);

            int sn = 1;
            for (int i = 0; i < aGridView.Rows.Count; i++)
            {
                PdfPCell snCell = new PdfPCell(new Phrase(sn++.ToString()));
                PdfPCell testNameCell = new PdfPCell(new Phrase(aGridView.Rows[i].Cells[1].Text));
                PdfPCell feeCell = new PdfPCell(new Phrase(aGridView.Rows[i].Cells[2].Text));
                snCell.HorizontalAlignment = 1;
                feeCell.HorizontalAlignment = 1;
                pdfTable.AddCell(snCell);
                pdfTable.AddCell(testNameCell);
                pdfTable.AddCell(feeCell);
            }

            Phrase totalPhrase = new Phrase("Total Fee: " + totalFee + Environment.NewLine);
            Phrase paymentStatusPhrase = new Phrase("Payment Status : Unpaid" + Environment.NewLine);
            Phrase dotlinePhrase2 = new Phrase(".............................................................................................................................." + Environment.NewLine);
            Phrase creditPhrase = new Phrase("<------------- Managed by Admin : Md Saifur Rahman Id : C183027 ------------->");

            Paragraph prg = new Paragraph();
            prg.Add(headingPhrase);
            prg.Add(dotlinePhrase);
            prg.Add(printDatePhrase);
            prg.Add(billNoPhrase);
            prg.Add(patientNamePhrase);
            prg.Add(dateOfBirthPhrase);
            prg.Add(mobileNoPhrase);
            prg.Add(Chunk.NEWLINE);
            prg.Add(selectedTestPhrase);
            prg.Add(pdfTable);
            prg.Add(Chunk.NEWLINE);
            prg.Add(totalPhrase);
            prg.Add(paymentStatusPhrase);
            prg.Add(dotlinePhrase2);
            prg.Add(creditPhrase);

            return prg;
        }

        public Paragraph GetTypeWiseReportPdfParagraph(string fromDate, string toDate, GridView aGridView, string totalFee)
        {
            var titleFont = FontFactory.GetFont("Candara", 18, Font.BOLD);
            Phrase headingPhrase = new Phrase("Type Wise Report" + Environment.NewLine, titleFont);
            Phrase dotlinePhrase = new Phrase(".............................................................................................................................." + Environment.NewLine);
            Phrase fromDatePhrase = new Phrase("From Date: " + fromDate + Environment.NewLine);
            Phrase toDatePhrase = new Phrase("To Date: " + toDate + Environment.NewLine);

            PdfPTable pdfTable = new PdfPTable(4);

            PdfPCell SN = new PdfPCell(new Phrase("SN"));
            SN.HorizontalAlignment = 1;
            pdfTable.AddCell(SN);
            PdfPCell TestType = new PdfPCell(new Phrase("Test Type"));
            TestType.HorizontalAlignment = 1;
            pdfTable.AddCell(TestType);
            PdfPCell NoOfTest = new PdfPCell(new Phrase("No Of Test"));
            NoOfTest.HorizontalAlignment = 1;
            pdfTable.AddCell(NoOfTest);
            PdfPCell TotalAmount = new PdfPCell(new Phrase("Total Amount"));
            TotalAmount.HorizontalAlignment = 1;
            pdfTable.AddCell(TotalAmount);

            int sn = 1;
            for (int i = 0; i < aGridView.Rows.Count; i++)
            {
                PdfPCell snCell = new PdfPCell(new Phrase(sn++.ToString()));
                PdfPCell testTypeCell = new PdfPCell(new Phrase(aGridView.Rows[i].Cells[1].Text));
                PdfPCell noOfTestCell = new PdfPCell(new Phrase(aGridView.Rows[i].Cells[2].Text));
                PdfPCell totalAmountCell = new PdfPCell(new Phrase(aGridView.Rows[i].Cells[3].Text));

                snCell.HorizontalAlignment = 1;
                noOfTestCell.HorizontalAlignment = 1;
                totalAmountCell.HorizontalAlignment = 1;

                pdfTable.AddCell(snCell);
                pdfTable.AddCell(testTypeCell);
                pdfTable.AddCell(noOfTestCell);
                pdfTable.AddCell(totalAmountCell);

            }

            Phrase totalPhrase = new Phrase("Total: " + totalFee + Environment.NewLine);
            Phrase dotlinePhrase2 = new Phrase(".............................................................................................................................." + Environment.NewLine);
            Phrase creditPhrase = new Phrase("<------------- Managed by Admin : Md Saifur Rahman Id : C183027 ------------->");

            Paragraph pgp = new Paragraph();
            pgp.Add(headingPhrase);
            pgp.Add(dotlinePhrase);
            pgp.Add(fromDatePhrase);
            pgp.Add(toDatePhrase);
            pgp.Add(Chunk.NEWLINE);
            pgp.Add(pdfTable);
            pgp.Add(Chunk.NEWLINE);
            pgp.Add(totalPhrase);
            pgp.Add(dotlinePhrase2);
            pgp.Add(creditPhrase);

            return pgp;
        }
        // TestWiseReport pdf file data.....
        public Paragraph GetTestWiseReportPdfParagraph(string fromDate, string toDate, GridView aGridView, string totalFee)
        {
            var titleFont = FontFactory.GetFont("Candara", 18, Font.BOLD);
            Phrase headingPhrase = new Phrase("Test Wise Report" + Environment.NewLine, titleFont);
            Phrase dotlinePhrase = new Phrase(".............................................................................................................................." + Environment.NewLine);
            Phrase fromDatePhrase = new Phrase("From Date: " + fromDate + Environment.NewLine);
            Phrase toDatePhrase = new Phrase("To Date: " + toDate + Environment.NewLine);

            PdfPTable pdfTable = new PdfPTable(4);

            PdfPCell SN = new PdfPCell(new Phrase("SN"));
            SN.HorizontalAlignment = 1;
            pdfTable.AddCell(SN);
            PdfPCell TestName = new PdfPCell(new Phrase("Test Name"));
            TestName.HorizontalAlignment = 1;
            pdfTable.AddCell(TestName);
            PdfPCell NoOfTest = new PdfPCell(new Phrase("No Of Test"));
            NoOfTest.HorizontalAlignment = 1;
            pdfTable.AddCell(NoOfTest);
            PdfPCell TotalAmount = new PdfPCell(new Phrase("Total Amount"));
            TotalAmount.HorizontalAlignment = 1;
            pdfTable.AddCell(TotalAmount);

            int sn = 1;
            for (int i = 0; i < aGridView.Rows.Count; i++)
            {
                PdfPCell snCell = new PdfPCell(new Phrase(sn++.ToString()));
                PdfPCell testNameCell = new PdfPCell(new Phrase(aGridView.Rows[i].Cells[1].Text));
                PdfPCell noOfTestCell = new PdfPCell(new Phrase(aGridView.Rows[i].Cells[2].Text));
                PdfPCell totalAmountCell = new PdfPCell(new Phrase(aGridView.Rows[i].Cells[3].Text));

                snCell.HorizontalAlignment = 1;
                noOfTestCell.HorizontalAlignment = 1;
                totalAmountCell.HorizontalAlignment = 1;

                pdfTable.AddCell(snCell);
                pdfTable.AddCell(testNameCell);
                pdfTable.AddCell(noOfTestCell);
                pdfTable.AddCell(totalAmountCell);
            }

            Phrase totalPhrase = new Phrase("Total: " + totalFee + Environment.NewLine);
            Phrase dotlinePhrase2 = new Phrase(".............................................................................................................................." + Environment.NewLine);
            Phrase creditPhrase = new Phrase("<------------- Managed by Admin : Md Saifur Rahman Id : C183027 ------------->");

            Paragraph pgp = new Paragraph();
            pgp.Add(headingPhrase);
            pgp.Add(dotlinePhrase);
            pgp.Add(fromDatePhrase);
            pgp.Add(toDatePhrase);
            pgp.Add(Chunk.NEWLINE);
            pgp.Add(pdfTable);
            pgp.Add(Chunk.NEWLINE);
            pgp.Add(totalPhrase);
            pgp.Add(dotlinePhrase2);
            pgp.Add(creditPhrase);

            return pgp;
        }
        // UnpaidBillReport pdf file data.....
        public Paragraph GetUnpaidBillReportPdfParagraph(string fromDate, string toDate, GridView aGridView, string totalFee)
        {
            var titleFont = FontFactory.GetFont("Candara", 18, Font.BOLD);
            Phrase headingPhrase = new Phrase("Unpaid Bill Report" + Environment.NewLine, titleFont);
            Phrase dotlinePhrase = new Phrase(".............................................................................................................................." + Environment.NewLine);
            Phrase fromDatePhrase = new Phrase("From Date: " + fromDate + Environment.NewLine);
            Phrase toDatePhrase = new Phrase("To Date: " + toDate + Environment.NewLine);

            PdfPTable pdfTable = new PdfPTable(5);

            PdfPCell SN = new PdfPCell(new Phrase("SN"));
            SN.HorizontalAlignment = 1;
            pdfTable.AddCell(SN);
            PdfPCell BillNo = new PdfPCell(new Phrase("Bill No"));
            BillNo.HorizontalAlignment = 1;
            pdfTable.AddCell(BillNo);
            PdfPCell PatientName = new PdfPCell(new Phrase("Patient Name"));
            PatientName.HorizontalAlignment = 1;
            pdfTable.AddCell(PatientName);
            PdfPCell MobileNo = new PdfPCell(new Phrase("Mobile No"));
            MobileNo.HorizontalAlignment = 1;
            pdfTable.AddCell(MobileNo);
            PdfPCell TotalAmount = new PdfPCell(new Phrase("Billl Amount"));
            TotalAmount.HorizontalAlignment = 1;
            pdfTable.AddCell(TotalAmount);

            int sn = 1;
            for (int i = 0; i < aGridView.Rows.Count; i++)
            {
                PdfPCell snCell = new PdfPCell(new Phrase(sn++.ToString()));
                PdfPCell billNoCell = new PdfPCell(new Phrase(aGridView.Rows[i].Cells[1].Text));
                PdfPCell nameCell = new PdfPCell(new Phrase(aGridView.Rows[i].Cells[2].Text));
                PdfPCell mobileNoCell = new PdfPCell(new Phrase(aGridView.Rows[i].Cells[3].Text));
                PdfPCell billAmountCell = new PdfPCell(new Phrase(aGridView.Rows[i].Cells[4].Text));

                snCell.HorizontalAlignment = 1;
                billNoCell.HorizontalAlignment = 1;
                mobileNoCell.HorizontalAlignment = 1;
                billAmountCell.HorizontalAlignment = 1;

                pdfTable.AddCell(snCell);
                pdfTable.AddCell(billNoCell);
                pdfTable.AddCell(nameCell);
                pdfTable.AddCell(mobileNoCell);
                pdfTable.AddCell(billAmountCell);
            }

            Phrase totalPhrase = new Phrase("Total: " + totalFee + Environment.NewLine);
            Phrase dotlinePhrase2 = new Phrase(".............................................................................................................................." + Environment.NewLine);
            Phrase creditPhrase = new Phrase("<------------- Managed by Admin : Md Saifur Rahman Id : C183027 ------------->");

            Paragraph pgp = new Paragraph();
            pgp.Add(headingPhrase);
            pgp.Add(dotlinePhrase);
            pgp.Add(fromDatePhrase);
            pgp.Add(toDatePhrase);
            pgp.Add(Chunk.NEWLINE);
            pgp.Add(pdfTable);
            pgp.Add(Chunk.NEWLINE);
            pgp.Add(totalPhrase);
            pgp.Add(dotlinePhrase2);
            pgp.Add(creditPhrase);

            return pgp;
        }

    }
}