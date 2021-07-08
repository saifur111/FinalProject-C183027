using FinalProject_C183027.get_set_Classes;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace FinalProject_C183027.databaseController
{
    public class paymentDB:dbConnection
    {
        public dueView GetDue(string billNo, string mobileNo)
        {
            dueView d_V = null;
            qry = "SELECT p.PatientId, p.BillAmount, tr.EntryDate AS DueDate FROM Patient AS p JOIN TestRequest AS tr ON p.PatientId = tr.PatientId WHERE p.PaymentStatus='0' AND (p.PatientId='" + billNo + "' OR p.MobileNo='" + mobileNo + "') ";
            sqlCommand = new SqlCommand(qry, sqlCon);
            sqlCon.Open();
            sqlReader = sqlCommand.ExecuteReader();
            if (sqlReader.HasRows)
            {
                d_V = new dueView();
                while (sqlReader.Read())
                {
                    d_V.PatientId = Convert.ToInt32(sqlReader["PatientId"]);
                    d_V.Amount = sqlReader["BillAmount"].ToString();
                    d_V.DueDate = sqlReader["DueDate"].ToString();
                }
                sqlReader.Close();
                sqlCon.Close();
                return d_V;
            }
            else
            {
                sqlCon.Close();
                return d_V;
            }
        }

        public int MakePayment(int patientId)
        {
            qry = "UPDATE Patient SET PaymentStatus='1' WHERE PatientId='" + patientId + "'";
            sqlCommand = new SqlCommand(qry, sqlCon);
            sqlCon.Open();
            int rowAffacted = sqlCommand.ExecuteNonQuery();
            sqlCon.Close();
            return rowAffacted;
        }

    }
}