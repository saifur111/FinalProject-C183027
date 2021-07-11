using FinalProject_C183027.get_set_Classes;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace FinalProject_C183027.databaseController
{
    public class testDB:dbConnection
    {
        //---------------------------------------- Test Type Setup Page-------------------------------------


        // Here Check test Type value testTypeSetup page textbox...... if Condition
        public bool TestTypeCheck(testType object_TestType)
        {
            qry = "SELECT * FROM TestType WHERE TestType = '" + object_TestType.testType_get_set_class_testTypeName + "'";// get value text input typeNameInput.Text..
            sqlCommand = new SqlCommand(qry, sqlCon);
            sqlCon.Open();
            sqlReader = sqlCommand.ExecuteReader();
            bool typeNameIsExists = sqlReader.HasRows;
            sqlReader.Close();
            sqlCon.Close();
            return typeNameIsExists; // return true or false
        }

        //---------------------------------------------------------------------------------------------------
        // HereSave testType value testTypeSetup page textbox......else Condition.
        public int TestTypeSave(testType object_TestType)
        {
            qry = "INSERT INTO TestType (TestType) VALUES ('" + object_TestType.testType_get_set_class_testTypeName + "')";
            sqlCommand = new SqlCommand(qry, sqlCon);
            sqlCon.Open();
            int rowAffected = sqlCommand.ExecuteNonQuery();
            sqlCon.Close();
            return rowAffected;
        }

        //---------------------------------------------------------------------------------------------------

        //here create a list for table view  data test type setup .......
        public List<testType> GetAllTestTypes()
        {
            qry = "SELECT * FROM TestType";
            sqlCommand = new SqlCommand(qry, sqlCon);
            sqlCon.Open();
            sqlReader = sqlCommand.ExecuteReader();

            List<testType> testTypesList_object = new List<testType>();
            // here read table value database for wesite table.........
            while (sqlReader.Read())
            {
                testType object_TestType = new testType();
                object_TestType.testType_get_set_class_testTypeId = (int)sqlReader["TestTypeId"];

                object_TestType.testType_get_set_class_testTypeName = sqlReader["TestType"].ToString();

                testTypesList_object.Add(object_TestType);
            }

            sqlReader.Close();
            sqlCon.Close();
            return testTypesList_object;
        }
        //---------------------------------------------------------------------------------------------------




        //---------------------------------------- Test Setup Page-------------------------------------

        // save test in database for Test setUp page.......
        public int TestSave(test object_Test)
        {
            qry = "INSERT INTO Test (TestName, Fee, TestTypeId) VALUES ('" + object_Test.test_get_set_class_TestName + "','" + object_Test.test_get_set_class_Fee + "','" + object_Test.test_get_set_class_TestTypeId + "')";
            sqlCommand = new SqlCommand(qry, sqlCon);
            sqlCon.Open();
            int rowAffected = sqlCommand.ExecuteNonQuery();
            sqlCon.Close();
            return rowAffected;
        }
        //---------------------------------------------------------------------------------------------------
        //Test Check  founction here...............
        public bool TestCheck(test object_Test)
        {
            qry = "SELECT * FROM Test WHERE TestName = '" + object_Test.test_get_set_class_TestName + "'";
            sqlCommand = new SqlCommand(qry,sqlCon);
            sqlCon.Open();
            sqlReader = sqlCommand.ExecuteReader();
            bool testNameExists = sqlReader.HasRows;
            sqlReader.Close();
            sqlCon.Close();
            return testNameExists;
        }

        //---------------------------------------------------------------------------------------------------
        //Get all Test form list founction here...............
        public List<test> GetAllTest()
        {
           qry = "SELECT TestId, TestName, Fee, TestType FROM Test JOIN " +
                "TestType ON Test.TestTypeId=TestType.TestTypeId ORDER BY TestName ASC";
            sqlCommand = new SqlCommand(qry, sqlCon);
            sqlCon.Open();
            sqlReader = sqlCommand.ExecuteReader();

            List<test> testList = new List<test>();
            while (sqlReader.Read())
            {
                test object_Test = new test();
                object_Test.test_get_set_class_TestId = (int)sqlReader["TestId"];// Databease test table  TestID value here
                
                object_Test.test_get_set_class_TestName = sqlReader["TestName"].ToString(); //Databease test table TestName value here
                
                object_Test.test_get_set_class_Fee = Convert.ToDouble(sqlReader["Fee"]); //Databease test table  fee value here
               
                object_Test.test_get_set_class_TestType = sqlReader["TestType"].ToString();//Databease test table  TestType value here

                object_Test.test_get_set_class_TestId = (int)sqlReader["TestId"];

                object_Test.test_get_set_class_TestName = sqlReader["TestName"].ToString();

                object_Test.test_get_set_class_Fee = Convert.ToDouble(sqlReader["Fee"]);

                object_Test.test_get_set_class_TestType = sqlReader["TestType"].ToString();

                testList.Add(object_Test);
            }
            sqlReader.Close();
            sqlCon.Close();
            return testList;
        }
        //---------------------------------------------------------------------------------------------------



    }
}