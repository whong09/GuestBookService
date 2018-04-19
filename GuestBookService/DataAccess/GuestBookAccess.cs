using GuestBookService.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GuestBookService.DataAccess
{
    public class GuestBookAccess
    {
        string _connectionString;

        public GuestBookAccess(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IEnumerable<GuestBookEntry> GetGuestBookEntries()
        {
            MySqlConnection connection = new MySqlConnection(_connectionString);
            List<GuestBookEntry> guestBook = new List<GuestBookEntry>();
            try
            {
                connection.Open();
                string sql = "select name, comment, create_dt from guestbook order by create_dt";
                MySqlCommand cmd = new MySqlCommand(sql, connection);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    guestBook.Add(new GuestBookEntry
                    {
                        GuestName = (string)reader["name"],
                        GuestComment = (string)reader["comment"],
                        CreateDate = (DateTime)reader["create_dt"]
                    });
                }
                reader.Close();
                return guestBook;
            }
            catch
            {
                return null;
            }
            finally
            {
                connection.Close();
            }
        }

        public void CreateGuestBookEntry(GuestBookEntry guestBookEntry)
        {
            MySqlConnection connection = new MySqlConnection(_connectionString);
            try
            {
                connection.Open();
                string sql = $"insert into guestbook values ('{guestBookEntry.GuestName}', '{guestBookEntry.GuestComment}', '{guestBookEntry.CreateDate.ToString("s")}')";
                MySqlCommand cmd = new MySqlCommand(sql, connection);
                cmd.ExecuteNonQuery();
            }
            catch
            {
                return;
            }
            finally
            {
                connection.Close();
            }
        }
    }
}
