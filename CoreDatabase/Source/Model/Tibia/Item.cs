using System.ComponentModel.DataAnnotations.Schema;

namespace CoreDatabase.Source.Model.Tibia
{
	[Table("items")]
	public class Item
	{
		[Column("id")]
		public string? id { get; set; }
		[Column("article")]
		public string? article { get; set; }
		[Column("name")]
		public string? name { get; set; }
		[Column("fromid")]
		public string? fromid { get; set; }
		[Column("toid")]
		public string? toid { get; set; }
		[Column("attribute")]
		public List<Attributes>? attribute { get; set; }
	}

}
