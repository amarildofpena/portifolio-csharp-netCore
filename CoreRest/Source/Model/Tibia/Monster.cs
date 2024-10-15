using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreRest.Source.Model.Tibia
{
	public class Monster
	{
		public string? name { get; set; }
		public string? description { get; set; }
		public string? race { get; set; }
		public long? experience { get; set; }
		public int? speed { get; set; }
		public int? manacost { get; set; }
		public Health? health { get; set; }
		public Look? look { get; set; }
		public TargetChange? targetChange { get; set; }
		public Flag? flags { get; set; }
		public List<Attack>? attacks { get; set; }
		public List<Defense>? defenses { get; set; }
		public Element? elements { get; set; }

	}
}
