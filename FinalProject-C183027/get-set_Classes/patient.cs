using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalProject_C183027.get_set_Classes
{
    public class patient
    {
        public int PatientId { get; set; }
        public string Name { get; set; }
        public string DateOfBirth { get; set; }
        public string MobileNo { get; set; }
        public double BillAmount { get; set; }
        public int PaymentStatus { get; set; }
    }
}