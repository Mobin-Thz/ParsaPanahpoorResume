using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using Resume.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Resume.Infra.Data.MongoDb
{
    public class MongoDbContext : DbContext
    {

        public MongoDbContext(DbContextOptions<MongoDbContext> options)
            : base(options)
        {
        }

        public DbSet<Education> Educations { get; set; }

    }

}
