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
                testTypeDropDownList.DataTextField = "TestTypeName";  // testType Class string variable here
                testTypeDropDownList.DataValueField = "TestTypeId";   // testType Class string variable here
                testTypeDropDownList.DataBind();
                testTypeDropDownList.Items.Insert(0, new ListItem("Select Test Type", "0"));
            }

        }
        protected void saveButton_Click(object sender, EventArgs e)
        {
            test object_test = new test(); // Create text class object b
            object_test.TestName = textNameTextBox.Text;
            object_test.Fee = Double.Parse(feeTexBox.Text);
            object_test.TestTypeId = Convert.ToInt32(testTypeDropDownList.SelectedValue);
            outputLabel.Text = object_TestManager.TestSave(object_test);

            textNameTextBox.Text = string.Empty;
            feeTexBox.Text = string.Empty;

            testSetupGridView.DataSource = object_TestManager.GetAllTest();
            testSetupGridView.DataBind();

            testTypeDropDownList.ClearSelection();
        }
    }
}