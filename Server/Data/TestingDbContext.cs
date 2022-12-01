using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SODesk.Server.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SODesk.Server.Data
{
    public class TestingDbContext : AppDb
    {
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseInMemoryDatabase("SODesk");
            base.OnConfiguring(options);
        }
    }
}
