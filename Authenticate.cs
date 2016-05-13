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