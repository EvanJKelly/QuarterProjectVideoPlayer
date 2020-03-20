using Microsoft.Azure;
using Microsoft.Data.SqlClient;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using QuatorProjectVIdeoPlayer.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc.Filters;


namespace QuatorProjectVIdeoPlayer.Data
{
    public class VideoDb
    {
        public static void addVideo(Video video)
        {
            SqlConnection con = DBHelper.GetConnection();

            SqlCommand addCmd = new SqlCommand();
            addCmd.Connection = con;
            addCmd.CommandText = "INSERT INTO Video(VideoTitle, VideoLink, Thumbnail, AccountId) " +
                "VALUES (@title, @videolink, @thumbnail, @accountid)";
            addCmd.Parameters.AddWithValue("@title", video.VideoTitle);
            addCmd.Parameters.AddWithValue("@videolink", video.VideoLink);
            addCmd.Parameters.AddWithValue("@thumbnail", video.ThumbnailUrl);
            addCmd.Parameters.AddWithValue("@accountid", video.AccountId);

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
