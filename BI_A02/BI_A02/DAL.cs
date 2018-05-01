/*
*   FILENAME: DAL
*   PROJECT: BI_A02
*   PROGRAMMER: Jody Markic
*   FIRST VERSION: 10/2/2017
*   DESCRIPTION: This files holds all the data access to the database yoyoProduction.
*                Here is where all stored procedures that Insert and retrieve values from the database
*                are held.
*
*/
using System;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace BI_A02
{
    //
    // CLASS: DAL
    // DESCRIPTION: This class hold all stored procedures responsible for inserting and retrieving data from yoyoProduction
    //
    class DAL
    {
        //local variable
        private SqlConnection mySQLConnection = new System.Data.SqlClient.SqlConnection(ConfigurationManager.ConnectionStrings["DALstring"].ConnectionString);

        //
        //  METHOD      : OpenConnection
        //  DESCRIPTION : open connection to database
        //  PARAMETERS  : na
        //  RETURNS     : void
        //
        public void OpenConnection()
        {
            mySQLConnection.Open();
        }

        //
        //  METHOD      : CloseConnection
        //  DESCRIPTION : close connection to database
        //  PARAMETERS  : na
        //  RETURNS     : void
        //
        public void CloseConnection()
        {
            mySQLConnection.Close();
        }

        //
        //  METHOD      : GetData
        //  DESCRIPTION : provide a procedure and get a return value
        //  PARAMETERS  : procedureName
        //  RETURNS     : void
        //
        public int GetData(string procedureName)
        {
            //create command object with a connection to yoyoProduction
            //and provide it a procedure name
            int returnedValue = 0;
            SqlCommand mySQLCommand = new SqlCommand(
              procedureName, mySQLConnection);

            mySQLCommand.CommandType = System.Data.CommandType.StoredProcedure;
            //open a connection
            mySQLConnection.Open();

            //read data
            SqlDataReader myReader = mySQLCommand.ExecuteReader();

            //store data into a return value
            while (myReader.Read())
            {
                returnedValue = int.Parse(myReader[0].ToString());
            }
            mySQLConnection.Close();

            return returnedValue;
        }

        //
        //  METHOD      : GetData
        //  DESCRIPTION : provide a procedure and productID and get a return value
        //  PARAMETERS  : procedureName
        //  RETURNS     : void
        //
        public int GetData(string procedureName, int productID)
        {
            //create command object with a connection to yoyoProduction
            //and provide it a procedure name
            int returnedValue = 0;
            SqlCommand mySQLCommand = new SqlCommand(
              procedureName, mySQLConnection);

            //add the  parameters
            mySQLCommand.CommandType = System.Data.CommandType.StoredProcedure;
            mySQLCommand.Parameters.Add("@productID", SqlDbType.Int).Value = productID;
            //open a connection
            mySQLConnection.Open();

            //execute reader
            SqlDataReader myReader = mySQLCommand.ExecuteReader();


            //store return value into returned value
            while (myReader.Read())
            {
                returnedValue = int.Parse(myReader[0].ToString());
            }
            mySQLConnection.Close();

            return returnedValue;
        }


        //
        //  METHOD      : InsertToProduction
        //  DESCRIPTION : insert values read in from the Q to yoyoProduction's Production table
        //  PARAMETERS  : procedureName
        //  RETURNS     : void
        //
        public void InsertToProduction(string newRecord)
        {
            //local variables
            string workArea;
            string serialNumber;
            string line;
            string state;
            string reason;
            DateTime dateTime;
            int productID;

            //split the record
            string[] splitRecord = newRecord.Split(',');

            workArea = splitRecord[0];
            serialNumber = splitRecord[1];
            line = splitRecord[2];
            state = splitRecord[3];
            reason = splitRecord[4];
            dateTime = Convert.ToDateTime(splitRecord[5]);
            productID = Int32.Parse(splitRecord[6]);

            //open a connection
            mySQLConnection.Open();

            //create a command object with a stored procedure and connection object
            SqlCommand mySQLCommand = new SqlCommand(
                "InsertToProduction", mySQLConnection);

            mySQLCommand.CommandType = CommandType.StoredProcedure;
            //add values in as parameters
            mySQLCommand.Parameters.AddWithValue("@workArea", workArea);
            mySQLCommand.Parameters.AddWithValue("@serialNumber", serialNumber);
            mySQLCommand.Parameters.AddWithValue("@line", line);
            mySQLCommand.Parameters.AddWithValue("@state", state);
            mySQLCommand.Parameters.AddWithValue("@reason", reason);
            mySQLCommand.Parameters.AddWithValue("@dateTime", dateTime);
            mySQLCommand.Parameters.AddWithValue("@productID", productID);

            //execute the non query
            int result = mySQLCommand.ExecuteNonQuery();
            //close the connection
            mySQLConnection.Close();
        }
    }
}
