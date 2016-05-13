using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace Employee3.App_Code
{
    public class EmployeeMGRConfig
    {
        public static string GetConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["EmployeeConnection"].ConnectionString;
        }
        public static SqlConnection GetConnection()
        {
            try
            {
                return DBOpenconnection(GetConnectionString());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }


        }
        public static DataSet GetDataSet(string sqlQuery)
        {
            SqlDataAdapter SDA = new SqlDataAdapter(sqlQuery, GetConnection());
            DataSet ds = new DataSet();
            SDA.Fill(ds);
            return ds;
        }
        static protected SqlConnection DBOpenconnection(string conStr)
        {
            //SqlConnection Tempconn ;
            try
            {
                SqlConnection Tempconn = new SqlConnection(conStr);
                //if (Tempconn.State == ConnectionState.Open)
                //{
                //    DBCloseconnection(Tempconn);
                //}
                Tempconn.ConnectionString = conStr;
                if (Tempconn.State == ConnectionState.Closed)
                    Tempconn.Open();
                return Tempconn;
            }
            catch (Exception ex)
            {
                //error log
                throw new Exception(ex.ToString());
                //return null;
            }

        }
        //close connection if it is opened
        static public void DBCloseconnection(SqlConnection Tempconn)
        {
            try
            {
                if (Tempconn == null || Tempconn.State == ConnectionState.Open)
                {
                    Tempconn.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.StackTrace);
                //error log
            }
        }
        public static DataTable GetDataTable(string sqlQuery)
        {
            SqlDataAdapter SDA = new SqlDataAdapter(sqlQuery, GetConnection());
            DataTable DT = new DataTable();
            SDA.Fill(DT);
            return DT;
        }
        public static SqlDataReader GetSqlDataReader(SqlCommand com)
        {
            SqlConnection con = GetConnection();
            com.Connection = con;
            con.Open();
            SqlDataReader reader = com.ExecuteReader(CommandBehavior.CloseConnection);
            return reader;
        }
        public static int ConvertDigits(string sText)
        {
            string strVal = "";
            foreach (char c in sText)
            {
                strVal += (c.ToString().Replace("०", "0")
                .Replace("१", "1")
                .Replace("२", "2")
                .Replace("३", "3")
                .Replace("४", "4")
                .Replace("५", "5")
                .Replace("६", "6")
                .Replace("७", "7")
                .Replace("८", "8")
                .Replace("९", "9"));
            }
            return int.Parse(strVal);

        }
        public static bool SendNow(string userName)
        {
            bool bln = false;
            try
            {
                MailMessage message = new MailMessage();
                message.From = new MailAddress("subash@neptelglobal.com");

                message.To.Add(new MailAddress("subhash.paudel@gmail.com"));
                message.CC.Add(new MailAddress("subash@neptelglobal.com"));
                message.CC.Add(new MailAddress("48yogen@gmail.com"));
                //message.Bcc.Add(new MailAddress("subash@neptelglobal.com"));
                message.Subject = "Your Account is created in PIS";

                message.BodyEncoding = System.Text.Encoding.UTF8;
                message.Priority = MailPriority.Normal;
                message.IsBodyHtml = true;
                message.Body = (" Your information is added in PIS. Please Check your detail and complete your details using following details.<br/><br/>" +
                                    "http://localhost/EmployeePages/Login.aspx" +
                                    "<br/>User Name:" + userName + "<br/>Password:" + userName);
                SmtpClient client = new SmtpClient("smtp.gmail.com");
                client.Port = 587;
                client.EnableSsl = true;
                client.Credentials = new NetworkCredential("pisnepal@gmail.com", "spaudel00");
                client.Send(message);
                message = null;
                bln = true;
            }
            catch (Exception ex)
            {

            }
            return bln;
        }

        public string Encryption(String password)
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            byte[] encrypt;
            UTF8Encoding encode = new UTF8Encoding();
            //encrypt the given password string into Encrypted data  
            encrypt = md5.ComputeHash(encode.GetBytes(password));
            StringBuilder encryptdata = new StringBuilder();
            //Create a new string by using the encrypted data  
            for (int i = 0; i < encrypt.Length; i++)
            {
                encryptdata.Append(encrypt[i].ToString());
            }
            return encryptdata.ToString();
        }

    }
}