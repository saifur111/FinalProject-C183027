﻿using FinalProject_C183027.get_set_Classes;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace FinalProject_C183027.databaseController
{
    public class reportDB:dbConnection
    {
        public List<testWiseReport> GetTestWiseReportView(string fromDate, string toDate)
        {
            qry = "SELECT ti.TestName,ti.Fee, COUNT(tr.TestId) AS NoOfTest, (Fee*COUNT(tr.TestId)) AS TotalAmount FROM TestInfo AS ti LEFT JOIN TestRequest AS tr ON ti.TestId=tr.TestId WHERE tr.EntryDate BETWEEN '" + fromDate + "' AND '" + toDate + "' OR tr.EntryDate IS NULL GROUP BY ti.TestName, ti.Fee";
            List<testWiseReport> T_W_ReportList = new List<testWiseReport>();
            sqlCommand = new SqlCommand(qry, sqlCon);
            sqlCon.Open();
            sqlReader = sqlCommand.ExecuteReader();
            while (sqlReader.Read())
            {
                testWiseReport T_W_Report = new testWiseReport();
                T_W_Report.TestName = sqlReader["TestName"].ToString();
                T_W_Report.NoOfTest = sqlReader["NoOfTest"].ToString();
                T_W_Report.TotalAmount = sqlReader["TotalAmount"].ToString();

                T_W_ReportList.Add(T_W_Report);
            }
            sqlReader.Close();
            sqlCon.Close();
            return T_W_ReportList;
        }

        public List<typeWiseReport> GetTypeWiseReportView(string fromDate, string toDate)
        {
            qry = "SELECT a.TestType , Sum(a.NoOfTest) AS NoOfTest , Sum(a.TotalAmount) AS TotalAmount FROM (SELECT tyi.TestType, Count(tr.testId) As NoOfTest, (Fee*Count(tr.testId)) As TotalAmount From TestTypeInfo AS tyi Left Outer Join TestInfo AS ti ON tyi.TestTypeId = ti.TestTypeId Left Outer Join TestRequest tr ON ti.TestId = tr.TestId WHERE EntryDate BETWEEN '" + fromDate + "' AND '" + toDate + "' OR EntryDate IS NULL GROUP BY tyi.TestType, Fee) a GROUP BY a.TestType";
            List<typeWiseReport> TypeWiseReportView = new List<typeWiseReport>();
            sqlCommand = new SqlCommand(qry, sqlCon);
            sqlCon.Open();
            sqlReader = sqlCommand.ExecuteReader();
            while (sqlReader.Read())
            {
                typeWiseReport T_W_Report = new typeWiseReport();
                T_W_Report.TestType = sqlReader["TestType"].ToString();
                T_W_Report.NoOfTest = sqlReader["NoOfTest"].ToString();
                T_W_Report.TotalAmount = sqlReader["TotalAmount"].ToString();

                TypeWiseReportView.Add(T_W_Report);
            }
            sqlReader.Close();
            sqlCon.Close();
            return TypeWiseReportView;
        }

        public List<unPaidBillCheck> GetUnpaidBillReportList(string fromDate, string toDate)
        {
            qry = "SELECT p.PatientId AS BillNo, Name, MobileNo, BillAmount, COUNT(*) " +
                    "FROM PatientInfo AS p LEFT JOIN TestRequest AS tr " +
                    "ON p.PatientId=tr.PatientId " +
                    "WHERE PaymentStatus='0' AND tr.EntryDate BETWEEN '" + fromDate + "' AND '" + toDate + "' " +
                    "GROUP BY p.PatientId, Name, MobileNo, BillAmount";
            List<unPaidBillCheck> UP_B_CheckList = new List<unPaidBillCheck>();
            sqlCommand = new SqlCommand(qry, sqlCon);
            sqlCon.Open();
            sqlReader = sqlCommand.ExecuteReader();
            while (sqlReader.Read())
            {
                unPaidBillCheck up_B_Check = new unPaidBillCheck();
                up_B_Check.BillNo = sqlReader["BillNo"].ToString();
                up_B_Check.Name = sqlReader["Name"].ToString();
                up_B_Check.MobileNo = sqlReader["MobileNo"].ToString();
                up_B_Check.BillAmount = sqlReader["BillAmount"].ToString();
                UP_B_CheckList.Add(up_B_Check);
            }
            sqlReader.Close();
            sqlCon.Close();
            return UP_B_CheckList;
        }
    }
}