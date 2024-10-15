using CoreDatabase.Source.Configuration;
using CoreDatabase.Source.Interfaces;
using CoreDatabase.Source.Model.Tibia;
using CoreRest.Source.Model.Tibia;
using CoreRest.Source.RequestModel.In.Tibia;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreDatabase.Source.Repository.Tibia
{
	public class MonsterRepository : IMonsterRepository
	{
		private readonly DbContexto _dbContext;

		public MonsterRepository(DbContexto dbContext)
		{
			_dbContext = dbContext;
		}

		public IEnumerable<Model.Tibia.Monster> searchMonster(MonsterRest request)
		{
			throw new NotImplementedException();
		}
	}
}
