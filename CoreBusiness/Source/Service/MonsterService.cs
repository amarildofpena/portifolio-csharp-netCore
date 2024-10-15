using CoreBusiness.Source.Interface;
using CoreRest.Source.Model.Tibia;
using CoreRest.Source.RequestModel.In.Tibia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreBusiness.Source.Service
{
	public class MonsterService : IMonsterService
	{
		public IEnumerable<Monster> getMonsters(MonsterRest inputs)
		{
			throw new NotImplementedException();
		}
	}
}
