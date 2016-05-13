using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Web;
using System.Web.UI.WebControls;

namespace Employee3.App_Code
{
    public class EmployeeDBAccess
    {
        public static DataTable getDropDownData(string tblName)
        {
            try
            {
                SqlCommand CMD = new SqlCommand();
                CMD.Connection = EmployeeMGRConfig.GetConnection();
                CMD.CommandType = CommandType.Text;
                CMD.CommandText = "Select * From " + tblName;
                SqlDataAdapter SDA = new SqlDataAdapter(CMD);
                DataTable DT = new DataTable();
                SDA.Fill(DT);
                EmployeeMGRConfig.GetConnection().Dispose();
                CMD.Connection.Dispose();
                CMD = null;
                SDA.Dispose();
                return DT;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
            finally
            {
                EmployeeMGRConfig.GetConnection().Close();
            }
        }

        public static DataTable getEmployeeForFront()
        {
            string SQL = "sp_get_Employee_ForFront";

            try
            {
                SqlConnection con = EmployeeMGRConfig.GetConnection();
                SqlCommand CMD = new SqlCommand(SQL, con);

                CMD.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter SDA = new SqlDataAdapter(CMD);
                DataTable DT = new DataTable();
                SDA.Fill(DT);
                CMD.Connection.Dispose();
                CMD = null;
                SDA.Dispose();
                return DT;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
            finally
            {
                EmployeeMGRConfig.GetConnection().Close();
            }
        }

        public static DataTable GetAllEmployee()
        {
            string SQL = "sp_get_Employee";

            try
            {
                SqlConnection con = EmployeeMGRConfig.GetConnection();
                SqlCommand CMD = new SqlCommand(SQL, con);

                CMD.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter SDA = new SqlDataAdapter(CMD);
                DataTable DT = new DataTable();
                SDA.Fill(DT);
                CMD.Connection.Dispose();
                CMD = null;
                SDA.Dispose();
                return DT;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
            finally
            {
                EmployeeMGRConfig.GetConnection().Close();
            }




        }
        public static DataTable getDropDownData(string tblFields, string tblName, string whereCond)
        {
            try
            {
                SqlCommand CMD = new SqlCommand();
                CMD.Connection = EmployeeMGRConfig.GetConnection();
                CMD.CommandType = CommandType.Text;
                CMD.CommandText = "Select " + tblFields + " From " + tblName + " where " + whereCond;
                SqlDataAdapter SDA = new SqlDataAdapter(CMD);
                DataTable DT = new DataTable();
                SDA.Fill(DT);
                EmployeeMGRConfig.GetConnection().Dispose();
                CMD.Connection.Dispose();
                CMD = null;
                SDA.Dispose();
                return DT;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
            finally
            {
                EmployeeMGRConfig.GetConnection().Close();
            }
        }

        public static int saveDataIntblEmployee(tblEmployee tblEmployeeClass)
        {

            string storeProcedureName = "sp_Insert_Employee";
            try
            {
                int rowAffected = 0;
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = EmployeeMGRConfig.GetConnection();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = storeProcedureName;

                    cmd.Parameters.AddWithValue("@fldEmployeeID", tblEmployeeClass.fldEmployeeID);
                    cmd.Parameters.AddWithValue("@fldFirstName", tblEmployeeClass.fldFirstName);
                    cmd.Parameters.AddWithValue("@fldMiddleName", tblEmployeeClass.fldMiddleName);
                    cmd.Parameters.AddWithValue("@fldLastName", tblEmployeeClass.fldLastName);
                    cmd.Parameters.AddWithValue("@fldGender", tblEmployeeClass.fldGender);
                    cmd.Parameters.AddWithValue("@fldDob", tblEmployeeClass.fldDob);
                    cmd.Parameters.AddWithValue("@fldPhoneNo", tblEmployeeClass.fldPhoneNo);
                    cmd.Parameters.AddWithValue("@fldMobileNo", tblEmployeeClass.fldMobileNo);
                    cmd.Parameters.AddWithValue("@fldFaxNo", tblEmployeeClass.fldFaxNo);
                    cmd.Parameters.AddWithValue("@fldPersonalEmail", tblEmployeeClass.fldPersonalEmail);
                    cmd.Parameters.AddWithValue("@fldOfficialEmail", tblEmployeeClass.fldOfficialEmail);
                    cmd.Parameters.AddWithValue("@fldAddress", tblEmployeeClass.fldAddress);
                    cmd.Parameters.AddWithValue("@fldDistrict", tblEmployeeClass.fldDistrict);
                    cmd.Parameters.AddWithValue("@fldCitizenshipNo", tblEmployeeClass.fldCitizenshipNo);
                    cmd.Parameters.AddWithValue("@fldCitizenshipIssuedDate", tblEmployeeClass.fldCitizenshipIssuedDate);
                    cmd.Parameters.AddWithValue("@fldCitzenshipIssuedDistrict", tblEmployeeClass.fldCitzenshipIssuedDistrict);
                    cmd.Parameters.AddWithValue("@fldDateofJoin", tblEmployeeClass.fldDateofJoin);
                    cmd.Parameters.AddWithValue("@fldDateofPermanent", tblEmployeeClass.fldDateofPermanent);
                    cmd.Parameters.AddWithValue("@fldDateofRetirement", tblEmployeeClass.fldDateofRetirement);
                    cmd.Parameters.AddWithValue("@fldMaritalStatus", tblEmployeeClass.fldMaritalStatus);
                    cmd.Parameters.AddWithValue("@fldChildBoy", tblEmployeeClass.fldChildBoy);
                    cmd.Parameters.AddWithValue("@fldLeaveHome", tblEmployeeClass.fldLeaveHome);
                    cmd.Parameters.AddWithValue("@fldLeaveSick", tblEmployeeClass.fldLeaveSick);
                    cmd.Parameters.AddWithValue("@fldIsActive", tblEmployeeClass.fldIsActive);
                    cmd.Parameters.AddWithValue("@fldCreatedBy", tblEmployeeClass.fldCreatedBy);
                    cmd.Parameters.AddWithValue("@fldCreatedDate", tblEmployeeClass.fldCreatedDate);
                    cmd.Parameters.AddWithValue("@fldUpdatedBy", tblEmployeeClass.fldUpdatedBy);
                    cmd.Parameters.AddWithValue("@fldUpdatedDate", tblEmployeeClass.fldUpdatedDate);
                    cmd.Parameters.AddWithValue("@fldNote", tblEmployeeClass.fldNote);

                    rowAffected = int.Parse(cmd.ExecuteScalar().ToString());
                }
                return rowAffected;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
            finally
            {
                EmployeeMGRConfig.GetConnection().Close();
            }


        }

        public tblEmployee getEmployee(int empID)
        {

            tblEmployee emp = new tblEmployee();
            string storeProcedureName = "sp_Insert_Employee";
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = EmployeeMGRConfig.GetConnection();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = storeProcedureName;

                cmd.Parameters.AddWithValue("@fldEmployeeID", empID);
                int result = cmd.ExecuteNonQuery();
                cmd.Connection.Close();
                //cmd = null;


            }
            return emp;
        }

        //public static DataTable GetFamily()
        //{

        //}
        public static int RegisterEmployee(tblEmployee employee)
        {
            string SQL = "sp_Insert_Employee";
            try
            {
                int rowAffected = 0;
                using (SqlCommand CMD = new SqlCommand())
                {
                    CMD.Connection = EmployeeMGRConfig.GetConnection();
                    CMD.CommandType = CommandType.StoredProcedure;
                    CMD.CommandText = SQL;

                    CMD.Parameters.AddWithValue("@fldFirstName", employee.fldFirstName);
                    CMD.Parameters.AddWithValue("@fldMiddleName", employee.fldMiddleName);
                    CMD.Parameters.AddWithValue("@fldLastName", employee.fldLastName);
                    CMD.Parameters.AddWithValue("@fldMobileNo", employee.fldMobileNo);
                    CMD.Parameters.AddWithValue("@fldPersonalEmail", employee.fldPersonalEmail);
                    rowAffected = Convert.ToInt32(CMD.ExecuteScalar());
                    CMD.Connection.Close();
                }
                return rowAffected;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
            finally
            {
                EmployeeMGRConfig.GetConnection().Close();
            }

        }
        public static int saveDataIntblDocument(tblDocument tblDocument)
        {

            string storeProcedureName = "sp_Insert_Document";
            try
            {
                int rowAffected = 0;
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = EmployeeMGRConfig.GetConnection();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = storeProcedureName;

                    cmd.Parameters.AddWithValue("@fldEmployeeID", tblDocument.fldEmployeeID);

                    cmd.Parameters.AddWithValue("@CitizenshipCopy", tblDocument.fldCitizenshipCopy);
                    cmd.Parameters.AddWithValue("@PpPhoto", tblDocument.fldPpPhoto);
                    cmd.Parameters.AddWithValue("@Document", tblDocument.fldDocument);

                    cmd.Parameters.AddWithValue("@fldNote", tblDocument.fldNote);

                    rowAffected = int.Parse(cmd.ExecuteScalar().ToString());
                }
                return rowAffected;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
            finally
            {
                EmployeeMGRConfig.GetConnection().Close();
            }


        }

        public static DataTable GetBirthdayThisweek(int noofDaysinmonth, int bMonth, int bfDay, int blDay)
        {
            string storeProcedureName = "sp_get_BirthdyThisWeek_TwoMonths";
            try
            {
                DataTable dt = new DataTable();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = EmployeeMGRConfig.GetConnection();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = storeProcedureName;
                    cmd.Parameters.AddWithValue("@DaysMonth", bMonth);
                    cmd.Parameters.AddWithValue("@Month", bMonth);
                    cmd.Parameters.AddWithValue("@startDay", bfDay);
                    cmd.Parameters.AddWithValue("@endDay", blDay);
                    SqlDataAdapter SDA = new SqlDataAdapter(cmd);
                    SDA.Fill(dt);
                    SDA.Dispose();
                }
                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
            finally
            {
                EmployeeMGRConfig.GetConnection().Close();
            }

        }

        public static DataTable GetBirthdayThisweek(int bMonth, int bfDay, int blDay)
        {
            string storeProcedureName = "sp_get_BirthdyThisWeek";
            try
            {
                DataTable dt = new DataTable();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = EmployeeMGRConfig.GetConnection();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = storeProcedureName;

                    cmd.Parameters.AddWithValue("@Month", bMonth);
                    cmd.Parameters.AddWithValue("@startDay", bfDay);
                    cmd.Parameters.AddWithValue("@endDay", blDay);
                    SqlDataAdapter SDA = new SqlDataAdapter(cmd);
                    SDA.Fill(dt);
                    SDA.Dispose();
                }
                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
            finally
            {
                EmployeeMGRConfig.GetConnection().Close();
            }


        }


        public static DataTable GetWorkWithinThisWeek(DateTime sow, DateTime eow)
        {
            string storeProcedureName = "sp_get_WorkThisWeek";
            try
            {
                DataTable dt = new DataTable();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = EmployeeMGRConfig.GetConnection();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = storeProcedureName;

                    cmd.Parameters.AddWithValue("@sow", sow);
                    cmd.Parameters.AddWithValue("@eow", eow);
                    SqlDataAdapter SDA = new SqlDataAdapter(cmd);
                    SDA.Fill(dt);
                    SDA.Dispose();
                }
                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
            finally
            {
                EmployeeMGRConfig.GetConnection().Close();
            }

        }

        public static DataTable GetEmployeeListAllReport()
        {
            string storeProcedureName = "sp_get_employeeDetails_ReportAll";
            try
            {
                DataTable dt = new DataTable();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = EmployeeMGRConfig.GetConnection();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = storeProcedureName;
                    SqlDataAdapter SDA = new SqlDataAdapter(cmd);
                    SDA.Fill(dt);
                    SDA.Dispose();
                }
                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
            finally
            {
                EmployeeMGRConfig.GetConnection().Close();
            }

        }

        public static DataSet GetEmployeeIndividualReport(int employeeID)
        {
            string storeProcedureName = "sp_get_employeeDetails_ReportIndividual";
            try
            {
                DataSet Ds = new DataSet();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = EmployeeMGRConfig.GetConnection();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = storeProcedureName;
                    cmd.Parameters.AddWithValue("@EmployeeId", employeeID);
                    SqlDataAdapter SDA = new SqlDataAdapter(cmd);
                    SDA.Fill(Ds);
                    SDA.Dispose();
                }
                return Ds;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
            finally
            {
                EmployeeMGRConfig.GetConnection().Close();
            }

        }

        public static DataTable GetTraining(int empID)
        {
            DataTable dt = new DataTable();
            string conStr = ConfigurationManager.ConnectionStrings["EmployeeConnection"].ConnectionString;
            using (SqlConnection con = new SqlConnection(conStr))
            {
                con.Open();
                SqlParameter EmployeeID = new SqlParameter("@EmployeeID", SqlDbType.Int);
                EmployeeID.Value = empID;
                string SQL = "sp_Get_Training";
                SqlCommand CMD = new SqlCommand(SQL, con);
                CMD.CommandType = CommandType.StoredProcedure;
                CMD.Parameters.Add(EmployeeID);
                SqlDataAdapter SDA = new SqlDataAdapter(CMD);
                SDA.Fill(dt);
                CMD.Connection.Close();
                CMD = null;
                SDA.Dispose();
            }
            return dt;
        }

        public static DataTable GetAllNotices()
        {
            DataTable DT = new DataTable();
            string conStr = ConfigurationManager.ConnectionStrings["EmployeeConnection"].ConnectionString;
            using (SqlConnection con = new SqlConnection(conStr))
            {
                con.Open();
                string SQL = "sp_get_Notice";
                SqlCommand CMD = new SqlCommand(SQL, con);
                CMD.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter SDA = new SqlDataAdapter(CMD);
                SDA.Fill(DT);
                CMD.Connection.Close();
                CMD = null;
                SDA.Dispose();
            }
            return DT;
        }

        public static DataTable GetAllMessages()
        {
            DataTable DT = new DataTable();
            string conStr = ConfigurationManager.ConnectionStrings["EmployeeConnection"].ConnectionString;
            using (SqlConnection con = new SqlConnection(conStr))
            {
                con.Open();
                string SQL = "sp_get_Message";
                SqlCommand CMD = new SqlCommand(SQL, con);
                CMD.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter SDA = new SqlDataAdapter(CMD);
                SDA.Fill(DT);
                CMD.Connection.Close();
                CMD = null;
                SDA.Dispose();
            }
            return DT;
        }

        public static int InserMessage(string message)
        {
            int result = 0;
            using (SqlConnection con = EmployeeMGRConfig.GetConnection())
            {
                con.Open();
                string SQL = "sp_insert_Message";
                SqlCommand CMD = new SqlCommand(SQL, con);
                CMD.CommandType = CommandType.StoredProcedure;
                CMD.Parameters.AddWithValue("@fldMessage", message);
                CMD.Parameters.AddWithValue("@fldCreatedDate", DateTime.Now);
                CMD.Parameters.AddWithValue("@fldCreatedBy", "Admin");
                result = CMD.ExecuteNonQuery();
                CMD.Connection.Close();
                CMD = null;
                return result;
            }
        }
        public static int GetCurrentEmployee(string username)
        {
            int result = 0;
            string conStr = ConfigurationManager.ConnectionStrings["EmployeeConnection"].ConnectionString;
            using (SqlConnection con = new SqlConnection(conStr))
            {

                con.Open();
                string SQL = "sp_GetEmployee_ByUserName";
                SqlCommand CMD = new SqlCommand(SQL, con);
                CMD.CommandType = CommandType.StoredProcedure;

                CMD.Parameters.AddWithValue("@fldUsername", username);
                result = Convert.ToInt32(CMD.ExecuteScalar());
                return result;
            }
        }

        public static int SaveInsurance(tblInsurance tblInsurance)
        {
            int result = 0;
            string conStr = ConfigurationManager.ConnectionStrings["EmployeeConnection"].ConnectionString;

            using (SqlConnection con = new SqlConnection(conStr))
            {
                con.Open();
                string SQL = "sp_Insert_Insurance";
                SqlCommand CMD = new SqlCommand(SQL, con);
                CMD.CommandType = CommandType.StoredProcedure;

                CMD.Parameters.AddWithValue("@fldEmployeeID", tblInsurance.fldEmployeeID);
                CMD.Parameters.AddWithValue("@fldInsuranceDesc", tblInsurance.fldInsuranceDesc);
                CMD.Parameters.AddWithValue("@fldInsuranceNote", tblInsurance.fldInsuranceNote);


                result = CMD.ExecuteNonQuery();
                CMD.Connection.Close();
                CMD = null;

            }
            return result;
        }

        public static int UpdateEmployee(tblEmployee emp)
        {
            string storeProcedureName = "sp_Update_Employee";
            int result = 0;
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = EmployeeMGRConfig.GetConnection();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = storeProcedureName;
                cmd.Parameters.AddWithValue("@fldEmployeeID", emp.fldEmployeeID);
                cmd.Parameters.AddWithValue("@fldFirstName", emp.fldFirstName);
                cmd.Parameters.AddWithValue("@fldMiddleName", emp.fldMiddleName);
                cmd.Parameters.AddWithValue("@fldLastName", emp.fldLastName);
                cmd.Parameters.AddWithValue("@fldGender", emp.fldGender);
                cmd.Parameters.AddWithValue("@fldDobYear", emp.fldDobYear);
                cmd.Parameters.AddWithValue("@fldDobMonth", emp.fldDobMonth);
                cmd.Parameters.AddWithValue("@fldDobDay", emp.fldDobDay);



                cmd.Parameters.AddWithValue("@fldDob", emp.fldDob);
                cmd.Parameters.AddWithValue("@fldPhoneNo", emp.fldPhoneNo);
                cmd.Parameters.AddWithValue("@fldMobileNo", emp.fldMobileNo);
                cmd.Parameters.AddWithValue("@fldFaxNo", emp.fldFaxNo);
                cmd.Parameters.AddWithValue("@fldPersonalEmail", emp.fldPersonalEmail);
                cmd.Parameters.AddWithValue("@fldOfficialEmail", emp.fldOfficialEmail);
                cmd.Parameters.AddWithValue("@fldAddress", emp.fldAddress);
                cmd.Parameters.AddWithValue("@fldDistrict", emp.fldDistrict);
                cmd.Parameters.AddWithValue("@fldCitizenshipNo", emp.fldCitizenshipNo);
                cmd.Parameters.AddWithValue("@fldCitizenshipIssuedDate", emp.fldCitizenshipIssuedDate);
                cmd.Parameters.AddWithValue("@fldCitzenshipIssuedDistrict", emp.fldCitzenshipIssuedDistrict);
                cmd.Parameters.AddWithValue("@fldDateofJoin", emp.fldDateofJoin);
                cmd.Parameters.AddWithValue("@fldDateofPermanent", emp.fldDateofPermanent);
                cmd.Parameters.AddWithValue("@fldDateofRetirement", emp.fldDateofRetirement);
                cmd.Parameters.AddWithValue("@fldMaritalStatus", emp.fldMaritalStatus);
                cmd.Parameters.AddWithValue("@fldChildBoy", emp.fldChildBoy);
                cmd.Parameters.AddWithValue("@fldLeaveHome", emp.fldLeaveHome);
                cmd.Parameters.AddWithValue("@fldLeaveSick", emp.fldLeaveSick);
                cmd.Parameters.AddWithValue("@fldIsActive", emp.fldIsActive);
                cmd.Parameters.AddWithValue("@fldCreatedBy", emp.fldCreatedBy);
                cmd.Parameters.AddWithValue("@fldCreatedDate", emp.fldCreatedDate);
                cmd.Parameters.AddWithValue("@fldUpdatedBy", emp.fldUpdatedBy);
                cmd.Parameters.AddWithValue("@fldUpdatedDate", DateTime.Today);
                cmd.Parameters.AddWithValue("@fldNote", emp.fldNote);
                result = cmd.ExecuteNonQuery();
                cmd.Connection.Close();
                return result;
            }
        }

        public static DataTable GetDesignationForEmployee(int eID)
        {
            DataTable DT = new DataTable();
            string conStr = EmployeeMGRConfig.GetConnectionString();
            using (SqlConnection con = new SqlConnection(conStr))
            {
                con.Open();
                SqlParameter EmployeeID = new SqlParameter("@EmployeeID", SqlDbType.Int);
                EmployeeID.Value = eID;
                string SQL = "sp_Get_Designation";
                SqlCommand CMD = new SqlCommand(SQL, con);
                CMD.CommandType = CommandType.StoredProcedure;
                CMD.Parameters.Add(EmployeeID);
                SqlDataAdapter SDA = new SqlDataAdapter(CMD);
                SDA.Fill(DT);
                CMD.Connection.Close();
                CMD = null;
                SDA.Dispose();
            }
            return DT;
        }

        public static DataTable GetEducationForEmployee(int eID)
        {
            DataTable DT = new DataTable();
            string conStr = ConfigurationManager.ConnectionStrings["EmployeeConnection"].ConnectionString;
            using (SqlConnection con = new SqlConnection(conStr))
            {
                con.Open();
                SqlParameter EmployeeID = new SqlParameter("@EmployeeID", SqlDbType.Int);
                EmployeeID.Value = eID;
                string SQL = "sp_Get_Education";
                SqlCommand CMD = new SqlCommand(SQL, con);
                CMD.CommandType = CommandType.StoredProcedure;
                CMD.Parameters.Add(EmployeeID);
                SqlDataAdapter SDA = new SqlDataAdapter(CMD);
                SDA.Fill(DT);
                CMD.Connection.Close();
                CMD = null;
                SDA.Dispose();
            }
            return DT;
        }

        public static DataTable GetFamilyForEmployee(int eID)
        {
            DataTable DT = new DataTable();
            string conStr = ConfigurationManager.ConnectionStrings["EmployeeConnection"].ConnectionString;
            using (SqlConnection con = new SqlConnection(conStr))
            {
                con.Open();
                SqlParameter EmployeeID = new SqlParameter("@fldEmployeeID", SqlDbType.Int);
                EmployeeID.Value = eID;
                string SQL = "sp_Get_Family";
                SqlCommand CMD = new SqlCommand(SQL, con);
                CMD.CommandType = CommandType.StoredProcedure;
                CMD.Parameters.Add(EmployeeID);
                SqlDataAdapter SDA = new SqlDataAdapter(CMD);
                SDA.Fill(DT);
                CMD.Connection.Close();
                CMD = null;
                SDA.Dispose();
            }
            return DT;
        }
    }
}