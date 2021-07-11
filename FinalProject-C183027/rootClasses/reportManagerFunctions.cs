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

        public List<testWiseReport> GetTestWiseReport(string fromDate, string toDate)
        {
            return report_DB.GetTestWiseReport(fromDate, toDate);
        }



        public List<typeWiseReport> GetTypeWiseReport(string fromDate, string toDate)
        {
            return report_DB.GetTypeWiseReport(fromDate, toDate);
        }



        public List<unPaidBillCheck> GetUnpaidBillReportView(string fromDate, string toDate)
        {
            return report_DB.GetUnpaidBillReportList(fromDate, toDate);
        }
    }
}