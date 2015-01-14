using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;

namespace WebUI.Class.Article_Grid.grid_search_remote_csharp_backend
{
    public class GridSearchRemoteExampleController : ApiController
    {
        public AlbumsPayload Get()
        {
            AlbumsPayload payload = new AlbumsPayload();
            List<Album> albums = new List<Album>();
            payload.Albums = albums;
            int count = 0;

            string filtersString = Request.GetQueryNameValuePairs().Where(q => q.Key == "filter").FirstOrDefault().Value;
            Filter[] filters = null;
            if (filtersString != null)
            {
                filters = JsonConvert.DeserializeObject<Filter[]>(filtersString);
            }
           

            using (MySqlConnection cn = new MySqlConnection("server=127.0.0.1;uid=root;pwd=root;database=chinook;"))
            {
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    cmd.CommandText = "SELECT COUNT(AlbumId) FROM `chinook`.`album` join `chinook`.`artist` on (`chinook`.`album`.ArtistId = `chinook`.`artist`.ArtistId)";
                    string whereClause = "";
                    if (filters != null)
                    {
                        whereClause += " WHERE ";

                        for (var i = 0; i < filters.Length; i++)
                        {
                            if (i > 0)
                            {
                                whereClause += " OR "; 
                            }

                            string columnName = "";
                            string columnValue = filters[i].Value;

                            switch (filters[i].Property)
                            {
                                case "title":
                                    columnName = "album.Title";
                                    break;
                                case "artistName":
                                    columnName = "artist.Name";
                                    break;
                            }

                            whereClause += string.Format(" {0} LIKE '%{1}%'", columnName, columnValue);
                        }  
                    }

                    cmd.CommandText += whereClause;
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.Connection = cn;
                    cn.Open();

                    object countObject = cmd.ExecuteScalar();
                    count = int.Parse(countObject.ToString());
                    payload.Count = count;

                    cmd.CommandText = "SELECT AlbumId, Title, Name as ArtistName FROM `chinook`.`album` join `chinook`.`artist` on (`chinook`.`album`.ArtistId = `chinook`.`artist`.ArtistId)";

                    cmd.CommandText += whereClause;
                    cmd.CommandType = System.Data.CommandType.Text;

                    MySqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Album album = new Album()
                        {
                            Id = reader.GetInt32(0).ToString(),
                            Title = reader.GetString(1),
                            ArtistName = reader.GetString(2)
                        };
                        albums.Add(album);
                    }

                    cn.Close();

                }
            }

            return payload;
        }     
    }
}
