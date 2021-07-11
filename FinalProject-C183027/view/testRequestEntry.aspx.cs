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
        testRequestManagerFunctions T_R_Manager = new testRequestManagerFunctions();
        testManagerFuntions T_Manager = new testManagerFuntions();
        PDFManagersAllFunctions P_Manager = new PDFManagersAllFunctions();
        patient ptn = new patient();
        test tst = new test();
        testRequest T_Request = new testRequest();

        private List<test> testList;

        string date = DateTime.Now.ToString("dd-MM-yyyy");

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                selectTestDropDownList.DataSource = T_Manager.GetAllTest();//testManagerFunction class GetAllTest function called..
                selectTestDropDownList.DataTextField = "test_get_set_class_TestName";
                selectTestDropDownList.DataValueField = "test_get_set_class_TestId";
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
                feeInput.Text = T_R_Manager.GetFee(Convert.ToInt32(selectTestDropDownList.SelectedValue));
        }

        // Add button event code here.......

        public void addButton_Click(object sender, EventArgs e)
        {
            outputLabel.Text = "";

            tst.test_get_set_class_TestId = Convert.ToInt32(selectTestDropDownList.SelectedValue);
            tst.test_get_set_class_TestName = selectTestDropDownList.SelectedItem.Text;

            tst.test_get_set_class_Fee = Convert.ToDouble(feeInput.Text);

            if (Session["TempTest"] == null)
            {
                testList = new List<test>();
            }
            else
            {
                testList = (List<test>)Session["TempTest"];
            }
            testList.Add(tst);
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

        // save button event  code here........

        protected void saveButton_Click(object sender, EventArgs e)
        {
            ptn.patient_get_set_class_Name = patientNameInput.Text;
            ptn.patient_get_set_class_DateOfBirth = dateOfbirthInput.Text;
            ptn.patient_get_set_class_MobileNo = phoneInput.Text;

            ptn.patient_get_set_class_BillAmount = Convert.ToDouble(totalInput.Text);

            ptn.patient_get_set_class_PaymentStatus = 0;

            

            if (T_R_Manager.SavePatient(ptn) != "Please use another Mobile No !")//testRequestManagerFunctions SavePatient function called..
            {
                foreach (test anyTest in (List<test>)Session["TempTest"])
                {
                    
                    T_Request.testRequest_get_set_class_PatientId = T_R_Manager.GetPatientId(ptn.patient_get_set_class_MobileNo);//testRequestManagerFunctions GetPatientId function called..
                   
                    T_Request.testRequest_get_set_class_TestId = anyTest.test_get_set_class_TestId;
                    
                    T_Request.testRequest_get_set_class_EntryDate = date;

                    outputLabel.Text = T_R_Manager.SaveTestRequest(T_Request); //testRequestManagerFunctions SaveTestRequest function called..
                }

                // PDF save code Here....
                pdf_PrintFunction();
            }
            else
            {
                outputLabel.Text = "Please use another Mobile No !";
            }
        }
        private void pdf_PrintFunction()
        {
            Document pdfDocument = new Document(PageSize.A4, 50f, 50f, 50f, 50f);
            PdfWriter.GetInstance(pdfDocument, Response.OutputStream);

            pdfDocument.Open();

            pdfDocument.Add(P_Manager.GetBillPdfParagraph(date, T_R_Manager.GetPatientId(ptn.patient_get_set_class_MobileNo), ptn.patient_get_set_class_Name, ptn.patient_get_set_class_DateOfBirth, ptn.patient_get_set_class_MobileNo, testRequestGridView, totalInput.Text));
           
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
            Response.AppendHeader("content-disposition", "attachment;filename=Bill-Details.pdf");
            Response.Write(pdfDocument);
            Response.Flush();
            Response.End();
            throw new NotImplementedException();
        }
    }
}