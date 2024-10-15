using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreRest.Source.Model.Tibia
{
	public class Flag
	{
		public int summonable { get; set; } = 0;
		public int attackable { get; set; } = 1;
		public int hostile { get; set; } = 1;
		public int illusionable { get; set; } = 0;
		public int convinceable { get; set; } = 0;
		public int pushable { get; set; } = 0;
		public int canpushitems { get; set; } = 1;
		public int staticattack { get; set; } = 10;
		public int lightlevel { get; set; } = 0;
		public int lightcolor { get; set; } = 0;
		public int targetdistance { get; set; } = 1;
		public int runonhealth { get; set; } = 1;
	}
}
