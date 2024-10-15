using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreRest.Source.Model.Tibia
{
	public class DefenseDetail
	{
		public string? name { get; set; }
		public string? interval { get; set; }
		public string? chance { get; set; }
		public string? min { get; set; }
		public string? max { get; set; }
		public Attribute? attribute { get; set; }
	}
}
