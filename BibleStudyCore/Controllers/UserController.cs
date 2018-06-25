using BibleStudyCore.Data;
using BibleStudyCore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Html;
using Newtonsoft.Json.Linq;

namespace BibleStudyCore.Controllers
{
    public class UserController : Controller
    {
        //public IActionResult Index()
        //{
        //    return View();
        //}

        private readonly ApplicationDbContext _dbContext;

        public UserController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ViewResult> Index()
        {
            var userId = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            //var raw = await _dbContext.User.FromSql((string) $"EXECUTE usp_GetVerse1ById @Id",
            //    new SqlParameter("@Id", SqlDbType.NVarChar) {Value = userId}).ToArrayAsync();

            string connection =
                $"Data Source=185.45.113.166;Initial Catalog=Bible;Integrated Security=False;User ID=kevin;Password=Krn171995;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            //using (SqlConnection conn = new SqlConnection(connection))
            //{
            //    using (SqlCommand cmd = new SqlCommand("usp_GetVerse1ById"))
            //    {
            //        cmd.CommandType = CommandType.StoredProcedure;
            //        cmd.Parameters.Add(new SqlParameter("@ID", userId));
            //        conn.Open();
            //        cmd.Connection = conn;

            //        using (SqlDataReader rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection))
            //        {
            //            while (rdr.Read())
            //            {
                            
            //                string verse = rdr.GetString(rdr.GetOrdinal("Verse1"));
                            
            //            }
            //            rdr.Close();
            //            return verse;
            //        }
            //    }
            //}

            SqlConnection conn;
            SqlCommand comm;
            SqlDataReader dataReader;
            //SqlParameter param = new SqlParameter("@Id", SqlDbType.NChar) { Value = userId };
            string sql = $"usp_GetVerse1ById";
            conn = new SqlConnection(connection);
            {
                
                comm = new SqlCommand(sql, conn);
                comm.CommandType = CommandType.StoredProcedure;
                comm.Parameters.Add(new SqlParameter("@ID", userId));
                conn.Open();
                dataReader = comm.ExecuteReader();
                dataReader.Read();
                string verse = dataReader.GetString(dataReader.GetOrdinal("Verse1"));
                dataReader.Close();
                comm.Dispose();
                conn.Close();

                using (HttpClient client = new HttpClient())
                {
                    string baseUrl = $"https://api.esv.org/v3/passage/html/?include-css-link=true&wrapping-div=true&include-book-titles=true&include-passage-references=true&include-chapter-numbers=true&include-verse-numbers=true&include-crossrefs=true&include-headings=true&include-audio-link=true&include-copyright=true&q=" + verse;
                    client.BaseAddress = new Uri(baseUrl);
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Token", "0a807084443809306503c0e429e76d3351adfe54");

                    HttpResponseMessage response = await client.GetAsync(baseUrl);
                    response.EnsureSuccessStatusCode();
                    string responseBody = await response.Content.ReadAsStringAsync();

                    HtmlContentBuilder str = new HtmlContentBuilder();
                    str.AppendHtml(responseBody);
                    

                    //object text = JsonConvert.DeserializeObject(responseBody.ToString());
                    //ViewBag.Message = text;

                    //StringBuilder sb = new StringBuilder();
                    //JArray o = JArray.Parse(responseBody.ToString());

                    //foreach (JProperty prop in o[""].Children<JProperty>())
                    //{
                    //    JArray text = (JArray)prop.Value;
                    //    sb.AppendFormat("<h1>{0}</h1> <p>{1}<p> />\r\n",
                    //        text["bookname"], text["text"]);
                    //    //sb.AppendFormat("<img src='{0}' alt='{1}' />\r\n",
                    //    //    photo["src"], photo["alt"]);
                    //}

                    return View(str);
                }
            }


            //string json = JsonConvert.SerializeObject(verse, Formatting.None);



            //JObject list = JObject.Parse(raw.ToString());
            //string verse = (string) list["verse"];
            //return verse;

            //HttpClient verse = new HttpClient();
            //verse.BaseAddress = new Uri(https://labs.bible.org/api/?);
        }
    }
}


//\'({Email})\'