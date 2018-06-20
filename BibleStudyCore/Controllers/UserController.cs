using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;
using BibleStudyCore.Data;
using BibleStudyCore.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Newtonsoft.Json.Linq;

namespace BibleStudyCore.Controllers
{
    public class UserController : Controller
    {
        private readonly ApplicationDbContext _dbContext;

        public UserController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<User>> Index()
        {
            var userId = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            return await _dbContext.User.FromSql((string)$"EXECUTE usp_GetVerseById @Id", 
                new SqlParameter("@Id", SqlDbType.NVarChar) { Value = userId }).ToArrayAsync();
           
            //JObject list = JObject.Parse(raw.ToString());
            //string verse = (string) list["verse"];
            //return verse;

            //HttpClient verse = new HttpClient();
            //verse.BaseAddress = new Uri(https://labs.bible.org/api/?);
        }
    }
}

//\'({Email})\'