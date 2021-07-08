using FinalProject_C183027.get_set_Classes;
using FinalProject_C183027.rootClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iTextSharp;
using iTextSharp.text;
using iTextSharp.text.pdf;
namespace FinalProject_C183027.view
{
    public partial class testRequestEntry : System.Web.UI.Page
    {
        testRequestManagerFunctions aTestRequestManager = new testRequestManagerFunctions();
        testManagerFuntions TestManager = new testManagerFuntions();
        private List<test> testList;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                selectTestDropDownList.DataSource = TestManager.GetAllTest();
                selectTestDropDownList.DataTextField = "TestName";
                selectTestDropDownList.DataValueField = "TestId";
                selectTestDropDownList.DataBind();
                selectTestDropDownList.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Select Test Name", "0"));
            }
        }
        // On select index change dropdown List.....
        protected void IndexChanged(object sender, EventArgs e)
        {
            if (selectTestDropDownList.SelectedIndex == 0)
                feeInput.Text = "0";
            else
                feeInput.Text = aTestRequestManager.GetFee(Convert.ToInt32(selectTestDropDownList.SelectedValue));
        }

        // Add button event code here
        public void addButton_Click(object sender, EventArgs e)
        {
            outputLabel.Text = "";
            test aTest = new test();
            aTest.TestId = Convert.ToInt32(selectTestDropDownList.SelectedValue);
            aTest.TestName = selectTestDropDownList.SelectedItem.Text;
            aTest.Fee = Convert.ToDouble(feeInput.Text);

            if (Session["TempTest"] == null)
            {
                testList = new List<test>();
            }
            else
            {
                testList = (List<test>)Session["TempTest"];
            }
            testList.Add(aTest);
            testRequestGridView.DataSource = testList;
            testRequestGridView.DataBind();
            Session["TempTest"] = testList;

            double sum = 0;
            for (int i = 0; i < testRequestGridView.Rows.Count; i++)
            {
                sum += Double.Parse(testRequestGridView.Rows[i].Cells[2].Text);
            }
            totalInput.Text = sum.ToString();
        }

        // save button event  code here
        protected void saveButton_Click(object sender, EventArgs e)
        {
            patient aPatient = new patient();
            aPatient.Name = patientNameInput.Text;
            aPatient.DateOfBirth = dateOfbirthInput.Text;
            aPatient.MobileNo = phoneInput.Text;
            aPatient.BillAmount = Convert.ToDouble(totalInput.Text);
            aPatient.PaymentStatus = 0;
            string date = DateTime.Now.ToString("yyyy-MM-dd");

            if (aTestRequestManager.SavePatient(aPatient) != "Please use another Mobile No !")
            {
                foreach (test anyTest in (List<test>)Session["TempTest"])
                {
                    testRequest TestRequest = new testRequest();
                    TestRequest.PatientId = aTestRequestManager.GetPatientId(aPatient.MobileNo);
                    TestRequest.TestId = anyTest.TestId;
                    TestRequest.EntryDate = date;

                    outputLabel.Text = aTestRequestManager.SaveTestRequest(TestRequest);
                }
                // PDF save code Here....

                PDFManagersAllFunctions aPdfManager = new PDFManagersAllFunctions();
                Document pdfDocument = new Document(PageSize.A4, 50f, 50f, 50f, 50f);
                PdfWriter.GetInstance(pdfDocument, Response.OutputStream);

                pdfDocument.Open();
                pdfDocument.Add(aPdfManager.GetBillPdfParagraph(date, aTestRequestManager.GetPatientId(aPatient.MobileNo), aPatient.Name, aPatient.DateOfBirth, aPatient.MobileNo, testRequestGridView, totalInput.Text));
                pdfDocument.Close();

                patientNameInput.Text = string.Empty;
                dateOfbirthInput.Text = string.Empty;
                phoneInput.Text = string.Empty;
                testRequestGridView.DataSource = null;
                testRequestGridView.DataBind();
                Session["TempTest"] = null;
                totalInput.Text = String.Empty;
                selectTestDropDownList.ClearSelection();

                Response.ContentType = "application/pdf";
                Response.AppendHeader("content-disposition", "attachment;filename=Bill.pdf");
                Response.Write(pdfDocument);
                Response.Flush();
                Response.End();
            }
            else
            {
                outputLabel.Text = "Please use another Mobile No !";
            }
        }

    }
}