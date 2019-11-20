using Microsoft.Data.SqlClient;
using QuatorProjectVIdeoPlayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuatorProjectVIdeoPlayer.Data
{
    public class VideoDb
    {
        public static string getThumbnail(int id)
        {
            string thumbnail = string.Empty;
            SqlConnection con = DBHelper.GetConnection();

            SqlCommand addCmd = new SqlCommand();
            addCmd.Connection = con;
            addCmd.CommandText = "SELECT Thumbnail" +
                "FROM Video" +
                "WHERE VideoId = @id";
            addCmd.Parameters.AddWithValue("@id", id);

            con.Open();
            SqlDataReader reader = addCmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    thumbnail = reader["Thumbnail"].ToString();
                }
            }
         
            reader.Close();
            con.Dispose();

            if(thumbnail != null)
            {
                return thumbnail;
            }
            else
            {
                return null;
            }
        }
    }
}
