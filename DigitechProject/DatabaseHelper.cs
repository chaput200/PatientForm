/*
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitechProject
{
    using System;
    using System.Configuration;
    using System.Data;
    using System.Data.SqlClient;

    public static class DatabaseHelper
    {
        

        //METHOD FOR GETTING PATIENT OBJ BY KEY
        public static Patient GetPatientByKey(Guid patientKey)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["PatientDB"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM Patient WHERE PatientKEY = @PatientKEY", conn);
                cmd.Parameters.AddWithValue("@PatientKEY", patientKey);
                conn.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    return new Patient
                    {
                        PatientKEY = (Guid)reader["PatientKEY"],
                        FirstName = reader["FirstName"].ToString(),
                        LastName = reader["LastName"].ToString(),
                        MiddleInitial = reader["MiddleInitial"].ToString(),
                        Address1 = reader["Address1"].ToString(),
                        Address2 = reader["Address2"].ToString(),
                        City = reader["City"].ToString(),
                        State = reader["State"].ToString(),
                        ZipCode = reader["ZipCode"].ToString(),
                        HomePhone = reader["HomePhone"].ToString(),
                        BusineesPhone = reader["BusineesPhone"].ToString(),
                        CellPhone = reader["CellPhone"].ToString(),
                        EmailAddress = reader["EmailAddress"].ToString()
                    };
                }
                return null;
            }
        }


        public static void CreatePatient(Patient patient)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["PatientDB"].ConnectionString;
            //using (SqlConnection conn = new SqlConnection(connectionString))

            using (var conn = new SqlConnection("Server=localhost\\SQLEXPRESS;Database=DigitechTestDB;Integrated Security=True;"))
            using (SqlCommand cmd = new SqlCommand("dbo.CreatePatient", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                // Assign a new GUID for the PatientKEY
                Guid newPatientKey = Guid.NewGuid();
                cmd.Parameters.AddWithValue("@PatientKEY", newPatientKey);

                // Assign the GUID to the object in case it's used later (e.g., returned to the UI)
                patient.PatientKEY = newPatientKey;

                cmd.Parameters.AddWithValue("@LastName", patient.LastName);
                cmd.Parameters.AddWithValue("@FirstName", patient.FirstName);
                cmd.Parameters.AddWithValue("@MiddleInitial", patient.MiddleInitial);
                cmd.Parameters.AddWithValue("@Address1", patient.Address1);
                cmd.Parameters.AddWithValue("@Address2", patient.Address2);
                cmd.Parameters.AddWithValue("@City", patient.City);
                cmd.Parameters.AddWithValue("@State", patient.State);
                cmd.Parameters.AddWithValue("@ZipCode", patient.ZipCode);
                cmd.Parameters.AddWithValue("@HomePhone", patient.HomePhone);
                cmd.Parameters.AddWithValue("@BusineesPhone", patient.BusineesPhone);
                cmd.Parameters.AddWithValue("@CellPhone", patient.CellPhone);
                cmd.Parameters.AddWithValue("@EmailAddress", patient.EmailAddress);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public static void UpdatePatient(Patient patient)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["PatientDB"].ConnectionString;

            using (var conn = new SqlConnection("Server=localhost\\SQLEXPRESS;Database=DigitechTestDB;Integrated Security=True;"))
            //using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand("dbo.UpdatePatient", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@PatientKEY", patient.PatientKEY);
                cmd.Parameters.AddWithValue("@LastName", patient.LastName);
                cmd.Parameters.AddWithValue("@FirstName", patient.FirstName);
                cmd.Parameters.AddWithValue("@MiddleInitial", patient.MiddleInitial);
                cmd.Parameters.AddWithValue("@Address1", patient.Address1);
                cmd.Parameters.AddWithValue("@Address2", patient.Address2);
                cmd.Parameters.AddWithValue("@City", patient.City);
                cmd.Parameters.AddWithValue("@State", patient.State);
                cmd.Parameters.AddWithValue("@ZipCode", patient.ZipCode);
                cmd.Parameters.AddWithValue("@HomePhone", patient.HomePhone);
                cmd.Parameters.AddWithValue("@BusineesPhone", patient.BusineesPhone);
                cmd.Parameters.AddWithValue("@CellPhone", patient.CellPhone);
                cmd.Parameters.AddWithValue("@EmailAddress", patient.EmailAddress);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // You can also add GetAllPatients() and GetPatientByKey(Guid id) if needed.
    }

}
*/

