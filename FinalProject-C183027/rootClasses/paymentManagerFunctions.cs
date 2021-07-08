using FinalProject_C183027.databaseController;
using FinalProject_C183027.get_set_Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalProject_C183027.rootClasses
{
    public class paymentManagerFunctions
    {
        private paymentDB p_db = new paymentDB();

        public dueView GetDue(string billNo, string mobileNo)
        {
            return p_db.GetDue(billNo, mobileNo);
        }

        public string MakePayment(int patientId)
        {
            int rowAffacted = p_db.MakePayment(patientId);
            if (rowAffacted > 0)
                return "Payment Successful";
            else
                return "Sorry, payment is not successful !";
        }
    }
}