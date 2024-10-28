using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicDB_Winforms1
{
    public class AlbumService
    {
        private readonly string _connectionString;

        public AlbumService(string connectionString)
        {
            _connectionString = connectionString;
        }
        public DataTable GetAlbums(bool showDeleted, string artistName, string genreName, int? startYear, int? endYear, int? minListeners, int? maxListeners)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand("spGetAlbums", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                command.Parameters.AddWithValue("@ShowDeleted", showDeleted ? 1 : 0);
                command.Parameters.AddWithValue("@ArtistName", string.IsNullOrEmpty(artistName) ? (object)DBNull.Value : artistName);
                command.Parameters.AddWithValue("@GenreName", string.IsNullOrEmpty(genreName) ? (object)DBNull.Value : genreName);
                command.Parameters.AddWithValue("@StartYear", startYear.HasValue ? (object)startYear.Value : DBNull.Value);
                command.Parameters.AddWithValue("@EndYear", endYear.HasValue ? (object)endYear.Value : DBNull.Value);
                command.Parameters.AddWithValue("@MinMonthlyListeners", minListeners.HasValue ? (object)minListeners.Value : DBNull.Value);
                command.Parameters.AddWithValue("@MaxMonthlyListeners", maxListeners.HasValue ? (object)maxListeners.Value : DBNull.Value);

                connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable albumsTable = new DataTable();
                adapter.Fill(albumsTable);
                connection.Close();
                return albumsTable;
            }
        }



        public void CreateAlbum(string albumName, string artistName, string genreName, int releaseYear, int monthlyListeners)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand("spCreateAlbum", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                command.Parameters.AddWithValue("@AlbumName", albumName);
                command.Parameters.AddWithValue("@ArtistName", artistName);
                command.Parameters.AddWithValue("@GenreName", genreName);
                command.Parameters.AddWithValue("@ReleaseYear", releaseYear);
                command.Parameters.AddWithValue("@MonthlyListeners", monthlyListeners);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void UpdateAlbum(int albumID, string albumName, string artistName, string genreName, int releaseYear, int monthlyListeners, byte[] albumCover)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand("spUpdateAlbum", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                command.Parameters.AddWithValue("@AlbumID", albumID);
                command.Parameters.AddWithValue("@AlbumName", albumName);
                command.Parameters.AddWithValue("@ArtistName", artistName);
                command.Parameters.AddWithValue("@GenreName", genreName);
                command.Parameters.AddWithValue("@ReleaseYear", releaseYear);
                command.Parameters.AddWithValue("@MonthlyListeners", monthlyListeners);

                if (albumCover != null)
                {
                    command.Parameters.AddWithValue("@AlbumCover", albumCover);
                }
                else
                {
                    command.Parameters.AddWithValue("@AlbumCover", DBNull.Value);
                }

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void DeleteAlbum(int albumID)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand("spDeleteAlbum", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                command.Parameters.AddWithValue("@AlbumID", albumID);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }
        public DataTable GetSongsByAlbumID(int albumID)
        {
            DataTable songsTable = new DataTable();

            using (SqlConnection conn = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand("spGetSongsByAlbumID", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@AlbumID", albumID);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(songsTable);
            }

            return songsTable;
        }

        // TODO: form inheritage
    }
}
