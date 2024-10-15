using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreRest.Source.Model.Tibia
{
	public class Attack
	{
		public string name { get; set; } = "";
		public int interval { get; set; } = 2000;
		public int? skill { get; set; } = 75;
		public int? attack { get; set; } = 60;
		public int? chance { get; set; } = 90;
		public int? range { get; set; } = 3;
		public int? target { get; set; } = 1;
		public int? radius { get; set; } = 2;
		public int? min { get; set; } = -200;
		public int? max { get; set; } = -400;
		public int? attribute { get; set; } = -400;

	}
}
