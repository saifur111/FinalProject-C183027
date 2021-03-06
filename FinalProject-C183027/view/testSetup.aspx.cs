using FinalProject_C183027.get_set_Classes;
using FinalProject_C183027.rootClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FinalProject_C183027.view
{
    public partial class testSetup : System.Web.UI.Page
    {
        testManagerFuntions object_TestManager = new testManagerFuntions();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                testTypeDropDownList.DataSource = object_TestManager.GetAllTestTypes();
                testTypeDropDownList.DataTextField = "testType_get_set_class_testTypeName";  // testType Class string variable here
                testTypeDropDownList.DataValueField = "testType_get_set_class_testTypeId";   // testType Class string variable here
                testTypeDropDownList.DataBind();
                testTypeDropDownList.Items.Insert(0, new ListItem("Select Test Type", "0"));
            }

        }
        protected void saveButton_Click(object sender, EventArgs e)
        {
            test object_test = new test(); // Create test class object....getsetClasses

            object_test.test_get_set_class_TestName = textNameTextBox.Text;
            object_test.test_get_set_class_Fee = Double.Parse(feeTexBox.Text);

            object_test.test_get_set_class_TestTypeId = Convert.ToInt32(testTypeDropDownList.SelectedValue);

            outputLabel.Text = object_TestManager.TestSave(object_test);//testManagerFuntions class TestSave function callded
            
            textNameTextBox.Text = string.Empty;
            feeTexBox.Text = string.Empty;

            testSetupGridView.DataSource = object_TestManager.GetAllTest();// testManagerFuntions class Getalltest function callded...

            testSetupGridView.DataBind();

            testTypeDropDownList.ClearSelection();
        }
    }
}