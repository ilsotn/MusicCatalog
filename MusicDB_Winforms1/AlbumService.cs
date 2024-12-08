﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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

                ConfigureAlbums(albumsTable);

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
                    command.Parameters.Add("@AlbumCover", SqlDbType.Binary).Value = DBNull.Value;

/*                    command.Parameters.AddWithValue("@AlbumCover", DBNull.Value);
*/                }

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
        public void CreateAlbumWithSongs(
     string albumName,
     string artistName,
     string genreName,
     int releaseYear,
     int monthlyListeners,
     List<(string SongName, int Duration)> songs,
     byte[] albumCoverData)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction();

                try
                {
                    SqlCommand cmdAlbum = new SqlCommand("spCreateAlbum", connection, transaction)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmdAlbum.Parameters.AddWithValue("@AlbumName", albumName);
                    cmdAlbum.Parameters.AddWithValue("@ReleaseYear", releaseYear);
                    cmdAlbum.Parameters.AddWithValue("@ArtistName", artistName);
                    cmdAlbum.Parameters.AddWithValue("@GenreName", genreName);
                    cmdAlbum.Parameters.AddWithValue("@MonthlyListeners", monthlyListeners);
                    cmdAlbum.Parameters.AddWithValue("@Country", "UNK"); 

                    cmdAlbum.Parameters.AddWithValue("@AlbumCover", (object)albumCoverData ?? DBNull.Value);

                    SqlParameter albumIDParam = new SqlParameter("@AlbumID", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Output
                    };
                    cmdAlbum.Parameters.Add(albumIDParam);

                    cmdAlbum.ExecuteNonQuery();
                    int albumID = (int)albumIDParam.Value;

                    foreach (var song in songs)
                    {
                        SqlCommand cmdSong = new SqlCommand("spAddSongToAlbum", connection, transaction)
                        {
                            CommandType = CommandType.StoredProcedure
                        };
                        cmdSong.Parameters.AddWithValue("@AlbumID", albumID);
                        cmdSong.Parameters.AddWithValue("@SongName", song.SongName);
                        cmdSong.Parameters.AddWithValue("@Duration", song.Duration);

                        cmdSong.ExecuteNonQuery();
                    }

                    transaction.Commit();
                }
                catch
                {
                    transaction.Rollback();
                    throw; 
                }
            }
        }
        public void AddSongToAlbum(int albumID, string songName, int duration)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("spAddSongToAlbum", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                cmd.Parameters.AddWithValue("@AlbumID", albumID);
                cmd.Parameters.AddWithValue("@SongName", songName);
                cmd.Parameters.AddWithValue("@Duration", duration);

                connection.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteSongFromAlbum(int songID, int albumID)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("spDeleteSongFromAlbum", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                cmd.Parameters.AddWithValue("@SongID", songID);
                cmd.Parameters.AddWithValue("@AlbumID", albumID);

                connection.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public (string AlbumName, byte[] AlbumCover, DataTable SongsTable) GetAlbumDetails(int albumID)
        {
            DataTable songsTable = GetSongsByAlbumID(albumID);
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand("spGetAlbumByID", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                command.Parameters.AddWithValue("@AlbumID", albumID);

                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        string albumName = reader["AlbumName"].ToString();
                        byte[] albumCover = reader["AlbumCover"] as byte[];

                        return (albumName, albumCover, songsTable);
                    }
                }
            }
            return (null, null, songsTable);
        }

        public void ConfigureAlbums(DataTable albumsTable)
        {
            if (albumsTable.Columns.Contains("AlbumCover"))
            {
                albumsTable.Columns["AlbumCover"].ExtendedProperties["IsHidden"] = true;
            }

            if (albumsTable.Columns.Contains("AlbumID"))
            {
                albumsTable.Columns["AlbumID"].ExtendedProperties["IsHidden"] = true;
            }
        }

/*        public DataTable GetConfiguredAlbums(bool showDeleted, string artistName, string genreName, int? startYear, int? endYear, int? minListeners, int? maxListeners)
        {
            DataTable albumsTable = GetAlbums(showDeleted, artistName, genreName, startYear, endYear, minListeners, maxListeners);
            return albumsTable;
        }*/

    }
}
