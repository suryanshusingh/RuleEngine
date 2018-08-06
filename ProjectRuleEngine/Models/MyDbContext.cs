using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace ProjectRuleEngine.Models
{
    public class MyDbContext : DbContext
    {
        public DbSet<UpdatedData> UpdatedDatas { get; set; }
    }
}