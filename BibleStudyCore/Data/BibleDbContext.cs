using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using BibleStudyCore.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using Ninject.Planning.Targets;

namespace BibleStudyCore.Data
{
    public abstract class BibleDbContext : DbContext
    {
        protected BibleDbContext(DbContextOptions<BibleDbContext> options)
            : base(options)
        {
        }
        public DbSet<User> User { get; set; }
        public string userId { get; set; }

        //public IDataReader MyDataReader()
        //{
            
        //    //var raw = await _dbContext.User.FromSql((string) $"EXECUTE usp_GetVerse1ById @Id",
        //    //    new SqlParameter("@Id", SqlDbType.NVarChar) {Value = userId}).ToArrayAsync();

        //    string connection =
        //        $"Data Source=185.45.113.166;Initial Catalog=Bible;Integrated Security=False;User ID=kevin;Password=Krn171995;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        //    using (SqlConnection conn = new SqlConnection(connection))
        //    {
        //        using (SqlCommand cmd = new SqlCommand("usp_GetVerse1ById"))
        //        {
        //            cmd.CommandType = CommandType.StoredProcedure;
        //            cmd.Parameters.Add(new SqlParameter("@ID", userId));
        //            conn.Open();
        //            cmd.Connection = conn;

        //            using (SqlDataReader rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection))
        //            {
        //                while (rdr.Read())
        //                {

        //                    string verse = rdr.GetString(rdr.GetOrdinal("Verse1"));

                            


        //                }
        //                rdr.Close();
        //            }
        //        }
        //    }
        //}
    }
}
