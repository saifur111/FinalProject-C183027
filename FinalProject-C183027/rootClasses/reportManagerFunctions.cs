using FinalProject_C183027.databaseController;
using FinalProject_C183027.get_set_Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalProject_C183027.rootClasses
{
    public class reportManagerFunctions
    {
        reportDB report_DB = new reportDB();

        public List<testWiseReport> GetTestWiseReportView(string fromDate, string toDate)
        {
            return report_DB.GetTestWiseReportView(fromDate, toDate);
        }



        public List<typeWiseReport> GetTypeWiseReportView(string fromDate, string toDate)
        {
            return report_DB.GetTypeWiseReportView(fromDate, toDate);
        }



        public List<unPaidBillCheck> GetUnpaidBillReportView(string fromDate, string toDate)
        {
            return report_DB.GetUnpaidBillReportList(fromDate, toDate);
        }
    }
}