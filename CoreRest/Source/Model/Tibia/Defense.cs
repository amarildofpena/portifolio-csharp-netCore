using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreRest.Source.Model.Tibia
{
	public class Defense
	{
		public int? armor { get; set; }
		public int? defense { get; set; }
		public List<DefenseDetail>? defenses { get; set; }
	}
}
