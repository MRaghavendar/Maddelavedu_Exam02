using Maddelavedu_Exam02.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace Maddelavedu_Exam02.SportsPlayers
{
    public class PlayerContext : DbContext
    {
        public PlayerContext() : base("PlayerContext")
        {
        }

        public DbSet<Player> Player { get; set; }
        public DbSet<Played> Played { get; set; }
        public DbSet<Match> Match { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}