using EnglishLearning.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace EnglishLearning.DAL
{
    public class EnglishContext : DbContext
    {
        public EnglishContext() : base("EnglishLearning")
        {

        }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<Word> Words { get; set; }
        public DbSet<Users> Users{ get; set; }
    }
}