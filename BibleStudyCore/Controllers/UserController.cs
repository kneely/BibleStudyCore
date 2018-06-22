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
using System.Security.Claims;
using System.Threading.Tasks;

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
            var raw = await _dbContext.User.FromSql((string) $"EXECUTE usp_GetVerseById @Id",
                new SqlParameter("@Id", SqlDbType.NVarChar) {Value = userId}).ToArrayAsync();

            string json = JsonConvert.SerializeObject(raw, Formatting.None);
            
            using (HttpClient client = new HttpClient())
            {
                string baseUrl = $"http://labs.bible.org/api/?type=json&formatting=plain&passage=" + json;
                client.BaseAddress = new Uri(baseUrl);

                HttpResponseMessage response = await client.GetAsync(baseUrl);
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();

                object verse = JsonConvert.DeserializeObject(responseBody.ToString());
                ViewBag.Message = verse;

                //StringBuilder sb = new StringBuilder();
                //JArray o = JArray.Parse(responseBody.ToString());

                //foreach (JProperty prop in o[""].Children<JProperty>())
                //{
                //    JArray photo = (JArray)prop.Value;
                //    sb.AppendFormat("<h1>{0}</h1> <p>{1}<p> />\r\n",
                //        photo["bookname"], photo["alt"]);
                //    //sb.AppendFormat("<img src='{0}' alt='{1}' />\r\n",
                //    //    photo["src"], photo["alt"]);
                //}

                return View();
            }

            //JObject list = JObject.Parse(raw.ToString());
            //string verse = (string) list["verse"];
            //return verse;

            //HttpClient verse = new HttpClient();
            //verse.BaseAddress = new Uri(https://labs.bible.org/api/?);
        }
    }
}


//\'({Email})\'