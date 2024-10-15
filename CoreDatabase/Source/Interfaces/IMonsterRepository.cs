
using CoreDatabase.Source.Model.Tibia;
using CoreRest.Source.RequestModel.In.Tibia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreDatabase.Source.Interfaces
{
	public interface IMonsterRepository
	{
		IEnumerable<Monster> searchMonster(MonsterRest request);
	}
}
