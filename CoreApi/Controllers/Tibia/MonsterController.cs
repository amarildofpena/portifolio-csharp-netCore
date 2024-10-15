using CoreBusiness.Source.Interface;
using CoreRest.Source.Model.Tibia;
using CoreRest.Source.RequestModel.In.Tibia;
using Microsoft.AspNetCore.Mvc;

namespace CoreApi.Controllers.Tibia
{
	[ApiController]
	[Route("[controller]")]
	public class MonsterController : ControllerBase
	{

		private readonly ILogger<MonsterController> _logger;
		private readonly IMonsterService _monsterService;

		public MonsterController(ILogger<MonsterController> logger, IMonsterService monsterService)
		{
			_logger = logger;
			_monsterService = monsterService;
		}

		[HttpGet(Name = "Monsters")]
		public ActionResult<IEnumerable<Monster>> Get([FromQuery] MonsterRest inputs)
		{
			try
			{
				return Ok(_monsterService.getMonsters(inputs));
			}
			catch (Exception e)
			{
				return StatusCode(400, $"Falha ao consultar monstros {e.Message}");
			}
		}
	}
}
