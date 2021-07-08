using FinalProject_C183027.get_set_Classes;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace FinalProject_C183027.databaseController
{
    public class testRequestDB:dbConnection
    {
        public bool CheckPatient(patient Patient)
        {

            qry = "SELECT * FROM Patient WHERE MobileNo = '" + Patient.MobileNo + "'";
            sqlCommand = new SqlCommand(qry, sqlCon);
            sqlCon.Open();
            sqlReader = sqlCommand.ExecuteReader();
            bool patientExists = sqlReader.HasRows;
            sqlReader.Close();
            sqlCon.Close();
            return patientExists;
        }
        //------------------------------------------------
        public int SavePatient(patient Patient)
        {
            qry = "INSERT INTO Patient (Name, DateOfBirth, MobileNo, BillAmount, PaymentStatus) VALUES ('" + Patient.Name + "','" + Patient.DateOfBirth + "','" + Patient.MobileNo + "','" + Patient.BillAmount + "','" + Patient.PaymentStatus + "')";
            sqlCommand = new SqlCommand(qry, sqlCon);
            sqlCon.Open();
            int rowAffected = sqlCommand.ExecuteNonQuery();
            sqlCon.Close();
            return rowAffected;
        }
        //-------------------------------------------------
        public string GetFee(int TestId)
        {
            qry = "SELECT * FROM Test WHERE TestId='" + TestId + "'";
            sqlCommand = new SqlCommand(qry, sqlCon);
            string fee = String.Empty;
            sqlCon.Open();
            sqlReader = sqlCommand.ExecuteReader();
            while (sqlReader.Read())
            {
                fee = sqlReader["Fee"].ToString();
            }
            sqlReader.Close();
            sqlCon.Close();
            return fee;
        }
        //-------------------------------------------------------
        public int GetPatientId(string mobileNo)
        {
            qry = "SELECT * FROM Patient WHERE MobileNo='" + mobileNo + "'";
            sqlCommand = new SqlCommand(qry, sqlCon);
            int patientId = 0;
            sqlCon.Open();
            sqlReader = sqlCommand.ExecuteReader();
            while (sqlReader.Read())
            {
                patientId = Convert.ToInt32(sqlReader["PatientId"]);
            }
            sqlReader.Close();
            sqlCon.Close();
            return patientId;
        }
        //----------------------------------------------------
        public int SaveTestRequest(testRequest TestRequest)
        {
            qry = "INSERT INTO TestRequest (PatientId, TestId, EntryDate) VALUES ('" + TestRequest.PatientId + "','" + TestRequest.TestId + "','" + TestRequest.EntryDate + "')";
            sqlCommand = new SqlCommand(qry, sqlCon);
            sqlCon.Open();
            int rowAffected = sqlCommand.ExecuteNonQuery();
            sqlCon.Close();
            return rowAffected;
        }
    }
}