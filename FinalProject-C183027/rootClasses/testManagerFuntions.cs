using FinalProject_C183027.databaseController;
using FinalProject_C183027.get_set_Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalProject_C183027.rootClasses
{
    public class testManagerFuntions
    {
        testDB object_TestDatabase = new testDB();

        //--------------------------------TEST-TYPE-SETUP Page Function-----------------------------------------------------------

        // Here testTypesave function which was called by testTypeSetup Page......
        public string TestTypeSave(testType object_testType)
        {
            if (object_TestDatabase.TestTypeCheck(object_testType))
                return "Type Name is Already Saved !";
            else
                {
                int rowAffected = object_TestDatabase.TestTypeSave(object_testType);
                if (rowAffected > 0)
                    return "Type Setup Data Successfully Saved.";
                else
                    return "Type Setup Data Saving Failed !";
            }
        }

        //---------------------------------------------------------------------------------------------------
        
        // Here testTypesave list function which was called by testTypeSetup Page......
        public List<testType> GetAllTestTypes()
        {
            return object_TestDatabase.GetAllTestTypes();
        }

        //------------------------------------------------ END ---------------------------------------------------




        //--------------------------------TEST-SETUP Page Function-----------------------------------------------------------

        // Here testsave function which was called by TestSetup Page......
        public string TestSave(test object_Test)
        {
            if (object_TestDatabase.TestCheck(object_Test))
                return "Test Name is Already Saved !";
            else
            {
                int rowAffected =object_TestDatabase.TestSave(object_Test);
                if (rowAffected > 0)
                    return "Test Saved.";
                else
                    return "Test Name Save Failed !";
            }
        }

        //---------------------------------------------------------------------------------------------------
        // Here GetAllTest list function which was called by TestSetup Page......
        public List<test> GetAllTest()
        {
            return object_TestDatabase.GetAllTest();
        }
        //---------------------------------------------------- END -----------------------------------------------
    }
}