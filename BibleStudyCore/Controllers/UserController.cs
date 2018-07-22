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

            SqlConnection conn;
            SqlCommand comm;
            SqlDataReader dataReader;
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
                    string baseUrl = $"http://labs.bible.org/api/?passage=" + verse;

                    HttpResponseMessage response = await client.GetAsync(baseUrl);
                    response.EnsureSuccessStatusCode();
                    string responseBody = await response.Content.ReadAsStringAsync();

                    HtmlContentBuilder str = new HtmlContentBuilder();
                    str.AppendHtml(responseBody);

                    ViewBag.Verse = verse;
                    ViewBag.Text = str;

                    return View();
                }
            }
        }

        [HttpPost]
        public Task<ViewResult> Index(DbContext dbContext)
        {
            return Index();
        }
    }
}


