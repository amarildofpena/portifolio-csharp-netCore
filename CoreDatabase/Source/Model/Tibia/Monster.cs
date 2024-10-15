using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreDatabase.Source.Model.Tibia
{
	public class Monster
	{
		[Key]
		public int Id { get; set; }

		[Required]
		[MaxLength(100)]
		public string Nome { get; set; }

		[Required]
		[MaxLength(50)]
		public string Tipo { get; set; }

		[Required]
		public int HP { get; set; }

		[Required]
		public int Ataque { get; set; }

		[Required]
		public int Defesa { get; set; }
	}
}
