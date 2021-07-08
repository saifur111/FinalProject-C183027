using FinalProject_C183027.databaseController;
using FinalProject_C183027.get_set_Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalProject_C183027.rootClasses
{
    
    public class testRequestManagerFunctions
    {
        testRequestDB TestRequestDatabase = new testRequestDB();
        public string SavePatient(patient obj_patient)
        {
            if (TestRequestDatabase.CheckPatient(obj_patient))
            {
                return "Please use another Mobile Number!";
            }
            else
            {
                int rowAffacted = TestRequestDatabase.SavePatient(obj_patient);
                if (rowAffacted > 0)
                    return "Patient Information Saved.";
                else
                    return "Sorry, Patient Information failed to Saved!";
            }
        }
        //-----------------------------------------------------------
        
        //For text Request enter page Index change Function
   
        public string GetFee(int TestId)
        {
            return TestRequestDatabase.GetFee(TestId);
        }

        //-----------------------------------------------------------
        public int GetPatientId(string mobileNo)
        {
            return TestRequestDatabase.GetPatientId(mobileNo);
        }
        //------------------------------------------------------------

        public string SaveTestRequest(testRequest TestRequest)
        {
            int rowAffacted = TestRequestDatabase.SaveTestRequest(TestRequest);
            if (rowAffacted > 0)
                return "Test Request Saved";
            else
                return "Sorry, Test Request failed to Saved !";
        }
        //------------------------------------------------------------
    }
}