using System;
using BibleStudyCore.Data;
using BibleStudyCore.Models;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.UI.Pages.Internal.Account;

namespace BibleStudyCore.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _dbContext;

        public HomeController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ViewResult> Index()
        {
            try
            {
                var userId = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
                string connection =
                    $"Data Source=185.45.113.166;Initial Catalog=Bible;Integrated Security=False;User ID=kevin;Password=Krn171995;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

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
                    decimal progress = dataReader.GetInt32(dataReader.GetOrdinal("ProgressID"));
                    dataReader.Close();
                    comm.Dispose();
                    conn.Close();

                    ViewBag.Progress = progress;

                    return View();
                }
            }
            catch
            {
                return View();
            }

        }
        public async Task<ViewResult> Verse1()
        {
            try
            {
                var userId = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
                string connection =
                    $"Data Source=185.45.113.166;Initial Catalog=Bible;Integrated Security=False;User ID=kevin;Password=Krn171995;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

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
            catch
            {
                return View();
            }


        }
        public async Task<ViewResult> Verse2()
        {
            try
            {
                var userId = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
                string connection =
                    $"Data Source=185.45.113.166;Initial Catalog=Bible;Integrated Security=False;User ID=kevin;Password=Krn171995;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

                SqlConnection conn;
                SqlCommand comm;
                SqlDataReader dataReader;
                string sql = $"usp_GetVerse2ById";
                conn = new SqlConnection(connection);
                {

                    comm = new SqlCommand(sql, conn);
                    comm.CommandType = CommandType.StoredProcedure;
                    comm.Parameters.Add(new SqlParameter("@ID", userId));
                    conn.Open();
                    dataReader = comm.ExecuteReader();
                    dataReader.Read();
                    string verse = dataReader.GetString(dataReader.GetOrdinal("Verse2"));
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
            catch
            {
                return View();
            }
        }
        public async Task<ViewResult> Verse3()
        {
            try
            {
                var userId = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
                string connection =
                    $"Data Source=185.45.113.166;Initial Catalog=Bible;Integrated Security=False;User ID=kevin;Password=Krn171995;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

                SqlConnection conn;
                SqlCommand comm;
                SqlDataReader dataReader;
                string sql = $"usp_GetVerse3ById";
                conn = new SqlConnection(connection);
                {

                    comm = new SqlCommand(sql, conn);
                    comm.CommandType = CommandType.StoredProcedure;
                    comm.Parameters.Add(new SqlParameter("@ID", userId));
                    conn.Open();
                    dataReader = comm.ExecuteReader();
                    dataReader.Read();
                    string verse = dataReader.GetString(dataReader.GetOrdinal("Verse3"));
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
            catch
            {

                return View();
            }
        }
        public async Task<ViewResult> Verse4()
        {
            try
            {
                var userId = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
                string connection =
                    $"Data Source=185.45.113.166;Initial Catalog=Bible;Integrated Security=False;User ID=kevin;Password=Krn171995;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

                SqlConnection conn;
                SqlCommand comm;
                SqlDataReader dataReader;
                string sql = $"usp_GetVerse4ById";
                conn = new SqlConnection(connection);
                {

                    comm = new SqlCommand(sql, conn);
                    comm.CommandType = CommandType.StoredProcedure;
                    comm.Parameters.Add(new SqlParameter("@ID", userId));
                    conn.Open();
                    dataReader = comm.ExecuteReader();
                    dataReader.Read();
                    string verse = dataReader.GetString(dataReader.GetOrdinal("Verse4"));
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
            catch
            {

                return View();
            }
        }

        public async Task<ViewResult> Complete()
        {
            try
            {
                var userId = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
                string connection =
                    $"Data Source=185.45.113.166;Initial Catalog=Bible;Integrated Security=False;User ID=kevin;Password=Krn171995;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

                SqlConnection conn;
                SqlCommand comm;
                SqlDataReader dataReader;
                string sql = $"usp_UpdateProgressID";
                conn = new SqlConnection(connection);
                {
                    comm = new SqlCommand(sql, conn);
                    comm.CommandType = CommandType.StoredProcedure;
                    comm.Parameters.Add(new SqlParameter("@ID", userId));
                    conn.Open();
                    dataReader = comm.ExecuteReader();
                    dataReader.Read();
                    //string verse = dataReader.GetString(dataReader.GetOrdinal("Verse4"));
                    dataReader.Close();
                    comm.Dispose();
                    conn.Close();

                    return View();

                }
            }
            catch
            {

                return View();
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
