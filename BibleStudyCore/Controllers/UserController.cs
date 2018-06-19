using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using BibleStudyCore.Data;
using BibleStudyCore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BibleStudyCore.Controllers
{
    public class UserController : Controller
    {
        private readonly BibleDbContext _dbContext;
        
        public UserController(BibleDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<User>> Index()
        {
            string Email = HttpContext.User.Identity.Name.ToString();
            return await _dbContext.User.FromSql("usp_GetVerseByEmail @p0", Email).ToListAsync();
        }
    }
}