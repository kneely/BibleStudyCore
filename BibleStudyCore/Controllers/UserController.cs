using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BibleStudyCore.Data;
using BibleStudyCore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BibleStudyCore.Controllers
{
    public class UserController : Controller
    {
        private readonly ApplicationDbContext _dbContext;
        private string Id { get; }

        public UserController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

    //    public async Task<IEnumerable<User>> Index()
    //    {
    //        //return await _dbContext.User.FromSql("dbo.GetVerseById @Id", Id).ToListAsync();
    //    }
    }
}