using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace DigitechProject
{
    public static class DatabaseHelper
    {
        // METHOD FOR GETTING PATIENT OBJ BY KEY
        public static Patient GetPatientByKey(Guid patientKey)
        {
            //var connectionString = ConfigurationManager.ConnectionStrings["PatientDB"].ConnectionString;

            var connectionString = ConfigurationManager.ConnectionStrings["PatientDB"].ConnectionString;
            using (var conn = new SqlConnection("Server=localhost\\SQLEXPRESS;Database=DigitechTestDB;Integrated Security=True;"))
            //using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.Patients WHERE PatientKEY = @PatientKEY", conn);
                cmd.Parameters.AddWithValue("@PatientKEY", patientKey);
                conn.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    return new Patient
                    {
                        PatientKEY = (Guid)reader["PatientKEY"],
                        FirstName = reader["FirstName"].ToString(),
                        LastName = reader["LastName"].ToString(),
                        MiddleInitial = reader["MiddleInitial"].ToString(),
                        Address1 = reader["Address1"].ToString(),
                        Address2 = reader["Address2"].ToString(),
                        City = reader["City"].ToString(),
                        State = reader["State"].ToString(),
                        ZipCode = reader["ZipCode"].ToString(),
                        HomePhone = reader["HomePhone"].ToString(),
                        BusineesPhone = reader["BusineesPhone"].ToString(),
                        CellPhone = reader["CellPhone"].ToString(),
                        EmailAddress = reader["EmailAddress"].ToString()
                    };
                }
                return null;
            }
        }

        public static void CreatePatient(Patient patient)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["PatientDB"].ConnectionString;

            //using (var conn = new SqlConnection(connectionString))
            using (var conn = new SqlConnection("Server=localhost\\SQLEXPRESS;Database=DigitechTestDB;Integrated Security=True;"))
            using (SqlCommand cmd = new SqlCommand("dbo.CreatePatient", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                Guid newPatientKey = Guid.NewGuid();
                cmd.Parameters.AddWithValue("@PatientKEY", newPatientKey);
                patient.PatientKEY = newPatientKey;

                cmd.Parameters.AddWithValue("@LastName", patient.LastName);
                cmd.Parameters.AddWithValue("@FirstName", patient.FirstName);
                cmd.Parameters.AddWithValue("@MiddleInitial", patient.MiddleInitial);
                cmd.Parameters.AddWithValue("@Address1", patient.Address1);
                cmd.Parameters.AddWithValue("@Address2", patient.Address2);
                cmd.Parameters.AddWithValue("@City", patient.City);
                cmd.Parameters.AddWithValue("@State", patient.State);
                cmd.Parameters.AddWithValue("@ZipCode", patient.ZipCode);
                cmd.Parameters.AddWithValue("@HomePhone", patient.HomePhone);
                cmd.Parameters.AddWithValue("@BusinessPhone", patient.BusineesPhone);
                cmd.Parameters.AddWithValue("@CellPhone", patient.CellPhone);
                cmd.Parameters.AddWithValue("@EmailAddress", patient.EmailAddress);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public static void UpdatePatient(Patient patient)
        {

            var connectionString = ConfigurationManager.ConnectionStrings["PatientDB"].ConnectionString;
            using (var conn = new SqlConnection("Server=localhost\\SQLEXPRESS;Database=DigitechTestDB;Integrated Security=True;"))
            //using (var conn = new SqlConnection(connectionString))
            //using (SqlCommand cmd = new SqlCommand("dbo.UpdatePatient", conn))
            using (SqlCommand cmd = new SqlCommand("dbo.UpdatePatient", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@PatientKEY", patient.PatientKEY);
                cmd.Parameters.AddWithValue("@LastName", patient.LastName);
                cmd.Parameters.AddWithValue("@FirstName", patient.FirstName);
                cmd.Parameters.AddWithValue("@MiddleInitial", patient.MiddleInitial);
                cmd.Parameters.AddWithValue("@Address1", patient.Address1);
                cmd.Parameters.AddWithValue("@Address2", patient.Address2);
                cmd.Parameters.AddWithValue("@City", patient.City);
                cmd.Parameters.AddWithValue("@State", patient.State);
                cmd.Parameters.AddWithValue("@ZipCode", patient.ZipCode);
                cmd.Parameters.AddWithValue("@HomePhone", patient.HomePhone);
                cmd.Parameters.AddWithValue("@BusinessPhone", patient.BusineesPhone);
                cmd.Parameters.AddWithValue("@CellPhone", patient.CellPhone);
                cmd.Parameters.AddWithValue("@EmailAddress", patient.EmailAddress);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}