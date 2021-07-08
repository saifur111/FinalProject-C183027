using FinalProject_C183027.databaseController;
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
    public partial class testTypeSetup : System.Web.UI.Page
    {
        testManagerFuntions object_TestManager = new testManagerFuntions();// here testManagerfunction class object create........
        testType object_testType = new testType(); // here get-setClasses folder er TestType Class object Create.....
        
        protected void Page_Load(object sender, EventArgs e){}

        protected void typeNameSave_Click(object sender, EventArgs e)
        {
            object_testType.TestTypeName = typeNameInput.Text;// get value text input..
            outputLabel.Text = object_TestManager.TestTypeSave(object_testType);
            typeNameInput.Text = string.Empty;

            // Here Table  GridView Code ...........
            TestTypeGridView.DataSource = object_TestManager.GetAllTestTypes(); //here testManagerfunction class GetAllTestTypes function called
            TestTypeGridView.DataBind();
        }
    }
}