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
            qry = "SELECT * FROM TestType WHERE TestType = '" + object_TestType.TestTypeName + "'";
            sqlCommand = new SqlCommand(qry, sqlCon);
            sqlCon.Open();
            sqlReader = sqlCommand.ExecuteReader();
            bool typeNameIsExists = sqlReader.HasRows;
            sqlReader.Close();
            sqlCon.Close();
            return typeNameIsExists;
        }

        //---------------------------------------------------------------------------------------------------
        // HereSave testType value testTypeSetup page textbox......else Condition.
        public int TestTypeSave(testType object_TestType)
        {
            qry = "INSERT INTO TestType (TestType) VALUES ('" + object_TestType.TestTypeName + "')";
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

            List<testType> testTypes = new List<testType>();
            // here read table value database for wesite table.........
            while (sqlReader.Read())
            {
                testType object_TestType = new testType();
                object_TestType.TestTypeId = (int)sqlReader["TestTypeId"];
                object_TestType.TestTypeName = sqlReader["TestType"].ToString();
                testTypes.Add(object_TestType);
            }

            sqlReader.Close();
            sqlCon.Close();
            return testTypes;
        }
        //---------------------------------------------------------------------------------------------------


        //---------------------------------------- Test Type Setup Page-------------------------------------

        // save test in database for Test setUp page.......
        public int TestSave(test object_Test)
        {
            qry = "INSERT INTO Test (TestName, Fee, TestTypeId) VALUES ('" + object_Test.TestName + "','" + object_Test.Fee + "','" + object_Test.TestTypeId + "')";
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
            qry = "SELECT * FROM Test WHERE TestName = '" + object_Test.TestName + "'";
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
           qry = "SELECT TestId, TestName, Fee, TestType FROM Test JOIN TestType ON Test.TestTypeId=TestType.TestTypeId ORDER BY TestName ASC";
            sqlCommand = new SqlCommand(qry, sqlCon);
            sqlCon.Open();
            sqlReader = sqlCommand.ExecuteReader();

            List<test> testList = new List<test>();
            while (sqlReader.Read())
            {
                test object_Test = new test();
                object_Test.TestId = (int)sqlReader["TestId"];// Databease test table  TestID value here
                object_Test.TestName = sqlReader["TestName"].ToString(); //Databease test table TestName value here
                object_Test.Fee = Convert.ToDouble(sqlReader["Fee"]); //Databease test table  fee value here
                object_Test.TestType = sqlReader["TestType"].ToString();//Databease test table  TestType value here

                object_Test.TestId = (int)sqlReader["TestId"];
                object_Test.TestName = sqlReader["TestName"].ToString();
                object_Test.Fee = Convert.ToDouble(sqlReader["Fee"]);
                object_Test.TestType = sqlReader["TestType"].ToString();

                testList.Add(object_Test);
            }
            sqlReader.Close();
            sqlCon.Close();
            return testList;
        }
        //---------------------------------------------------------------------------------------------------



    }
}