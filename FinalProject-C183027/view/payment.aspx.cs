using FinalProject_C183027.get_set_Classes;
using FinalProject_C183027.rootClasses;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FinalProject_C183027.view
{
    public partial class payment : System.Web.UI.Page
    {
        paymentManagerFunctions p_m_function = new paymentManagerFunctions();
        protected void Page_Load(object sender, EventArgs e)
        {
            outputLabel.Text = "";
            amountInput.Text = "";
            dueDateInput.Text = "";
        }
        protected void searchButton_Click(object sender, EventArgs e)
        {
            if (billNoInput.Text != "" || mobileNoInput.Text != "")
            {
                dueView d_V = new dueView();
                d_V = p_m_function.GetDue(billNoInput.Text, mobileNoInput.Text);
                if (d_V != null)
                {
                    Session["patientId"] = d_V.PatientId;
                    amountInput.Text = d_V.Amount;
                    dueDateInput.Text = d_V.DueDate;
                }
                else
                {
                    outputLabel.ForeColor = Color.Red;
                    outputLabel.Text = "No Unpaid bill information found For this Bill No/Mobile No !";
                }
            }
            else
            {
                amountInput.Text = "";
                dueDateInput.Text = "";
                outputLabel.ForeColor = Color.Brown;
                outputLabel.Text = "Please insert Bill No or Mobile No";
            }
        }

        protected void payButton_Click(object sender, EventArgs e)
        {
            outputLabel.Text = p_m_function.MakePayment(Convert.ToInt32(Session["patientId"]));
            Session["patientId"] = null;
        }
    }
}