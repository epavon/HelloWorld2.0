using HelloWorld2.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorld2.Data
{
    public class HelloWorldDb : DbContext
    {
        public HelloWorldDb()
            : base(ConnectionStringName)
        {

        }

        public DbSet<Degree>    Degrees { get; set; }
        public DbSet<Post>      Posts { get; set; }
        public DbSet<Comment>   Comments { get; set; }
        public DbSet<Project>   Projects { get; set; }
        public DbSet<Work>      Works { get; set; }
        public DbSet<Skill>     Skills { get; set; }
        public DbSet<Creation>  Creations { get; set; }
        public DbSet<About>     Abouts { get; set; }
        public DbSet<School>    Schools { get; set; }
        public DbSet<Website>   Websites { get; set; }

        public static string ConnectionStringName
        {
            get
            {
                if (ConfigurationManager.AppSettings["ConnectionStringName"] != null)
                {
                    return ConfigurationManager.AppSettings["ConnectionStringName"].ToString();
                }

                return "DefaultConnection";
            }
        }

    }
}
