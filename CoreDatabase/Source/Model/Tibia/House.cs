using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreDatabase.Source.Model.Tibia
{
	[Table("houses")]
	public class House
	{
		[Column("id")]
		public int? id { get; set; }
		[Column("owner")]
		public int? owner { get; set; }
		[Column("paid")]
		public int? paid { get; set; }
		[Column("warnings")]
		public int? warnings { get; set; }
		[Column("name")]
		public string? name { get; set; }
		[Column("rent")]
		public int? rent { get; set; }
		[Column("town_id")]
		public int? town_id { get; set; }
		[Column("bid")]
		public int? bid { get; set; }
		[Column("bid_end")]
		public int? bid_end { get; set; }
		[Column("last_bid")]
		public int? last_bid { get; set; }
		[Column("highest_bidder")]
		public int? highest_bidder { get; set; }
		[Column("size")]
		public int? size { get; set; }
		[Column("beds")]
		public int? beds { get; set; }

	}
}
