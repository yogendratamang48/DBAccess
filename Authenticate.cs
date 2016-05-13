protected void btnLogin_Click(object sender, EventArgs e)
        {
            if (AuthenticateUser(txtUserName.Text, txtPassword.Text))
            {
                FormsAuthentication.RedirectFromLoginPage(txtUserName.Text, cbRememberMe.Checked);
                
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Invalid Credentials !')", true);
            }
        }
        protected bool AuthenticateUser(string username, string password)
        {
            string conStr = ConfigurationManager.ConnectionStrings["EmployeeConnection"].ConnectionString;
            using (SqlConnection con = new SqlConnection(conStr))
            {
                con.Open();
                string SQL = "sp_Authenticate_User";
                SqlCommand CMD = new SqlCommand(SQL, con);
                CMD.CommandType = CommandType.StoredProcedure;
                CMD.Parameters.AddWithValue("@UserName", username);
                CMD.Parameters.AddWithValue("@Password", password);
                int ReturnCode = Convert.ToInt32(CMD.ExecuteScalar());
                CMD.Connection.Close();
                CMD = null;
                return ReturnCode == 1;
            }

        }
		
		
		protected void CreateUser(tblEmployee employee)
        {
            int result = 0;
            string conStr = ConfigurationManager.ConnectionStrings["EmployeeConnection"].ConnectionString;
            using (SqlConnection con = new SqlConnection(conStr))
            {
                con.Open();
                string checkSQL = "sp_Check_User";
                string SQL = "sp_insert_User";
                SqlCommand cmdCheck = new SqlCommand(checkSQL, con);
                SqlCommand CMD = new SqlCommand(SQL, con);
                cmdCheck.CommandType = CommandType.StoredProcedure;
                string password = new EmployeeMGRConfig().Encryption(employee.fldMobileNo);
                CMD.CommandType = CommandType.StoredProcedure;

                cmdCheck.Parameters.AddWithValue("@UserName", employee.fldPersonalEmail);

                if (Convert.ToInt32(cmdCheck.ExecuteScalar()) == 1)
                {


                    CMD.Parameters.AddWithValue("@fldEmployeeId", employee.fldEmployeeID);
                    CMD.Parameters.AddWithValue("@fldLoginName", employee.fldMobileNo);
                    CMD.Parameters.AddWithValue("@fldUsername", employee.fldPersonalEmail);
                    CMD.Parameters.AddWithValue("@fldPassword", password);
                    CMD.Parameters.AddWithValue("@fldIsActive", 0);
                    CMD.Parameters.AddWithValue("@fldCreatedBy", "Admin");
                    CMD.Parameters.AddWithValue("fldUserType", "staff");
                    CMD.Parameters.AddWithValue("@fldCreatedDate", DateTime.Now);
                    CMD.Parameters.AddWithValue("@fldUpdatedBy", "Admin");
                    CMD.Parameters.AddWithValue("@fldUpdatedDate", DateTime.Now);
                    CMD.Parameters.AddWithValue("@fldNote", " ");
                    result = CMD.ExecuteNonQuery();
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('UserName Already Taken!')", true);
                }
                CMD.Connection.Close();
                CMD = null;
            }
        }