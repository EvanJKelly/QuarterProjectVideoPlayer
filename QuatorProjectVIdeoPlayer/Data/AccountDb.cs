using Microsoft.Data.SqlClient;
using QuatorProjectVIdeoPlayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuatorProjectVIdeoPlayer.Data
{
    public class AccountDb
    {
        public static void Add(Account a)
        {
            SqlConnection con = DBHelper.GetConnection();

            SqlCommand addCmd = new SqlCommand();
            addCmd.Connection = con;
            addCmd.CommandText = "INSERT INTO Account(Username, Password, Email, DarkMode) " +
                "VALUES (@username, @password, @email, @darkMode)";
            addCmd.Parameters.AddWithValue("@username", a.Username);
            addCmd.Parameters.AddWithValue("@password", a.Password);
            addCmd.Parameters.AddWithValue("@email", a.Email);
            if (a.DarkMode)
            {
                addCmd.Parameters.AddWithValue("@darkMode", 1);
            }
            else
            {
                addCmd.Parameters.AddWithValue("@darkMode", 0);
            }
            

            try
            {
                con.Open();
                addCmd.ExecuteNonQuery();
            }
            finally
            {
                con.Dispose();
            }
        }

        public static bool IsEmailTaken(string email)
        {
            Account a = new Account();
            SqlConnection con = DBHelper.GetConnection();

            SqlCommand addCmd = new SqlCommand();
            addCmd.Connection = con;
            addCmd.CommandText = "SELECT Email " +
                "FROM Account " +
                "WHERE Email = @email";
            addCmd.Parameters.AddWithValue("@email", email);

            con.Open();
            using (SqlDataReader reader = addCmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    a.Email = reader["Email"].ToString();
                }
                reader.Close();
                con.Dispose();
            }

            if (a.Email == email)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool IsUsernameTaken(string username)
        {
            Account a = new Account();
            SqlConnection con = DBHelper.GetConnection();

            SqlCommand addCmd = new SqlCommand();
            addCmd.Connection = con;
            addCmd.CommandText = "SELECT Username " +
                "FROM Account " +
                "WHERE Username = @username";
            addCmd.Parameters.AddWithValue("@username", username);

            con.Open();
            using (SqlDataReader reader = addCmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    a.Username = reader["Username"].ToString();
                }
                reader.Close();
                con.Dispose();
            }

            if (a.Username == username)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static Account IsLoginValid(LoginViewModel model)
        {
            Account a = new Account();
            SqlConnection con = DBHelper.GetConnection();

            SqlCommand addCmd = new SqlCommand();
            addCmd.Connection = con;
            addCmd.CommandText = "SELECT * " +
                "FROM Account " +
                "WHERE Email = @email AND Password = @password";
            addCmd.Parameters.AddWithValue("@email", model.Email);
            addCmd.Parameters.AddWithValue("@password", model.Password);

            con.Open();
            SqlDataReader reader = addCmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    a.AccountId = Convert.ToInt32(reader["AccountId"]);
                    a.Username = reader["Username"].ToString();
                    a.DarkMode = Convert.ToBoolean(reader["DarkMode"]);
                    a.Email = reader["Email"].ToString();
                    a.Password = reader["Password"].ToString();
                }
            }
            reader.Close();
            con.Dispose();
            
            if(a.Username != null && a.Password != null)
            {
                return a;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Switches the boolean value of darkmode in the database
        /// </summary>
        public static void SwitchDarkMode(bool onOrOff, int? memberId) 
        {
            if (onOrOff)
            {
                //darkmode on
                SqlConnection con = DBHelper.GetConnection();

                SqlCommand addCmd = new SqlCommand();
                addCmd.Connection = con;
                addCmd.CommandText = "UPDATE Account " +
                    "SET DarkMode = @value " +
                    "WHERE AccountId = @id";
                addCmd.Parameters.AddWithValue("@value", 1);
                addCmd.Parameters.AddWithValue("@id", memberId);

                try
                {
                    con.Open();
                    addCmd.ExecuteNonQuery();
                }
                finally
                {
                    con.Dispose();
                }
            }
            else
            {
                //darkmode off
                SqlConnection con = DBHelper.GetConnection();

                SqlCommand addCmd = new SqlCommand();
                addCmd.Connection = con;
                addCmd.CommandText = "UPDATE Account " +
                    "SET DarkMode = @value " +
                    "WHERE AccountId = @id";
                addCmd.Parameters.AddWithValue("@value", 0);
                addCmd.Parameters.AddWithValue("@id", memberId);

                try
                {
                    con.Open();
                    addCmd.ExecuteNonQuery();
                }
                finally
                {
                    con.Dispose();
                }
            }
        }
    }
}
