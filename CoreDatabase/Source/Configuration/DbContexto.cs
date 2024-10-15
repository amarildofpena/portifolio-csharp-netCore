using CoreDatabase.Source.Model.Tibia;
using CoreRest.Source.Model.Tibia;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Monster = CoreDatabase.Source.Model.Tibia.Monster;

namespace CoreDatabase.Source.Configuration
{
	public class DbContexto : DbContext
	{
		public DbSet<House>? Casas { get; set; }
		public DbSet<Attributes>? Attributes { get; set; }
		public DbSet<Item>? Items { get; set; }
		public DbSet<Monster>? Monsters { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{

			optionsBuilder.UseMySql("Server=localhost;DataBase=gb_cn;Uid=root;Pwd=", new MySqlServerVersion(new Version(8, 0)));
		}
	}
}
