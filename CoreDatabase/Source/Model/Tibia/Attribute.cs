using System.ComponentModel.DataAnnotations.Schema;

namespace CoreDatabase.Source.Model.Tibia
{
	[Table("attributes")]
	public class Attributes
	{
		[Column("id")]
		public string? id { get; set; } = "";
		[Column("key")]
		public string? key { get; set; } = "";
		[Column("value")]
		public string? value { get; set; }
	}
}
