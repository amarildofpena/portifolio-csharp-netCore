using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreRest.Source.Model.Generic
{
	public class ResponsePaginated
	{
		public ResponsePaginated(List<object>? objetosRetorno, int? perPage, int? currentPage)
		{
			if (objetosRetorno == null)
			{
				throw new ArgumentNullException();
			}
			this.Page = currentPage;
			this.PerPage = perPage;
			this.Total = objetosRetorno.Count;
			this.LastPage = Total % PerPage;
		}
		public List<object>? Data { get; set; }
		public int? Page { get; set; }
		public int? PerPage { get; set; }
		public int? LastPage { get; set; }
		public int? Total { get; set; }

	}
}
