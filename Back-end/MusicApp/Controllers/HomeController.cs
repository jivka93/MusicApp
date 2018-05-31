using MusicApp.Data;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Web.Mvc;

namespace MusicApp.Controllers
{
    public class HomeController : Controller
    {
        private SqlConnection connection;
        private SqlDataAdapter adapter;

        public string Index()
        {
            var connectionString = "Data Source=.\\SQLEXPRESS; Initial Catalog = MusicApp; Integrated Security = True;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                DataTable dataTable = new DataTable();
                var query = "SELECT * FROM Artists";

                adapter = new SqlDataAdapter()
                {
                    SelectCommand = new SqlCommand(query, connection)
                };

                adapter.Fill(dataTable);
                var artists = new List<ReadArtist>(dataTable.Rows.Count);

                if (dataTable.Rows.Count > 0)
                {
                    foreach (DataRow row in dataTable.Rows)
                    {
                        artists.Add(new ReadArtist(row));
                    }
                }

                var json = JsonConvert.SerializeObject(artists);
                connection.Close();
                return json;
            }
        }

        // ======================================================================


        public string Get()
        {
            var connectionString = "Data Source=.\\SQLEXPRESS; Initial Catalog = MusicApp; Integrated Security = True;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                DataTable dataTable = new DataTable();
                var query = "SELECT * FROM Artists";

                adapter = new SqlDataAdapter()
                {
                    SelectCommand = new SqlCommand(query, connection)
                };

                adapter.Fill(dataTable);
                var artists = new List<ReadArtist>(dataTable.Rows.Count);

                if (dataTable.Rows.Count > 0)
                {
                    foreach (DataRow row in dataTable.Rows)
                    {
                        artists.Add(new ReadArtist(row));
                    }
                }

                var json = JsonConvert.SerializeObject(artists);
                connection.Close();
                return json;
            }
        }


        public string Get(int id)
        {
            var connectionString = "Data Source=.\\SQLEXPRESS; Initial Catalog = MusicApp; Integrated Security = True;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                DataTable dataTable = new DataTable();
                var query = $"SELECT * FROM Artists WHERE Id = {id}";

                adapter = new SqlDataAdapter()
                {
                    SelectCommand = new SqlCommand(query, connection)
                };

                adapter.Fill(dataTable);
                ReadArtist artist;

                if (dataTable.Rows.Count == 1)
                {
                    artist = new ReadArtist(dataTable.Rows[0]);
                    var json = JsonConvert.SerializeObject(artist);
                    connection.Close();
                    return json;
                }

                return null;
            }
        }

        // ======================================================================

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}